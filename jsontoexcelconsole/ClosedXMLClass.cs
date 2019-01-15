using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ClosedXMLSpace
{
    class ClosedXMLClass
    {
        public void ClosedXMLExport(List<string> appnamefree, List<string> appurlfree, List<string> appnamepaid, List<string> appurlpaid, 
            List<string> appnamets, List<string> appurlts, List<string> appprice)
        {
            // var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AppStoreData.xlsx");

            // Excelファイル作成
            using (var book = new XLWorkbook(XLEventTracking.Disabled))
            {
                var sheet = book.AddWorksheet("Sheet1");

                // データ出力
                for (int j = 1; j <= 10; ++j)
                {
                    for (int i = 1; i <= 100; ++i)
                    {
                        // 順位
                        if (j == 1 || j == 4 || j == 8)
                        {
                            sheet.Cell(i, j).Value = i;
                        }
                        // トップ無料・アプリ名
                        else if (j == 2)
                        {
                            sheet.Cell("B" + i).Value = appnamefree[i - 1];
                        }
                        // トップ無料・AppStore・リンク
                        else if (j == 3)
                        {
                            sheet.Cell("C" + i).Value = "AppStoreで詳細";
                            sheet.Cell("C" + i).Hyperlink = new XLHyperlink(appurlfree[i - 1]);
                        }
                        // トップ有料・アプリ名
                        else if (j == 5)
                        {
                            sheet.Cell("E" + i).Value = appnamepaid[i - 1];
                        }
                        // トップ有料・値段
                        else if (j == 6)
                        {
                            sheet.Cell("F" + i).Value = appprice[i - 1];
                        }
                        // トップ有料・AppStore・リンク
                        else if (j == 7)
                        {
                            sheet.Cell("G" + i).Value = "AppStoreで詳細";
                            sheet.Cell("G" + i).Hyperlink = new XLHyperlink(appurlpaid[i - 1]);
                        }
                        // トップセールス・アプリ名
                        else if (j == 9)
                        {
                            sheet.Cell("I" + i).Value = appnamets[i - 1];
                        }
                        // トップセールス・AppStore・リンク
                        else if (j == 10)
                        {
                            sheet.Cell("J" + i).Value = "AppStoreで詳細";
                            sheet.Cell("J" + i).Hyperlink = new XLHyperlink(appurlts[i - 1]);
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
                saveFileDialog1.FileName = "";

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
                saveFileDialog1.CreatePrompt = false;

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
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), saveFileDialog1.FileName);
                    // ブックの保存
                    book.SaveAs(path);
                    Console.WriteLine("Excelへのエクスポート完了しました");

                }
                else
                {
                    Console.WriteLine("Excelへのエクスポートをキャンセルしました");
                }

                // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
                saveFileDialog1.Dispose();
            }
        }
    }
}
