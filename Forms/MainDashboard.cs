using CoreScanner;
using OnTime.Extensions.SDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static OnTime.Extensions.SDK.Schema;
using static OnTime.Extensions.SDK.StatusBase;

namespace BarcodeScanningExtension
{
    public partial class MainDashboard : Form
    {
        // Constants
        internal const int INTERVAL_BLINK_ERROR_MS = 250;
        internal const int INTERVAL_FOCUS_CHECK_MS = 500;
        internal const int ITERATIONS_BLINK_ERROR = 6;
        internal const int THRESHOLD_INPUT_CLEAR_MS = 200;

        // CoreScanner Data
        internal static bool CoreScannerDriversAvailable;
        internal static int[] ConnectedScannerIDs;
        internal static XDocument LastScanXML;
        internal static XDocument ScannerXML;
        internal static CCoreScanner CoreScanner;

        private int LastScannerID
        {
            get
            {
                try
                {
                    if (LastScanXML != null)
                    {
                        return Int32.Parse(LastScanXML.Element("outArgs").Element("scannerID").Value);
                    }
                }
                catch
                {
                    return -2;
                }

                return -1;
            }
        }

        private string LastScanResult
        {
            get
            {
                if (LastScanXML != null)
                {
                    try
                    {
                        return ScannerExtensions.ParseHexToString(LastScanXML.Element("outArgs").Element("arg-xml").Element("scandata").Element("datalabel").Value);
                    }
                    catch
                    {
                        return string.Empty;
                    }
                }

                return String.Empty;
            }
        }

        // Keyboard Emulation Data
        private readonly List<char> RecentInput = new List<char>();

        // General Data
        private bool PerformTransfer;
        private bool ProcessingScan;
        private readonly bool Initializing;

        private Order CurrentOrder;
        private User UpdateToUser;
        private OrderColumn RecentMatchingField;
        private OrderStatusBase UpdateToStatus;
        private readonly DataAccess Data;

        // Control Flash Tasks
        private Task FlashTask;
        private CancellationToken FlashToken = new CancellationToken();
        private readonly CancellationTokenSource FlashTokenSource = new CancellationTokenSource();

        // Timers
        private readonly System.Windows.Forms.Timer KeyboardEmulationInputTimer = new System.Windows.Forms.Timer() { Interval = THRESHOLD_INPUT_CLEAR_MS };
        private readonly System.Windows.Forms.Timer UpdateFocusStatusTimer = new System.Windows.Forms.Timer() { Interval = INTERVAL_FOCUS_CHECK_MS };

        // Colors
        private readonly Color ErrorScanColor = Color.FromArgb(255, 220, 220);
        private readonly Color ValidScanColor = Color.FromArgb(225, 255, 225);

