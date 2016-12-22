using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebExtras.Core;

namespace WebExtras.FontAwesomeParser
{
  class Program
  {
    static void Main(string[] args)
    {
      const string ipFilePath = "..\\fontawesome.html";
      const string opFilePath = "..\\fontawesome-output.txt";
      string text = File.ReadAllText(ipFilePath);
      text = text.Replace("&#", "");

      XmlDocument doc = new XmlDocument();
      doc.LoadXml(text);

      XmlNodeList list = doc.SelectNodes("//div[@class='col-md-4 col-sm-6 col-lg-3']");
      IDictionary<string, string> classes = new Dictionary<string, string>();

      foreach (XmlNode node in list)
      {
        XmlNode small = node.SelectSingleNode("small[@class='text-muted pull-right']");

        string faName = node.InnerText
          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(g => g.Replace("\r", "").Replace("\n", ""))
          .FirstOrDefault(t => t.StartsWith("fa-"));

        if (string.IsNullOrWhiteSpace(faName))
          throw new Exception("Unable to parse fa- css class");

        string cssClass = string.Join("_", faName.Split('-').Skip(1).Select(f => f.ToTitleCase()));

        bool startsWithNumber = char.IsDigit(cssClass.ToCharArray()[0]);

        cssClass = startsWithNumber ? "N" + cssClass : cssClass;

        classes[cssClass] = small == null ? string.Empty : small.InnerText;
      }

      const string commentTemplate = "/// <summary>\r\n/// Since FA v{0}\r\n/// </summary>";
      List<string> lines = new List<string>();
      foreach (var kv in classes)
      {
        if (!string.IsNullOrWhiteSpace(kv.Value))
          lines.Add(string.Format(commentTemplate, kv.Value));

        lines.Add(kv.Key + ",");
      }

      File.WriteAllLines(opFilePath, lines);
    }
  }
}
