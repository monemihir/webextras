// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Nancy.ViewEngines.Razor;
using WebExtras.Html;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  ///   A bootstrap form control which allows appending and prepending of elements
  /// </summary>
  public class FormControl<TModel, TValue> : IFormControl<TModel, TValue>
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="component">form component to initalise with</param>
    public FormControl(IFormComponent<TModel, TValue> component)
    {
      Component = component;
    }

    #region Implementation of IFormControl<TModel,TValue>

    /// <summary>
    ///   Underlying form component
    /// </summary>
    public IFormComponent<TModel, TValue> Component { get; private set; }

    #endregion

    #region Implementation of IHtmlString

    /// <summary>Returns an HTML-encoded string.</summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      string html = Component.ToHtml();

      return new NonEncodedHtmlString(html).ToHtmlString();
    }

    #endregion
  }
}