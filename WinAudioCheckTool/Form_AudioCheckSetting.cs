using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Infomedia.XStudio.XstudioDataInfo;
using System.IO;
using System.Xml;
using WinAudioCheckTool.Classes;

namespace WinAudioCheckTool
{
    public partial class Form_AudioCheckSetting : DevExpress.XtraEditors.XtraForm
    {

        AudioCheckSettingsInfo myAudioCheckSettingsInfo = new AudioCheckSettingsInfo();
        OldAudioCheckSettingsInfo myOldAudioCheckSettingsInfo = new OldAudioCheckSettingsInfo();
       

        public Form_AudioCheckSetting()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.txt_Reverse.Value.ToString().Trim().Length == 0)
            {
                XtraMessageBox.Show("请输入反相检测阀值！", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.txt_ReversDuration.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("请输入反相检测时间长度！", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                double.Parse(this.txt_Reverse.Text.Trim());
            }
            catch
            {
                XtraMessageBox.Show("反相检测阀值输入不正确！", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int.Parse(this.txt_ReversDuration.Text.Trim());
            }
            catch
            {
                XtraMessageBox.Show("反相检测时间长度输入不正确！", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //this.myAudioCheckSettingsInfo.Mutedbfs = (int)this.se_Mutedbfs.Value;
            //this.myAudioCheckSettingsInfo.MuteDuration = (int)this.se_MuteDuration.Value;
            //this.myAudioCheckSettingsInfo.Overloaddbfs = (int)this.se_Overloaddbfs.Value;
            //this.myAudioCheckSettingsInfo.ReversDuration = int.Parse(this.txt_ReversDuration.Text.Trim());
            //this.myAudioCheckSettingsInfo.Reverse = (double)this.txt_Reverse.Value;//double.Parse(this.txt_Reverse.Value.Trim());
            //this.myAudioCheckSettingsInfo.SLevelThreshold_Limit = (short)this.se_LR.Value;
            //this.myAudioCheckSettingsInfo.NLRLevelTime_Limit = (int)this.se_LRDuration.Value;


            //this.myAudioCheckSettingsInfo.IsCheckMutedbfs = this.chk_Mute.Checked;
            //this.myAudioCheckSettingsInfo.ISCheckOnair = true;
            //this.myAudioCheckSettingsInfo.IsCheckOverloaddbfs = this.chk_OverLoad.Checked;
            //this.myAudioCheckSettingsInfo.IsCheckReverse = this.chk_Reverse.Checked;
            //this.myAudioCheckSettingsInfo.IsCheckSLevelThreshold_Limit = this.chk_LR.Checked;
            //this.myAudioCheckSettingsInfo.ISCheckXStudio = true;

            //SetAudioCheckSettingsInfo(this.myAudioCheckSettingsInfo);
            SetAudioCheckSettingsInfo();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form_AudioCheckSetting_Load(object sender, EventArgs e)
        {
            this.myOldAudioCheckSettingsInfo = GetOldAudioCheckSettingsInfo();
            this.se_Mutedbfs.Value = this.myOldAudioCheckSettingsInfo.Mutedbfs;
            this.se_MuteDuration.Value = this.myOldAudioCheckSettingsInfo.MuteDuration;
            this.se_Overloaddbfs.Value = this.myOldAudioCheckSettingsInfo.Overloaddbfs;
            this.txt_ReversDuration.Text = (int.Parse(this.myOldAudioCheckSettingsInfo.ReversDuration.ToString())).ToString();
            this.txt_Reverse.Value = (decimal)this.myOldAudioCheckSettingsInfo.Reverse;
            this.se_LR.Value = this.myOldAudioCheckSettingsInfo.SLevelThreshold_Limit;
            this.se_LRDuration.Value = this.myOldAudioCheckSettingsInfo.NLRLevelTime_Limit;

            this.chk_LR.Checked = this.myOldAudioCheckSettingsInfo.IsCheckSLevelThreshold_Limit;
            this.chk_Mute.Checked = this.myOldAudioCheckSettingsInfo.IsCheckMutedbfs;

            this.chk_OverLoad.Checked = this.myOldAudioCheckSettingsInfo.IsCheckOverloaddbfs;
            this.chk_Reverse.Checked = this.myOldAudioCheckSettingsInfo.IsCheckReverse;
        }

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
            OldAudioCheckSettingsInfo _AudioCheckSettingsInfo = null;
            try
            {
                string xmlfile = Application.StartupPath + @"\AudioCheckParameter.xml";
                if (File.Exists(xmlfile))
                {
                    _AudioCheckSettingsInfo = new OldAudioCheckSettingsInfo();
                    XmlDocument xmlDoc;
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlfile);   //加载xml文件   xmlDoc.SelectSingleNode("AudioCheckParameter").
                    _AudioCheckSettingsInfo.IsCheckMutedbfs = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckMutedbfs").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.Mutedbfs = short.Parse(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Mutedbfs").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.MuteDuration = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("MuteDuration").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.IsCheckReverse = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckReverse").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.Reverse = float.Parse(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Reverse").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.ReversDuration = Convert.ToInt32(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("ReversDuration").Attributes["value"].Value.ToString().Trim());
                    _AudioCheckSettingsInfo.IsCheckOverloaddbfs = xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("IsCheckOverloaddbfs").Attributes["value"].Value.ToString().Trim() == "0" ? false : true;
                    _AudioCheckSettingsInfo.Overloaddbfs = short.Parse(xmlDoc.SelectSingleNode("AudioCheckParameter").SelectSingleNode("Overloaddbfs").Attributes["value"].Value.ToString().Trim());
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

        private void  SetAudioCheckSettingsInfo(AudioCheckSettingsInfo pAudioCheckSettingsInfo)
        {
           
            try
            {
                string xmlfile = Application.StartupPath + @"\AudioCheckParameter.xml";
                if (File.Exists(xmlfile))
                { 
                    XmlDocument xmlDoc;
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlfile);   //加载xml文件   xmlDoc.SelectSingleNode("AudioCheckParameter").
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckMutedbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckMutedbfs == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Mutedbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.Mutedbfs.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//MuteDuration").Attributes["value"].Value = pAudioCheckSettingsInfo.MuteDuration.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckReverse").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckReverse == false ? "0" : "1";

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Reverse").Attributes["value"].Value = pAudioCheckSettingsInfo.Reverse.ToString();
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//ReversDuration").Attributes["value"].Value = pAudioCheckSettingsInfo.ReversDuration.ToString();
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckOverloaddbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckOverloaddbfs == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Overloaddbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.Overloaddbfs.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckSLevelThreshold_Limit").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckSLevelThreshold_Limit == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//SLevelThreshold_Limit").Attributes["value"].Value = pAudioCheckSettingsInfo.SLevelThreshold_Limit.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//NLRLevelTime_Limit").Attributes["value"].Value = pAudioCheckSettingsInfo.NLRLevelTime_Limit.ToString();

                      //this.myAudioCheckSettingsInfo.NLRLevelTime_Limit 
                    xmlDoc.Save(xmlfile);
                  
                }
            }
            catch (Exception ex)
            {
                 

            }
          
        }
        private void SetOldAudioCheckSettingsInfo(OldAudioCheckSettingsInfo pAudioCheckSettingsInfo)
        {

            try
            {
                string xmlfile = Application.StartupPath + @"\AudioCheckParameter.xml";
                if (File.Exists(xmlfile))
                {
                    XmlDocument xmlDoc;
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlfile);   //加载xml文件   xmlDoc.SelectSingleNode("AudioCheckParameter").
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckMutedbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckMutedbfs == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Mutedbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.Mutedbfs.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//MuteDuration").Attributes["value"].Value = pAudioCheckSettingsInfo.MuteDuration.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckReverse").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckReverse == false ? "0" : "1";

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Reverse").Attributes["value"].Value = pAudioCheckSettingsInfo.Reverse.ToString();
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//ReversDuration").Attributes["value"].Value = pAudioCheckSettingsInfo.ReversDuration.ToString();
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckOverloaddbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckOverloaddbfs == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Overloaddbfs").Attributes["value"].Value = pAudioCheckSettingsInfo.Overloaddbfs.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckSLevelThreshold_Limit").Attributes["value"].Value = pAudioCheckSettingsInfo.IsCheckSLevelThreshold_Limit == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//SLevelThreshold_Limit").Attributes["value"].Value = pAudioCheckSettingsInfo.SLevelThreshold_Limit.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//NLRLevelTime_Limit").Attributes["value"].Value = pAudioCheckSettingsInfo.NLRLevelTime_Limit.ToString();

                    //this.myAudioCheckSettingsInfo.NLRLevelTime_Limit 
                    xmlDoc.Save(xmlfile);

                }
            }
            catch (Exception ex)
            {


            }

        }
        private void SetAudioCheckSettingsInfo()
        {

            try
            {
                string xmlfile = Application.StartupPath + @"\AudioCheckParameter.xml";
                if (File.Exists(xmlfile))
                {
                    XmlDocument xmlDoc;
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlfile);   //加载xml文件   xmlDoc.SelectSingleNode("AudioCheckParameter").
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckMutedbfs").Attributes["value"].Value = this.chk_Mute.Checked == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Mutedbfs").Attributes["value"].Value = this.se_Mutedbfs.Value.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//MuteDuration").Attributes["value"].Value = this.se_MuteDuration.Value.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckReverse").Attributes["value"].Value = this.chk_Reverse.Checked == false ? "0" : "1";

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Reverse").Attributes["value"].Value = this.txt_Reverse.Value.ToString();
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//ReversDuration").Attributes["value"].Value = this.txt_ReversDuration.Text.Trim();
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckOverloaddbfs").Attributes["value"].Value = this.chk_OverLoad.Checked == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//Overloaddbfs").Attributes["value"].Value = this.se_Overloaddbfs.Value.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//IsCheckSLevelThreshold_Limit").Attributes["value"].Value = this.chk_LR.Checked == false ? "0" : "1";
                    xmlDoc.SelectSingleNode("//AudioCheckParameter//SLevelThreshold_Limit").Attributes["value"].Value = this.se_LR.Value.ToString();

                    xmlDoc.SelectSingleNode("//AudioCheckParameter//NLRLevelTime_Limit").Attributes["value"].Value = this.se_LRDuration.Value.ToString();

                    //this.myAudioCheckSettingsInfo.NLRLevelTime_Limit 
                    xmlDoc.Save(xmlfile);

                }
            }
            catch (Exception ex)
            {


            }

        }
    }
}