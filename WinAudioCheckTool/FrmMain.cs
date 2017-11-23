using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infomedia.XStudio.XstudioDataInfo;
using DevExpress.XtraEditors;
using System.Collections;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using WinAudioCheckTool.Classes;
using AudioTechReviewDAL;
using System.Xml;
using System.Threading;
using System.Runtime.InteropServices;

namespace WinAudioCheckTool
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
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
        #region //属性

        private Thread ExcThread;
        private Thread AudioCheckCompleteThread;
        private string defaultPath = "";
        /// <summary>
        /// 是否记录静音报警详情
        /// </summary>
        private bool isLowLevelAlarm = false;
        /// <summary>
        /// 是否采用最新质检库质检
        /// </summary>
        private bool isNewCheck = false;

        private List<string> FileList = null;

        private bool isStart = true;
        /// <summary>
        /// 质检总数
        /// </summary>
        private int TotalCount = 0;
        /// <summary>
        /// 成功总数
        /// </summary>
        private int AudioOKCount = 0;
        /// <summary>
        /// 静音报警总数
        /// </summary>
        private int LowLevelAlarmCount = 0;
        /// <summary>
        /// 过载报警总数
        /// </summary>
        private int MaxLevelAlarmCount = 0;
        /// <summary>
        ///  反相报警总数
        /// </summary>
        private int AntiphaseAlarmCount = 0;
        /// <summary>
        /// 左右电平差报警总数
        /// </summary>
        private int LRLevelDiffAlarmCount = 0;
        /// <summary>
        /// 报警总数
        /// </summary>
        private int TotalAlarmCount = 0;
        #endregion
        private AudioCheckSettingsInfo AudioCheckInfo = new AudioCheckSettingsInfo();
        private OldAudioCheckSettingsInfo OldAudioCheckInfo = new OldAudioCheckSettingsInfo();
        public FrmMain()
        {
            InitializeComponent();
            this.isLowLevelAlarm = Convert.ToBoolean(barLowLevel.EditValue);

        }


        private void btn_AudioCheckSettins_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ExcThread != null && ExcThread.IsAlive)
            {

                XtraMessageBox.Show("文件质检中！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                Form_AudioCheckSetting settings = new Form_AudioCheckSetting();

               
                if (settings.ShowDialog() == DialogResult.OK)
                {
                     

                    XtraMessageBox.Show("参数设置成功!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            
        }

        private void btn_SelectFiles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ExcThread != null && ExcThread.IsAlive)
                {

                    XtraMessageBox.Show("文件质检中！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                using (OpenFileDialog open = new OpenFileDialog())
                {

                    open.Filter = "音频文件|*.s48";// "音频文件|*.s48;*.mp3;*.mp2;*.wave;*.wma;*.wav|所有文件|*.*|s48|*.s48";
                    open.Multiselect = true;
                    if (open.ShowDialog() == DialogResult.OK)
                    {

                        string[] files = open.FileNames;
                        this.isStart = true;
                        this.txtInfo.Text = "";
                        AppendMessageLine("开始加载文件...");

                        AppendMessageLine("共检测到" + files.Length + "个文件");

                        if (isNewCheck)
                        {
                            ExcThread = new Thread(new ParameterizedThreadStart(this.AudioCheckByFilesFunc));
                        }
                        else 
                        { 
                            ExcThread = new Thread(new ParameterizedThreadStart(this.OldAudioCheckByFilesFunc));
                        }
                        
                       

                        ExcThread.IsBackground = true;
                        ExcThread.Start(files);


                    }
                }
                //Application.DoEvents();
            }
            catch (Exception ex)
            {
                CommonFunction.WriteLocalLog("调用方法btn_SelectFiles_ItemClick()异常，错误信息：" + ex.Message);

            }
        }

        private void btn_SelectFolders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (ExcThread != null && ExcThread.IsAlive)
                {

                    XtraMessageBox.Show("文件质检中！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择文件夹";
                dialog.ShowNewFolderButton = false;

                if (defaultPath != "")
                {
                    //设置此次默认目录为上一次选中目录
                    dialog.SelectedPath = defaultPath;

                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string foldPath = dialog.SelectedPath;
                    defaultPath = dialog.SelectedPath;
                    DirectoryInfo d = new DirectoryInfo(foldPath);

                    this.isStart = true;
                    this.txtInfo.Text = "";
                    AppendMessageLine("开始扫描所选目录...");
                    this.FileList = new List<string>();
                    GetFiles(d);
                    if (this.FileList == null)
                        return;
                    AppendMessageLine("共检测到" + this.FileList.Count + "个文件");
                    if (isNewCheck)
                    {
                        ExcThread = new Thread(new ParameterizedThreadStart(this.AudioCheckByFilesFunc)); 
                    }
                    else
                    {
                        ExcThread = new Thread(new ParameterizedThreadStart(this.OldAudioCheckByFilesFunc)); 
                    } 
                  
                    ExcThread.IsBackground = true;
                    ExcThread.Start(this.FileList.ToArray());

                }
            }
            catch (Exception ex)
            {

                CommonFunction.WriteLocalLog("调用方法btn_SelectFolders_ItemClick()异常，错误信息：" + ex.Message);
            }
        }

        #region //Function

        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="pContent"></param>
        private void AppendMessageLine(string pContent)
        {
            this.txtInfo.AppendText(DateTime.Now + ":  " + pContent + "\n");
        }


        private bool doAudioCheck(string sourceFile, out string report)
        {
            try
            {

                ClassAudioTechReview.StartAudioCheckEx(AudioCheckInfo, sourceFile, 0);

                while (ClassAudioTechReview.GetProgress() != 100)
                {
                    Application.DoEvents();
                }

                report = "";

                if (ClassAudioTechReview.GetAudioCheckStatus())
                {
                    if (File.Exists(sourceFile + ".xml"))
                    {
                        report = File.ReadAllText(sourceFile + ".xml", Encoding.GetEncoding("gb2312"));

                    }

                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception wz)
            {
                report = wz.Message;
                return false;
            }
            finally
            {
                //try
                //{
                //    if (File.Exists(sourceFile + ".txt"))
                //    {
                //        File.Delete(sourceFile + ".txt");
                //    }
                //}
                //catch { }
            }
        }

        private bool doOldAudioCheck(string sourceFile, out string report)
        {
            bool result;
            uint resule = 0;
            try
            {

                System.IO.Directory.SetCurrentDirectory(Application.StartupPath);
                Application.DoEvents();
                COS_AudioFile_InitLib();
                byte[] b_audioFile = (new UnicodeEncoding()).GetBytes(sourceFile);

                byte[] b_report = (new UnicodeEncoding()).GetBytes(Application.StartupPath + "\\" + "TempReport.txt");

                byte[] b_UserName = (new UnicodeEncoding()).GetBytes("");

                byte[] b_Time = (new UnicodeEncoding()).GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                //this.resule = IPAT_InitCheck(bytes, true, ClassFunction.ReversDuration, ClassFunction.Reverse, true, ClassFunction.MuteDuration, ClassFunction.Mutedbfs, false, ClassFunction.Overloaddbfs, true, ClassFunction.SLevelThreshold_Limit, ClassFunction.NLRLevelTime_Limit, pszReportName, pszReportTime, pszReport);
                //IPAT_StartCheck(true, ClassFunction.ReversDuration, ClassFunction.Reverse, true, ClassFunction.MuteDuration, ClassFunction.Mutedbfs, false, ClassFunction.Overloaddbfs, true, ClassFunction.SLevelThreshold_Limit, ClassFunction.NLRLevelTime_Limit, this.resule);


                resule = IPAT_InitCheck(b_audioFile, OldAudioCheckInfo.IsCheckReverse, OldAudioCheckInfo.ReversDuration, OldAudioCheckInfo.Reverse, OldAudioCheckInfo.IsCheckMutedbfs, OldAudioCheckInfo.MuteDuration, OldAudioCheckInfo.Mutedbfs, OldAudioCheckInfo.IsCheckOverloaddbfs, OldAudioCheckInfo.Overloaddbfs, OldAudioCheckInfo.IsCheckSLevelThreshold_Limit, OldAudioCheckInfo.SLevelThreshold_Limit, OldAudioCheckInfo.NLRLevelTime_Limit, b_UserName, b_Time, b_report);
                IPAT_StartCheck(OldAudioCheckInfo.IsCheckReverse, OldAudioCheckInfo.ReversDuration, OldAudioCheckInfo.Reverse, OldAudioCheckInfo.IsCheckMutedbfs, OldAudioCheckInfo.MuteDuration, OldAudioCheckInfo.Mutedbfs, OldAudioCheckInfo.IsCheckOverloaddbfs, OldAudioCheckInfo.Overloaddbfs, OldAudioCheckInfo.IsCheckSLevelThreshold_Limit, OldAudioCheckInfo.SLevelThreshold_Limit, OldAudioCheckInfo.NLRLevelTime_Limit, resule);

                while (IPAT_GetCheckProcess(resule) != 100)
                {
                    Application.DoEvents();
                }


                report = "";
                result = IPAT_IsFindLimitValue(resule);
                IPAT_CloseCheck(resule);
                if (result)
                {
                    if (File.Exists(Application.StartupPath + "\\" + "TempReport.txt"))
                    {
                        report = File.ReadAllText(Application.StartupPath + "\\" + "TempReport.txt", Encoding.GetEncoding("gb2312"));

                    }

                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception wz)
            {
                report = wz.Message;
                return false;
            }
            finally
            {

                try
                {
                    COS_AudioFile_UnInitLib();
                    if (File.Exists(Application.StartupPath + "\\" + "TempReport.txt"))
                    {
                        File.Delete(Application.StartupPath + "\\" + "TempReport.txt");
                    }
                }
                catch { }
            }
        }

        public string DurationToHMS(string duration)
        {
            if (duration.Length == 0 || duration.Trim() == string.Empty || duration == "0")
                return "00:00:00";
            if (duration.IndexOf(":") != -1) return duration;

            long totalMillisecondTime = Convert.ToInt64(duration);
            long totalSecondTime = totalMillisecondTime / 1000;
            long h = totalSecondTime / 3600;//小时
            totalSecondTime = totalSecondTime % 3600;
            long m = totalSecondTime / 60;//分钟
            long s = totalSecondTime % 60;//秒

            return String.Format("{0:00}:{1:00}:{2:00}", h, m, s);
        }
        private void WriteAlarmLog(XmlNode pNode)
        {
            try
            {


                if (pNode != null && pNode.ChildNodes != null)
                {
                    foreach (XmlNode item in pNode.ChildNodes)
                    {
                        try
                        {
                            string Type = item.Attributes["Type"].Value;
                            string Begin = DurationToHMS(item.Attributes["Begin"].Value);
                            string End = DurationToHMS(item.Attributes["End"].Value);
                            CommonFunction.WriteLog("Type：" + Type + "Begin：" + Begin + " End:" + End + "");
                        }
                        catch (Exception)
                        {

                            continue;
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ReportAnalysis(string pReport, string FilePath)
        {
            try
            {
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(pReport);
                XmlNode temNode = null;

                //静音检测
                temNode = xmlDoc.SelectSingleNode("//LimitDetect//LowLevel");
                if (temNode != null)
                {
                    int count = 0;
                    string AlarmCnt = temNode.Attributes["AlarmCnt"].Value;
                    try
                    {
                        count = Convert.ToInt32(AlarmCnt);
                    }
                    catch
                    {
                        count = 0;

                    }
                    if (count > 0)
                    {
                        this.AppendMessageLine("静音检测报警");
                        this.LowLevelAlarmCount++;
                        if (isLowLevelAlarm)
                        {
                            CommonFunction.WriteLog("文件：" + FilePath + " 静音错误详情");
                            WriteAlarmLog(temNode);
                        }
                    }
                }

                //过载检测
                temNode = xmlDoc.SelectSingleNode("//LimitDetect//MaxLevel");
                if (temNode != null)
                {
                    int count = 0;
                    string AlarmCnt = temNode.Attributes["AlarmCnt"].Value;
                    try
                    {
                        count = Convert.ToInt32(AlarmCnt);
                    }
                    catch
                    {
                        count = 0;

                    }
                    if (count > 0)
                    {
                        this.AppendMessageLine("过载检测报警");
                        this.MaxLevelAlarmCount++;
                    }
                }
                //反相检测
                temNode = xmlDoc.SelectSingleNode("//LimitDetect//Antiphase");
                if (temNode != null)
                {
                    int count = 0;
                    string AlarmCnt = temNode.Attributes["AlarmCnt"].Value;
                    try
                    {
                        count = Convert.ToInt32(AlarmCnt);
                    }
                    catch
                    {
                        count = 0;

                    }
                    if (count > 0)
                    {
                        this.AppendMessageLine("反相检测报警");
                        this.AntiphaseAlarmCount++;
                    }
                }

                //左右电平差检测
                temNode = xmlDoc.SelectSingleNode("//LimitDetect//LRLevelDiff");
                if (temNode != null)
                {
                    int count = 0;
                    string AlarmCnt = temNode.Attributes["AlarmCnt"].Value;
                    try
                    {
                        count = Convert.ToInt32(AlarmCnt);
                    }
                    catch
                    {
                        count = 0;

                    }
                    if (count > 0)
                    {
                        this.AppendMessageLine("左右电平差检测报警");
                        this.LRLevelDiffAlarmCount++;
                    }
                }
                //temNode = xmlDoc.SelectSingleNode("//LimitDetect//LevelEQ");
                //if (temNode != null)
                //{
                //    string AlarmCnt = temNode.Attributes["AlarmCnt"].Value;
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private int GetStringCount(string FullStr, string strIn)
        {
            try
            {
                int index = 0;
                int count = 0;
                while ((index = FullStr.IndexOf(strIn, index)) != -1)
                {
                    count++;
                    index = index + strIn.Length;
                }
                return count;

            }
            catch (Exception)
            {
                return -1;

            }
        }
        private void ReportOldAnalysis(string pReport, string FilePath)
        {
            try
            {
                if (pReport != null)
                {
                    pReport = pReport.Substring(pReport.IndexOf("本次辅助技审极限检测结果"));

                    //静音检测
                    int count1 = GetStringCount(pReport, "静音:");
                    int count2 = GetStringCount(pReport, "右静音:");
                    int count3 = GetStringCount(pReport, "左静音:");
                    int count = count1 + count2 + count3;
                    
                    if (count > 0)
                    {
                        this.LowLevelAlarmCount++;
                        this.AppendMessageLine("静音检测报警");
                        if (isLowLevelAlarm)
                        {
                            CommonFunction.WriteLog("文件：" + FilePath + " 错误详情");
                            CommonFunction.WriteLog(pReport);  
                        }
                    }


                    //过载检测
                    if (GetStringCount(pReport, "过载:") > 0)
                    {
                        this.MaxLevelAlarmCount++;
                        this.AppendMessageLine("过载检测报警");
                    }


                    //反相检测
                    if (GetStringCount(pReport, "反相:") > 0)
                    {
                        this.AntiphaseAlarmCount++;
                        this.AppendMessageLine("反相检测报警");

                    }

                    //左右电平差检测
                    if (GetStringCount(pReport, "电平差:") > 0)
                    {
                        this.LRLevelDiffAlarmCount++;
                        this.AppendMessageLine("左右电平差检测报警");
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region //选择目录质检


        private void AudioCheckByDirectoryFunc(object pFilePath)
        {
            try
            {
                this.Invoke(new AudioCheckByDirectoryEx(this.AudioCheckByDirectory), new object[] { pFilePath });
            }
            catch { }
        }
        private delegate void AudioCheckByDirectoryEx(DirectoryInfo pFilePath);
        private void AudioCheckByDirectory(DirectoryInfo dir)
        {
            try
            {
                TotalCount = 0;
                AudioOKCount = 0;
                LowLevelAlarmCount = 0;
                MaxLevelAlarmCount = 0;
                AntiphaseAlarmCount = 0;
                LRLevelDiffAlarmCount = 0;
                TotalAlarmCount = 0;


                ArrayList FileList = new ArrayList();
                FileInfo[] allFile = dir.GetFiles();
                foreach (FileInfo fi in allFile)
                {
                    try
                    {
                        if (!isStart)
                        {
                            break;
                        }
                        if (txtInfo.Text.Length > txtInfo.MaxLength)
                            txtInfo.Text = "";
                        if (fi.Extension.Trim().ToLower() == ".s48")
                        {


                            string fileName = fi.Name;// Path.GetFileNameWithoutExtension(item);
                            string report = "";
                            this.TotalCount++;
                            if (doAudioCheck(fi.FullName, out report))
                            {
                                AppendMessageLine("质检成功,文件路径：" + fi.FullName);
                                this.AudioOKCount++;

                            }
                            else
                            {
                                AppendMessageLine("质检失败,文件路径：" + fi.FullName);
                                ReportAnalysis(report, fi.FullName);
                                this.TotalAlarmCount++;


                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        CommonFunction.WriteLocalLog("调用方法AudioCheckByFiles()异常，错误信息：" + ex.Message);
                        continue;
                    }
                    finally
                    {
                        try
                        {
                            if (File.Exists(fi.FullName + ".xml"))
                            {
                                File.Delete(fi.FullName + ".xml");
                            }
                        }
                        catch
                        {
                        }

                    }


                }
                DirectoryInfo[] allDir = dir.GetDirectories();
                foreach (DirectoryInfo d in allDir)
                {
                    AudioCheckByDirectory(d);
                }
            }
            catch (Exception ex)
            {

                CommonFunction.WriteLocalLog("调用方法AudioCheckByDirectory()异常，错误信息：" + ex.Message);
            }
            finally
            {

                //AppendMessageLine("共质检" + this.TotalCount + "文件，成功：" + this.AudioOKCount + "个文件, 报警：" + this.TotalAlarmCount + "个文件");

                //AppendMessageLine("静音报警文件数：" + LowLevelAlarmCount);
                //AppendMessageLine("过载报警文件数：" + MaxLevelAlarmCount);
                //AppendMessageLine("反相报警文件数：" + AntiphaseAlarmCount);
                //AppendMessageLine("左右电平差报警文件数：" + LRLevelDiffAlarmCount);
            }


        }

        #endregion

        #region //选择文件质检
        #region //Old

        private void OldAudioCheckByFilesFunc(object pFiles)
        {
            try
            {
                this.Invoke(new OldAudioCheckByFileEx(this.OldAudioCheckByFiles), new object[] { pFiles });
            }
            catch { }
        }
        private delegate void OldAudioCheckByFileEx(string[] pFiles);
        private void OldAudioCheckByFiles(string[] pFiles)
        {
            try
            {

                TotalCount = 0;
                AudioOKCount = 0;
                LowLevelAlarmCount = 0;
                MaxLevelAlarmCount = 0;
                AntiphaseAlarmCount = 0;
                LRLevelDiffAlarmCount = 0;
                TotalAlarmCount = 0;
                AppendMessageLine("开始音频质检...");
                OldAudioCheckInfo = GetOldAudioCheckSettingsInfo();
                foreach (var item in pFiles)
                {
                    try
                    {
                        if (!isStart)
                        {
                            break;
                        }
                        if (txtInfo.Text.Length > txtInfo.MaxLength)
                            txtInfo.Text = "";

                        string fileName = Path.GetFileNameWithoutExtension(item);
                        string report = "";
                        this.TotalCount++;
                        if (doOldAudioCheck(item, out report))
                        {
                            AppendMessageLine("质检成功,文件路径：" + item);
                            this.AudioOKCount++;

                        }
                        else
                        {
                            AppendMessageLine("质检失败,文件路径：" + item);
                            ReportOldAnalysis(report, item);
                            this.TotalAlarmCount++;


                        }
                    }
                    catch (Exception ex)
                    {

                        CommonFunction.WriteLocalLog("调用方法AudioCheckByFiles()异常，错误信息：" + ex.Message);
                        continue;
                    }
                    finally
                    {

                        try
                        {
                            if (File.Exists(item + ".xml"))
                            {
                                File.Delete(item + ".xml");
                            }
                        }
                        catch
                        {
                        }
                    }


                }
            }
            catch (Exception ex)
            {

                CommonFunction.WriteLocalLog("调用方法AudioCheckByFiles()异常，错误信息：" + ex.Message);
            }
            finally
            {
                AppendMessageLine("共质检" + this.TotalCount + "文件，成功：" + this.AudioOKCount + "个文件, 报警：" + this.TotalAlarmCount + "个文件");

                AppendMessageLine("静音报警文件数：" + LowLevelAlarmCount);
                AppendMessageLine("过载报警文件数：" + MaxLevelAlarmCount);
                AppendMessageLine("反相报警文件数：" + AntiphaseAlarmCount);
                AppendMessageLine("左右电平差报警文件数：" + LRLevelDiffAlarmCount);
            }
        }

        #endregion

        #region //New
        private void AudioCheckByFilesFunc(object pFiles)
        {
            try
            {
                this.Invoke(new AudioCheckByFileEx(this.AudioCheckByFiles), new object[] { pFiles });
            }
            catch { }
        }
        private delegate void AudioCheckByFileEx(string[] pFiles);
        private void AudioCheckByFiles(string[] pFiles)
        {
            try
            {

                TotalCount = 0;
                AudioOKCount = 0;
                LowLevelAlarmCount = 0;
                MaxLevelAlarmCount = 0;
                AntiphaseAlarmCount = 0;
                LRLevelDiffAlarmCount = 0;
                TotalAlarmCount = 0;
                AppendMessageLine("开始音频质检...");
                AudioCheckInfo = GetAudioCheckSettingsInfo();
                foreach (var item in pFiles)
                {
                    try
                    {
                        if (!isStart)
                        {
                            break;
                        }
                        if (txtInfo.Text.Length > txtInfo.MaxLength)
                            txtInfo.Text = "";

                        string fileName = Path.GetFileNameWithoutExtension(item);
                        string report = "";
                        this.TotalCount++;
                        if (doAudioCheck(item, out report))
                        {
                            AppendMessageLine("质检成功,文件路径：" + item);
                            this.AudioOKCount++;

                        }
                        else
                        {
                            AppendMessageLine("质检失败,文件路径：" + item);
                            ReportAnalysis(report, item);
                            this.TotalAlarmCount++;


                        }
                    }
                    catch (Exception ex)
                    {

                        CommonFunction.WriteLocalLog("调用方法AudioCheckByFiles()异常，错误信息：" + ex.Message);
                        continue;
                    }
                    finally
                    {

                        try
                        {
                            if (File.Exists(item + ".xml"))
                            {
                                File.Delete(item + ".xml");
                            }
                        }
                        catch
                        {
                        }
                    }


                }
            }
            catch (Exception ex)
            {

                CommonFunction.WriteLocalLog("调用方法AudioCheckByFiles()异常，错误信息：" + ex.Message);
            }
            finally
            {
                AppendMessageLine("共质检" + this.TotalCount + "文件，成功：" + this.AudioOKCount + "个文件, 报警：" + this.TotalAlarmCount + "个文件");

                AppendMessageLine("静音报警文件数：" + LowLevelAlarmCount);
                AppendMessageLine("过载报警文件数：" + MaxLevelAlarmCount);
                AppendMessageLine("反相报警文件数：" + AntiphaseAlarmCount);
                AppendMessageLine("左右电平差报警文件数：" + LRLevelDiffAlarmCount);
            }
        }
        #endregion

        #endregion

        private void AudioCheckCompleteFunc()
        {
            try
            {
                this.Invoke(new AudioCheckCompleteEx(this.AudioCheckComplete));
            }
            catch { }
        }
        private delegate void AudioCheckCompleteEx();
        private void AudioCheckComplete()
        {
            try
            {

                Application.DoEvents();
                AppendMessageLine("静音报警文件数：" + LowLevelAlarmCount);
                while (this.ExcThread == null)
                {
                    string aa = "";
                }

                while (this.ExcThread != null && this.ExcThread.IsAlive)
                {
                    string aa = "";
                }
                if (this.ExcThread != null)
                {
                    AppendMessageLine("共质检" + this.TotalCount + "文件，成功：" + this.AudioOKCount + "个文件, 报警：" + this.TotalAlarmCount + "个文件");

                    AppendMessageLine("静音报警文件数：" + LowLevelAlarmCount);
                    AppendMessageLine("过载报警文件数：" + MaxLevelAlarmCount);
                    AppendMessageLine("反相报警文件数：" + AntiphaseAlarmCount);
                    AppendMessageLine("左右电平差报警文件数：" + LRLevelDiffAlarmCount);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 搜索文件夹中指定类型的文件
        /// </summary>
        /// <param name="dir"></param> 
        private void GetFiles(DirectoryInfo dir)
        {
            try
            {
                Application.DoEvents();
                FileInfo[] allFile = dir.GetFiles();
                foreach (FileInfo fi in allFile)
                {
                    if (".s48" == fi.Extension.Trim().ToLower())
                    {
                        FileList.Add(fi.FullName);

                    }

                }
                DirectoryInfo[] allDir = dir.GetDirectories();
                foreach (DirectoryInfo d in allDir)
                {
                    GetFiles(d);
                }

            }
            catch (Exception)
            {

            }

        }

        #endregion


        private AudioCheckSettingsInfo GetAudioCheckSettingsInfo()
        {
            AudioCheckSettingsInfo _AudioCheckSettingsInfo = null;
            try
            {
                string xmlfile = Application.StartupPath + @"\AudioCheckParameter.xml";
                if (File.Exists(xmlfile))
                {
                    _AudioCheckSettingsInfo = new AudioCheckSettingsInfo();
                    XmlDocument xmlDoc;
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlfile);   //加载xml文件   xmlDoc.SelectSingleNode("AudioCheckParameter").
                    _AudioCheckSettingsInfo.IsCheckMutedbfs = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckMutedbfs").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.Mutedbfs = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Mutedbfs").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.MuteDuration = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("MuteDuration").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.IsCheckReverse = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckReverse").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.Reverse = Convert.ToDouble(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Reverse").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.ReversDuration = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("ReversDuration").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.IsCheckOverloaddbfs = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckOverloaddbfs").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.Overloaddbfs = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Overloaddbfs").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.IsCheckSLevelThreshold_Limit = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckSLevelThreshold_Limit").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.SLevelThreshold_Limit = Convert.ToInt16(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("SLevelThreshold_Limit").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.NLRLevelTime_Limit = Convert.ToInt16(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("NLRLevelTime_Limit").Attributes["value"].Value.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                _AudioCheckSettingsInfo = null;

            }
            return _AudioCheckSettingsInfo;
        }
        private OldAudioCheckSettingsInfo GetOldAudioCheckSettingsInfo()
        {
            OldAudioCheckSettingsInfo _OldAudioCheckSettingsInfo = null;
            try
            {
                string xmlfile = Application.StartupPath + @"\AudioCheckParameter.xml";
                if (File.Exists(xmlfile))
                {
                    _OldAudioCheckSettingsInfo = new OldAudioCheckSettingsInfo();
                    XmlDocument xmlDoc;
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlfile);   //加载xml文件   xmlDoc.SelectSingleNode("AudioCheckParameter").
                    _OldAudioCheckSettingsInfo.IsCheckMutedbfs = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckMutedbfs").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _OldAudioCheckSettingsInfo.Mutedbfs = short.Parse(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Mutedbfs").Attributes["value"].Value.ToString().Trim());
                    _OldAudioCheckSettingsInfo.MuteDuration = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("MuteDuration").Attributes["value"].Value.ToString().Trim());
                    _OldAudioCheckSettingsInfo.IsCheckReverse = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckReverse").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _OldAudioCheckSettingsInfo.Reverse = float.Parse(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Reverse").Attributes["value"].Value.ToString().Trim());
                    _OldAudioCheckSettingsInfo.ReversDuration = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("ReversDuration").Attributes["value"].Value.ToString().Trim());
                    _OldAudioCheckSettingsInfo.IsCheckOverloaddbfs = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckOverloaddbfs").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _OldAudioCheckSettingsInfo.Overloaddbfs = short.Parse(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Overloaddbfs").Attributes["value"].Value.ToString().Trim());
                    _OldAudioCheckSettingsInfo.IsCheckSLevelThreshold_Limit = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckSLevelThreshold_Limit").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _OldAudioCheckSettingsInfo.SLevelThreshold_Limit = Convert.ToInt16(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("SLevelThreshold_Limit").Attributes["value"].Value.ToString().Trim());
                    _OldAudioCheckSettingsInfo.NLRLevelTime_Limit = Convert.ToInt16(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("NLRLevelTime_Limit").Attributes["value"].Value.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                _OldAudioCheckSettingsInfo = null;

            }
            return _OldAudioCheckSettingsInfo;
        }

        private void btn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isStart = false;
        }

        private void btnLimitDetectCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barLowLevel_EditValueChanged(object sender, EventArgs e)
        {
            this.isLowLevelAlarm = Convert.ToBoolean(barLowLevel.EditValue);
        }

         

        private void barIsNewCheck_EditValueChanged(object sender, EventArgs e)
        {
            this.isNewCheck = Convert.ToBoolean(barIsNewCheck.EditValue);
        }



    }
}
