using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace OpensAsItWasClosed
{
    class ini
    {
        //INI file ********
        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW",
            SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int WritePrivateProfileString
            (
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFilename
            );
        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW",
            SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString
            (
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            string lpReturnString,
            int nSize,
            string lpFilename
            );

        /* code *************************************** */
        public void setIniValue(string iniFile, string category, string key, string value)
        {
            WritePrivateProfileString(category, key, value, iniFile);
        }
        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <param name="iniFile">The ini file.</param>
        /// <param name="category">The category.</param>
        public string getIniValue(string iniFile, string category, string key, string defaultValue)
        {
            string returnString = new string(' ', 65536);
            GetPrivateProfileString(category, key, defaultValue, returnString, 65536, iniFile);
            return returnString.Split('\0')[0];
        }/// 
        /* ****************************************** */
    }//class ini
}//namespace OpensAsItWasClosed
