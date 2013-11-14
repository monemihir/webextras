/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a CSS classes collection
  /// </summary>
  public class CssClassesCollection : IList<string>, ICollection<string>, IEnumerable<string>
  {
    private List<string> m_cssClasses;

    /// <summary>
    /// Constructor
    /// </summary>
    public CssClassesCollection()
    {
      m_cssClasses = new List<string>();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="cssClasses">Existing CSS classes to be added</param>
    public CssClassesCollection(IEnumerable<string> cssClasses)
      : this()
    {
      if (cssClasses != null)
        m_cssClasses.AddRange(cssClasses);
    }

    /// <summary>
    /// Searches for the specified object and returns the index of the
    /// first occurrence within the entire collection.
    /// </summary>
    /// <param name="item">Item to be located</param>
    /// <returns>Index of the first occurence of the item if found, else returns -1</returns>
    public int IndexOf(string item)
    {
      return m_cssClasses.IndexOf(item);
    }

    /// <summary>
    /// Inserts the given item at the specified index
    /// </summary>
    /// <param name="index">Index at which to insert</param>
    /// <param name="item">Item to be inserted</param>
    public void Insert(int index, string item)
    {
      m_cssClasses.Insert(index, item);
    }

    /// <summary>
    /// Remove the item at the specified index
    /// </summary>
    /// <param name="index">Index at which to remove</param>
    public void RemoveAt(int index)
    {
      m_cssClasses.RemoveAt(index);
    }

    /// <summary>
    /// Gets or sets the element at the specified index
    /// </summary>
    /// <param name="index">Index at which to get or set</param>
    /// <returns>The element at the specified index</returns>
    public string this[int index]
    {
      get
      {
        return m_cssClasses[index];
      }
      set
      {
        m_cssClasses[index] = value;
      }
    }

    /// <summary>
    /// Adds the given item to the collection. Note: Individual CSS classes will be
    /// added. For eg. If the item is 'class1 class2', it will be treated as 2 CSS
    /// classes and in turn 2 items 'class1' and 'class2' will be added to the collection
    /// </summary>
    /// <param name="item">Item to be added</param>
    public void Add(string item)
    {
      m_cssClasses.AddRange(item.Split(' '));
    }

    /// <summary>
    /// Adds the given collection of items to the collection. Note: Individual CSS 
    /// classes will be added. For eg. If any of the items in the new collection is of
    /// type 'class1 class2', it will be treated as 2 CSS classes and in turn 2 items 
    /// 'class1' and 'class2' will be added to the collection
    /// </summary>
    /// <param name="collection">New collection to be added</param>
    public void AddRange(IEnumerable<string> collection)
    {
      IEnumerable<string> flattened = collection.Select(f => f.Split(' ')).SelectMany(f => f);

      m_cssClasses.AddRange(flattened);
    }

    /// <summary>
    /// Clears all items in the collection
    /// </summary>
    public void Clear()
    {
      m_cssClasses.Clear();
    }

    /// <summary>
    /// Check whether the givem item exists in the collection
    /// </summary>
    /// <param name="item">Item to be checked</param>
    /// <returns>True if the item exists in the collection, else False</returns>
    public bool Contains(string item)
    {
      return m_cssClasses.Contains(item);
    }

    /// <summary>
    /// Copies the collection to the given string array, starting at the specified
    /// index in the target array
    /// </summary>
    /// <param name="array">The array to be copied to</param>
    /// <param name="arrayIndex">Index at which to start copying</param>
    public void CopyTo(string[] array, int arrayIndex)
    {
      m_cssClasses.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Returns the current number of elements in the collection
    /// </summary>
    public int Count
    {
      get { return m_cssClasses.Count; }
    }

    /// <summary>
    /// Flag indicating whether the current collection is a readonly
    /// collection
    /// </summary>
    public bool IsReadOnly
    {
      get { return IsReadOnly; }
    }

    /// <summary>
    /// Remove the given item from collection
    /// </summary>
    /// <param name="item">Item to be removed</param>
    /// <returns>True if success, else False</returns>
    public bool Remove(string item)
    {
      return m_cssClasses.Remove(item);
    }

    /// <summary>
    /// Returns the enumerator for the collection
    /// </summary>
    /// <returns>The enumerator for the collection</returns>
    public IEnumerator<string> GetEnumerator()
    {
      return m_cssClasses.GetEnumerator();
    }

    /// <summary>
    /// Returns the enumerator for the collection
    /// </summary>
    /// <returns>The enumerator for the collection</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return m_cssClasses.GetEnumerator();
    }
  }
}
