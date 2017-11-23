using System;
using System.Collections.Generic;
using System.Text;

namespace WinAudioCheckTool.Classes
{
    public class AudioCheckInfo
    {
        private string id;

        /// <summary>
        /// 音频ID
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string audioFileName;
        /// <summary>
        /// 音频名称
        /// </summary>
        public string AudioFileName
        {
            get { return audioFileName; }
            set { audioFileName = value; }
        }

        private string audioFilePath;
        /// <summary>
        /// 音频文件路径
        /// </summary>
        public string AudioFilePath
        {
            get { return audioFilePath; }
            set { audioFilePath = value; }
        }

        private int audioCheckState;
        /// <summary>
        /// 质检状态 0：未开始，1：通过 -1：不通过
        /// </summary>
        public int AudioCheckState
        {
            get { return audioCheckState; }
            set { audioCheckState = value; }
        }
        private int lowLevelAlarmCnt;
        /// <summary>
        /// 静音报警数
        /// </summary>
        public int LowLevelAlarmCnt
        {
            get { return lowLevelAlarmCnt; }
            set { lowLevelAlarmCnt = value; }
        }

        private int maxLevelAlarmCnt;
        /// <summary>
        /// 过载报警数
        /// </summary>
        public int MaxLevelAlarmCnt
        {
            get { return maxLevelAlarmCnt; }
            set { maxLevelAlarmCnt = value; }
        }

        private int antiphaseAlarmCnt;
        /// <summary>
        /// 反相报警数
        /// </summary>
        public int AntiphaseAlarmCnt
        {
            get { return antiphaseAlarmCnt; }
            set { antiphaseAlarmCnt = value; }
        }

        private int lRLevelDiffAlarmCnt;
        /// <summary>
        /// 左右电平差报警数
        /// </summary>
        public int LRLevelDiffAlarmCnt
        {
            get { return lRLevelDiffAlarmCnt; }
            set { lRLevelDiffAlarmCnt = value; }
        } 
          
    }
}
