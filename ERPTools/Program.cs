using ExcelTools.Src;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPTools
{
    static class Program
    {

        private static bool run = true;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Init();
            if (run)
            {
                Application.Run(new MainForm());
            }
                   
        }
        #region 软件更新检测
        private static void Init()
        {
            string productVersion = "";
            string config = Application.StartupPath + "\\配置文件\\版本信息.xml";
            string configPath = Application.StartupPath + "\\配置文件\\Config.xml";
            Param param = new Param();
            string url = "";
            if (false == System.IO.Directory.Exists(Application.StartupPath + "\\Temporary"))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Temporary");
            }
            string path = Application.StartupPath + "\\Temporary\\" + "版本号.txt";
            string updaterpath = Application.StartupPath + "\\";


            if (File.Exists(config))
            {
                #region 判断软件是否需要更新
                DataKeep.Serialize(config, false, ref param);
                foreach (Map map in param.Maps)
                {
                    if (map.Name.Equals("版本号"))
                    {
                        productVersion = map.Value;
                    }
                    if (map.Name.Equals("url"))
                    {
                        url = map.Value;
                    }
                    if (map.Name.Equals("更新器"))
                    {
                        updaterpath += map.Value;
                    }
                }
                using (var client = new WebClient())
                {
                    try { client.DownloadFile(url, path); }
                    catch { }
                }
                if (File.Exists(path))
                {
                    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    StreamReader reader = new StreamReader(stream);
                    string str = reader.ReadToEnd().Trim();
                    reader.Close();
                    stream.Close();
                    int result = string.Compare(productVersion, str, true);
                    if (result < 0)
                    {
                        if (File.Exists(updaterpath))
                        {
                            if (DialogResult.Cancel == MessageBox.Show("本软件有最新版本是否需要更新?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                            {
                                run = true;
                            }
                            else
                            {
                                System.Diagnostics.Process.Start(updaterpath);
                                run = false;
                                Application.Exit();
                            }
                        }
                    }
                    File.Delete(path);
                }
                #endregion
            }
        }
        #endregion

    }
}
