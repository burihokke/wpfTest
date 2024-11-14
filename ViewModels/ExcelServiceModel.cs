using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using WpfApp5.Core;

namespace WpfApp5.ViewModels
{
    class ExcelServiceModel : BaseServiceModel
	{
		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="serviceName">機能名</param>
		public ExcelServiceModel(string serviceName) : base(serviceName) { }
		#endregion

		#region publicメソッド
		/// <summary>
		/// 実行
		/// </summary>
		public void Execute()
        {
            this.Result.Value = "終わった";
            this.StatusImage.Value = ChangeStatus(Statuses.Processing);

			var excel = new ExcelService();
			excel.CreateExcel();
			excel.AddSheet("hoge");
			excel.SetCellValue("A1", 2);
			excel.SetCellValue(1, 2, "you");
        }
		#endregion
	}
}
