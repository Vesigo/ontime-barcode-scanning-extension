# Scan Barcode to Update Status Extension
© 2010-2021 Vesigo Studios. All Rights Reserved.

## Introduction

The Scan Barcode to Update Status Extension for OnTime is an interface to allow for usage of barcode scanning devices within the OnTime Management Suite or OnTime Dispatch software applications. This extension allows the user to update the statuses of shipments by scanning the barcodes found on the shipment's shipping labels.

All generic keyboard emulation barcode scanners and many programmable barcode scanner models are compatible with this extension (see the Device Compatibility section below).

## Installation

Install this extension into OnTime using one of the following methods:
- Compiling and packaging this project into an OTEX file.
- Following the directions to download the latest version from the knowledge base article: [How to Use the Scan Barcode to Update Status Extension](https://www.ontime360.com/support/kb/a263/how-to-use-the-scan-barcode-to-update-status-extension.aspx)

## Getting Started

1. Open *OnTime Management Suite* or *OnTime Dispatch*
2. Navigate to the **Tracking** view
3. At the top of the window, within the **Tracking** tab, click on the **Scan Barcode to Update Status Extension** button
4. Ensure a compatible barcode scanning device is connected via USB, Bluetooth, etc.

## Updating the Status of an Order

1. Select a status to apply to scanned shipments via the drop down box labeled **Update status to**. Optionally supply a custom status description to apply alongside the status update via the text box labeled **Status Description**
2. Scan a barcode containing a matching tracking number of an existing order within OnTime
3. Verify that the tracking number displayed within the **Barcode Scan Result** box is green, indicating a successful status update. You may additionally confirm that the recently scanned barcode appears within the history table at the bottom of the window
4. Repeat step 3 for any remaining shipments or repeat steps 1 through 3 for any applicable shipments that require different statuses or status descriptions.

## Troubleshooting

**When I scan a barcode, the 'Barcode Scan Result' box appears as red**

This typically occurs because the the tracking number that was received from the barcode did not match any order's tracking number within your OnTime account. Ensure that the tracking number appears as expected within the **Barcode Scan Result** box, and that an order already exists within your OnTime account with a matching tracking number.

If you are confident that the tracking number matches an existing order or shipment, an internal error may be occurring that is preventing the status update. Consult the informational box directly right of the box labeled **Status Description** for more information regarding what error has occurred. Contact [OnTime Customer Support](https://www.ontime360.com/support.aspx) if the error persists.

**The extension is not doing anything when I scan a barcode with my scanner**

If your scanner is not a compatible programmable Zebra scanner (i.e. a keyboard emulation scanner), the extension window must be focused at all times in order to recognize incoming scanning results.

Usage of the bottom-most status bar's current display value can help determine the current focus state of the extension window. If the extension window is not focused, the extension will display **Refocus window to detect scanner input** in the bottom-most status bar. When the extension window is focused, the extension will display **Ready** in the bottom-most status bar, and will accept scanner input at any time.

If your scanner is a compatible programmable Zebra scanner, the **Refocus window to detect scanner input** message may not display, and will accept scanner input regardless of the window's focused state.

**The 'Barcode Scan Result' box contains ERROR and appears as red**

Restart OnTime Management Suite or OnTime Dispatch then disconnect and reconnect any connected scanners.

Contact [OnTime Customer Support](https://www.ontime360.com/support.aspx) if the error persists. If applicable, consult the informational box directly right of the box labeled **Status Description** for more information regarding what error has occurred.

**Can this extension support multiple scanners at once?**

Yes. This extension is expected accept input from any combination of supported scanners.

## Device Compatability

The Scan Barcode to Update Status Extension is compatible will all keyboard emulation barcode scanning devices. This extension is also compatible with the following Zebra programmable barcode scanning devices:

- DS3408 Handheld Scanner
- DS3608-DP DS3678-DP Ultra Rugged Scanners
- DS3608-ER DS3678-ER Ultra Rugged Scanners
- DS3608-HD DS3678-HD Ultra Rugged Scanners
- DS3608-HP DS3678-HP Ultra Rugged Scanners
- DS3608-SR DS3678-SR Ultra Rugged Scanners
- DS457 Series
- DS4800 Series
- DS6878-DL
- DS6878-HC
- DS6878-SR Cordless Bluetooth 2D Imager
- DS8100 Series
- DS9208 Omnidirectional Hands-Free Presentation Imager
- DS9908-HD
- DS9908-SR
- DS9908R-HD
- DS9908R-SR
- LI2208
- LI3608-ER
- LI3608-SR
- LI4278
- LS9203i General Purpose Bar Code Scanner
- MP6000 Scanner Scale
- Symbol DS4308
- Symbol DS4308-HC
- Symbol DS4308P
- Symbol DS7708
- Symbol DS9808 Hybrid Presentation Imager
- Symbol LS2208 General Purpose Bar Code Scanner
- Symbol LS3008 Rugged Bar Code Scanner
- Symbol LS4208 General Purpose Bar Code Scanner
- Symbol LS4278 Cordless General Purpose Bar Code Scanner
- Symbol LS7708 General Purpose Presentation Scanner