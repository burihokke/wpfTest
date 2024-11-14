using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp5.ViewModels;
using WpfApp5.ViewModels.window;
using WpfApp5.Views;

namespace WpfApp5
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public IServiceProvider ServiceProvider { get; set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			var services = new ServiceCollection();
			services.AddSingleton<IWindowService, WindowService>();
			services.AddTransient<NewViewModel>();

			ServiceProvider = services.BuildServiceProvider();

			var mainWindow = new MainWindow
			{
				DataContext = ServiceProvider.GetRequiredService<NewViewModel>()
			};
			mainWindow.Show();

			base.OnStartup(e);
		}
	}

}
