using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PatternsStudy.Utils
{
	public static class ContentFilter
	{
		public static string RemoveNonPrintChars(string html, List<string> remove)
		{
			foreach (string s in remove)
			{
				html = html.Replace(s, string.Empty);
			}

			return html;
		}

		public static string RemoveNonPrintTags(string html, List<string> tags)
		{
			foreach (var t in tags)
			{
				html = Regex.Replace(html, t, string.Empty);
			}

			return html;
		}

		public static string HtmlFilter(string htmlInput, string htmlClass, bool preserveInner)
		{
			HtmlDocument html = new HtmlDocument();
			html.LoadHtml(htmlInput);

			HtmlNode root = html.DocumentNode;

			var nodes = root.Descendants()
				.Where(n => n.GetAttributeValue("class", "").Equals(htmlClass)).ToList();

			foreach (var node in nodes)
			{
				string tag = $"(<?{node.Name} class=\"{htmlClass}\">|</?{node.Name}>)";

				if (preserveInner)
				{
					html.DocumentNode.InnerHtml = Regex.Replace(html.DocumentNode.InnerHtml, tag, string.Empty);
				}
				else
				{
					node.ParentNode.RemoveChild(node, preserveInner);
				}
			}

			return html.DocumentNode.InnerHtml;
		}

		public static string HtmlFilter(string htmlInput, string htmlTag, string htmlClass, bool preserveInner)
		{
			HtmlDocument html = new HtmlDocument();
			html.LoadHtml(htmlInput);

			HtmlNode root = html.DocumentNode;

			var nodes = root.Descendants(htmlTag)
				.Where(n => n.GetAttributeValue("class", "").Equals(htmlClass)).ToList();

			foreach (var node in nodes)
			{
				string tag = $"(<?{node.Name} class=\"{htmlClass}\">|</?{node.Name}>)";

				if (preserveInner)
				{
					html.DocumentNode.InnerHtml = Regex.Replace(html.DocumentNode.InnerHtml, tag, string.Empty);
				}
				else
				{
					node.ParentNode.RemoveChild(node, preserveInner);
				}
			}

			return html.DocumentNode.InnerHtml;
		}
	}
}