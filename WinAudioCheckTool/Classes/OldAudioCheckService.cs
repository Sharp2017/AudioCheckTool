
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Infomedia.XStudio.XstudioDataInfo;
using System.Windows.Forms;
using System.IO;

namespace WinAudioCheckTool.Classes
{
    public class OldAudioCheckService
    {
        #region //DllImport
         
        [DllImport("mediafilerw.dll")]
        public static extern int COS_AudioFile_InitLib();
        [DllImport("mediafilerw.dll")]
        public static extern int COS_AudioFile_UnInitLib();
        [DllImport("IPATExdll.dll")]
        public static extern uint IPAT_InitCheck(byte[] pszFile, bool bCheckRP_Limit, int nRPTime_Limit, float fRPThreshold_Limit,
                    bool bCheckMute_Limit, int nMuteTime_Limit, short sMuteThreshold_Limit,
                    bool bCheckOverload_Limit, short sOverloadThreshold_Limit,
                    bool bCheckLRLevel_Limit, short sLevelThreshold_Limit, int nLRLevelTime_Limit, byte[] pszReportName, byte[] pszReportTime,
                    byte[] pszReport);

        [DllImport("IPATExdll.dll")]
        public static extern void IPAT_StartCheck(bool bCheckRP, int nRPTime, float fRPThreshold,
            bool bCheckMute, int nMuteTime, short sMuteThreshold,
            bool bCheckOverload, short sOverloadThreshold,
            bool bCheckLRLevel, short sLevelThreshold, int nLRLevelTime,
            uint pHandle);
        [DllImport("IPATExdll.dll")]
        public static extern int IPAT_GetCheckProcess(uint pContext);
        [DllImport("IPATExdll.dll")]
        public static extern void IPAT_StopCheck(uint pContext);
        [DllImport("IPATExdll.dll")]
        public static extern void IPAT_CloseCheck(uint pContext);
        [DllImport("IPATExdll.dll")]
        public static extern bool IPAT_IsFindLimitValue(uint pHandle);
        #endregion
        uint resule = 0;

        public static bool DoAudioCheck(OldAudioCheckSettingsInfo pAinfo, string fileName, string title,out string reportInfo)
        {
            bool result = false;
            reportInfo = "";
            try
            {
                System.IO.Directory.SetCurrentDirectory(Application.StartupPath);
                Application.DoEvents();
                COS_AudioFile_InitLib();

                byte[] b_audioFile = (new UnicodeEncoding()).GetBytes(fileName);

                byte[] b_report = (new UnicodeEncoding()).GetBytes(Application.StartupPath + "\\" + "TempReport.txt");

                byte[] b_UserName = (new UnicodeEncoding()).GetBytes("");

                byte[] b_Time = (new UnicodeEncoding()).GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                uint resule = 0; 
                 
                resule = IPAT_InitCheck(b_audioFile, pAinfo.IsCheckReverse, pAinfo.ReversDuration, pAinfo.Reverse, pAinfo.IsCheckMutedbfs, pAinfo.MuteDuration, pAinfo.Mutedbfs, pAinfo.IsCheckOverloaddbfs, pAinfo.Overloaddbfs, pAinfo.IsCheckSLevelThreshold_Limit, pAinfo.SLevelThreshold_Limit, pAinfo.NLRLevelTime_Limit, b_UserName, b_Time, b_report);
                IPAT_StartCheck(pAinfo.IsCheckReverse, pAinfo.ReversDuration, pAinfo.Reverse, pAinfo.IsCheckMutedbfs, pAinfo.MuteDuration, pAinfo.Mutedbfs, pAinfo.IsCheckOverloaddbfs, pAinfo.Overloaddbfs, pAinfo.IsCheckSLevelThreshold_Limit, pAinfo.SLevelThreshold_Limit, pAinfo.NLRLevelTime_Limit, resule);

                while (IPAT_GetCheckProcess(resule) != 100)
                {
                    Application.DoEvents();
                }

                result = IPAT_IsFindLimitValue(resule);

                IPAT_CloseCheck(resule);
                return result;

            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                COS_AudioFile_UnInitLib();
                if (File.Exists(Application.StartupPath + "\\" + "TempReport.txt"))
                {
                    File.Delete(Application.StartupPath + "\\" + "TempReport.txt");   
                }
            }
        }
    }
}
