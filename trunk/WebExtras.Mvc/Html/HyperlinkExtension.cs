using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  public static class HyperlinkExtension
  {
    public static Hyperlink AddIcons(this Hyperlink html, params Icon[] icons)
    {
      if (icons == null)
        throw new ArgumentNullException("icons");

      Italic i = new Italic(null);
      i["class"] = string.Join(" ", icons.Select(x => x.GetStringValue()));

      html.PrependElement(i);

      return html;
    }

    public static Hyperlink AddWhiteIcons(this Hyperlink html, params Icon[] icons)
    {
      if (icons == null)
        throw new ArgumentNullException("icons");

      Italic i = new Italic(null);
      i["class"] = "icon-white " + string.Join(" ", icons.Select(x => x.GetStringValue()));

      html.PrependElement(i);

      return html;
    }
  }
}
