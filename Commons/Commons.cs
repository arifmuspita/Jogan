using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PWDTK_DOTNET451;
using System.Reflection;
using System.Web;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commons
{
    public enum StatusTestingControl
    {None,
        On,
        Off,
        Start,
        Finish,
        Empty,
        Attached,
        Standby,
        Ready,
        Loading,
        Unloading,
        Testing,
        TestDone,
        Available,
        ByPassTest,
        Booked
    }
    public static class AppCollections
    {
        public struct GridFormat
        {
            public string headerText;
            public string fieldName;
            public string fieldNameFilter;
            /*
             * N2 -> numeric
             * C2 -> currency
             * d  -> short date
             * D  -> long date
            */
            public string formatField;
            public DataGridViewContentAlignment textAlign;
            // <> -1 use for filter datatable
            // index will be same on combobox SelectedIndex
            public int indexForSearch;
            public int colWidth;
            public bool colVisible;
            //use for identify which column type that will be filtered
            //select ftEmpty if field will not filtered
            public FilterType filterType;

        }

        public enum FilterType
        { ftEmpty, ftDate, ftString, ftNumeric,ftBoolean }
    }
    public enum MachineState
    {
        msOn, msOff, msMaintanance
    }
    public class TransactionMachineState
    {
        public TransactionMachineState()
        {
            Machine_Type = "";
            Machine_ID = "";
            Status = MachineState.msOn;
            Machine_Number = 0;
        }
        public int Machine_Number { get; set; }
        public string Machine_Type { get; set; }
        public string Machine_ID { get; set; }
        public MachineState Status { get; set; }
    }
    public delegate void EventMachineBook(object sender, TransactionMachineState e);
    public class Commons
    {

        private static string FKey = "34E6F674681518A8A1560954";

        public static string EncryptMD5(string input)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.


                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static T GetEnumFromString<T>(string EnumInString)
        { 
            foreach (T foo in Enum.GetValues(typeof(T)))
            {
                if (foo.ToString().ToUpper()== EnumInString.ToUpper())
                {
                    return foo;
                }
            } 
            return default(T);
        }
        public static string EncryptPWDTK(string Text, string OutsideSalt, out string PWDTKSalt)
        {
            string ret = "";
            PWDTKSalt = OutsideSalt;

            if (OutsideSalt == "")
            {
                byte[] hashsalt = PWDTK.GetRandomSalt();
                PWDTKSalt = PWDTK.HashBytesToHexString(hashsalt);
                ret = PWDTK.PasswordToHashHexString(hashsalt, Text);
            }
            else
            {
                byte[] salt = PWDTK.HashHexStringToBytes(OutsideSalt);
                ret = PWDTK.PasswordToHashHexString(salt, Text);
            }
            //2. Add the encryption password using PBKDF2

            return ret;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string EncryptTripleDES(string Data)
        {
            try
            {
                byte[] _rgbkey = Encoding.ASCII.GetBytes(FKey);

                // Create a new 3DES key.
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

                // Set the KeySize = 192 for 168-bit DES encryption.
                // The msb of each byte is a parity bit, so the key length is actually 168 bits.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                //des.KeySize = 192;
                des.Key = _rgbkey;
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;

                ICryptoTransform ic = des.CreateEncryptor();

                byte[] ret = ic.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

                des.Clear();
                string _ret = ByteArrayToString(ret);
                return _ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }



        public static string DecryptTripleDES(string Data)
        {
            try
            {
                byte[] _rgbkey = Encoding.ASCII.GetBytes(FKey);
                byte[] _data = StringToByteArray(Data); //Encoding.ASCII.GetBytes(Data);

                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

                des.Key = _rgbkey;
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;

                ICryptoTransform ic = des.CreateDecryptor();

                byte[] fromEncrypt = ic.TransformFinalBlock(_data, 0, _data.Length);
                des.Clear();

                string _ret = ASCIIEncoding.ASCII.GetString(fromEncrypt);// HexStringFromBytes(fromEncrypt);
                return _ret;// new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static string SerializeIt(object obj)
        {
            string str = "";
            if (obj != null) { str = JsonConvert.SerializeObject(obj); }
            return str;
        }

        public static string SerializeIt(object obj,bool EncryptData)
        {
            string str = "";
            if (obj != null)
            {
                if (obj != null) {
                    str = JsonConvert.SerializeObject(obj); 
                    if (EncryptData) str = EncryptTripleDES(str);
                }
            }
            return str;
        }
        public static T DeserializeIt<T>(string JSONObject, bool EncryptedData)
        {
            if (JSONObject != "")
            {
                if (!EncryptedData) { JSONObject = DecryptTripleDES(JSONObject); }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JSONObject);
            }
            return default(T);
        }
        public static void SetSessions(string CookiesName, object CookiesObj)
        {
            string CookiesVal = EncryptTripleDES(SerializeIt(CookiesObj));
            HttpCookie hc = null;
            for (int cch = HttpContext.Current.Request.Cookies.Count; cch > 0; cch--)
            {
                if (HttpContext.Current.Request.Cookies.AllKeys[cch - 1] == CookiesName)
                {
                    hc = HttpContext.Current.Request.Cookies[cch - 1];
                    break;
                }
            }
            if (hc != null) { HttpContext.Current.Response.Cookies.Remove(CookiesName); }
            HttpContext.Current.Response.SetCookie(new HttpCookie(CookiesName, CookiesVal));
        }

        public static string GetSessions(string CookiesName)
        {
            string ret = "";
            HttpCookie ck = HttpContext.Current.Request.Cookies[CookiesName];
            ret = ck == null ? "" : ck.Value;
            if (ret != "") { ret = DecryptTripleDES(ret); }
            return ret;
        }

        public static T ObjectFromJSON<T>(string JSONObject, bool Decrypted = true)
        {
            if (JSONObject != "")
            {
                if (!Decrypted) { JSONObject = DecryptTripleDES(JSONObject); }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JSONObject);
            }
            return default(T);
        }

        public static T JSONToObjectFromCookies<T>(string CookiesName)
        {

            string json = GetSessions(CookiesName);
            return ObjectFromJSON<T>(json);
        }

        public static void SetSessionsClear(string ACookiesName = "")
        {
            HttpCookie hc = null;
            // bool isfound = false;
            for (int cch = HttpContext.Current.Request.Cookies.Count; cch > 0; cch--)
            {
                if (ACookiesName != "")
                {
                    if (HttpContext.Current.Request.Cookies.AllKeys[cch - 1] == ACookiesName)
                    {
                        hc = HttpContext.Current.Request.Cookies[cch - 1];
                        //isfound = true;
                    }
                }
                else
                {
                    hc = HttpContext.Current.Request.Cookies[cch - 1];
                }
                if (hc != null)
                {
                    hc.Expires = DateTime.Now.AddDays(-1d);
                    //HttpContext.Current.Response.Cookies.Add(hc);
                    HttpContext.Current.Response.Cookies.Set(hc);
                    HttpContext.Current.Response.Cookies.Remove(ACookiesName);
                }
            }
        }
        public static bool IsRequiredField(Type source, string FieldName)
        {
            bool ret = false;
            if (source != null)
            {
                PropertyInfo prop =  source.GetProperty(FieldName);
                if (prop != null)
                {
                    object[] dbFieldAtts = prop.GetCustomAttributes(typeof(RequiredAttribute), true);
                    ret = (dbFieldAtts != null && dbFieldAtts.Length > 0);
                }
            }
            return ret;
        }
        public static void SetDefaultValue(object source)
        {
            if (source != null)
            {
                Type type = source.GetType();
                foreach (PropertyInfo info in type.GetProperties())
                {
                    PropertyInfo property = type.GetProperty(info.Name);
                    if ((property != null) && (property.PropertyType.Namespace != "System.Data.Objects.DataClasses")) //&& (property.PropertyType != typeof(EntityState)))
                    {
                        try
                        {
                            bool isrequired = false;
                            foreach (CustomAttributeData attr in property.CustomAttributes)
                            {
                                isrequired = (attr.AttributeType.Name == "RequiredAttribute");
                            }

                            if (isrequired)
                            {
                                if (property.PropertyType == typeof(string)) { property.SetValue(source, "A"); }
                                else if (property.PropertyType == typeof(int) ||
                                        property.PropertyType == typeof(float) ||
                                        property.PropertyType == typeof(double)
                                        ) { property.SetValue(source, 0); }
                                else if (property.PropertyType == typeof(DateTime)) { property.SetValue(source, DateTime.Now); }
                                else if (property.PropertyType == typeof(bool)) { property.SetValue(source, false); }
                                else
                                {
                                    //property.Attributes
                                    object obj = Activator.CreateInstance(property.PropertyType);
                                    property.SetValue(source, obj);
                                    SetDefaultValue(obj);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            string msg = e.Message;
                        }
                    }
                }
            }
        }

        public static void CopyProperties(object source, object destination)
        {
            if (source == null || destination == null) return;
            Type type = source.GetType();
            foreach (PropertyInfo info in destination.GetType().GetProperties())
            {
                PropertyInfo property = type.GetProperty(info.Name);
                if ((property != null) && (property.PropertyType.Namespace != "System.Data.Objects.DataClasses")  &&
                        (!(info.Name.ToUpper() == "ID" || info.Name.ToUpper() == "CREATED_DATE" || info.Name.ToUpper() == "CREATED_USER" || info.Name.ToUpper() == "UPDATED_DATE" || info.Name.ToUpper() == "UPDATED_DATE"))) {
                    try
                    {
                        object obj2 = property.GetValue(source, null);
                        if (obj2 != null) { info.SetValue(destination, obj2, null); }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        public static object GetValueFromProperty(object source, string PropertyName)
        {
            object ret = null;
            Type type = source.GetType();
            PropertyInfo prop = type.GetProperty(PropertyName);
            if (prop != null)
            {
                ret = prop.GetValue(source, null);
            }
            return ret;
        }

        public static void SetValueOfProperty(object source, string PropertyName, object Value)
        {
            Type type = source.GetType();
            PropertyInfo prop = type.GetProperty(PropertyName);
            if (prop != null) { prop.SetValue(source, Value); }            
        }


        //<div class="row">
        //        <div class="col-md-2"><label for="Code">Group ID * :</label></div>
        //        <div class="col-md-10"><input type = "text" class="form-control" name="Group_ID" value="@data.Group_ID" id="Group_ID" required="required" style="width:300px" /></div>
        //        <div class="help-block with-errors"></div>
        //    </div>
        //public static string GenerateSimpleHTML(object Source, List<string> ExcludeFields=null)
        //{
        //    object ret = null;
        //    Type type = Source.GetType();
        //    foreach (PropertyInfo info in type.GetProperties())
        //    {
        //        PropertyInfo property = type.GetProperty(info.Name);
        //    }
        //        PropertyInfo prop = type.GetProperty(PropertyName);
        //    if (prop != null)
        //    {
        //        ret = prop.GetValue(source, null);
        //    }
        //    return ret;
        //}
    }
}
