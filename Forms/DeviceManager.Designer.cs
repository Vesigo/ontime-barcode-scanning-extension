namespace BarcodeScanningExtension
{
    partial class DeviceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceManager));
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DownloadLink = new System.Windows.Forms.LinkLabel();
            this.DevicesList = new System.Windows.Forms.ListView();
            this.ButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Controls.Add(this.DescriptionLabel, 0, 0);
            this.pnlMain.Controls.Add(this.DownloadLink, 0, 1);
            this.pnlMain.Controls.Add(this.DevicesList, 0, 2);
            this.pnlMain.Controls.Add(this.ButtonsPanel, 0, 3);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(8, 8);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 4;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlMain.Size = new System.Drawing.Size(340, 391);
            this.pnlMain.TabIndex = 0;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 3);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(334, 130);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = resources.GetString("DescriptionLabel.Text");
            // 
            // DownloadLink
            // 
            this.DownloadLink.AutoSize = true;
            this.DownloadLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadLink.Location = new System.Drawing.Point(5, 141);
            this.DownloadLink.Margin = new System.Windows.Forms.Padding(5);
            this.DownloadLink.Name = "DownloadLink";
            this.DownloadLink.Size = new System.Drawing.Size(330, 13);
            this.DownloadLink.TabIndex = 1;
            this.DownloadLink.TabStop = true;
            this.DownloadLink.Text = "Download Zebra CoreScanner Drivers";
            this.DownloadLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnDownloadLinkClicked);
            // 
            // DevicesList
            // 
            this.DevicesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesList.HideSelection = false;
            this.DevicesList.Location = new System.Drawing.Point(3, 162);
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(334, 197);
            this.DevicesList.TabIndex = 2;
            this.DevicesList.UseCompatibleStateImageBehavior = false;
            this.DevicesList.View = System.Windows.Forms.View.List;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.AutoSize = true;
            this.ButtonsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonsPanel.ColumnCount = 3;
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ButtonsPanel.Controls.Add(this.CloseButton, 2, 0);
            this.ButtonsPanel.Controls.Add(this.RefreshButton, 0, 0);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 362);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.RowCount = 1;
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsPanel.Size = new System.Drawing.Size(340, 29);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(262, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.OnButtonCloseClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(3, 3);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "&Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.OnRefreshButtonClick);
            // 
            // DeviceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(356, 407);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceManager";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devices";
            this.Shown += new System.EventHandler(this.OnDeviceManagerShown);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.LinkLabel DownloadLink;
        private System.Windows.Forms.ListView DevicesList;
        private System.Windows.Forms.TableLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button CloseButton;
    }
}