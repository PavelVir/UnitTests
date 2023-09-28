
using System;
using Microsoft.Extensions.Configuration;
using System.Dynamic;

using A2v10.Data.Interfaces;
using A2v10.Infrastructure;

namespace Server_side.Configuration
{
    public class TestApplicationHost : IApplicationHost, IDataConfiguration
    {
        private readonly IConfiguration _configuration;
        readonly IProfiler _profiler;
        private readonly IServiceLocator _locator;
        public TestApplicationHost(IProfiler profiler, IServiceLocator locator, IConfiguration configuration)
        {
            _profiler = profiler;
            _locator = locator;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }

        public IServiceLocator Locator => _locator;

        public String ConnectionString(String source)
        {
            if (String.IsNullOrEmpty(source))
                source = "Default";
            var cnnStr = _configuration.GetConnectionString(source);
            if (cnnStr == null)
                throw new Exception($"Connection string '{source}' not found");
            return cnnStr;
        }

        public IProfiler Profiler => _profiler;

        public Boolean Mobile => false;
        public Boolean Embedded => false;
        public Boolean IsAdminMode => false;


        public String AppPath => _configuration.GetSection("appPath").Value;

        public String AppKey =>
                _configuration.GetSection("appKey").Value ?? String.Empty;

        IApplicationReader _appReader;

        public void SetAdmin(bool bAdmin)
        {
        }

        public void StartApplication(Boolean bAdmin)
        {
            _appReader = new FileApplicationReader(AppPath, AppKey);
        }

        public IApplicationReader ApplicationReader => _appReader;

        public String AppDescription => _configuration.GetSection("appDescription").Value;
        public String AppHost => _configuration.GetSection("appHost").Value;
        public String UserAppHost => _configuration.GetSection("userAppHost").Value;

        public String SupportEmail => _configuration.GetSection("supportEmail").Value;
        public String SmtpConfig => _configuration.GetSection("mailSettings").Value;
        public String CustomLayout => _configuration.GetSection("layout").Value;

        public String HostingPath { get; set; }

        public ITheme Theme => null;
        public String HelpUrl => null;

        public Boolean IsMultiTenant => false;
        public Boolean IsMultiCompany => false;
        public Boolean IsUsePeriodAndCompanies => false;
        public Boolean IsRegistrationEnabled => false;
        public Boolean IsDebugConfiguration => true;
        public Boolean IsProductionEnvironment => false;
        public Boolean IsDTCEnabled => false;
        public Boolean IsAdminAppPresent => false;
        public String CustomUserMenu => null;

        public Int32? TenantId { get; set; }
        public Int64? UserId { get; set; }
        public String UserSegment { get; set; }
        public String UserName { get; set; }
        public String CatalogDataSource => null;
        public String TenantDataSource => null;

        public String UseClaims => _configuration.GetSection("useClaims").Value;
        public String CustomSecuritySchema => _configuration.GetSection(AppHostKeys.customSecuritySchema).Value;
        public String ActualSecuritySchema => CustomSecuritySchema ?? "a2security";

        public String ScriptEngine => "ChakraCore";

        public String MakeRelativePath(String path, String fileName)
        {
            throw new NotImplementedException(nameof(MakeRelativePath));
        }


#pragma warning disable CA1065
        public String AppVersion => throw new NotSupportedException();
        public String AppBuild => throw new NotSupportedException();
        public String Copyright => throw new NotSupportedException();
#pragma warning restore CA1065

        public String GetAppSettings(String source)
        {
            return source;
        }

        public ExpandoObject GetEnvironmentObject(String key)
        {
            throw new NotImplementedException(nameof(GetEnvironmentObject));
        }

        public ExpandoObject GetAppSettingsObject(String key)
        {
            throw new NotImplementedException(nameof(GetEnvironmentObject));
        }

        public void CheckIsMobile(String host)
        {
        }
    }
}
