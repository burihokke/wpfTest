using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Models
{
	internal class ConnectionInfoModel
	{
		public string Host { get; }
		public string User { get; }
		public string Database { get; }

		public ConnectionInfoModel()
		{
			Host = GetApp("host");
			User = GetApp("user");
			Database = GetApp("database");
		}

		private string GetApp(string key)
		{
			string? value = ConfigurationManager.AppSettings[key];
			if (value == null) return "";
			else return value.ToString();
		}

		public string ConnectionInfo()
		{
			return $"Host={Host};Username={User};Database={Database}";
		}
	}
}
