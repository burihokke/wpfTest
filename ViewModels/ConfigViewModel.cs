using CommunityToolkit.Mvvm.ComponentModel;
using Reactive.Bindings;
using WpfApp5.Models;
namespace WpfApp5.ViewModels
{
	class ConfigViewModel : ObservableObject
	{
        public ReactivePropertySlim<string> Host { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> User { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> Database { get; } = new ReactivePropertySlim<string>();

        public ConfigViewModel()
        {
            var info = new ConnectionInfoModel();

            Host.Value = info.Host;
            User.Value = info.User;
            Database.Value = info.Database;
        }
    }
}
