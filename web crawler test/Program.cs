using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Text;

HtmlWeb htmlWeb = new HtmlWeb()
{
    AutoDetectEncoding = false,
    OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
};

//Load trang web, nạp html vào document
HtmlDocument document = htmlWeb.Load("https://www.");


var threadItems = document.DocumentNode.QuerySelectorAll("ul#threads > li").ToList();

var objs = new List<object>();
foreach (var item in threadItems)
{
    var linkNode = item.QuerySelector("a.title");
    var link = linkNode.Attributes["href"].Value;
    var text = linkNode.InnerText;
    var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;

    objs.Add(new { link, text, readCount });
}

