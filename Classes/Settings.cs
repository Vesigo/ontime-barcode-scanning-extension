using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace BarcodeScanningExtension
{
    public class Settings : SettingsBase
    {
        public bool AdditionalFilters { get; set; }
        public bool FilterIncomingTrackingNumber { get; set; }
        public bool FilterOutgoingTrackingNumber { get; set; }
        public bool FilterPurchaseOrderNumber { get; set; }
        public bool FilterReferenceNumber { get; set; }
        public int LastStatusUsedIndex { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public string AssignedInRouteUserDescription { get; set; }
        public string CancelledBillableUserDescription { get; set; }
        public string CancelledUserDescription { get; set; }
        public string DeliveredUserDescription { get; set; }
        public string DispatchedUserDescription { get; set; }

        public Settings()
        {
            this.SettingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.xml");
            this.EncryptionKey = "A6x83yZ09";
        }

        // Must override WriteSettings() to write values
        public override void WriteSettings(UserSettingsWriter writer)
        {
            writer.WriteEncrypted("LastStatusUsedIndex", LastStatusUsedIndex.ToString());
            writer.WriteEncrypted("DispatchedUserDescription", DispatchedUserDescription);
            writer.WriteEncrypted("AssignedInRouteUserDescription", AssignedInRouteUserDescription);
            writer.WriteEncrypted("DeliveredUserDescription", DeliveredUserDescription);
            writer.WriteEncrypted("CancelledUserDescription", CancelledUserDescription);
            writer.WriteEncrypted("CancelledBillableUserDescription", CancelledBillableUserDescription);
            writer.WriteEncrypted("AdditionalFilters", AdditionalFilters.ToString());
            writer.WriteEncrypted("FilterReferenceNumber", FilterReferenceNumber.ToString());
            writer.WriteEncrypted("FilterPurchaseOrderNumber", FilterPurchaseOrderNumber.ToString());
            writer.WriteEncrypted("FilterIncomingTrackingNumber", FilterIncomingTrackingNumber.ToString());
            writer.WriteEncrypted("FilterOutgoingTrackingNumber", FilterOutgoingTrackingNumber.ToString());
            writer.WriteEncrypted("WindowWidth", WindowWidth.ToString());
            writer.WriteEncrypted("WindowHeight", WindowHeight.ToString());
        }

        // Must override ReadSettings() to read values
        public override void ReadSettings(UserSettingsReader reader)
        {
            LastStatusUsedIndex = Convert.ToInt32(reader.ReadEncrypted("LastStatusUsedIndex", 1.ToString()));
            DispatchedUserDescription = reader.ReadEncrypted("DispatchedUserDescription", String.Empty);
            AssignedInRouteUserDescription = reader.ReadEncrypted("AssignedInRouteUserDescription", String.Empty);
            DeliveredUserDescription = reader.ReadEncrypted("DeliveredUserDescription", String.Empty);
            CancelledUserDescription = reader.ReadEncrypted("CancelledUserDescription", String.Empty);
            CancelledBillableUserDescription = reader.ReadEncrypted("CancelledBillableUserDescription", String.Empty);
            AdditionalFilters = Convert.ToBoolean(reader.ReadEncrypted("AdditionalFilters", false.ToString()));
            FilterReferenceNumber = Convert.ToBoolean(reader.ReadEncrypted("FilterReferenceNumber", false.ToString()));
            FilterPurchaseOrderNumber = Convert.ToBoolean(reader.ReadEncrypted("FilterPurchaseOrderNumber", false.ToString()));
            FilterIncomingTrackingNumber = Convert.ToBoolean(reader.ReadEncrypted("FilterIncomingTrackingNumber", false.ToString()));
            FilterOutgoingTrackingNumber = Convert.ToBoolean(reader.ReadEncrypted("FilterOutgoingTrackingNumber", false.ToString()));
            WindowWidth = Convert.ToInt32(reader.ReadEncrypted("WindowWidth", 850.ToString()));
            WindowHeight = Convert.ToInt32(reader.ReadEncrypted("WindowHeight", 650.ToString()));
        }
    }

    public abstract class SettingsBase
    {
        public string SettingsPath { get; set; }
        public string EncryptionKey { get; set; }

        public SettingsBase()
        {
            // These properties must be set by derived class
            SettingsPath = null;
            EncryptionKey = null;
        }

        /// <summary>
        /// Loads user settings from the specified file. The file should
        /// have been created using this class' Save method.
        /// You must implement ReadSettings for any data to be read.
        /// </summary>
        public void Load()
        {
            UserSettingsReader reader = new UserSettingsReader(EncryptionKey);
            reader.Load(SettingsPath);
            ReadSettings(reader);
        }

        /// <summary>
        /// Saves the current settings to the specified file.
        /// You must implement WriteSettings for any data to be written.
        /// </summary>
        public void Save()
        {
            UserSettingsWriter writer = new UserSettingsWriter(EncryptionKey);
            WriteSettings(writer);
            writer.Save(SettingsPath);
        }

        // Abstract methods
        public abstract void ReadSettings(UserSettingsReader reader);

        public abstract void WriteSettings(UserSettingsWriter writer);
    }

    public class UserSettingsWriter
    {
        private XmlDocument _doc;
        private string _encryptionKey;

        public UserSettingsWriter(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
            _doc = new XmlDocument();

            // Initialize settings document
            _doc.AppendChild(_doc.CreateNode(XmlNodeType.XmlDeclaration, null, null));
            _doc.AppendChild(_doc.CreateElement("Settings"));
        }

        /// <summary>
        /// Saves the current data to the specified file
        /// </summary>
        /// <param name="filename"></param>
        public void Save(string filename)
        {
            _doc.Save(filename);
        }

        /// <summary>
        /// Writes a string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string key, string value)
        {
            WriteNodeValue(key, value ?? String.Empty);
        }

        /// <summary>
        /// Writes an integer value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string key, int value)
        {
            WriteNodeValue(key, value);
        }

        /// <summary>
        /// Writes a floating-point value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string key, double value)
        {
            WriteNodeValue(key, value);
        }

        /// <summary>
        /// Writes a Boolean value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string key, bool value)
        {
            WriteNodeValue(key, value);
        }

        /// <summary>
        /// Writes a DateTime value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string key, DateTime value)
        {
            WriteNodeValue(key, value);
        }

        /// <summary>
        /// Writes an encrypted string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteEncrypted(string key, string value)
        {
            SimpleEncryption enc = new SimpleEncryption(_encryptionKey);
            WriteNodeValue(key, enc.Encrypt(value));
        }

        /// <summary>
        /// Internal method to write a node to the XML document
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void WriteNodeValue(string key, object value)
        {
            XmlElement elem = _doc.CreateElement(key);
            elem.InnerText = value.ToString();
            _doc.DocumentElement.AppendChild(elem);
        }
    }

    public class UserSettingsReader
    {
        private XmlDocument _doc;
        private string _encryptionKey;

        public UserSettingsReader(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
            _doc = new XmlDocument();
        }

        /// <summary>
        /// Loads data from the specified file
        /// </summary>
        /// <param name="filename"></param>
        public void Load(string filename)
        {
            if (File.Exists(filename))
                _doc.Load(filename);
        }

        /// <summary>
        /// Reads a string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string Read(string key, string defaultValue)
        {
            string result = ReadNodeValue(key);
            if (result != null)
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads an integer value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int Read(string key, int defaultValue)
        {
            string s = ReadNodeValue(key);
            if (int.TryParse(s, out int result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads a floating-point value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double Read(string key, double defaultValue)
        {
            string s = ReadNodeValue(key);
            if (double.TryParse(s, out double result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads a Boolean value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool Read(string key, bool defaultValue)
        {
            string s = ReadNodeValue(key);
            if (bool.TryParse(s, out bool result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads a DateTime value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public DateTime Read(string key, DateTime defaultValue)
        {
            string s = ReadNodeValue(key);
            if (DateTime.TryParse(s, out DateTime result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reads an encrypted string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string ReadEncrypted(string key, string defaultValue)
        {
            string result = ReadNodeValue(key);
            if (result != null)
            {
                SimpleEncryption enc = new SimpleEncryption(_encryptionKey);
                return enc.Decrypt(result);
            }
            return defaultValue;
        }

        /// <summary>
        /// Internal method to read a node from the XML document
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string ReadNodeValue(string key)
        {
            if (_doc.DocumentElement != null)
            {
                XmlNode node = _doc.DocumentElement.SelectSingleNode(key);
                if (node != null && !String.IsNullOrEmpty(node.InnerText))
                    return node.InnerText;
            }
            return null;
        }
    }

    /// <summary>
    /// Performs simple encryption and decryption
    /// </summary>
    public class SimpleEncryption
    {
        /// <summary>
        /// Key used for encryption and decryption
        /// </summary>
        private string _key;

        /// <summary>
        /// Initialization vector for DES encryption routine
        /// </summary>
        private readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// Performs simple encryption and decryption
        /// </summary>
        public SimpleEncryption(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="s">String to encrypt</param>
        /// <returns>The encrypted string</returns>
        public string Encrypt(string s)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="s">Encrypted string to decrypt</param>
        /// <returns>The unencrypted string</returns>
        public string Decrypt(string s)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
                des.IV = IV;
                return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}