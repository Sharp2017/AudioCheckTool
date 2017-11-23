using System;
using System.Collections.Generic;
using System.Text;

namespace WinAudioCheckTool.Classes
{
   public class OldAudioCheckSettingsInfo
    {
       /// <summary>
       /// 反相检测时长
       /// </summary>
       public int ReversDuration { get; set; }
        
       /// <summary>
       /// 反相检测参数
       /// </summary>
       public float Reverse { get; set; }
       /// <summary>
       /// 是否检测反相
       /// </summary>
       public bool IsCheckReverse { get; set; }
       /// <summary>
       /// 静音参数
       /// </summary>
        public  short Mutedbfs { get; set; }

       /// <summary>
       /// 静音检测时长
       /// </summary>
        public int MuteDuration { get; set; }
       /// <summary>
       /// 是否检测静音
       /// </summary>
        public bool IsCheckMutedbfs { get; set; }

       /// <summary>
       /// 过载检测参数
       /// </summary>
        public short Overloaddbfs { get; set; }
       /// <summary>
       /// 是否检测过载
       /// </summary>
        public bool IsCheckOverloaddbfs { get; set; }
       /// <summary>
       /// 左右声道电平差检测参数
       /// </summary>
        public short SLevelThreshold_Limit { get; set; }

       /// <summary>
        ///左右声道电平差检测时长
       /// </summary>
        public int NLRLevelTime_Limit { get; set; }
       /// <summary>
        /// 是否检测左右声道电平差
       /// </summary> 
        public bool IsCheckSLevelThreshold_Limit { get; set; }
    }
}
