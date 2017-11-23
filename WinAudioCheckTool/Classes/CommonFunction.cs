using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace WinAudioCheckTool.Classes
{
    public static class CommonFunction
    {
        public static string FileTypes = "*.*";
        public static bool IsEdit = false;
        public static int nbspCount = 6;
        //public static AudioCheckInfoDBService MyAudioCheckInfoDBService = new AudioCheckInfoDBService();
        public static void WriteLocalLog(string conent)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\log"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\log");
                }

                string fileName = DateTime.Now.ToString("yyyyMMdd") + "ErrorLog.txt";

                StreamWriter stream = File.AppendText(Application.StartupPath + "\\log\\" + fileName);
                stream.WriteLine(DateTime.Now + ":  " + conent);
                stream.Flush();
                stream.Close();

            }
            catch (System.Exception ex)
            {

            }



        }
        public static void WriteLog(string conent)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\log"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\log");
                }

                string fileName = DateTime.Now.ToString("yyyyMMdd") + "Log.txt";

                StreamWriter stream = File.AppendText(Application.StartupPath + "\\log\\" + fileName);
                stream.WriteLine(DateTime.Now + ":  " + conent);
                stream.Flush();
                stream.Close();

            }
            catch (System.Exception ex)
            {

            }



        }

        ///<summary> 
        ///返回*.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string GetAppConfig(string strKey)
        {
            try
            {
                string file = System.Windows.Forms.Application.ExecutablePath;
                Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                return config.AppSettings.Settings[strKey].Value.ToString();
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
