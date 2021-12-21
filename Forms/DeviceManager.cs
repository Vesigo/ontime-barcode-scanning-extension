using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BarcodeScanningExtension
{
    public partial class DeviceManager : Form
    {
        public DeviceManager()
        {
            InitializeComponent();
            Font = BarcodeScanningExtension.AppFont;
        }

        private void ListDevices()
        {
            if (Owner is MainDashboard)
            {
                DevicesList.Clear();
                DevicesList.Groups.Clear();

                if (MainDashboard.ScannerXML != null)
                {
                    var scanners = new List<string>();
                    foreach (var scanner in MainDashboard.ScannerXML.Root.Elements("scanner"))
                    {
                        var modelNumber = scanner.Element("modelnumber")?.Value?.Trim();
                        var serialNumber = scanner.Element("serialnumber")?.Value?.Trim();
                        var text = String.Format("Model {0} (S/N: {1})", modelNumber, serialNumber);
                        scanners.Add(text);
                    }

                    if (scanners.Count > 0)
                    {
                        DevicesList.Groups.Add(new ListViewGroup("Connected Devices"));
                        DevicesList.Items.Add(new ListViewItem(scanners.ToArray(), DevicesList.Groups[0]));
                    }
                    else
                    {
                        DevicesList.Items.Add(new ListViewItem("No devices found"));
                    }
                }
                else
                {
                    if (!MainDashboard.CoreScannerDriversAvailable)
                    {
                        DevicesList.Items.Add(new ListViewItem("Zebra CoreScanner drivers not installed"));
                    }
                    else
                    {
                        DevicesList.Items.Add(new ListViewItem("No devices found"));
                    }
                }
            }
        }

        private void RefreshList()
        {
            try
            {
                RefreshButton.Enabled = false;
                if (Owner is MainDashboard dashboard)
                {
                    dashboard.DetectCoreScannerDevices();
                    ListDevices();
                }
            }
            finally
            {
                RefreshButton.Enabled = true;
            }
        }

        private void OnRefreshButtonClick(object sender, EventArgs e) => RefreshList();

        private void OnButtonCloseClick(object sender, EventArgs e) => Close();

        private void OnDeviceManagerShown(object sender, EventArgs e) => RefreshList();

        private void OnDownloadLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                System.Diagnostics.Process.Start("https://www.vesigo.com/link.aspx?l=1002");
            }
            else
            {
                System.Diagnostics.Process.Start("https://www.vesigo.com/link.aspx?l=1003");
            }
        }
    }
}
