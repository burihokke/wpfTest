﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp5.ViewModels.window;

namespace WpfApp5.ViewModels
{
	partial class NewViewModel : ObservableObject, IDisposable
	{
		#region フィールドプロパティ
		/// <summary>
		/// 機能：Excel作成
		/// </summary>
		public ExcelServiceModel ExcelService { get; }

		/// <summary>
		/// 機能：エラーをわざと起こす
		/// </summary>
		public ErrorServiceModel ErrorService { get; }

		/// <summary>
		/// 
		/// </summary>
		private readonly CompositeDisposable disposable = new CompositeDisposable();

		private readonly IWindowService _windowService;

		/// <summary>
		/// コマンド：テスト
		/// </summary>
		public IRelayCommand CommandTest { get; }

		public IRelayCommand CommandClose { get; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public NewViewModel(IWindowService windowService)
		{
			_windowService = windowService;

			ExcelService = new ExcelServiceModel("Excel作成");
			ErrorService = new ErrorServiceModel("エラーをわざと起こす風");

			CommandTest = new RelayCommand(OnCommandTest);
			CommandClose = new RelayCommand(OnCommandClose);
		}
		#endregion

		#region privateメソッド
		/// <summary>
		/// コマンド：テスト
		/// </summary>
		private void OnCommandTest()
		{
			ExcelService.Execute();
			ErrorService.Execute();
		}

		private void OnCommandClose()
		{
			_windowService.CloseWindow();
		}
		#endregion

		public void Dispose() => disposable.Dispose();
	}
}
