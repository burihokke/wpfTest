using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;
using WpfApp5.Models;
namespace WpfApp5.ViewModels
{
	class ConfigViewModel : ObservableObject
	{
		#region フィールドプロパティ
		public ReactivePropertySlim<string> Host { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> User { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> Database { get; } = new ReactivePropertySlim<string>();

        public IRelayCommand CommandUpdate { get; }
		#endregion

		#region コンストラクタ
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
		private void OnCommandUpdate()
		{
			var info = new ConnectionInfoModel(Host.Value, User.Value, Database.Value);
			info.Save();
		}
		#endregion
	}
}
