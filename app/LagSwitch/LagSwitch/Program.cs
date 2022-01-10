using LagSwitch.States;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LagSwitch
{
    static class Program
    {
        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddSingleton<LagService>()
                .AddSingleton<SettingsDataLayer>()
                .AddSingleton<HotkeyService>()
                .AddScoped<MainForm>()
                .AddScoped<AlwaysOnTop>();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}
