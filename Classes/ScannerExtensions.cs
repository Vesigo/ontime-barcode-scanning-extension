using CoreScanner;
using System;

namespace BarcodeScanningExtension
{
    public static class ScannerExtensions
    {
        #region "Enumerations"

        public enum Actions
        {
            // Scanner SDK Commands
            GET_VERSION = 1000,
            REGISTER_FOR_EVENTS = 1001,
            UNREGISTER_FOR_EVENTS = 1002,

            // Scanner Access Control Commands
            CLAIM_DEVICE = 1500,
            RELEASE_DEVICE = 1501,

            // Scanner Common Commands
            ABORT_MACROPDF = 2000,
            ABORT_UPDATE_FIRMWARE = 2001,
            AIM_OFF = 2002,
            AIM_ON = 2003,
            FLUSH_MACROPDF = 2005,
            DEVICE_PULL_TRIGGER = 2011,
            DEVICE_RELEASE_TRIGGER = 2012,
            SCAN_DISABLE = 2013,
            SCAN_ENABLE = 2014,
            SET_PARAMETER_DEFAULTS = 2015,
            DEVICE_SET_PARAMETERS = 2016,
            SET_PARAMETER_PERSISTANCE = 2017,
            REBOOT_SCANNER = 2019,

            // Scanner Operation Mode Commands
            DEVICE_CAPTURE_IMAGE = 3000,
            DEVICE_CAPTURE_BARCODE = 3500,
            DEVICE_CAPTURE_VIDEO = 4000,

            // Scanner Management Commands
            ATTR_GETALL = 5000,
            ATTR_GET = 5001,
            ATTR_GETNEXT = 5002,
            ATTR_SET = 5004,
            ATTR_STORE = 5005,
            GET_DEVICE_TOPOLOGY = 5006,
            START_NEW_FIRMWARE = 5014,
            UPDATE_FIRMWARE = 5016,
            UPDATE_FIRMWARE_FROM_PLUGIN = 5017,
            UPDATE_DECODE_TONE = 5050,
            ERASE_DECODE_TONE = 5051,

            // Scanner Action Commands
            SET_ACTION = 6000,

            // Serial Scanner Commands
            DEVICE_SET_SERIAL_PORT_SETTINGS = 6101,

            // Other Commands
            DEVICE_SWITCH_HOST_MODE = 6200,

            // Keyboard Emulator Commands
            KEYBOARD_EMULATOR_ENABLE = 6300,

            KEYBOARD_EMULATOR_SET_LOCALE = 6301,
            KEYBOARD_EMULATOR_GET_CONFIG = 6302,

            // Scale Commands
            SCALE_READ_WEIGHT = 7000,

            SCALE_ZERO_SCALE = 7002,
            SCALE_SYSTEM_RESET = 7015
        }

        public enum Beeps
        {
            // High Short
            ONE_HIGH_SHORT = 0,
            TWO_HIGH_SHORT = 1,
            THREE_HIGH_SHORT = 2,
            FOUR_HIGH_SHORT = 3,
            FIVE_HIGH_SHORT = 4,

            // Low Short
            ONE_LOW_SHORT = 5,
            TWO_LOW_SHORT = 6,
            THREE_LOW_SHORT = 7,
            FOUR_LOW_SHORT = 8,
            FIVE_LOW_SHORT = 9,

            // High Long
            ONE_HIGH_LONG = 10,
            TWO_HIGH_LONG = 11,
            THREE_HIGH_LONG = 12,
            FOUR_HIGH_LONG = 13,
            FIVE_HIGH_LONG = 14,

            // Low Long
            ONE_LOW_LONG = 15,
            TWO_LOW_LONG = 16,
            THREE_LOW_LONG = 17,
            FOUR_LOW_LONG = 18,
            FIVE_LOW_LONG = 19,

            // Mixed
            FAST_WARBLE = 20,
            SLOW_WARBLE = 21,
            HIGH_LOW = 22,
            LOW_HIGH = 23,
            HIGH_LOW_HIGH = 24,
            LOW_HIGH_LOW = 25,
            HIGH_HIGH_LOW_LOW = 26,
        }

        public enum HostModes
        {
            XUA_45001_1,    //USB-IBMHID XUA-45001-1
            XUA_45001_2,    //USB-IBMTT XUA-45001-2
            XUA_45001_3,    //USB-HIDKB XUA-45001-3
            XUA_45001_8,    //USB-OPOS XUA-45001-8
            XUA_45001_9,    //USB-SNAPI with Imaging XUA-45001-9
            XUA_45001_10,   //USB-SNAPI without Imaging XUA-45001-10
            XUA_45001_11    //USB-CDC Serial Emulation XUA-45001-11
        }

        public enum LEDs
        {
            GREEN_LED_OFF = 42,
            GREEN_LED_ON = 43,
            YELLOW_LED_ON = 44,
            YELLOW_LED_OFF = 45,
            RED_LED_ON = 46,
            RED_LED_OFF = 47,
        }

        #endregion "Enumerations"

