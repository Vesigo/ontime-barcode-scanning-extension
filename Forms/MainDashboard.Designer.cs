namespace BarcodeScanningExtension
{
	partial class MainDashboard
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RootPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DashboardMenuStrip = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DevicesToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GettingStartedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.RightInnerPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DetailsPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DetailsTrackingNumberLabel = new System.Windows.Forms.Label();
			this.DetailsDateSubmittedLabel = new System.Windows.Forms.Label();
			this.DetailsStatusOldLabel = new System.Windows.Forms.Label();
			this.DetailsCustomerLabel = new System.Windows.Forms.Label();
			this.DetailsTrackingNumberResultLabel = new System.Windows.Forms.Label();
			this.DetailsDateSubmittedResultLabel = new System.Windows.Forms.Label();
			this.DetailsStatusOldResultLabel = new System.Windows.Forms.Label();
			this.DetailsCustomerResultLabel = new System.Windows.Forms.Label();
			this.DetailsStatusNewLabel = new System.Windows.Forms.Label();
			this.DetailsStatusNewResultLabel = new System.Windows.Forms.Label();
			this.ActionPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ActionLabel = new System.Windows.Forms.Label();
			this.LeftInnerPanel = new System.Windows.Forms.TableLayoutPanel();
			this.BarcodeScanResultLabel = new System.Windows.Forms.Label();
			this.ResultsLabel = new System.Windows.Forms.Label();
			this.SettingsPanel = new System.Windows.Forms.TableLayoutPanel();
			this.FilterPanel = new System.Windows.Forms.TableLayoutPanel();
			this.FilterCheckBox = new System.Windows.Forms.CheckBox();
			this.AdditionalFiltersPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ReferenceNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.OutgoingTrackingNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.IncomingTrackingNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.PurchaseOrderNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.StatusPanel = new System.Windows.Forms.TableLayoutPanel();
			this.UpdateStatusPanel = new System.Windows.Forms.TableLayoutPanel();
			this.StatusComboBox = new System.Windows.Forms.ComboBox();
			this.UpdateStatusToLabel = new System.Windows.Forms.Label();
			this.StatusDescriptionLabel = new System.Windows.Forms.Label();
			this.StatusDescriptionTextBox = new System.Windows.Forms.TextBox();
			this.TransferPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TransferLabel = new System.Windows.Forms.Label();
			this.TransferComboBox = new System.Windows.Forms.ComboBox();
			this.TransferAssignedComboBox = new System.Windows.Forms.CheckBox();
			this.TransferCollectionCheckBox = new System.Windows.Forms.CheckBox();
			this.TransferDeliveryCheckBox = new System.Windows.Forms.CheckBox();
			this.BottomInnerPanel = new System.Windows.Forms.TableLayoutPanel();
			this.HistoryDataGridView = new System.Windows.Forms.DataGridView();
			this.DateTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrackingNumberTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusInitialTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusNewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CustomerTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DashboardToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.DashboardStatusStrip = new System.Windows.Forms.StatusStrip();
			this.RootPanel.SuspendLayout();
			this.DashboardMenuStrip.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.RightInnerPanel.SuspendLayout();
			this.DetailsPanel.SuspendLayout();
			this.ActionPanel.SuspendLayout();
			this.LeftInnerPanel.SuspendLayout();
			this.SettingsPanel.SuspendLayout();
			this.FilterPanel.SuspendLayout();
			this.AdditionalFiltersPanel.SuspendLayout();
			this.StatusPanel.SuspendLayout();
			this.UpdateStatusPanel.SuspendLayout();
			this.TransferPanel.SuspendLayout();
			this.BottomInnerPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.HistoryDataGridView)).BeginInit();
			this.DashboardStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// RootPanel
			// 
			this.RootPanel.AutoSize = true;
			this.RootPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.RootPanel.ColumnCount = 1;
			this.RootPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.RootPanel.Controls.Add(this.DashboardMenuStrip, 0, 0);
			this.RootPanel.Controls.Add(this.MainPanel, 0, 1);
			this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RootPanel.Location = new System.Drawing.Point(0, 0);
			this.RootPanel.Name = "RootPanel";
			this.RootPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 23);
			this.RootPanel.RowCount = 3;
			this.RootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.RootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.RootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.RootPanel.Size = new System.Drawing.Size(834, 611);
			this.RootPanel.TabIndex = 0;
			// 
			// DashboardMenuStrip
			// 
			this.RootPanel.SetColumnSpan(this.DashboardMenuStrip, 2);
			this.DashboardMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.DashboardMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.DashboardMenuStrip.Name = "DashboardMenuStrip";
			this.DashboardMenuStrip.Padding = new System.Windows.Forms.Padding(0);
			this.DashboardMenuStrip.Size = new System.Drawing.Size(834, 24);
			this.DashboardMenuStrip.TabIndex = 2;
			this.DashboardMenuStrip.Text = "menuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DevicesToolStripMenuItem,
            this.DevicesToolStripSeparator,
            this.ExitToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
			this.FileToolStripMenuItem.Text = "&File";
			// 
			// DevicesToolStripMenuItem
			// 
			this.DevicesToolStripMenuItem.Name = "DevicesToolStripMenuItem";
			this.DevicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.DevicesToolStripMenuItem.Text = "&Devices...";
			this.DevicesToolStripMenuItem.Click += new System.EventHandler(this.OnDevicesToolStripMenuItemClick);
			// 
			// DevicesToolStripSeparator
			// 
			this.DevicesToolStripSeparator.Name = "DevicesToolStripSeparator";
			this.DevicesToolStripSeparator.Size = new System.Drawing.Size(177, 6);
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.ExitToolStripMenuItem.Text = "&Exit";
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GettingStartedToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.HelpToolStripMenuItem.Text = "&Help";
			// 
			// GettingStartedToolStripMenuItem
			// 
			this.GettingStartedToolStripMenuItem.Name = "GettingStartedToolStripMenuItem";
			this.GettingStartedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.GettingStartedToolStripMenuItem.Text = "Getting Started...";
			this.GettingStartedToolStripMenuItem.Click += new System.EventHandler(this.OnGettingStartedToolStripMenuItemClick);
			// 
			// MainPanel
			// 
			this.MainPanel.AutoSize = true;
			this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.MainPanel.ColumnCount = 2;
			this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.MainPanel.Controls.Add(this.RightInnerPanel, 1, 0);
			this.MainPanel.Controls.Add(this.LeftInnerPanel, 0, 0);
			this.MainPanel.Controls.Add(this.BottomInnerPanel, 0, 1);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(3, 27);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Padding = new System.Windows.Forms.Padding(8);
			this.MainPanel.RowCount = 2;
			this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.MainPanel.Size = new System.Drawing.Size(828, 538);
			this.MainPanel.TabIndex = 2;
			// 
			// RightInnerPanel
			// 
			this.RightInnerPanel.AutoSize = true;
			this.RightInnerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.RightInnerPanel.ColumnCount = 1;
			this.RightInnerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.RightInnerPanel.Controls.Add(this.DetailsPanel, 0, 0);
			this.RightInnerPanel.Controls.Add(this.ActionPanel, 0, 1);
			this.RightInnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightInnerPanel.Location = new System.Drawing.Point(495, 8);
			this.RightInnerPanel.Margin = new System.Windows.Forms.Padding(0);
			this.RightInnerPanel.Name = "RightInnerPanel";
			this.RightInnerPanel.RowCount = 2;
			this.RightInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.RightInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.RightInnerPanel.Size = new System.Drawing.Size(325, 358);
			this.RightInnerPanel.TabIndex = 0;
			// 
			// DetailsPanel
			// 
			this.DetailsPanel.AutoSize = true;
			this.DetailsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.DetailsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.DetailsPanel.ColumnCount = 2;
			this.DetailsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.DetailsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.DetailsPanel.Controls.Add(this.DetailsTrackingNumberLabel, 0, 0);
			this.DetailsPanel.Controls.Add(this.DetailsDateSubmittedLabel, 0, 1);
			this.DetailsPanel.Controls.Add(this.DetailsStatusOldLabel, 0, 2);
			this.DetailsPanel.Controls.Add(this.DetailsStatusNewLabel, 0, 3);
			this.DetailsPanel.Controls.Add(this.DetailsCustomerLabel, 0, 4);
			this.DetailsPanel.Controls.Add(this.DetailsTrackingNumberResultLabel, 1, 0);
			this.DetailsPanel.Controls.Add(this.DetailsDateSubmittedResultLabel, 1, 1);
			this.DetailsPanel.Controls.Add(this.DetailsStatusOldResultLabel, 1, 2);
			this.DetailsPanel.Controls.Add(this.DetailsStatusNewResultLabel, 1, 3);
			this.DetailsPanel.Controls.Add(this.DetailsCustomerResultLabel, 1, 4);
			this.DetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsPanel.Location = new System.Drawing.Point(3, 3);
			this.DetailsPanel.Name = "DetailsPanel";
			this.DetailsPanel.RowCount = 5;
			this.DetailsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DetailsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DetailsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DetailsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DetailsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.DetailsPanel.Size = new System.Drawing.Size(319, 101);
			this.DetailsPanel.TabIndex = 0;
			// 
			// DetailsTrackingNumberLabel
			// 
			this.DetailsTrackingNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsTrackingNumberLabel.AutoSize = true;
			this.DetailsTrackingNumberLabel.Location = new System.Drawing.Point(4, 4);
			this.DetailsTrackingNumberLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsTrackingNumberLabel.Name = "DetailsTrackingNumberLabel";
			this.DetailsTrackingNumberLabel.Size = new System.Drawing.Size(87, 13);
			this.DetailsTrackingNumberLabel.TabIndex = 0;
			this.DetailsTrackingNumberLabel.Text = "Tracking number";
			// 
			// DetailsDateSubmittedLabel
			// 
			this.DetailsDateSubmittedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsDateSubmittedLabel.AutoSize = true;
			this.DetailsDateSubmittedLabel.Location = new System.Drawing.Point(4, 24);
			this.DetailsDateSubmittedLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsDateSubmittedLabel.Name = "DetailsDateSubmittedLabel";
			this.DetailsDateSubmittedLabel.Size = new System.Drawing.Size(87, 13);
			this.DetailsDateSubmittedLabel.TabIndex = 1;
			this.DetailsDateSubmittedLabel.Text = "Date submitted";
			// 
			// DetailsStatusOldLabel
			// 
			this.DetailsStatusOldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsStatusOldLabel.AutoSize = true;
			this.DetailsStatusOldLabel.Location = new System.Drawing.Point(4, 44);
			this.DetailsStatusOldLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsStatusOldLabel.Name = "DetailsStatusOldLabel";
			this.DetailsStatusOldLabel.Size = new System.Drawing.Size(87, 13);
			this.DetailsStatusOldLabel.TabIndex = 2;
			this.DetailsStatusOldLabel.Text = "Status (Old)";
			// 
			// DetailsCustomerLabel
			// 
			this.DetailsCustomerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsCustomerLabel.AutoSize = true;
			this.DetailsCustomerLabel.Location = new System.Drawing.Point(4, 84);
			this.DetailsCustomerLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsCustomerLabel.Name = "DetailsCustomerLabel";
			this.DetailsCustomerLabel.Size = new System.Drawing.Size(87, 13);
			this.DetailsCustomerLabel.TabIndex = 3;
			this.DetailsCustomerLabel.Text = "Customer";
			// 
			// DetailsTrackingNumberResultLabel
			// 
			this.DetailsTrackingNumberResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsTrackingNumberResultLabel.AutoSize = true;
			this.DetailsTrackingNumberResultLabel.Location = new System.Drawing.Point(98, 4);
			this.DetailsTrackingNumberResultLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsTrackingNumberResultLabel.Name = "DetailsTrackingNumberResultLabel";
			this.DetailsTrackingNumberResultLabel.Size = new System.Drawing.Size(217, 13);
			this.DetailsTrackingNumberResultLabel.TabIndex = 4;
			this.DetailsTrackingNumberResultLabel.Text = "0";
			// 
			// DetailsDateSubmittedResultLabel
			// 
			this.DetailsDateSubmittedResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsDateSubmittedResultLabel.AutoSize = true;
			this.DetailsDateSubmittedResultLabel.Location = new System.Drawing.Point(98, 24);
			this.DetailsDateSubmittedResultLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsDateSubmittedResultLabel.Name = "DetailsDateSubmittedResultLabel";
			this.DetailsDateSubmittedResultLabel.Size = new System.Drawing.Size(217, 13);
			this.DetailsDateSubmittedResultLabel.TabIndex = 5;
			this.DetailsDateSubmittedResultLabel.Text = "0";
			// 
			// DetailsStatusOldResultLabel
			// 
			this.DetailsStatusOldResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsStatusOldResultLabel.AutoSize = true;
			this.DetailsStatusOldResultLabel.Location = new System.Drawing.Point(98, 44);
			this.DetailsStatusOldResultLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsStatusOldResultLabel.Name = "DetailsStatusOldResultLabel";
			this.DetailsStatusOldResultLabel.Size = new System.Drawing.Size(217, 13);
			this.DetailsStatusOldResultLabel.TabIndex = 6;
			this.DetailsStatusOldResultLabel.Text = "0";
			// 
			// DetailsCustomerResultLabel
			// 
			this.DetailsCustomerResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsCustomerResultLabel.AutoSize = true;
			this.DetailsCustomerResultLabel.Location = new System.Drawing.Point(98, 84);
			this.DetailsCustomerResultLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsCustomerResultLabel.Name = "DetailsCustomerResultLabel";
			this.DetailsCustomerResultLabel.Size = new System.Drawing.Size(217, 13);
			this.DetailsCustomerResultLabel.TabIndex = 7;
			this.DetailsCustomerResultLabel.Text = "0";
			// 
			// DetailsStatusNewLabel
			// 
			this.DetailsStatusNewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsStatusNewLabel.AutoSize = true;
			this.DetailsStatusNewLabel.Location = new System.Drawing.Point(4, 64);
			this.DetailsStatusNewLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsStatusNewLabel.Name = "DetailsStatusNewLabel";
			this.DetailsStatusNewLabel.Size = new System.Drawing.Size(87, 13);
			this.DetailsStatusNewLabel.TabIndex = 8;
			this.DetailsStatusNewLabel.Text = "Status (New)";
			// 
			// DetailsStatusNewResultLabel
			// 
			this.DetailsStatusNewResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsStatusNewResultLabel.AutoSize = true;
			this.DetailsStatusNewResultLabel.Location = new System.Drawing.Point(98, 64);
			this.DetailsStatusNewResultLabel.Margin = new System.Windows.Forms.Padding(3);
			this.DetailsStatusNewResultLabel.Name = "DetailsStatusNewResultLabel";
			this.DetailsStatusNewResultLabel.Size = new System.Drawing.Size(217, 13);
			this.DetailsStatusNewResultLabel.TabIndex = 9;
			this.DetailsStatusNewResultLabel.Text = "0";
			// 
			// ActionPanel
			// 
			this.ActionPanel.AutoSize = true;
			this.ActionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ActionPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.ActionPanel.ColumnCount = 1;
			this.ActionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ActionPanel.Controls.Add(this.ActionLabel, 0, 0);
			this.ActionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ActionPanel.Location = new System.Drawing.Point(3, 110);
			this.ActionPanel.Name = "ActionPanel";
			this.ActionPanel.RowCount = 1;
			this.ActionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ActionPanel.Size = new System.Drawing.Size(319, 245);
			this.ActionPanel.TabIndex = 1;
			// 
			// ActionLabel
			// 
			this.ActionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ActionLabel.AutoSize = true;
			this.ActionLabel.Location = new System.Drawing.Point(4, 116);
			this.ActionLabel.Margin = new System.Windows.Forms.Padding(3);
			this.ActionLabel.Name = "ActionLabel";
			this.ActionLabel.Size = new System.Drawing.Size(311, 13);
			this.ActionLabel.TabIndex = 0;
			this.ActionLabel.Text = "ActionLabel.Text";
			this.ActionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LeftInnerPanel
			// 
			this.LeftInnerPanel.AutoSize = true;
			this.LeftInnerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.LeftInnerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.LeftInnerPanel.ColumnCount = 1;
			this.LeftInnerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.LeftInnerPanel.Controls.Add(this.BarcodeScanResultLabel, 0, 0);
			this.LeftInnerPanel.Controls.Add(this.ResultsLabel, 0, 1);
			this.LeftInnerPanel.Controls.Add(this.SettingsPanel, 0, 2);
			this.LeftInnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftInnerPanel.Location = new System.Drawing.Point(11, 11);
			this.LeftInnerPanel.Name = "LeftInnerPanel";
			this.LeftInnerPanel.RowCount = 3;
			this.LeftInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LeftInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LeftInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LeftInnerPanel.Size = new System.Drawing.Size(481, 352);
			this.LeftInnerPanel.TabIndex = 1;
			// 
			// BarcodeScanResultLabel
			// 
			this.BarcodeScanResultLabel.AutoSize = true;
			this.BarcodeScanResultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BarcodeScanResultLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BarcodeScanResultLabel.Location = new System.Drawing.Point(4, 4);
			this.BarcodeScanResultLabel.Margin = new System.Windows.Forms.Padding(3);
			this.BarcodeScanResultLabel.Name = "BarcodeScanResultLabel";
			this.BarcodeScanResultLabel.Size = new System.Drawing.Size(473, 13);
			this.BarcodeScanResultLabel.TabIndex = 1;
			this.BarcodeScanResultLabel.Text = "Barcode Scan Result";
			this.BarcodeScanResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ResultsLabel
			// 
			this.ResultsLabel.BackColor = System.Drawing.SystemColors.Control;
			this.ResultsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResultsLabel.Location = new System.Drawing.Point(1, 21);
			this.ResultsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ResultsLabel.Name = "ResultsLabel";
			this.ResultsLabel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
			this.ResultsLabel.Size = new System.Drawing.Size(479, 57);
			this.ResultsLabel.TabIndex = 3;
			this.ResultsLabel.Text = "ResultsLabel.Text";
			this.ResultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.AutoSize = true;
			this.SettingsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.SettingsPanel.ColumnCount = 1;
			this.SettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.SettingsPanel.Controls.Add(this.FilterPanel, 0, 2);
			this.SettingsPanel.Controls.Add(this.StatusPanel, 0, 0);
			this.SettingsPanel.Controls.Add(this.TransferPanel, 0, 1);
			this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SettingsPanel.Location = new System.Drawing.Point(1, 79);
			this.SettingsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.RowCount = 3;
			this.SettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.SettingsPanel.Size = new System.Drawing.Size(479, 272);
			this.SettingsPanel.TabIndex = 2;
			// 
			// FilterPanel
			// 
			this.FilterPanel.AutoSize = true;
			this.FilterPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FilterPanel.ColumnCount = 2;
			this.FilterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.FilterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.FilterPanel.Controls.Add(this.FilterCheckBox, 0, 0);
			this.FilterPanel.Controls.Add(this.AdditionalFiltersPanel, 1, 1);
			this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FilterPanel.Location = new System.Drawing.Point(0, 215);
			this.FilterPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.FilterPanel.Name = "FilterPanel";
			this.FilterPanel.RowCount = 2;
			this.FilterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.FilterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.FilterPanel.Size = new System.Drawing.Size(479, 54);
			this.FilterPanel.TabIndex = 3;
			// 
			// FilterCheckBox
			// 
			this.FilterCheckBox.AutoSize = true;
			this.FilterPanel.SetColumnSpan(this.FilterCheckBox, 2);
			this.FilterCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FilterCheckBox.Location = new System.Drawing.Point(3, 3);
			this.FilterCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.FilterCheckBox.Name = "FilterCheckBox";
			this.FilterCheckBox.Size = new System.Drawing.Size(473, 17);
			this.FilterCheckBox.TabIndex = 0;
			this.FilterCheckBox.Text = "Search for orders by additional fields";
			this.FilterCheckBox.UseVisualStyleBackColor = true;
			this.FilterCheckBox.CheckedChanged += new System.EventHandler(this.OnFilterCheckBoxCheckChanged);
			// 
			// AdditionalFiltersPanel
			// 
			this.AdditionalFiltersPanel.AutoSize = true;
			this.AdditionalFiltersPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.AdditionalFiltersPanel.ColumnCount = 2;
			this.AdditionalFiltersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.AdditionalFiltersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.AdditionalFiltersPanel.Controls.Add(this.ReferenceNumberCheckBox, 0, 0);
			this.AdditionalFiltersPanel.Controls.Add(this.OutgoingTrackingNumberCheckBox, 1, 1);
			this.AdditionalFiltersPanel.Controls.Add(this.IncomingTrackingNumberCheckBox, 0, 1);
			this.AdditionalFiltersPanel.Controls.Add(this.PurchaseOrderNumberCheckBox, 1, 0);
			this.AdditionalFiltersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdditionalFiltersPanel.Enabled = false;
			this.AdditionalFiltersPanel.Location = new System.Drawing.Point(38, 20);
			this.AdditionalFiltersPanel.Margin = new System.Windows.Forms.Padding(0);
			this.AdditionalFiltersPanel.Name = "AdditionalFiltersPanel";
			this.AdditionalFiltersPanel.RowCount = 2;
			this.AdditionalFiltersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.AdditionalFiltersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.AdditionalFiltersPanel.Size = new System.Drawing.Size(441, 34);
			this.AdditionalFiltersPanel.TabIndex = 5;
			// 
			// ReferenceNumberCheckBox
			// 
			this.ReferenceNumberCheckBox.AutoSize = true;
			this.ReferenceNumberCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReferenceNumberCheckBox.Location = new System.Drawing.Point(3, 0);
			this.ReferenceNumberCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.ReferenceNumberCheckBox.Name = "ReferenceNumberCheckBox";
			this.ReferenceNumberCheckBox.Size = new System.Drawing.Size(154, 17);
			this.ReferenceNumberCheckBox.TabIndex = 1;
			this.ReferenceNumberCheckBox.Text = "Reference Number";
			this.ReferenceNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// OutgoingTrackingNumberCheckBox
			// 
			this.OutgoingTrackingNumberCheckBox.AutoSize = true;
			this.OutgoingTrackingNumberCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutgoingTrackingNumberCheckBox.Location = new System.Drawing.Point(163, 17);
			this.OutgoingTrackingNumberCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.OutgoingTrackingNumberCheckBox.Name = "OutgoingTrackingNumberCheckBox";
			this.OutgoingTrackingNumberCheckBox.Size = new System.Drawing.Size(275, 17);
			this.OutgoingTrackingNumberCheckBox.TabIndex = 4;
			this.OutgoingTrackingNumberCheckBox.Text = "Outgoing Tracking Number";
			this.OutgoingTrackingNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// IncomingTrackingNumberCheckBox
			// 
			this.IncomingTrackingNumberCheckBox.AutoSize = true;
			this.IncomingTrackingNumberCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IncomingTrackingNumberCheckBox.Location = new System.Drawing.Point(3, 17);
			this.IncomingTrackingNumberCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.IncomingTrackingNumberCheckBox.Name = "IncomingTrackingNumberCheckBox";
			this.IncomingTrackingNumberCheckBox.Size = new System.Drawing.Size(154, 17);
			this.IncomingTrackingNumberCheckBox.TabIndex = 3;
			this.IncomingTrackingNumberCheckBox.Text = "Incoming Tracking Number";
			this.IncomingTrackingNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// PurchaseOrderNumberCheckBox
			// 
			this.PurchaseOrderNumberCheckBox.AutoSize = true;
			this.PurchaseOrderNumberCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PurchaseOrderNumberCheckBox.Location = new System.Drawing.Point(163, 0);
			this.PurchaseOrderNumberCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.PurchaseOrderNumberCheckBox.Name = "PurchaseOrderNumberCheckBox";
			this.PurchaseOrderNumberCheckBox.Size = new System.Drawing.Size(275, 17);
			this.PurchaseOrderNumberCheckBox.TabIndex = 2;
			this.PurchaseOrderNumberCheckBox.Text = "Purchase Order Number";
			this.PurchaseOrderNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// StatusPanel
			// 
			this.StatusPanel.AutoSize = true;
			this.StatusPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.StatusPanel.ColumnCount = 1;
			this.StatusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.StatusPanel.Controls.Add(this.UpdateStatusPanel, 0, 0);
			this.StatusPanel.Controls.Add(this.StatusDescriptionLabel, 0, 1);
			this.StatusPanel.Controls.Add(this.StatusDescriptionTextBox, 0, 2);
			this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.StatusPanel.Location = new System.Drawing.Point(0, 0);
			this.StatusPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.StatusPanel.Name = "StatusPanel";
			this.StatusPanel.RowCount = 3;
			this.StatusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.StatusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.StatusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.StatusPanel.Size = new System.Drawing.Size(479, 131);
			this.StatusPanel.TabIndex = 1;
			// 
			// UpdateStatusPanel
			// 
			this.UpdateStatusPanel.AutoSize = true;
			this.UpdateStatusPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.UpdateStatusPanel.ColumnCount = 2;
			this.UpdateStatusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.UpdateStatusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.UpdateStatusPanel.Controls.Add(this.StatusComboBox, 1, 0);
			this.UpdateStatusPanel.Controls.Add(this.UpdateStatusToLabel, 0, 0);
			this.UpdateStatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UpdateStatusPanel.Location = new System.Drawing.Point(0, 0);
			this.UpdateStatusPanel.Margin = new System.Windows.Forms.Padding(0);
			this.UpdateStatusPanel.Name = "UpdateStatusPanel";
			this.UpdateStatusPanel.RowCount = 1;
			this.UpdateStatusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.UpdateStatusPanel.Size = new System.Drawing.Size(479, 27);
			this.UpdateStatusPanel.TabIndex = 0;
			// 
			// StatusComboBox
			// 
			this.StatusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.StatusComboBox.FormattingEnabled = true;
			this.StatusComboBox.Location = new System.Drawing.Point(95, 3);
			this.StatusComboBox.Name = "StatusComboBox";
			this.StatusComboBox.Size = new System.Drawing.Size(381, 21);
			this.StatusComboBox.TabIndex = 1;
			this.StatusComboBox.SelectedIndexChanged += new System.EventHandler(this.OnStatusComboBoxSelectedIndexChanged);
			// 
			// UpdateStatusToLabel
			// 
			this.UpdateStatusToLabel.AutoSize = true;
			this.UpdateStatusToLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UpdateStatusToLabel.Location = new System.Drawing.Point(1, 3);
			this.UpdateStatusToLabel.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.UpdateStatusToLabel.Name = "UpdateStatusToLabel";
			this.UpdateStatusToLabel.Size = new System.Drawing.Size(88, 21);
			this.UpdateStatusToLabel.TabIndex = 0;
			this.UpdateStatusToLabel.Text = "Update status to:";
			this.UpdateStatusToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StatusDescriptionLabel
			// 
			this.StatusDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusDescriptionLabel.AutoSize = true;
			this.StatusDescriptionLabel.Location = new System.Drawing.Point(3, 30);
			this.StatusDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.StatusDescriptionLabel.Name = "StatusDescriptionLabel";
			this.StatusDescriptionLabel.Size = new System.Drawing.Size(473, 13);
			this.StatusDescriptionLabel.TabIndex = 1;
			this.StatusDescriptionLabel.Text = "Status label:";
			// 
			// StatusDescriptionTextBox
			// 
			this.StatusDescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StatusDescriptionTextBox.Location = new System.Drawing.Point(3, 43);
			this.StatusDescriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.StatusDescriptionTextBox.Multiline = true;
			this.StatusDescriptionTextBox.Name = "StatusDescriptionTextBox";
			this.StatusDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.StatusDescriptionTextBox.Size = new System.Drawing.Size(473, 85);
			this.StatusDescriptionTextBox.TabIndex = 3;
			// 
			// TransferPanel
			// 
			this.TransferPanel.AutoSize = true;
			this.TransferPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TransferPanel.ColumnCount = 2;
			this.TransferPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TransferPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TransferPanel.Controls.Add(this.TransferAssignedComboBox, 0, 0);
			this.TransferPanel.Controls.Add(this.TransferLabel, 0, 1);
			this.TransferPanel.Controls.Add(this.TransferComboBox, 1, 1);
			this.TransferPanel.Controls.Add(this.TransferCollectionCheckBox, 1, 2);
			this.TransferPanel.Controls.Add(this.TransferDeliveryCheckBox, 1, 3);
			this.TransferPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TransferPanel.Location = new System.Drawing.Point(0, 134);
			this.TransferPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TransferPanel.Name = "TransferPanel";
			this.TransferPanel.RowCount = 4;
			this.TransferPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TransferPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TransferPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TransferPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TransferPanel.Size = new System.Drawing.Size(479, 81);
			this.TransferPanel.TabIndex = 2;
			// 
			// TransferLabel
			// 
			this.TransferLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TransferLabel.AutoSize = true;
			this.TransferLabel.Enabled = false;
			this.TransferLabel.Location = new System.Drawing.Point(3, 27);
			this.TransferLabel.Name = "TransferLabel";
			this.TransferLabel.Size = new System.Drawing.Size(32, 13);
			this.TransferLabel.TabIndex = 2;
			this.TransferLabel.Text = "User:";
			// 
			// TransferComboBox
			// 
			this.TransferComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TransferComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TransferComboBox.Enabled = false;
			this.TransferComboBox.FormattingEnabled = true;
			this.TransferComboBox.Location = new System.Drawing.Point(41, 23);
			this.TransferComboBox.Name = "TransferComboBox";
			this.TransferComboBox.Size = new System.Drawing.Size(435, 21);
			this.TransferComboBox.TabIndex = 1;
			this.TransferComboBox.SelectedIndexChanged += new System.EventHandler(this.OnTransferComboBoxSelectedIndexChanged);
			// 
			// TransferAssignedComboBox
			// 
			this.TransferAssignedComboBox.AutoSize = true;
			this.TransferPanel.SetColumnSpan(this.TransferAssignedComboBox, 2);
			this.TransferAssignedComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TransferAssignedComboBox.Location = new System.Drawing.Point(3, 3);
			this.TransferAssignedComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.TransferAssignedComboBox.Name = "TransferAssignedComboBox";
			this.TransferAssignedComboBox.Size = new System.Drawing.Size(473, 17);
			this.TransferAssignedComboBox.TabIndex = 0;
			this.TransferAssignedComboBox.Text = "Update currently assigned user";
			this.TransferAssignedComboBox.UseVisualStyleBackColor = true;
			this.TransferAssignedComboBox.CheckedChanged += new System.EventHandler(this.OnTransferCheckBoxCheckChanged);
			// 
			// TransferCollectionCheckBox
			// 
			this.TransferCollectionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TransferCollectionCheckBox.AutoSize = true;
			this.TransferCollectionCheckBox.Enabled = false;
			this.TransferCollectionCheckBox.Location = new System.Drawing.Point(41, 47);
			this.TransferCollectionCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.TransferCollectionCheckBox.Name = "TransferCollectionCheckBox";
			this.TransferCollectionCheckBox.Size = new System.Drawing.Size(435, 17);
			this.TransferCollectionCheckBox.TabIndex = 2;
			this.TransferCollectionCheckBox.Text = "Update user assigned to collection";
			this.TransferCollectionCheckBox.UseVisualStyleBackColor = true;
			this.TransferCollectionCheckBox.CheckedChanged += new System.EventHandler(this.OnTransferCheckBoxCheckChanged);
			// 
			// TransferDeliveryCheckBox
			// 
			this.TransferDeliveryCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TransferDeliveryCheckBox.AutoSize = true;
			this.TransferDeliveryCheckBox.Enabled = false;
			this.TransferDeliveryCheckBox.Location = new System.Drawing.Point(41, 64);
			this.TransferDeliveryCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.TransferDeliveryCheckBox.Name = "TransferDeliveryCheckBox";
			this.TransferDeliveryCheckBox.Size = new System.Drawing.Size(435, 17);
			this.TransferDeliveryCheckBox.TabIndex = 3;
			this.TransferDeliveryCheckBox.Text = "Update user assigned to delivery";
			this.TransferDeliveryCheckBox.UseVisualStyleBackColor = true;
			this.TransferDeliveryCheckBox.CheckedChanged += new System.EventHandler(this.OnTransferCheckBoxCheckChanged);
			// 
			// BottomInnerPanel
			// 
			this.BottomInnerPanel.AutoSize = true;
			this.BottomInnerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BottomInnerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.BottomInnerPanel.ColumnCount = 1;
			this.MainPanel.SetColumnSpan(this.BottomInnerPanel, 2);
			this.BottomInnerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.BottomInnerPanel.Controls.Add(this.HistoryDataGridView, 0, 0);
			this.BottomInnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BottomInnerPanel.Location = new System.Drawing.Point(11, 369);
			this.BottomInnerPanel.Name = "BottomInnerPanel";
			this.BottomInnerPanel.RowCount = 1;
			this.BottomInnerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.BottomInnerPanel.Size = new System.Drawing.Size(806, 158);
			this.BottomInnerPanel.TabIndex = 2;
			// 
			// HistoryDataGridView
			// 
			this.HistoryDataGridView.AllowUserToAddRows = false;
			this.HistoryDataGridView.AllowUserToDeleteRows = false;
			this.HistoryDataGridView.AllowUserToOrderColumns = true;
			this.HistoryDataGridView.AllowUserToResizeRows = false;
			this.HistoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.HistoryDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.HistoryDataGridView.ColumnHeadersHeight = 34;
			this.HistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.HistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTextBoxColumn,
            this.TrackingNumberTextBoxColumn,
            this.StatusInitialTextBoxColumn,
            this.StatusNewTextBoxColumn,
            this.CustomerTextBoxColumn});
			this.HistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HistoryDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.HistoryDataGridView.Location = new System.Drawing.Point(1, 1);
			this.HistoryDataGridView.Margin = new System.Windows.Forms.Padding(0);
			this.HistoryDataGridView.Name = "HistoryDataGridView";
			this.HistoryDataGridView.ReadOnly = true;
			this.HistoryDataGridView.RowHeadersVisible = false;
			this.HistoryDataGridView.RowHeadersWidth = 62;
			this.HistoryDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.HistoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.HistoryDataGridView.ShowCellErrors = false;
			this.HistoryDataGridView.ShowCellToolTips = false;
			this.HistoryDataGridView.ShowEditingIcon = false;
			this.HistoryDataGridView.ShowRowErrors = false;
			this.HistoryDataGridView.Size = new System.Drawing.Size(804, 156);
			this.HistoryDataGridView.TabIndex = 0;
			// 
			// DateTextBoxColumn
			// 
			this.DateTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.DateTextBoxColumn.HeaderText = "Time Scanned";
			this.DateTextBoxColumn.MinimumWidth = 8;
			this.DateTextBoxColumn.Name = "DateTextBoxColumn";
			this.DateTextBoxColumn.ReadOnly = true;
			this.DateTextBoxColumn.Width = 93;
			// 
			// TrackingNumberTextBoxColumn
			// 
			this.TrackingNumberTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TrackingNumberTextBoxColumn.HeaderText = "Tracking Number";
			this.TrackingNumberTextBoxColumn.MinimumWidth = 8;
			this.TrackingNumberTextBoxColumn.Name = "TrackingNumberTextBoxColumn";
			this.TrackingNumberTextBoxColumn.ReadOnly = true;
			// 
			// StatusInitialTextBoxColumn
			// 
			this.StatusInitialTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.StatusInitialTextBoxColumn.HeaderText = "Initial Status";
			this.StatusInitialTextBoxColumn.MinimumWidth = 8;
			this.StatusInitialTextBoxColumn.Name = "StatusInitialTextBoxColumn";
			this.StatusInitialTextBoxColumn.ReadOnly = true;
			this.StatusInitialTextBoxColumn.Width = 82;
			// 
			// StatusNewTextBoxColumn
			// 
			this.StatusNewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.StatusNewTextBoxColumn.HeaderText = "New Status";
			this.StatusNewTextBoxColumn.MinimumWidth = 8;
			this.StatusNewTextBoxColumn.Name = "StatusNewTextBoxColumn";
			this.StatusNewTextBoxColumn.ReadOnly = true;
			this.StatusNewTextBoxColumn.Width = 80;
			// 
			// CustomerTextBoxColumn
			// 
			this.CustomerTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.CustomerTextBoxColumn.HeaderText = "Customer";
			this.CustomerTextBoxColumn.MinimumWidth = 8;
			this.CustomerTextBoxColumn.Name = "CustomerTextBoxColumn";
			this.CustomerTextBoxColumn.ReadOnly = true;
			this.CustomerTextBoxColumn.Width = 76;
			// 
			// DashboardToolStripStatusLabel
			// 
			this.DashboardToolStripStatusLabel.Name = "DashboardToolStripStatusLabel";
			this.DashboardToolStripStatusLabel.Size = new System.Drawing.Size(48, 17);
			this.DashboardToolStripStatusLabel.Text = "tsStatus";
			// 
			// DashboardStatusStrip
			// 
			this.DashboardStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.DashboardStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DashboardToolStripStatusLabel});
			this.DashboardStatusStrip.Location = new System.Drawing.Point(0, 589);
			this.DashboardStatusStrip.Name = "DashboardStatusStrip";
			this.DashboardStatusStrip.Size = new System.Drawing.Size(834, 22);
			this.DashboardStatusStrip.TabIndex = 1;
			this.DashboardStatusStrip.Text = "statusStrip1";
			// 
			// MainDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(834, 611);
			this.Controls.Add(this.DashboardStatusStrip);
			this.Controls.Add(this.RootPanel);
			this.KeyPreview = true;
			this.MainMenuStrip = this.DashboardMenuStrip;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(850, 2200);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(850, 650);
			this.Name = "MainDashboard";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Barcode Scanner";
			this.RootPanel.ResumeLayout(false);
			this.RootPanel.PerformLayout();
			this.DashboardMenuStrip.ResumeLayout(false);
			this.DashboardMenuStrip.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.RightInnerPanel.ResumeLayout(false);
			this.RightInnerPanel.PerformLayout();
			this.DetailsPanel.ResumeLayout(false);
			this.DetailsPanel.PerformLayout();
			this.ActionPanel.ResumeLayout(false);
			this.ActionPanel.PerformLayout();
			this.LeftInnerPanel.ResumeLayout(false);
			this.LeftInnerPanel.PerformLayout();
			this.SettingsPanel.ResumeLayout(false);
			this.SettingsPanel.PerformLayout();
			this.FilterPanel.ResumeLayout(false);
			this.FilterPanel.PerformLayout();
			this.AdditionalFiltersPanel.ResumeLayout(false);
			this.AdditionalFiltersPanel.PerformLayout();
			this.StatusPanel.ResumeLayout(false);
			this.StatusPanel.PerformLayout();
			this.UpdateStatusPanel.ResumeLayout(false);
			this.UpdateStatusPanel.PerformLayout();
			this.TransferPanel.ResumeLayout(false);
			this.TransferPanel.PerformLayout();
			this.BottomInnerPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.HistoryDataGridView)).EndInit();
			this.DashboardStatusStrip.ResumeLayout(false);
			this.DashboardStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel RootPanel;
		private System.Windows.Forms.ToolStripStatusLabel DashboardToolStripStatusLabel;
		private System.Windows.Forms.StatusStrip DashboardStatusStrip;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.TableLayoutPanel RightInnerPanel;
        private System.Windows.Forms.TableLayoutPanel DetailsPanel;
        private System.Windows.Forms.Label DetailsTrackingNumberLabel;
        private System.Windows.Forms.Label DetailsDateSubmittedLabel;
        private System.Windows.Forms.Label DetailsStatusOldLabel;
        private System.Windows.Forms.Label DetailsCustomerLabel;
        private System.Windows.Forms.Label DetailsTrackingNumberResultLabel;
        private System.Windows.Forms.Label DetailsDateSubmittedResultLabel;
        private System.Windows.Forms.Label DetailsStatusOldResultLabel;
        private System.Windows.Forms.Label DetailsCustomerResultLabel;
        private System.Windows.Forms.Label DetailsStatusNewLabel;
        private System.Windows.Forms.Label DetailsStatusNewResultLabel;
        private System.Windows.Forms.TableLayoutPanel ActionPanel;
        private System.Windows.Forms.Label ActionLabel;
        private System.Windows.Forms.TableLayoutPanel LeftInnerPanel;
        private System.Windows.Forms.Label BarcodeScanResultLabel;
        private System.Windows.Forms.TableLayoutPanel SettingsPanel;
        private System.Windows.Forms.TableLayoutPanel StatusPanel;
        private System.Windows.Forms.TableLayoutPanel UpdateStatusPanel;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label UpdateStatusToLabel;
        private System.Windows.Forms.Label StatusDescriptionLabel;
        private System.Windows.Forms.TextBox StatusDescriptionTextBox;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.TableLayoutPanel BottomInnerPanel;
        private System.Windows.Forms.DataGridView HistoryDataGridView;
        private System.Windows.Forms.MenuStrip DashboardMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DevicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel TransferPanel;
        private System.Windows.Forms.Label TransferLabel;
        private System.Windows.Forms.ComboBox TransferComboBox;
        private System.Windows.Forms.CheckBox TransferCollectionCheckBox;
        private System.Windows.Forms.CheckBox TransferAssignedComboBox;
        private System.Windows.Forms.CheckBox TransferDeliveryCheckBox;
        private System.Windows.Forms.ToolStripSeparator DevicesToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GettingStartedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackingNumberTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusInitialTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusNewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel FilterPanel;
        private System.Windows.Forms.CheckBox FilterCheckBox;
        private System.Windows.Forms.CheckBox ReferenceNumberCheckBox;
        private System.Windows.Forms.CheckBox PurchaseOrderNumberCheckBox;
        private System.Windows.Forms.CheckBox IncomingTrackingNumberCheckBox;
        private System.Windows.Forms.CheckBox OutgoingTrackingNumberCheckBox;
        private System.Windows.Forms.TableLayoutPanel AdditionalFiltersPanel;
    }
}