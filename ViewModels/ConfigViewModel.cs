using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;
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
        public IRelayCommand CommandUpdate { get; }
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

			CommandUpdate = new RelayCommand(OnCommandUpdate);
        }
		#endregion

		#region privateメソッド
		/// <summary>
		/// 更新ボタン
		/// </summary>
		private void OnCommandUpdate()
		{
			var info = new ConnectionInfoModel(Host.Value, User.Value, Database.Value);
			info.Save();
		}
		#endregion
	}
}
