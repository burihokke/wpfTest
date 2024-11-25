using System.Configuration;

namespace WpfApp5.Models
{
	internal class ConnectionInfoModel
	{
		#region フィールドプロパティ
		/// <summary>
		/// ホスト
		/// </summary>
		public string Host { get; }

		/// <summary>
		/// ユーザー名
		/// </summary>
		public string User { get; }

		/// <summary>
		/// データベース
		/// </summary>
		public string Database { get; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ConnectionInfoModel()
		{
			Host = GetAppCofing("host");
			User = GetAppCofing("user");
			Database = GetAppCofing("database");
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="host">ホスト</param>
		/// <param name="user">ユーザー名</param>
		/// <param name="database">データベース</param>
		public ConnectionInfoModel(string host, string user, string database)
		{
			Host = host;
			User = user;
			Database = database;
		}
		#endregion

		#region publicメソッド
		/// <summary>
		/// 接続情報を取得する
		/// </summary>
		/// <returns>接続情報</returns>
		public string ConnectionInfo()
		{
			return $"Host={Host};Username={User};Database={Database}";
		}

		/// <summary>
		/// アプリ設定を保存
		/// </summary>
		public void Save()
		{
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			SetAppConfig(config, "host", Host);
			SetAppConfig(config, "user", User);
			SetAppConfig(config, "database", Database);
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
		}
		#endregion

		#region privateメソッド
		/// <summary>
		/// アプリ設定を取得
		/// </summary>
		/// <param name="key">キー</param>
		/// <returns>値</returns>
		private string GetAppCofing(string key)
		{
			string? value = ConfigurationManager.AppSettings[key];
			if (value == null) return "";
			else return value.ToString();
		}

		/// <summary>
		/// アプリ設定をセット
		/// </summary>
		/// <param name="config">設定</param>
		/// <param name="key">キー</param>
		/// <param name="value">値</param>
		private void SetAppConfig(Configuration config, string key, string value)
		{
			config.AppSettings.Settings[key].Value = value;
		}
		#endregion
	}
}
