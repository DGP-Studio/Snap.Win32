using System;
using System.Runtime.InteropServices;

namespace Snap.Win32.NativeMethod
{
    public class GDI32
    {
        #region GetDeviceCaps
        public enum DeviceCaps
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }
        [DllImport("gdi32.dll")]
        internal static extern int GetDeviceCaps(IntPtr hdc, DeviceCaps nIndex);
        #endregion
    }
}
