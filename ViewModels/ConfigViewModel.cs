using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;
using System.Windows;
using WpfApp5.Models;
namespace WpfApp5.ViewModels
{
	class ConfigViewModel : ObservableObject
	{
		#region フィールドプロパティ
		/// <summary>
		/// ホスト
		/// </summary>
		public ReactivePropertySlim<string> Host { get; } = new ReactivePropertySlim<string>();

		/// <summary>
		/// ユーザー名
		/// </summary>
        public ReactivePropertySlim<string> User { get; } = new ReactivePropertySlim<string>();

		/// <summary>
		/// データベース
		/// </summary>
        public ReactivePropertySlim<string> Database { get; } = new ReactivePropertySlim<string>();

		/// <summary>
		/// 登録ボタン
		/// </summary>
        public IRelayCommand<Window> CommandUpdate { get; }

		/// <summary>
		/// 終了ボタン
		/// </summary>
		public IRelayCommand<Window> CommandClose { get; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ConfigViewModel()
        {
            var info = new ConnectionInfoModel();

            Host.Value = info.Host;
            User.Value = info.User;
            Database.Value = info.Database;

			CommandUpdate = new RelayCommand<Window>(OnCommandUpdate);
			CommandClose = new RelayCommand<Window>(OnCommandClose);
        }
		#endregion

		#region privateメソッド
		/// <summary>
		/// 更新ボタン
		/// </summary>
		private void OnCommandUpdate(Window window)
		{
			var info = new ConnectionInfoModel(Host.Value, User.Value, Database.Value);
			info.Save();

			window?.Close();
		}

		private void OnCommandClose(Window window)
		{
			window?.Close();
		}
		#endregion
	}
}
