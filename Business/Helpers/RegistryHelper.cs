using Microsoft.Win32;

namespace Business.Helpers
{
    public class RegistryHelper
    {
        public void CreateRegistryKey()
        {
            RegistryKey regkey;
            regkey = Registry.CurrentUser.OpenSubKey("Software", true);
            regkey.CreateSubKey("MULTIPLE_COUNTDOWN");
        }
    }
}
