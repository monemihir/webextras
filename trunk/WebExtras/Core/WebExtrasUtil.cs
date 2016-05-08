// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace WebExtras.Core
{
  /// <summary>
  ///   WebExtras utility methods
  /// </summary>
  public static class WebExtrasUtil
  {
    /// <summary>
    ///   Creates a name-value collection based on an anonymous object
    /// </summary>
    /// <param name="anonObject">[Optional] Anonymous object to be converted</param>
    /// <returns>A name-value collection</returns>
    public static NameValueCollection AnonymousObjectToHtmlAttributes(object anonObject = null)
    {
      if (anonObject == null)
        return new NameValueCollection();

      NameValueCollection collection = new NameValueCollection();

      foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(anonObject))
      {
        object val = property.GetValue(anonObject) ?? string.Empty;

        collection.Add(property.Name.Replace('_', '-'), val.ToString());
      }

      return collection;
    }

    /// <summary>
    ///   Get a HTML field ID based on a member expression. This supports nested member expressions
    /// </summary>
    /// <param name="expression">Member lamba expression</param>
    /// <returns>HTML field ID for member</returns>
    public static string GetFieldIdFromExpression(MemberExpression expression)
    {
      return string.Join("_", GetComponents(expression));
    }

    /// <summary>
    ///   Get a HTML field name based on a member expression. This supports nested member expressions
    /// </summary>
    /// <param name="expression">Member lamba expression</param>
    /// <returns>HTML field name for member</returns>
    public static string GetFieldNameFromExpression(MemberExpression expression)
    {
      return string.Join(".", GetComponents(expression));
    }

    /// <summary>
    ///   Gets the usable components from the expression. For eg. f.Model.Member
    ///   will return Model and Member as usable components.
    /// </summary>
    /// <param name="expression">Member expression to process</param>
    /// <returns>
    ///   A collection of components that can be used to make
    ///   a field ID or field Name
    /// </returns>
    private static IEnumerable<string> GetComponents(MemberExpression expression)
    {
      List<string> components = new List<string>();
      List<string> split = expression.Expression.ToString().Split('.').ToList();

      if (split.Count > 1)
      {
        split.RemoveAt(0);
        components.AddRange(split);
      }

      components.Add(expression.Member.Name);
      return components;
    }
  }
}