using System;
using System.Runtime.InteropServices;
using wkmvc.Data;

namespace wkmvc
{
    /// <summary>
    /// Describe：平台检测
    /// Author：YuanGang
    /// Date：2016/08/17
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    internal class Platform
    {
        private const int PRODUCT_NANO_SERVER = 0x0000006D;
        private const int PRODUCT_DATACENTER_NANO_SERVER = 0x0000008F;
        private const int PRODUCT_STANDARD_NANO_SERVER = 0x00000090;

        [DllImport("api-ms-win-core-sysinfo-l1-2-1.dll", SetLastError = false)]
        private static extern bool GetProductInfo(
              int dwOSMajorVersion,
              int dwOSMinorVersion,
              int dwSpMajorVersion,
              int dwSpMinorVersion,
              out int pdwReturnedProductType);

        private bool? _isNano;
        private bool? _isMono;
        private bool? _isWindows;

        public bool IsRunningOnWindows
        {
            get
            {
                if (_isWindows == null)
                {
                    _isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                }

                return _isWindows.Value;
            }
        }

        public bool IsRunningOnMono
        {
            get
            {
                if (_isMono == null)
                {
                    _isMono = Type.GetType("Mono.Runtime") != null;
                }

                return _isMono.Value;
            }
        }

        public bool IsRunningOnNanoServer
        {
            get
            {
                if (_isNano == null)
                {
                    var osVersion = new Version(RtlGetVersion() ?? string.Empty);

                    try
                    {
                        int productType;
                        if (GetProductInfo(osVersion.Major, osVersion.Minor, 0, 0, out productType))
                        {
                            _isNano = productType == PRODUCT_NANO_SERVER ||
                                productType == PRODUCT_DATACENTER_NANO_SERVER ||
                                productType == PRODUCT_STANDARD_NANO_SERVER;
                        }
                        else
                        {
                            _isNano = false;
                        }
                    }
                    catch
                    {
                        // 如果API调用失败，这些API的设置是不存在的，这意味着不能在Nano上运行
                        _isNano = false;
                    }
                }

                return _isNano.Value;
            }
        }

        public bool UseInMemoryStore
        {
            get
            {
                return !IsRunningOnWindows || IsRunningOnMono || IsRunningOnNanoServer;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RTL_OSVERSIONINFOEX
        {
            internal uint dwOSVersionInfoSize;
            internal uint dwMajorVersion;
            internal uint dwMinorVersion;
            internal uint dwBuildNumber;
            internal uint dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string szCSDVersion;
        }

        [DllImport("ntdll")]
        private static extern int RtlGetVersion(out RTL_OSVERSIONINFOEX lpVersionInformation);

        internal static string RtlGetVersion()
        {
            RTL_OSVERSIONINFOEX osvi = new RTL_OSVERSIONINFOEX();
            osvi.dwOSVersionInfoSize = (uint)Marshal.SizeOf(osvi);
            if (RtlGetVersion(out osvi) == 0)
            {
                return $"{osvi.dwMajorVersion}.{osvi.dwMinorVersion}.{osvi.dwBuildNumber}";
            }
            else
            {
                return null;
            }
        }
    }

    internal class DataBaseProvider
    {
        private string dataBaserProvider = new Services.ConfigServices.AppConfigurtaionServices().GetAppSettings<ApplicationConfiguration>("siteconfig").DataBase;

        public bool _isSqlServer()
        {
            return dataBaserProvider == "MSSQL";
        }

        public bool _isMySql()
        {
            return dataBaserProvider == "MYSQL";
        }

        public bool _isOracle()
        {
            return dataBaserProvider == "ORALCE";
        }

    }

    internal class CacheProvider
    {
        private ApplicationConfiguration cacheProvider = new Services.ConfigServices.AppConfigurtaionServices().GetAppSettings<ApplicationConfiguration>("siteconfig");

        public bool _isUseRedis()
        {
            return cacheProvider.UseRedis;
        }

        public string _connectionString()
        {
            return cacheProvider.Redis_ConnectionString;
        }

        public string _instanceName()
        {
            return cacheProvider.Redis_InstanceName;
        }

    }
}