        public MainDashboard(DataAccess data)
        {
            try
            {
                Initializing = true;
                InitializeComponent();

                // Data
                RecentMatchingField = OrderColumn.TrackingNumber;

                BarcodeScanningExtension.Settings.Load();
                Data = data;
                FlashToken = FlashTokenSource.Token;
                ConnectedScannerIDs = new int[255];
                LoadResolution();
                LoadFilters();

                // CoreScanner init
                try
                {
                    CoreScanner = new CCoreScanner();
                    CoreScanner.Open(0, new short[1] { 1 }, 1, out int openStatus);
                    CoreScannerDriversAvailable = true;
                }
                catch (COMException)
                {
                    // CoreScanner drivers unavailable, disable functionality
                    CoreScannerDriversAvailable = false;
                }

                // UI
                Text = BarcodeScanningExtension.APP_NAME;
                Font = BarcodeScanningExtension.AppFont;

                ResultsLabel.Text = string.Empty;
                ActionLabel.Text = string.Empty;
                DashboardToolStripStatusLabel.Text = string.Empty;

                StatusComboBox.Items.Clear();
                StatusComboBox.Items.Add(GetStatusText(OrderStatusBase.Dispatched));
                StatusComboBox.Items.Add(GetStatusText(OrderStatusBase.AssignedInRoute));
                StatusComboBox.Items.Add(GetStatusText(OrderStatusBase.Delivered));
                StatusComboBox.Items.Add(GetStatusText(OrderStatusBase.Cancelled));
                StatusComboBox.Items.Add(GetStatusText(OrderStatusBase.CancelledBillable));

                if (StatusComboBox.Items.Count > 0)
                {
                    StatusComboBox.SelectedIndex = BarcodeScanningExtension.Settings.LastStatusUsedIndex;
                }

                if (StatusComboBox.SelectedItem != null)
                {
                    UpdateToStatus = GetStatusBase(StatusComboBox.SelectedItem.ToString());
                }

                LoadDescription(UpdateToStatus);
                TransferComboBox.Items.Clear();

                foreach (var user in Data.GetUserList.All(UserColumn.FirstName))
                {
                    var name = $"{user.FirstName} {user.LastName}".Trim();
                    var item = new UserComboBoxItem(user, name);
                    TransferComboBox.Items.Add(item);
                }

                if (TransferComboBox.Items.Count > 0)
                {
                    TransferComboBox.SelectedIndex = 0;
                    if (TransferComboBox.Items[0] is UserComboBoxItem @item)
                    {
                        UpdateToUser = item.User;
                    }
                    else
                    {
                        UpdateToUser = null;
                    }
                }
                else
                {
                    UpdateToUser = null;
                }

                // Control Events
                Click += GetScannerFocus;
                ActionPanel.Click += GetScannerFocus;
                DetailsPanel.Click += GetScannerFocus;
                StatusDescriptionLabel.Click += GetScannerFocus;
                ResultsLabel.Click += GetScannerFocus;
                BarcodeScanResultLabel.Click += GetScannerFocus;
                UpdateStatusToLabel.Click += GetScannerFocus;
                ActionLabel.Click += GetScannerFocus;
                DashboardStatusStrip.Click += GetScannerFocus;

                // Form Events
                Shown += OnMainDashboardShown;
                FormClosing += OnMainDashboardClosing;
                KeyPress += OnMainDashboardKeyPress;

                // Timer Events
                KeyboardEmulationInputTimer.Tick += OnKeyboardEmulationInputTimerTick;
                UpdateFocusStatusTimer.Tick += OnUpdateFocusStatusTimerTick;

                // CoreScanner setup
                if (CoreScannerDriversAvailable)
                {
                    CoreScanner.BarcodeEvent += new _ICoreScannerEvents_BarcodeEventEventHandler(OnCoreScannerBarcodeEvent);
                    CoreScanner.PNPEvent += new _ICoreScannerEvents_PNPEventEventHandler(OnCoreScannerPNPEvent);
                    CoreScanner.RegisterEvents(true);
                    DetectCoreScannerDevices();
                }
            }
            finally
            {
                Initializing = false;
            }
        }

        public void DetectCoreScannerDevices()
        {
            ScannerXML = null;

            if (!CoreScannerDriversAvailable && CoreScanner == null)
            {
                try
                {
                    CoreScanner = new CCoreScanner();
                    CoreScanner.Open(0, new short[1] { 1 }, 1, out _);
                    CoreScanner.BarcodeEvent += new _ICoreScannerEvents_BarcodeEventEventHandler(OnCoreScannerBarcodeEvent);
                    CoreScanner.PNPEvent += new _ICoreScannerEvents_PNPEventEventHandler(OnCoreScannerPNPEvent);
                    CoreScanner.RegisterEvents(true);
                }
                catch (COMException)
                {
                    // CoreScanner drivers unavailable, disable functionality
                    CoreScannerDriversAvailable = false;
                }
            }

            if (CoreScanner != null)
            {
                try
                {
                    CoreScanner.GetScanners(out _, ConnectedScannerIDs, out string xml, out int status);

                    if (status == 0)
                    {
                        try
                        {
                            ScannerXML = XDocument.Parse(xml);
                            CoreScannerDriversAvailable = true;
                        }
                        catch
                        {
                            // Failed to parse scanner XML
                        }
                    }
                    else
                    {
                        // CoreScanner failed to get connected scanners
                    }
                }
                catch (COMException)
                {
                    // CoreScanner drivers unavailable, disable functionality
                    CoreScannerDriversAvailable = false;
                }
            }
        }

