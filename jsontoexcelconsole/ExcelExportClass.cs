using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using PriceGet;

namespace ExcelExport
{
    class ExcelExportClass
    {
        public void ExcelOutputEx(List<string> appnamefree, List<string> appurlfree, List<string> appnamepaid,List<string> appurlpaid,
            List<string>appnamets, List<string>appurlts, List<string> appprice)
        {
            //Excelオブジェクトの初期化
            Excel.Application ExcelApp = null;
            Excel.Workbooks wbs = null;
            Excel.Workbook wb = null;
            Excel.Sheets shs = null;
            Excel.Worksheet ws = null;

            // 有料アプリの値段の取得
            AppPriceGet priceGet = new AppPriceGet();

            try
            {
                // Excelのインスタンスを作る
                ExcelApp = new Excel.Application();
                wbs = ExcelApp.Workbooks;
                wb = wbs.Add();

                shs = wb.Sheets;
                ws = shs[1];
                ws.Select(Type.Missing);

                ExcelApp.Visible = false;

                // エクセルファイルにデータをセットする
                for(int j = 1; j <= 10; ++j)
                {
                    for (int i = 1; i <= 100; ++i)
                    {
                        // Excelのcell指定
                        Excel.Range w_rgn = ws.Cells;
                        Excel.Range rgn = w_rgn[i, j];

                        try
                        {
                            if (j == 1)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = i;
                            }
                            else if (j == 2)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = appnamefree[i - 1];
                            }
                            else if (j == 3)
                            {
                                // Excelにデータをセット
                                ws.Hyperlinks.Add(rgn, appurlfree[i - 1], TextToDisplay: "AppStoreで詳細");
                            }
                            else if (j == 4)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = i;
                            }
                            else if (j == 5)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = appnamepaid[i - 1];
                            }
                            else if (j == 6)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = appprice[i - 1];
                                //rgn.Value2 = priceGet.GetAppPrice(appid[i - 1]);

                            }
                            else if (j == 7)
                            {
                                // Excelにデータをセット
                                ws.Hyperlinks.Add(rgn, appurlpaid[i - 1], TextToDisplay: "AppStoreで詳細");
                            }
                            else if (j == 8)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = i;
                            }
                            else if (j == 9)
                            {
                                // Excelにデータをセット
                                rgn.Value2 = appnamets[i - 1];
                            }
                            else if (j == 10)
                            {
                                // Excelにデータをセット
                                ws.Hyperlinks.Add(rgn, appurlts[i - 1], TextToDisplay: "AppStoreで詳細");
                            }
                        }
                        finally
                        {
                            // Excelのオブジェクトはループごとに開放する
                            Marshal.ReleaseComObject(w_rgn);
                            Marshal.ReleaseComObject(rgn);
                            w_rgn = null;
                            rgn = null;
                            GC.Collect();
                        }
                    }
                }
                // セーブダイアログの表示
                // SaveFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // ダイアログのタイトルを設定する
                saveFileDialog1.Title = "Excelファイルを保存する";

                // 初期表示するディレクトリを設定する
                saveFileDialog1.InitialDirectory = @"C:\";

                // 初期表示するファイル名を設定する
                saveFileDialog1.FileName = "AppstoreData";

                // ファイルのフィルタを設定する
                saveFileDialog1.Filter = "Excel Worksheet|*.xlsx";
                // saveFileDialog1.Filter = "テキスト ファイル|*.txt;*.log|すべてのファイル|*.*";

                // ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
                saveFileDialog1.FilterIndex = 2;

                // ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 false)
                saveFileDialog1.RestoreDirectory = true;

                // [ヘルプ] ボタンを表示する (初期値 false)
                saveFileDialog1.ShowHelp = true;

                // 存在しないファイルを指定した場合は、
                // 新しく作成するかどうかの問い合わせを表示する (初期値 false)
                saveFileDialog1.CreatePrompt = true;

                // 存在しているファイルを指定した場合は、
                // 上書きするかどうかの問い合わせを表示する (初期値 true)
                //saveFileDialog1.OverwritePrompt = true;

                // 存在しないファイル名を指定した場合は警告を表示する (初期値 false)
                //saveFileDialog1.CheckFileExists = true;

                // 存在しないパスを指定した場合は警告を表示する (初期値 true)
                //saveFileDialog1.CheckPathExists = true;

                // 拡張子を指定しない場合は自動的に拡張子を付加する (初期値 true)
                //saveFileDialog1.AddExtension = true;

                // 有効な Win32 ファイル名だけを受け入れるようにする (初期値 true)
                //saveFileDialog1.ValidateNames = true;

                // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // excelファイルの保存
                    wb.SaveAs(saveFileDialog1.FileName);
                    // wb.SaveAs(saveFileDialog1.FileName + ".xlsx");
                    wb.Close(false);
                    ExcelApp.Quit();
                }
                else
                {
                    // ワークブックを閉じて、Excelも閉じる
                    wb.Close(false);
                    ExcelApp.Quit();
                }

                // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
                saveFileDialog1.Dispose();
            }
            finally
            {
                //Excelのオブジェクトを開放し忘れているとプロセスが落ちないため注意
                Marshal.ReleaseComObject(ws);
                Marshal.ReleaseComObject(shs);
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(wbs);
                Marshal.ReleaseComObject(ExcelApp);

                ws = null;
                shs = null;
                wb = null;
                wbs = null;
                ExcelApp = null;

                GC.Collect();
            }
        }
    }
}
