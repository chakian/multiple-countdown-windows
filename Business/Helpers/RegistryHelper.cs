using Microsoft.Win32;
using System.Linq;

namespace Business.Helpers
{
    public class RegistryHelper
    {
        const string MCSubKey = "MULTIPLE_COUNTDOWN";
        public const string MCNode_UserID = "RegisteredAs";

        public static void CreateRegistryKey()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Software", true);
            if (regkey.GetSubKeyNames().Contains(MCSubKey) == false)
            {
                regkey.CreateSubKey(MCSubKey);
            }
        }
        public static void WriteRegistryNode(string nodeName, string value)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Software", true);
            regkey = regkey.OpenSubKey(MCSubKey, true);
            if (regkey == null)
            {
                CreateRegistryKey();
            }
            else
            {
                regkey.SetValue(nodeName, value);
            }
        }
        public static string ReadRegistryNode(string nodeName)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Software", true);
            regkey = regkey.OpenSubKey(MCSubKey, false);
            if(regkey == null)
            {
                CreateRegistryKey();
                return string.Empty;
            }else
            {
                return regkey.GetValue(nodeName, "").ToString();
            }
        }
    }
}
