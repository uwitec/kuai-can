using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KC.App.Core
{
    public class WinAPI
    {
        #region kernel32
        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="lpAppName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpString"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileString(string lpAppName,  // pointer to section name
     string lpKeyName,  // pointer to key name
     string lpString,   // pointer to string to add
     string lpFileName  // pointer to initialization filename
   );
        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="lpAppName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string lpAppName,        // points to section name
   string lpKeyName,        // points to key name
   string lpDefault,        // points to default string
   StringBuilder lpReturnedString,  // points to destination buffer
   int nSize,              // size of destination buffer
   string lpFileName        // points to initialization filename
 );
        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="lpAppName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="nDefault"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileInt(string lpAppName,  // address of section name
          string lpKeyName,  // address of key name
          int nDefault,       // return value if key name is not found
          string lpFileName  // address of initialization filename
        );


        #endregion

        #region winmm
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);

        public struct SNDINFO
        {
            /// <summary>
            /// 文件名
            /// </summary>
            public const int SND_FILENAME = 0x00020000;
            /// <summary>
            /// 异步播放
            /// </summary>
            public const int SND_SYNC = 0x0000;
            /// <summary>
            /// 同步播放
            /// </summary>
            public const int SND_ASYNC = 0x0001;
            /// <summary>
            /// 循环播放
            /// </summary>
            public const int SND_LOOP = 0x0008;
        }
        #endregion
    }
}
