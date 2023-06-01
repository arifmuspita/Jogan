using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads; 

namespace Utilities
{
    public class TwinCat3Utility:IDisposable 
    {
        private bool FAllowConnect;
        public bool AllowConnect { get { return FAllowConnect; } set { FAllowConnect=value; } }
        private TcAdsSymbolInfoLoader SymbolLoader { get; set; }
        private TcAdsClient FTwinCat3Client; 
        private AdsStream FAdsDataStream { get; set; }
        public BinaryReader BinaryReader { get; set; } 
        //private BinaryWriter BinaryWriter { get; set; }
        public TcAdsClient TwinCat3Client
        {
            get { if (FTwinCat3Client == null) FTwinCat3Client = new TcAdsClient(); return FTwinCat3Client; }
        }
        private List<TwinCat3Property> FTwinCat3PropertyList;
        public bool IsConnectedToPLC { get { return TwinCat3Client.IsConnected; } }
        public List<TwinCat3Property> TwinCat3PropertyList
        {
            get { if (FTwinCat3PropertyList == null) FTwinCat3PropertyList = new List<TwinCat3Property>(); return FTwinCat3PropertyList; }
            set { FTwinCat3PropertyList = value; }
        }

        public object ConfigurationManager { get; private set; }

        // public T2 DataObject { get; set; }

