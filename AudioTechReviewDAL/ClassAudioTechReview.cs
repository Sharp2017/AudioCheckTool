using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Infomedia.XStudio.XstudioDataInfo; 
namespace AudioTechReviewDAL
{
    public class ClassAudioTechReview
    {
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr AudioTechReview_CreateInstance(IntPtr hWnd);

        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr AudioTechReview_DestroyInstance(IntPtr h);

        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr AudioTechReview_StartReview(IntPtr h);

        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr AudioTechReview_StopReview(IntPtr h);

        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern IntPtr AudioTechReview_SetFileName(IntPtr h, byte[] pszFileName);

        //设置技审报告信息
        //pszReviewName: 技审人姓名
        //pszReviewTime: 技审时间
        //pszReviewPath: 技审文件路径
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetReportInfo(IntPtr h, byte[] pszReviewName, byte[] pszReviewTime, byte[] pszReviewPath, int nLanguage);

        //设置技审报告类型
        //nReportType:0:仅生成xml 1:仅生成txt 2：xml和txt同时生成
        //生成文件路径根据AudioTechReview_SetReportInfo 的pszReviewPath路径产生.xml和.txt后缀。
        //如果设置后缀为txt或者xml，则取文件名，根据类型加上后缀
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetReportType(IntPtr h, int nReportType);


        //获取处理进度.返回值小于100时表示正在处理过程中
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern uint AudioTechReview_GetProgress(IntPtr h);


        //获取当前检测是否出现极限报警
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern bool AudioTechReview_GetOverLimit(IntPtr h);


        //低电平告警参数设置
        //nDurationTime:低电平持续时间(秒)
        //nLevelThreshold：低电平阈值(dBFS)
        //fPercent:低电平占整个持续时间的比例阈值(0.0<fPercent<=1.0)
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetLowLevelParam(IntPtr h, uint nDurationTime, int nLevelThreshold, float fPercent);

        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetLowLevelParam_Limit(IntPtr h, uint nDurationTime, int nLevelThreshold, float fPercent);

        //最大允许电平设置
        //nDurationTime:低电平持续时间(秒)
        //nLevelThreshold：低电平阈值(dBFS)
        //fPercent:低电平占整个持续时间的比例阈值(0.0<fPercent<=1.0)
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetMaxLevelParam(IntPtr h, uint nDurationTime, int nLevelThreshold, float fPercent);
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetMaxLevelParam_Limit(IntPtr h, uint DurationTime, int nLevelThreshold, float fPercent);



        //反相参数设置
        //nDurationTime:低电平持续时间(秒)
        //fThreshold：反相阈值(dBFS)
        //fPercent:低电平占整个持续时间的比例阈值(0.0<fPercent<=1.0)
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetAntiphaseParam(IntPtr h, uint nDurationTime, float fThreshold, float fPercent);
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetAntiphaseParam_Limit(IntPtr h, uint nDurationTime, float fThreshold, float fPercent);

