using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp5.ViewModels.window
{
	internal class WindowService : IWindowService
	{
		public void CloseWindow()
		{
			Application.Current.Windows[0]?.Close();
		}
	}
}
