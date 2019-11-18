using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEDTeam.CES.Tool.Extensions
{
    public static class HtmlDocExtension
    {
        public static IEnumerable<HtmlElement> GetElementsByClassName(this HtmlDocument doc, string className)
        {
            var elements = new List<HtmlElement>();
            foreach (HtmlElement element in doc.All)
            {
                if (element.GetAttribute("className") == className)
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<HtmlElement> GetElementsByAttribute(this HtmlDocument doc, string attribute)
        {
            var elements = new List<HtmlElement>();
            foreach (HtmlElement element in doc.All)
            {
                if (!string.IsNullOrEmpty(element.GetAttribute(attribute)))
                {
                    elements.Add(element);
                }
            }
            return elements;
        }

        public static IEnumerable<HtmlElement> GetElementsByClassName(this HtmlElement doc, string className)
        {
            var elements = new List<HtmlElement>();
            foreach (HtmlElement element in doc.All)
            {
                if (element.GetAttribute("className") == className)
                {
                    yield return element;
                }
            }
        }
    }
}
