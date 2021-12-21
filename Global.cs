using System.Drawing;

namespace BarcodeScanningExtension
{
    internal static class Global
    {
        public const string AppName = "Scan Barcode to Update Status";
        public const string AppDescription = "Integrate laser 1D barcode scanners with OnTime and automate status updates.";
        public const string AppVersion = "1.5";
        public const string AppPublisher = "Vesigo Studios";
        public const string AppRibbonGroupName = "Barcode Scanning";
        public const string AppRibbonGroupDescription = "Barcode Scanning Extension";

        public const int InputClearThreshold = 200;
        public const int FocusCheckInterval = 500;
        public const int MessageDelaySpeed = 5000;

        public const int ResultErrorBlinkInterval = 250;
        public const int ResultErrorBlinkIterations = 6;

        public static Font AppFont = GetAppFont(FontStyle.Regular);
        
        public static Font GetAppFont(FontStyle style)
        {
            const string fontName = "Segoe UI";
            Font results = new Font(fontName, 9, style);
            if ((results.Name ?? "") == fontName)
                    return results;
                else
                    return SystemFonts.IconTitleFont;
        }

    }
}