        private Order GetOrder(string query)
        {
            Order result = null;
            try
            {
                var filters = new List<Filter>() { new Filter.Exact(OrderColumn.TrackingNumber, query) };

                if (FilterCheckBox.Checked)
                {
                    if (ReferenceNumberCheckBox.Checked) { filters.Add(new Filter.Exact(OrderColumn.ReferenceNumber, query)); }
                    if (PurchaseOrderNumberCheckBox.Checked) { filters.Add(new Filter.Exact(OrderColumn.PurchaseOrderNumber, query)); }
                    if (IncomingTrackingNumberCheckBox.Checked) { filters.Add(new Filter.Exact(OrderColumn.IncomingTrackingNumber, query)); }
                    if (OutgoingTrackingNumberCheckBox.Checked) { filters.Add(new Filter.Exact(OrderColumn.OutgoingTrackingNumber, query)); }
                }

                foreach (var filter in filters)
                {
                    result = Data.GetOrderList.Where(filter).FirstOrDefault();
                    if (result != null)
                    {
                        RecentMatchingField = (OrderColumn)filter.Column;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        private OrderStatusBase GetStatusBase(string status)
        {
            switch (status)
            {
                case "Entered":
                    return OrderStatusBase.Assigned;

                case "In Transit":
                    return OrderStatusBase.AssignedInRoute;

                case "Canceled":
                    return OrderStatusBase.Cancelled;

                case "Canceled Billable":
                    return OrderStatusBase.CancelledBillable;

                case "Completed":
                    return OrderStatusBase.Delivered;

                case "Submitted":
                    return OrderStatusBase.Dispatched;

                case "Quoted":
                    return OrderStatusBase.Quoted;

                case "Stored":
                    return OrderStatusBase.Stored;

                case "Stored (Unassigned)":
                    return OrderStatusBase.UnassignedStored;

                default:
                    return OrderStatusBase.None; ;
            }
        }

        private string GetStatusText(OrderStatusBase status)
        {
            switch (status)
            {
                case OrderStatusBase.Assigned:
                    return "Entered";

                case OrderStatusBase.AssignedInRoute:
                    return "In Transit";

                case OrderStatusBase.Cancelled:
                    return "Canceled";

                case OrderStatusBase.CancelledBillable:
                    return "Canceled Billable";

                case OrderStatusBase.Delivered:
                    return "Completed";

                case OrderStatusBase.Dispatched:
                    return "Submitted";

                case OrderStatusBase.None:
                    return "Unavailable";

                case OrderStatusBase.Quoted:
                    return "Quoted";

                case OrderStatusBase.Stored:
                    return "Stored";

                case OrderStatusBase.UnassignedStored:
                    return "Stored (Unassigned)";

                default:
                    return "Unknown";
            }
        }

        #region UI Control

        private void CreateHistoryRow(string trackingNumber, OrderStatusBase oldStatus, OrderStatusBase newStatus, Customer customer, bool useErrorColor = false)
        {
            var colDate = DateTime.Now.ToLongTimeString();
            var colTrackingNumber = trackingNumber;
            var colStatusOld = GetStatusText(oldStatus);
            var colStatusNew = GetStatusText(newStatus);
            var colCustomer = customer?.Name;

            HistoryDataGridView.Rows.Add(new object[] { colDate, colTrackingNumber, colStatusOld, colStatusNew, colCustomer });

            if (useErrorColor)
            {
                var row = HistoryDataGridView.Rows[HistoryDataGridView.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                if (row != null)
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = ErrorScanColor
                    };
                }
            }

            HistoryDataGridView.Sort(HistoryDataGridView.Columns[0], System.ComponentModel.ListSortDirection.Descending);
            HistoryDataGridView.ClearSelection();
        }

        private void FlashControl(Control control, int iterations, int interval)
        {
            try
            {
                if (FlashTask != null && !FlashTask.IsCompleted)
                {
                    FlashTokenSource.Cancel();
                    FlashTask.Wait();
                }

                FlashTask = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        FlashToken.ThrowIfCancellationRequested();

                        for (int i = 0; i < iterations * 2; i++)
                        {
                            if (FlashToken.IsCancellationRequested)
                            {
                                control.ForeColor = Color.FromArgb(255, control.ForeColor);
                                control.BackColor = Color.FromArgb(255, control.BackColor);
                                control.Invalidate();
                                FlashToken.ThrowIfCancellationRequested();
                            }
                            else
                            {
                                control.ForeColor = i % 2 == 0 ? Color.FromArgb(90, control.ForeColor) : Color.FromArgb(255, control.ForeColor);
                                control.BackColor = i % 2 == 0 ? Color.FromArgb(90, control.BackColor) : Color.FromArgb(255, control.BackColor);
                                control.Invalidate();
                            }

                            await Task.Delay(interval);
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return true;
                }, FlashTokenSource.Token);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ClearLabels()
        {
            DetailsTrackingNumberResultLabel.Text = String.Empty;
            DetailsDateSubmittedResultLabel.Text = String.Empty;
            DetailsStatusOldResultLabel.Text = String.Empty;
            DetailsStatusNewResultLabel.Text = String.Empty;
            DetailsCustomerResultLabel.Text = String.Empty;
        }

        private void UpdateLabels(string tn, DateTime ds, OrderStatusBase s1, OrderStatusBase s2, Customer customer)
        {
            DetailsTrackingNumberResultLabel.Text = tn;
            DetailsDateSubmittedResultLabel.Text = ds.ToLongDateString();
            DetailsStatusOldResultLabel.Text = GetStatusText(s1);
            DetailsStatusNewResultLabel.Text = GetStatusText(s2);
            DetailsCustomerResultLabel.Text = customer?.Name;
        }

        private bool UpdateOrderStatus(string lastScanResult)
        {
            if (CurrentOrder != null)
            {
                switch (RecentMatchingField)
                {
                    case OrderColumn.ReferenceNumber:
                        ActionLabel.Text = $"Found order with reference number: {lastScanResult}";
                        break;
                    case OrderColumn.PurchaseOrderNumber:
                        ActionLabel.Text = $"Found order with purchase order number: {lastScanResult}";
                        break;
                    case OrderColumn.IncomingTrackingNumber:
                        ActionLabel.Text = $"Found order with incoming tracking number: {lastScanResult}";
                        break;
                    case OrderColumn.OutgoingTrackingNumber:
                        ActionLabel.Text = $"Found order with outgoing tracking number: {lastScanResult}";
                        break;
                    default:
                        ActionLabel.Text = $"Found order with tracking number: {lastScanResult}";
                        break;
                }

                try
                {
                    ActionLabel.Text += $"{Environment.NewLine}{Environment.NewLine}";
                    if (CurrentOrder.Status?.Level == UpdateToStatus)
                    {
                        if ((bool)Data.SaveOrderStatusChange(CurrentOrder.ID, StatusDescriptionTextBox.Text, UpdateToStatus, DateTime.Now))
                        {
                            ActionLabel.Text += $"Order status is already '{GetStatusText(UpdateToStatus)}'. Saving status change with new description.'";
                            return true;
                        }
                        else
                        {
                            ActionLabel.Text += $"Order status failed to update";
                        }
                    }
                    else
                    {
                        if ((bool)Data.SaveOrderStatusChange(CurrentOrder.ID, StatusDescriptionTextBox.Text, UpdateToStatus, DateTime.Now))
                        {
                            ActionLabel.Text += $"Order status changed to '{GetStatusText(UpdateToStatus)}'";
                            return true;
                        }
                        else
                        {
                            ActionLabel.Text += $"Order status failed to update";
                        }
                    }
                }
                catch (Exception ex)
                {
                    ActionLabel.Text = $"Order status failed to update.{Environment.NewLine}{Environment.NewLine}Details: {ex.Message}";
                }
            }
            return false;
        }

        private bool UpdateOrder()
        {
            if (!PerformTransfer) return true;

            if (CurrentOrder != null)
            {
                try
                {
                    if (Data.UpdateOrder(CurrentOrder))
                    {
                        string text = $"{Environment.NewLine}{Environment.NewLine}";
                        if (TransferAssignedComboBox.Checked) text += $"Updated currently assigned user. ";
                        if (TransferCollectionCheckBox.Checked && !TransferDeliveryCheckBox.Checked) text += $"User assigned to collection: {((UserComboBoxItem)TransferComboBox.SelectedItem).Text}";
                        if (!TransferCollectionCheckBox.Checked && TransferDeliveryCheckBox.Checked) text += $"User assigned to delivery: {((UserComboBoxItem)TransferComboBox.SelectedItem).Text}";
                        if (TransferCollectionCheckBox.Checked && TransferDeliveryCheckBox.Checked) text += $"User assigned to collection and delivery: {((UserComboBoxItem)TransferComboBox.SelectedItem).Text}";

                        ActionLabel.Text += text;
                        return true;
                    }
                    else
                    {
                        ActionLabel.Text += $"Unable to update assigned user";
                    }
                }
                catch (Exception ex)
                {

                    ActionLabel.Text += $"Unable to update assigned user: {ex.Message}";
                }
            }
            return false;
        }

        private void UpdateStatusBar()
        {
            if (StatusDescriptionTextBox.ContainsFocus)
            {
                DashboardToolStripStatusLabel.Text = "Release status description focus to detect scanner input";
            }
            else
            {
                if (ContainsFocus)
                {
                    DashboardToolStripStatusLabel.Text = "Ready";
                }
                else
                {
                    DashboardToolStripStatusLabel.Text = "Refocus window to detect scanner input";
                }
            }
        }

        private void GetScannerFocus(object sender, EventArgs e)
        {
            // Focus the results label in order to detect keyboard-emulation scanner results
            ActiveControl = ResultsLabel;
        }

        public IEnumerable<Control> GetControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetControls(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        #endregion

        #region Settings

        private void LoadDescription(OrderStatusBase status)
        {
            switch (status)
            {
                case OrderStatusBase.AssignedInRoute:
                    StatusDescriptionTextBox.Text = BarcodeScanningExtension.Settings.AssignedInRouteUserDescription;
                    break;

                case OrderStatusBase.Cancelled:
                    StatusDescriptionTextBox.Text = BarcodeScanningExtension.Settings.CancelledUserDescription;
                    break;

                case OrderStatusBase.CancelledBillable:
                    StatusDescriptionTextBox.Text = BarcodeScanningExtension.Settings.CancelledBillableUserDescription;
                    break;

                case OrderStatusBase.Delivered:
                    StatusDescriptionTextBox.Text = BarcodeScanningExtension.Settings.DeliveredUserDescription;
                    break;

                case OrderStatusBase.Dispatched:
                    StatusDescriptionTextBox.Text = BarcodeScanningExtension.Settings.DispatchedUserDescription;
                    break;
            }
        }

        private void SaveDescription(OrderStatusBase status)
        {
            switch (status)
            {
                case OrderStatusBase.AssignedInRoute:
                    BarcodeScanningExtension.Settings.AssignedInRouteUserDescription = StatusDescriptionTextBox.Text;
                    break;

                case OrderStatusBase.Cancelled:
                    BarcodeScanningExtension.Settings.CancelledUserDescription = StatusDescriptionTextBox.Text;
                    break;

                case OrderStatusBase.CancelledBillable:
                    BarcodeScanningExtension.Settings.CancelledBillableUserDescription = StatusDescriptionTextBox.Text;
                    break;

                case OrderStatusBase.Delivered:
                    BarcodeScanningExtension.Settings.DeliveredUserDescription = StatusDescriptionTextBox.Text;
                    break;

                case OrderStatusBase.Dispatched:
                    BarcodeScanningExtension.Settings.DispatchedUserDescription = StatusDescriptionTextBox.Text;
                    break;
            }
        }

        private void LoadFilters()
        {
            FilterCheckBox.Checked = BarcodeScanningExtension.Settings.AdditionalFilters;
            ReferenceNumberCheckBox.Checked = BarcodeScanningExtension.Settings.FilterReferenceNumber;
            PurchaseOrderNumberCheckBox.Checked = BarcodeScanningExtension.Settings.FilterPurchaseOrderNumber;
            IncomingTrackingNumberCheckBox.Checked = BarcodeScanningExtension.Settings.FilterIncomingTrackingNumber;
            OutgoingTrackingNumberCheckBox.Checked = BarcodeScanningExtension.Settings.FilterOutgoingTrackingNumber;
        }

        private void SaveFilters()
        {
            BarcodeScanningExtension.Settings.AdditionalFilters = FilterCheckBox.Checked;
            BarcodeScanningExtension.Settings.FilterReferenceNumber = ReferenceNumberCheckBox.Checked;
            BarcodeScanningExtension.Settings.FilterPurchaseOrderNumber = PurchaseOrderNumberCheckBox.Checked;
            BarcodeScanningExtension.Settings.FilterIncomingTrackingNumber = IncomingTrackingNumberCheckBox.Checked;
            BarcodeScanningExtension.Settings.FilterOutgoingTrackingNumber = OutgoingTrackingNumberCheckBox.Checked;
        }

        private void LoadResolution()
        {
            Width = BarcodeScanningExtension.Settings.WindowWidth;
            Height = BarcodeScanningExtension.Settings.WindowHeight;
            Refresh();
        }

        private void SaveResolution()
        {
            BarcodeScanningExtension.Settings.WindowWidth = Width;
            BarcodeScanningExtension.Settings.WindowHeight = Height;
        }

        #endregion

        #region Overrides
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Ignore key input for specific control types
            if (GetControls(this, typeof(CheckBox)).Contains(ActiveControl))
            {
                return true;
            }

            if (GetControls(this, typeof(ComboBox)).Contains(ActiveControl))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Event Handlers

        private void OnStatusComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initializing)
            {
                if (StatusComboBox.SelectedItem != null)
                {
                    UpdateToStatus = GetStatusBase(StatusComboBox.SelectedItem.ToString());

                    // Save
                    var desc = StatusComboBox.Items[BarcodeScanningExtension.Settings.LastStatusUsedIndex];
                    SaveDescription(GetStatusBase(desc.ToString()));
                    BarcodeScanningExtension.Settings.LastStatusUsedIndex = StatusComboBox.SelectedIndex;

                    // Load
                    LoadDescription(UpdateToStatus);
                }
            }
        }

        private void OnCoreScannerBarcodeEvent(short eventType, ref string pscanData)
        {
            if (CoreScannerDriversAvailable)
            {
                try
                {
                    ProcessingScan = true;
                    LastScanXML = null;
                    CurrentOrder = null;

                    if (eventType == 1)
                    {
                        Invoke(new Action(() =>
                        {
                            KeyPreview = false;
                            GetScannerFocus(this, null);
                            Cursor = Cursors.WaitCursor;
                            DashboardToolStripStatusLabel.Text = "Processing...";
                            Refresh();
                        }));

                        try
                        {
                            var pscanDataClean = pscanData.Replace("\n", "").Replace("\t", "").Replace("\r", "");
                            LastScanXML = XDocument.Parse(pscanDataClean);
                        }
                        catch
                        {
                            // Failed to parse scan's resulting XML;
                            return;
                        }

                        if (LastScanXML != null)
                        {
                            Invoke(new Action(() =>
                            {
                                ResultsLabel.Text = string.Empty;
                                ActionLabel.Text = "";
                            }));

                            try
                            {
                                CurrentOrder = GetOrder(LastScanResult);
                            }
                            catch
                            {
                                CoreScanner.InvokeBeep(LastScannerID, ScannerExtensions.Beeps.THREE_LOW_SHORT);
                                CoreScanner.InvokeLED(LastScannerID, ScannerExtensions.LEDs.RED_LED_ON);
                                System.Media.SystemSounds.Exclamation.Play();
                                Invoke(new Action(() =>
                                {
                                    ResultsLabel.Text = "ERROR";
                                    ResultsLabel.BackColor = ErrorScanColor;
                                    ResultsLabel.ForeColor = Color.Black;
                                    FlashControl(ResultsLabel, ITERATIONS_BLINK_ERROR, INTERVAL_BLINK_ERROR_MS);
                                    ActionLabel.Text = "An error occurred while parsing the data returned by the scanner.";
                                }));
                                return;
                            }

                            bool success = false;
                            if (CurrentOrder != null)
                            {
                                Invoke(new Action(() =>
                                {
                                    // Update status
                                    OrderStatusBase oldStatus = CurrentOrder.Status == null ? OrderStatusBase.None : CurrentOrder.Status.Level;
                                    success = UpdateOrderStatus(LastScanResult);

                                    if (PerformTransfer)
                                    {
                                        // Get updated order to avoid overwriting with old status
                                        CurrentOrder = GetOrder(CurrentOrder.TrackingNumber);

                                        // Update users
                                        CurrentOrder.DriverCurrentlyAssigned = TransferAssignedComboBox.Checked ? UpdateToUser : CurrentOrder.DriverCurrentlyAssigned;
                                        CurrentOrder.CollectionAssignedDriver = TransferCollectionCheckBox.Checked ? UpdateToUser : CurrentOrder.CollectionAssignedDriver;
                                        CurrentOrder.DeliveryAssignedDriver = TransferDeliveryCheckBox.Checked ? UpdateToUser : CurrentOrder.DeliveryAssignedDriver;
                                        success &= UpdateOrder();
                                    }

                                    UpdateLabels(CurrentOrder.TrackingNumber, CurrentOrder.DateSubmitted, oldStatus, UpdateToStatus, CurrentOrder.Customer);
                                    CreateHistoryRow(CurrentOrder.TrackingNumber, oldStatus, UpdateToStatus, CurrentOrder.Customer, !success);
                                }));
                            }
                            else
                            {
                                // No order found
                                Invoke(new Action(() =>
                                {
                                    ActionLabel.Text = "No order found with result: " + LastScanResult;
                                    CreateHistoryRow(LastScanResult, OrderStatusBase.None, OrderStatusBase.None, null, !success);
                                }));
                            }

                            if (success)
                            {
                                // Successful scan
                                Invoke(new Action(() =>
                                {
                                    ResultsLabel.BackColor = ValidScanColor;
                                    ResultsLabel.ForeColor = Color.Black;
                                }));

                                CoreScanner.InvokeLED(LastScannerID, ScannerExtensions.LEDs.GREEN_LED_ON);
                                CoreScanner.InvokeBeep(LastScannerID, ScannerExtensions.Beeps.LOW_HIGH);
                            }
                            else
                            {
                                // Error
                                Invoke(new Action(() =>
                                {
                                    ResultsLabel.BackColor = ErrorScanColor;
                                    ResultsLabel.ForeColor = Color.Black;
                                    FlashControl(ResultsLabel, ITERATIONS_BLINK_ERROR, INTERVAL_BLINK_ERROR_MS);
                                }));

                                System.Media.SystemSounds.Exclamation.Play();
                                CoreScanner.InvokeBeep(LastScannerID, ScannerExtensions.Beeps.FIVE_LOW_SHORT);
                                CoreScanner.InvokeLED(LastScannerID, ScannerExtensions.LEDs.RED_LED_ON);
                            }

                            Invoke(new Action(() => ResultsLabel.Text = LastScanResult));
                        }

                        Invoke(new Action(() =>
                        {
                            KeyPreview = true;
                            Cursor = Cursors.Default;
                            UpdateStatusBar();
                        }));
                    }
                }
                finally
                {
                    ProcessingScan = false;
                }
            }
        }

        private void OnCoreScannerPNPEvent(short eventType, ref string ppnpData)
        {
            if (CoreScannerDriversAvailable)
            {
                DetectCoreScannerDevices();
            }
        }

        private void OnMainDashboardClosing(object sender, FormClosingEventArgs e)
        {
            // Stop timers
            KeyboardEmulationInputTimer.Stop();
            UpdateFocusStatusTimer.Stop();

            // Save settings
            SaveDescription(UpdateToStatus);
            SaveResolution();
            SaveFilters();
            BarcodeScanningExtension.Settings.Save();

            try
            {
                // Dispose of tokens and close CoreScanner instance
                if (FlashTokenSource != null)
                {
                    FlashTokenSource.Dispose();
                }

                if (CoreScannerDriversAvailable)
                {
                    CoreScanner.Close(0, out _);
                }
            }
            catch
            {
                // Error while closing form
            }
        }

        private void OnMainDashboardKeyPress(object sender, KeyPressEventArgs e)
        {
            if (StatusDescriptionTextBox.ContainsFocus || ProcessingScan || e.KeyChar == (char)Keys.ShiftKey) return;

            if (RecentInput.Count == 0)
                KeyboardEmulationInputTimer.Start();

            if (e.KeyChar == (char)Keys.Enter)
            {
                ProcessingScan = true;

                Cursor = Cursors.WaitCursor;
                DashboardToolStripStatusLabel.Text = "Processing...";
                KeyboardEmulationInputTimer.Stop();
                Refresh();

                LastScanXML = null;
                CurrentOrder = null;

                if (RecentInput.Count > 0)
                {
                    string scanResult = string.Join("", RecentInput.ToArray());
                    ResultsLabel.Text = string.Empty;
                    ActionLabel.Text = "";

                    CurrentOrder = GetOrder(scanResult);

                    bool success = false;
                    if (CurrentOrder != null)
                    {
                        // Update status
                        OrderStatusBase initStatus = CurrentOrder.Status == null ? OrderStatusBase.None : CurrentOrder.Status.Level;
                        success = UpdateOrderStatus(scanResult);

                        if (PerformTransfer)
                        {
                            // Get updated order to avoid overwriting with old status
                            CurrentOrder = GetOrder(CurrentOrder.TrackingNumber);

                            // Update users
                            CurrentOrder.DriverCurrentlyAssigned = TransferAssignedComboBox.Checked ? UpdateToUser : CurrentOrder.DriverCurrentlyAssigned;
                            CurrentOrder.CollectionAssignedDriver = TransferCollectionCheckBox.Checked ? UpdateToUser : CurrentOrder.CollectionAssignedDriver;
                            CurrentOrder.DeliveryAssignedDriver = TransferDeliveryCheckBox.Checked ? UpdateToUser : CurrentOrder.DeliveryAssignedDriver;
                            success &= UpdateOrder();
                        }

                        UpdateLabels(CurrentOrder.TrackingNumber, CurrentOrder.DateSubmitted, initStatus, UpdateToStatus, CurrentOrder.Customer);
                        CreateHistoryRow(CurrentOrder.TrackingNumber, initStatus, UpdateToStatus, CurrentOrder.Customer, !success);
                    }
                    else
                    {
                        ActionLabel.Text = "No order found with result: " + scanResult;
                        CreateHistoryRow(scanResult, OrderStatusBase.None, OrderStatusBase.None, null, !success);
                    }

                    if (success)
                    {
                        ResultsLabel.BackColor = ValidScanColor;
                        ResultsLabel.ForeColor = Color.Black;
                    }
                    else
                    {
                        ResultsLabel.BackColor = ErrorScanColor;
                        ResultsLabel.ForeColor = Color.Black;
                        FlashControl(ResultsLabel, ITERATIONS_BLINK_ERROR, INTERVAL_BLINK_ERROR_MS);
                        System.Media.SystemSounds.Exclamation.Play();
                    }

                    ResultsLabel.Text = scanResult;
                }

                RecentInput.Clear();
                KeyboardEmulationInputTimer.Start();
                UpdateStatusBar();
                Cursor = Cursors.Default;

                ProcessingScan = false;
            }
            else
            {
                RecentInput.Add(e.KeyChar);
            }
        }

        private void OnMainDashboardShown(object sender, EventArgs e)
        {
            KeyboardEmulationInputTimer.Start();
            UpdateFocusStatusTimer.Start();
            ClearLabels();
            ActionLabel.Text = "Scan any barcode to submit a status update";
        }

        private void OnKeyboardEmulationInputTimerTick(object sender, EventArgs e)
        {
            RecentInput.Clear();
            KeyboardEmulationInputTimer.Stop();
        }

        private void OnUpdateFocusStatusTimerTick(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void OnDevicesToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (var frm = new DeviceManager())
            {
                frm.ShowDialog(this);
            }
        }

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e) => Close();

        private void OnTransferCheckBoxCheckChanged(object sender, EventArgs e)
        {
            PerformTransfer = TransferAssignedComboBox.Checked;
            TransferLabel.Enabled = PerformTransfer;
            TransferComboBox.Enabled = PerformTransfer;
            TransferCollectionCheckBox.Enabled = PerformTransfer;
            TransferDeliveryCheckBox.Enabled = PerformTransfer;

            if (PerformTransfer == false)
            {
                TransferCollectionCheckBox.Checked = false;
                TransferDeliveryCheckBox.Checked = false;
            }
        }

        private void OnTransferComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (TransferComboBox.SelectedItem is UserComboBoxItem @item)
            {
                UpdateToUser = item.User;
            }
        }

        private void OnGettingStartedToolStripMenuItemClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.vesigo.com/link.aspx?l=1001");
        }

        private void OnFilterCheckBoxCheckChanged(object sender, EventArgs e)
        {
            SettingsPanel.SuspendLayout();
            AdditionalFiltersPanel.Enabled = FilterCheckBox.Checked;
            SettingsPanel.ResumeLayout();
        }

        #endregion

        #region Subclasses

        private class UserComboBoxItem
        {
            public string Text { get; private set; }
            public User User { get; private set; }

            public UserComboBoxItem(User user, string text)
            {
                this.Text = text;
                this.User = user;
            }

            public override string ToString() => Text;
        }
        #endregion
    }
}