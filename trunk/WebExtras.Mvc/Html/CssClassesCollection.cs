/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a CSS classes collection
  /// </summary>
  [Serializable]
  public class CssClassesCollection : List<string>
  {

    /// <summary>
    /// Constructor
    /// </summary>
    public CssClassesCollection()
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="cssClasses">Existing CSS classes to be added</param>
    public CssClassesCollection(IEnumerable<string> cssClasses)
    {
      AddRange(cssClasses);
    }

    /// <summary>
    /// Adds the given item to the collection. Note: Individual CSS classes will be
    /// added. For eg. If the item is 'class1 class2', it will be treated as 2 CSS
    /// classes and in turn 2 items 'class1' and 'class2' will be added to the collection
    /// </summary>
    /// <param name="item">Item to be added</param>
    public new void Add(string item)
    {
      AddRange(item.Split(' '));
    }

    /// <summary>
    /// Adds the given collection of items to the collection. Note: Individual CSS 
    /// classes will be added. For eg. If any of the items in the new collection is of
    /// type 'class1 class2', it will be treated as 2 CSS classes and in turn 2 items 
    /// 'class1' and 'class2' will be added to the collection
    /// </summary>
    /// <param name="collection">New collection to be added</param>
    public new void AddRange(IEnumerable<string> collection)
    {
      IEnumerable<string> flattened = collection.Select(f => f.Split(' ')).SelectMany(f => f);

      base.AddRange(flattened);
    }
  }
}