        //左右声道电平差参数设置
        //nDurationTime:低电平持续时间(秒)
        //nLevelThreshold：低电平阈值(dBFS)
        //fPercent:低电平占整个持续时间的比例阈值(0.0<fPercent<=1.0)
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetLRLevelDiffParam(IntPtr h, uint nDurationTime, int nLevelThreshold, float fPercent);
        [DllImport("AudioCheckDLL\\AudioTechReview.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void AudioTechReview_SetLRLevelDiffParam_Limit(IntPtr h, uint nDurationTime, int nLevelThreshold, float fPercent);


        static IntPtr h = IntPtr.Zero;

        public static void StartAudioCheck(AudioCheckSettingsInfo info, string audioFile)
        {
            h = AudioTechReview_CreateInstance(IntPtr.Zero);
            AudioTechReview_SetFileName(h, (new UnicodeEncoding()).GetBytes(audioFile));
            AudioTechReview_SetReportInfo(h, (new UnicodeEncoding()).GetBytes(info.UserName), (new UnicodeEncoding()).GetBytes(DateTime.Now.ToString()), (new UnicodeEncoding()).GetBytes(audioFile + ".txt"), 0);
            AudioTechReview_SetReportType(h, 1);
            if (info.IsCheckMutedbfs)
            {
                //AudioTechReview_SetLowLevelParam(h,  uint.Parse((info.MuteDuration * 1000).ToString()), info.Mutedbfs, 0.9f);
                AudioTechReview_SetLowLevelParam_Limit(h, uint.Parse((info.MuteDuration * 1000).ToString()), info.Mutedbfs, 1.0f);
            }
            if (info.IsCheckOverloaddbfs)
            {
                //AudioTechReview_SetMaxLevelParam(h, uint.Parse("1000"), info.Overloaddbfs, 0.9f);
                AudioTechReview_SetMaxLevelParam_Limit(h, uint.Parse("1000"), info.Overloaddbfs, 1.0f);
            }

            if (info.IsCheckReverse)
            {
                //AudioTechReview_SetAntiphaseParam(h, uint.Parse((info.ReversDuration * 1000).ToString()), (float)info.Reverse, 0.9f);
                AudioTechReview_SetAntiphaseParam_Limit(h, uint.Parse((info.ReversDuration * 1000).ToString()), (float)info.Reverse, 1.0f);
            }

            if (info.IsCheckSLevelThreshold_Limit)
            {
                //AudioTechReview_SetLRLevelDiffParam(h, uint.Parse((info.NLRLevelTime_Limit * 1000).ToString()), info.SLevelThreshold_Limit, 1);
                AudioTechReview_SetLRLevelDiffParam_Limit(h, uint.Parse((info.NLRLevelTime_Limit * 1000).ToString()), info.SLevelThreshold_Limit, 1);
            }

            AudioTechReview_StartReview(h);
        }
        public static void StartAudioCheckEx(AudioCheckSettingsInfo info, string audioFile, int  ReportType)
        {
            h = AudioTechReview_CreateInstance(IntPtr.Zero);
            AudioTechReview_SetFileName(h, (new UnicodeEncoding()).GetBytes(audioFile));
            if (ReportType == 0)
            {
                AudioTechReview_SetReportInfo(h, (new UnicodeEncoding()).GetBytes(info.UserName), (new UnicodeEncoding()).GetBytes(DateTime.Now.ToString()), (new UnicodeEncoding()).GetBytes(audioFile + ".xml"), 0);
            }
            else  
            {
                AudioTechReview_SetReportInfo(h, (new UnicodeEncoding()).GetBytes(info.UserName), (new UnicodeEncoding()).GetBytes(DateTime.Now.ToString()), (new UnicodeEncoding()).GetBytes(audioFile + ".txt"), 0);
            } 
            AudioTechReview_SetReportType(h, ReportType);
            if (info.IsCheckMutedbfs)
            {
                //AudioTechReview_SetLowLevelParam(h,  uint.Parse((info.MuteDuration * 1000).ToString()), info.Mutedbfs, 0.9f);
                AudioTechReview_SetLowLevelParam_Limit(h, uint.Parse((info.MuteDuration * 1000).ToString()), info.Mutedbfs, 1.0f);
            }
            if (info.IsCheckOverloaddbfs)
            {
                //AudioTechReview_SetMaxLevelParam(h, uint.Parse("1000"), info.Overloaddbfs, 0.9f);
                AudioTechReview_SetMaxLevelParam_Limit(h, uint.Parse("1000"), info.Overloaddbfs, 1.0f);
            }

            if (info.IsCheckReverse)
            {
                //AudioTechReview_SetAntiphaseParam(h, uint.Parse((info.ReversDuration * 1000).ToString()), (float)info.Reverse, 0.9f);
                AudioTechReview_SetAntiphaseParam_Limit(h, uint.Parse((info.ReversDuration * 1000).ToString()), (float)info.Reverse, 1.0f);
            }

            if (info.IsCheckSLevelThreshold_Limit)
            {
                //AudioTechReview_SetLRLevelDiffParam(h, uint.Parse((info.NLRLevelTime_Limit * 1000).ToString()), info.SLevelThreshold_Limit, 1);
                AudioTechReview_SetLRLevelDiffParam_Limit(h, uint.Parse((info.NLRLevelTime_Limit * 1000).ToString()), info.SLevelThreshold_Limit, 1);
            }

            AudioTechReview_StartReview(h);
        }

        public static void StartAudioCheck(AudioCheckSettingsInfo info, string audioFile, float Antiphase_fPercent)
        {
            h = AudioTechReview_CreateInstance(IntPtr.Zero);
            AudioTechReview_SetFileName(h, (new UnicodeEncoding()).GetBytes(audioFile));
            AudioTechReview_SetReportInfo(h, (new UnicodeEncoding()).GetBytes(info.UserName), (new UnicodeEncoding()).GetBytes(DateTime.Now.ToString()), (new UnicodeEncoding()).GetBytes(audioFile + ".txt"), 0);
            AudioTechReview_SetReportType(h, 1);
            if (info.IsCheckMutedbfs)
            {
                //AudioTechReview_SetLowLevelParam(h,  uint.Parse((info.MuteDuration * 1000).ToString()), info.Mutedbfs, 0.9f);
                AudioTechReview_SetLowLevelParam_Limit(h, uint.Parse((info.MuteDuration * 1000).ToString()), info.Mutedbfs, 1.0f);
            }
            if (info.IsCheckOverloaddbfs)
            {
                //AudioTechReview_SetMaxLevelParam(h, uint.Parse("1000"), info.Overloaddbfs, 0.9f);
                AudioTechReview_SetMaxLevelParam_Limit(h, uint.Parse("1000"), info.Overloaddbfs, 1.0f);
            }

            if (info.IsCheckReverse)
            {
                //AudioTechReview_SetAntiphaseParam(h, uint.Parse((info.ReversDuration * 1000).ToString()), (float)info.Reverse, 0.9f);
                AudioTechReview_SetAntiphaseParam_Limit(h, uint.Parse((info.ReversDuration * 1000).ToString()), (float)info.Reverse, Antiphase_fPercent);
            }

            if (info.IsCheckSLevelThreshold_Limit)
            {
                //AudioTechReview_SetLRLevelDiffParam(h, uint.Parse((info.NLRLevelTime_Limit * 1000).ToString()), info.SLevelThreshold_Limit, 1);
                AudioTechReview_SetLRLevelDiffParam_Limit(h, uint.Parse((info.NLRLevelTime_Limit * 1000).ToString()), info.SLevelThreshold_Limit, 1);
            }

            AudioTechReview_StartReview(h);
        }

        public static int GetProgress()
        {
            int res = (int)AudioTechReview_GetProgress(h);
            return res;
        }

        public static bool GetAudioCheckStatus()
        {
            return AudioTechReview_GetOverLimit(h);
        }

        public static void DestroyInstance()
        {
            AudioTechReview_DestroyInstance(h);
        }

        public static void StopAudioCheck()
        {
            AudioTechReview_StopReview(h);
        }
    }
}
