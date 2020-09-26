using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExcelTools.Src
{
    class DataKeep
    {
        #region 保存xml

        public static T Serialize<T>(string strFile, bool bSave, ref T obj)
          where T : class
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                if (bSave)
                {
                    Stream stream = new FileStream(strFile, FileMode.Create, FileAccess.Write, FileShare.Read);
                    xs.Serialize(stream, obj);
                    stream.Close();
                }
                else
                {
                    bool bExist = File.Exists(strFile);
                    if (bExist)
                    {
                        Stream stream = new FileStream(strFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                        obj = xs.Deserialize(stream) as T;
                        stream.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return obj;
        }
        #endregion
    }
}
