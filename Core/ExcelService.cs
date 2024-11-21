using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Core
{
	internal class ExcelService : IDisposable
	{
		private XLWorkbook _workbook;
		private IXLWorksheet _currentSheet;

		/// <summary>
		/// Excel作成
		/// </summary>
		public void CreateExcel()
		{
			_workbook?.Dispose();
			_workbook = new XLWorkbook();
			_currentSheet = null;
		}

		/// <summary>
		/// シートを追加
		/// </summary>
		/// <param name="sheetName">シート名</param>
		public void AddSheet(string sheetName)
		{
			_currentSheet = _workbook.Worksheets.Add(sheetName);
		}

		/// <summary>
		/// アクティブのシート変更
		/// </summary>
		/// <param name="sheetName">シート名</param>
		public void SetActivateSheet(string sheetName)
		{
			_currentSheet = _workbook.Worksheet(sheetName);
		}

		/// <summary>
		/// セルに値をセット
		/// </summary>
		/// <param name="cellAddress">セルアドレス(ex.A1)</param>
		/// <param name="value">値</param>
		public void SetCellValue(string cellAddress, object value)
		{
			CheckCurrentSheet();
			SetCellValue(_currentSheet.Cell(cellAddress), value);
		}

		/// <summary>
		/// セルに値をセット
		/// </summary>
		/// <param name="row">行</param>
		/// <param name="column">列</param>
		/// <param name="value">値</param>
		public void SetCellValue(int row,  int column, object value)
		{
			CheckCurrentSheet();
			SetCellValue(_currentSheet.Cell(row, column), value);
		}

		/// <summary>
		/// セルの背景色をセットする
		/// </summary>
		/// <param name="row">行</param>
		/// <param name="column">列</param>
		/// <param name="color">色</param>
		public void SetCellBackColor(int row, int column, XLColor color)
		{
			CheckCurrentSheet();
			_currentSheet.Cell(row, column).Style.Fill.SetBackgroundColor(color);
		}

		public void DefuineAutoFilter()
		{
			var range = _currentSheet.Range(1, 1, _currentSheet.LastRowUsed().RowNumber(), _currentSheet.LastColumnUsed().ColumnNumber());
		}

		/// <summary>
		/// セルの値を取得する
		/// </summary>
		/// <param name="cellAddress">セルアドレス(A1)</param>
		/// <returns>セルの値</returns>
		public string GetCellValu(string cellAddress)
		{
			return _currentSheet.Cell(cellAddress).Value.ToString().Trim();
		}

		/// <summary>
		/// ファイルを保存
		/// </summary>
		/// <param name="filePath">保存するファイルのパス</param>
		public void SaveFile(string filePath)
		{
			_workbook.SaveAs(filePath);
		}

		public void Close()
		{
			Dispose();
		}


		private void SetCellValue(IXLCell cell, object value)
		{
			switch (value)
			{
				case string str:
					cell.Value = str;
					break;
				case int intVal:
					cell.Value = intVal;
					break;
				case double doubleVal:
					cell.Value = doubleVal;
					break;
				case DateTime dateVal:
					cell.Value = dateVal;
					break;
				case bool boolVal:
					cell.Value = boolVal;
					break;
				default:
					cell.Value = value?.ToString() ?? string.Empty;
					break;
			}
		}

		private void CheckCurrentSheet()
		{
			if (_currentSheet == null)
				throw new InvalidOperationException("現在のシートが設定されていません。");
		}

		public void Dispose()
		{
			_workbook?.Dispose();
			_workbook = null;
		}
	}
}
