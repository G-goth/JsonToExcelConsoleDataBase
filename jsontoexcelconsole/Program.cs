using ExcelExport;
using JsonToString;
using ClosedXMLSpace;
using System;
using System.Collections.Generic;

namespace JsonToExcelConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("処理中ですしばらくお待ちください・・・");
            JsonToStringClass jsonToString = new JsonToStringClass();
            ExcelExportClass excelExport = new ExcelExportClass();
            ClosedXMLClass closedXMLClass = new ClosedXMLClass();

            string url_free = "https://itunes.apple.com/jp/rss/topfreeapplications/limit=100/genre=6014/json";
            string url_paid = "https://itunes.apple.com/jp/rss/toppaidapplications/limit=100/genre=6014/json";
            string url_topsales = "https://itunes.apple.com/jp/rss/topgrossingapplications/limit=100/genre=6014/json";

            List<string> freeAppNameList = new List<string>();
            List<string> freeAppURLList = new List<string>();

            List<string> paidAppNameList = new List<string>();
            List<string> paidAppURLList = new List<string>();
            List<string> paidAppIDList = new List<string>();
            List<string> paidAppPriceList = new List<string>();

            List<string> tsAppNameList = new List<string>();
            List<string> tsAppURLList = new List<string>();

            //トップ無料
            Console.WriteLine("トップ無料のデータを取得しています・・・");
            freeAppNameList = jsonToString.JsonToString(url_free, 0);
            freeAppURLList = jsonToString.JsonToString(url_free, 2);
            Console.WriteLine("トップ無料のデータ取得が完了しました。");

            // トップ有料
            Console.WriteLine("トップ有料のデータを取得しています・・・");
            paidAppNameList = jsonToString.JsonToString(url_paid, 0);
            paidAppPriceList = jsonToString.JsonToString(url_paid, 1);
            paidAppURLList = jsonToString.JsonToString(url_paid, 2);
            Console.WriteLine("トップ有料のデータ取得が完了しました。");

            // トップセールス
            Console.WriteLine("トップセールスのデータを取得しています・・・");
            tsAppNameList = jsonToString.JsonToString(url_topsales, 0);
            tsAppURLList = jsonToString.JsonToString(url_topsales, 2);
            Console.WriteLine("トップセールスのデータ取得が完了しました。");

            // Excelにエクスポート
            Console.WriteLine("Excelにエクスポートしています・・・");
            closedXMLClass.ClosedXMLExport(freeAppNameList, freeAppURLList, paidAppNameList, paidAppURLList, tsAppNameList, tsAppURLList, paidAppPriceList);
            // excelExport.ExcelOutputEx(freeAppNameList, freeAppURLList, paidAppNameList, paidAppURLList, tsAppNameList, tsAppURLList, paidAppPriceList);
        }
    }
}
