using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Standard.Tool.Platform.Common.Helper;
using Standard.Tool.Platform.Extension;
using Standard.Tool.Platform.Pages.Account;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Standard.Tool.Platform.Data.Infrastructure;
using Standard.Tool.Platform.Auth;
using Standard.Tool.Platform.PostgreSql;
using Standard.Tool.Platform.Data.Infrastructure.Services;
using MediatR;
using Standard.Tool.Platform.CommonPage;

namespace Standard.Tool.Platform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string _connStr;
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var hostbuilder = CreateHostBuilder(e.Args);
            var host = await hostbuilder.StartAsync();
            ProviderFactory.ServiceProvider = host.Services;
            await host.InitStartUp();
            host.Services.GetRequiredService<LoginPage>()?.Show();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            AppDomain.CurrentDomain.Load("Standard.Tool.Platform.Materials");
            AppDomain.CurrentDomain.Load("Standard.Tool.Platform.Menus");
            AppDomain.CurrentDomain.Load("Standard.Tool.Platform.Data");

            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).Add(new JsonConfigurationSource { Path = $"appsettings.json", Optional = false, ReloadOnChange = true }).Build();
            var connStr = configuration.GetConnectionString("Standard.Tool.Platform.Database");

            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices((ctx, services) =>
            {
                services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
                services.AddTransient<IReadTableService, ReadTableService>();
                services.AddSingleton(new TableDataHelper(AppDomain.CurrentDomain.BaseDirectory));
                services.AddPostgreSqlStorage(connStr);

                services.AddSingleton<MainWindow>();
                services.AddSingleton<AccountPage>();
                services.AddSingleton<LoginPage>();



                services.AddTransient<Account>();



                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            });

            return hostBuilder;
        }
    }
}