        public void ConnectPLC(string NetID)
        {
            if (!FAllowConnect) return;
            //string netid = ConfigurationManager.AppSettings["TwinCatNetID"];
            try
            {
                TwinCat3Client.Timeout =1000 * 30;//1 minute
                TwinCat3Client.Connect(NetID, 851);
                SymbolLoader = FTwinCat3Client.CreateSymbolInfoLoader();
            }
            catch (Exception ee)
            {
                string msg = ee.Message;
                if (ee.InnerException != null)
                {
                    msg = msg + "\r\n" + ee.InnerException.Message;
                    if (ee.InnerException.InnerException != null)
                    {
                        msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show("Error while connecting to : " + NetID + "\r\n" + msg);
            }
        }

        public virtual void ExtractPLCSymbols(string[] FolderVar, object AObject = null)
        {
            if (!FAllowConnect) return;
            if (IsConnectedToPLC)
            {
                if (FolderVar != null && SymbolLoader != null)
                {
                    List<TcAdsSymbolInfo> symbols = new List<TcAdsSymbolInfo>();
                    try
                    {
                        foreach (TcAdsSymbolInfo item in SymbolLoader.GetSymbols(false))
                        {
                            symbols.Add(item);
                        }
                        foreach (var prnt in FolderVar)
                        {
                            var symbols2 = from x in symbols
                                           where x.Name.Contains(prnt)
                                           orderby x.Name
                                           select x;
                            foreach (var item in symbols2)
                            {
                                TwinCat3Property prop = new TwinCat3Property
                                {
                                    DeviceNotificationHandle = 0,// FTwinCat3Client.AddDeviceNotification(item.Name, AdsDataStream, 1, 1, AdsTransMode.OnChange, 100, 0, textBox4),
                                    VariableName = item.Name,
                                    DataObject1 = AObject
                                };
                                TwinCat3PropertyList.Add(prop);
                                prop.DeviceNotificationHandle = FTwinCat3Client.AddDeviceNotification(item.Name, FAdsDataStream, 1, 1, AdsTransMode.OnChange, 100, 0, prop);
                                // treeViewSymbols.Nodes.Add(new TreeNode { Text = item.Name });
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        string msg = ee.Message;
                        if (ee.InnerException != null)
                        {
                            msg = msg + "\r\n" + ee.InnerException.Message;
                            if (ee.InnerException.InnerException != null)
                            {
                                msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                            }
                        }
                        MessageBox.Show("Error while load symbol from PLC\r\n" + msg);
                    }
                }
            }
        }

        public virtual void AddPLCVariable(string AVariableName, object ADataObject1 = null, object ADataObject2 = null)
        {
            if (!FAllowConnect) return;
            if (FTwinCat3Client.IsConnected)
            {
                //ConnectPLC();
                TwinCat3Property prop = new TwinCat3Property
                {
                    DeviceNotificationHandle = 0,
                    VariableName = AVariableName,
                    DataObject1 = ADataObject1,
                    DataObject2 = ADataObject2
                };
                TwinCat3PropertyList.Add(prop);
                try
                {
                    prop.DeviceNotificationHandle = FTwinCat3Client.AddDeviceNotification(AVariableName, FAdsDataStream, 1, 1, AdsTransMode.OnChange, 100, 0, prop);
                }
                catch (Exception ee)
                {
                    //TwinCat3Client.DeleteVariableHandle(varhandle);
                    //AllowConnect = false;
                    string msg = ee.Message;
                    if (ee.InnerException != null)
                    {
                        msg = msg + "\r\n" + ee.InnerException.Message;
                        if (ee.InnerException.InnerException != null)
                        {
                            msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                        }
                    }
                    MessageBox.Show("Error Add data : " + AVariableName + "\r\n" + msg);
                    //AllowConnect = true;
                }
                
            }
        }

        public virtual object ReadAnyFromPLC(string VariableName, TypeOfData TypeOfData, Type ComplexTypeData = null)
        {
            if (!FAllowConnect) return null;
            //ConnectPLC();
            object val = null;
            int varhandle = TwinCat3Client.CreateVariableHandle(VariableName);

            Type tp = null;
            switch (TypeOfData)
            {
                case TypeOfData.tpBool: tp = typeof(Boolean); break;
                case TypeOfData.tpByte: tp = typeof(Byte); break;
                case TypeOfData.tpDouble: tp = typeof(Double); break;
                case TypeOfData.tpInt: tp = typeof(int); break;
                case TypeOfData.tpObject: tp = ComplexTypeData; break; //typeof(ComplexTypeData);break;
                case TypeOfData.tpString: tp = typeof(String); break;

            }
            try
            {
                if (TypeOfData == TypeOfData.tpString)
                {
                    val = TwinCat3Client.ReadAny(varhandle, tp,new int[] { 255 });
                } else val = TwinCat3Client.ReadAny(varhandle, tp);
                TwinCat3Client.DeleteVariableHandle(varhandle);
            }
            catch (Exception ee)
            {
                TwinCat3Client.DeleteVariableHandle(varhandle);
                string msg = ee.Message;
                if (ee.InnerException != null)
                {
                    msg = msg + "\r\n" + ee.InnerException.Message;
                    if (ee.InnerException.InnerException != null)
                    {
                        msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show("Error while read data : " + VariableName + "\r\n" + msg);
            }

            return val;
        }

        public virtual void WriteAnyToPLC(string VariableName, TypeOfData TypeOfData, object Value)
        {
            if (!FAllowConnect) return;
            // ConnectPLC();
            int varhandle = TwinCat3Client.CreateVariableHandle(VariableName);
            try
            {
                object objectVal = null;
                char[] chars;
                switch (TypeOfData)
                {
                    case TypeOfData.tpBool:
                        if (Value.GetType() == typeof(String)) { objectVal = Boolean.Parse((string)Value); } else objectVal = (bool)Value;
                        break;
                    case TypeOfData.tpByte:
                        if (Value.GetType() == typeof(String)) { objectVal = Byte.Parse((string)Value); } else objectVal = (byte)Value;
                        break;
                    case TypeOfData.tpDouble:
                        if (Value.GetType() == typeof(String)) { objectVal = Double.Parse((string)Value); } else objectVal = (double)Value;
                        break;
                    case TypeOfData.tpInt:
                        if (Value.GetType() == typeof(String)) { objectVal = int.Parse((string)Value); } else objectVal = (int)Value;
                        break;
                    case TypeOfData.tpObject: objectVal=Value; break;  
                    case TypeOfData.tpString:
                        objectVal = Value.ToString(); 
                        break;
                } 
                if (TypeOfData == TypeOfData.tpString)
                {
                    TwinCat3Client.WriteAny(varhandle, objectVal, new int[] { ((string)Value).Length }); 
                }
                else TwinCat3Client.WriteAny(varhandle, objectVal);
                TwinCat3Client.DeleteVariableHandle(varhandle); 
            }
            catch (Exception ee)
            {
                TwinCat3Client.DeleteVariableHandle(varhandle);
                string msg = ee.Message;
                if (ee.InnerException != null)
                {
                    msg = msg + "\r\n" + ee.InnerException.Message;
                    if (ee.InnerException.InnerException != null)
                    {
                        msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show("Error while write data : " + VariableName + "\r\n" + msg);
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
               
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        public TwinCat3Utility()
        {
            FAllowConnect = false;
            FAdsDataStream = new AdsStream(31);
            BinaryReader = new BinaryReader(FAdsDataStream, System.Text.Encoding.ASCII);
            FTwinCat3Client = new TcAdsClient();
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TwinCat3Utility() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            if (FTwinCat3PropertyList!=null) FTwinCat3PropertyList.Clear();
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            FAdsDataStream.Dispose();
            BinaryReader.Dispose();
            TwinCat3Client.Dispose();
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
