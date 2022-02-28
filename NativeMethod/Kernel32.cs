using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Snap.Win32.NativeMethod
{
    public class Kernel32
    {
        #region GlobalMemoryStatus
        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryStatusEx
        {
            public uint dwLength; //当前结构体大小
            public uint dwMemoryLoad; //当前内存使用率
            public ulong ullTotalPhys; //总计物理内存大小
            public ulong ullAvailPhys; //可用物理内存大小
            public ulong ullTotalPageFile; //总计交换文件大小
            public ulong ullAvailPageFile; //总计交换文件大小
            public ulong ullTotalVirtual; //总计虚拟内存大小
            public ulong ullAvailVirtual; //可用虚拟内存大小
            public ulong ullAvailExtendedVirtual; //保留 这个值始终为0
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="meminfo"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MemoryStatusEx meminfo);
        #endregion

        #region LoadLibrary
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr LoadLibrary(string libFilename);
        #endregion

        #region FreeLibrary
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool FreeLibrary(IntPtr hModule);
        #endregion

        // this methods are taken from https://raw.githubusercontent.com/Microsoft/referencesource/9da503f9ef21e8d1f2905c78d4e3e5cbb3d6f85a/mscorlib/microsoft/win32/win32native.cs
        // Note - do NOT use this to call methods.  Use P/Invoke, which will
        // do much better things w.r.t. marshaling, pinning memory, security 
        // stuff, better interactions with thread aborts, etc.  This is used
        // solely by DoesWin32MethodExist for avoiding try/catch EntryPointNotFoundException
        // in scenarios where an OS Version check is insufficient
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);
    }
}
