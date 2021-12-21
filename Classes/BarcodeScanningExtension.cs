using OnTime.Extensions.SDK;
using System.AddIn;
using System.Drawing;

namespace BarcodeScanningExtension
{
    [AddIn(APP_NAME, Description = APP_DESC, Publisher = APP_PUBL, Version = APP_VERS)]
    public class BarcodeScanningExtension : TrackingView
    {
        // Constants
        public const int APP_FONT_SIZE = 9;
        public const string APP_DESC = "Integrate laser 1D barcode scanners with OnTime and automate status updates.";
        public const string APP_DESC_GROUP = "Barcode Scanning Extension";
        public const string APP_FONT_NAME = "Segoe UI";
        public const string APP_NAME = "Scan Barcode to Update Status";
        public const string APP_NAME_GROUP = "Barcode Scanning";
        public const string APP_PUBL = "Vesigo Studios";
        public const string APP_VERS = "1.5";

        // Properties
        public static readonly Font AppFont = GetFont();
        public static readonly Settings Settings = new Settings();

        public override void Initialize()
        {
            // Initialize the independent extension.
            InitializeTrackingExtension(APP_NAME_GROUP, APP_DESC_GROUP);

            // Add a new button to the ribbon bar.
            Buttons.Add(new RibbonButton(APP_NAME, APP_DESC, Properties.Resources.ribbon, Properties.Resources.icon, Open));
        }

        public void Open()
        {
            var dataAccess = this.Data;
            using (var frm = new MainDashboard(dataAccess))
            {
                frm.ShowDialog();
            }
        }

        private static Font GetFont()
        {
            Font results = new Font(APP_FONT_NAME, APP_FONT_SIZE, FontStyle.Regular);

            if (results != null)
            {
                if (results.Name == APP_FONT_NAME)
                {
                    return results;
                }
            }

            return SystemFonts.IconTitleFont;
        }
    }
}