        /// <summary>
        /// Parses individual whitespace-separated, base-16 hexidecimal values into their char equivalents.
        /// </summary>
        /// <param name="rawData">A string of whitespace-separated, base-16 hexidecimal values</param>
        /// <returns>A string containing the concatenated char results</returns>
        public static string ParseHexToString(string rawData)
        {
            if (String.IsNullOrWhiteSpace(rawData)) return String.Empty;
            string result = string.Empty;

            try
            {
                string[] hexValues = rawData.Split(' ');
                foreach (var hex in hexValues)
                {
                    int value = Convert.ToInt32(hex, 16);
                    result += (char)value;
                }
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception thrown when parsing hexidecimal values: {ex.Message}");
            }

            return result;
        }

        #region "CoreScanner API Helper Functions"


        /// <summary>
        /// Sends a operation command to a connected scanner device
        /// </summary>
        /// <param name="coreScanner">A CoreScanner instance</param>
        /// <param name="action">Type of operation to perform</param>
        /// <param name="inXML">XML containing the arguments for the operation</param>
        /// <param name="outXML">Reference to a string to output the XML response as a result of the operation</param>
        /// <returns>An integer value representing the result of the operation</returns>
        public static int Invoke(this CCoreScanner coreScanner, Actions action, string inXML, ref string outXML)
        {
            coreScanner.ExecCommand((int)action, ref inXML, out outXML, out int status);
            return status;
        }

        /// <summary>
        /// Sends a audible "beep" operation command to a connected scanner device
        /// </summary>
        /// <param name="coreScanner">A CoreScanner instance</param>
        /// <param name="scannerId">The ID of the scanner to invoke the command upon/param>
        /// <param name="beepType">Type of beep to invoke</param>
        /// <returns>An integer value representing the result of the operation</returns>
        public static int InvokeBeep(this CCoreScanner coreScanner, int scannerId, Beeps beepType)
        {
            var input = $"<inArgs><scannerID>{scannerId}</scannerID><cmdArgs><arg-int>{(int)beepType}</arg-int></cmdArgs></inArgs>";
            coreScanner.ExecCommand((int)Actions.SET_ACTION, ref input, out _, out int status);
            return status;
        }

        /// <summary>
        /// Sends a LED-light visual feedback operation command to a connected scanner device
        /// </summary>
        /// <param name="coreScanner">A CoreScanner instance</param>
        /// <param name="scannerId">The ID of the scanner to invoke the command upon/param>
        /// <param name="beepType">Type of LED-light visual feedback to invoke</param>
        /// <returns>An integer value representing the result of the operation</returns>
        public static int InvokeLED(this CCoreScanner coreScanner, int scannerId, LEDs ledType)
        {
            var input = $"<inArgs><scannerID>{scannerId}</scannerID><cmdArgs><arg-int>{(int)ledType}</arg-int></cmdArgs></inArgs>";
            coreScanner.ExecCommand((int)Actions.SET_ACTION, ref input, out _, out int status);
            return status;
        }

        /// <summary>
        /// Send a command to register to or unregister from CoreScanner events
        /// </summary>
        /// <param name="coreScanner">A CoreScanner instance</param>
        /// <param name="register">A boolean to determine a register or unregister operation</param>
        /// <returns>An integer value representing the result of the operation</returns>
        public static int RegisterEvents(this CCoreScanner coreScanner, bool register)
        {
            var input = $"<inArgs><cmdArgs><arg-int>2</arg-int><arg-int>1,16</arg-int></cmdArgs></inArgs>";
            coreScanner.ExecCommand(register ? (int)Actions.REGISTER_FOR_EVENTS : (int)Actions.UNREGISTER_FOR_EVENTS, ref input, out _, out int status);
            return status;
        }

        /// <summary>
        /// Sends a command to switch the type of host-mode for a CoreScanner instance
        /// </summary>
        /// <param name="coreScanner">A CoreScanner instance</param>
        /// <param name="register">The type of mode to switch to</param>
        /// <returns>An integer value representing the result of the operation</returns>
        public static int SwitchHostMode(this CCoreScanner coreScanner, HostModes mode)
        {
            var input = $"<inArgs><cmdArgs><arg-string>{mode.ToString().Replace('_', '-')}</arg-string><arg-bool>TRUE</arg-bool><arg-bool>FALSE</arg-bool></cmdArgs></inArgs>";
            coreScanner.ExecCommand((int)Actions.DEVICE_SWITCH_HOST_MODE, ref input, out _, out int status);
            return status;
        }

        /// <summary>
        /// Send a command to enable or disable keyboard-emulation 
        /// </summary>
        /// <param name="coreScanner">A CoreScanner instance</param>
        /// <param name="register">A boolean to determine enabling or disabling of keyboard-enumlation</param>
        /// <returns>An integer value representing the result of the operation</returns>
        public static int ToggleKeyboardEmulation(this CCoreScanner coreScanner, bool enable)
        {
            var input = $"<inArgs><cmdArgs><arg-bool>{enable.ToString().ToUpper()}</arg-bool></cmdArgs></inArgs>";
            coreScanner.ExecCommand((int)Actions.KEYBOARD_EMULATOR_ENABLE, ref input, out _, out int status);
            return status;
        }

        #endregion "CoreScanner API Helper Functions"
    }
}