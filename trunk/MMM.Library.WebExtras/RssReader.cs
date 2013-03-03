/*
* This file is part of - Code Library
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace WebExtras
{
  /// <summary>
  /// A generic RSS 2.0 reader
  /// </summary>
  public sealed class RssReader
  {
    /// <summary>
    /// RSS feed channel
    /// </summary>
    public string RssFeedChannel { get; private set; }

    /// <summary>
    /// RSS data retrieved.
    /// </summary>
    public List<Dictionary<string, string>> RssData { get; private set; }

    /// <summary>
    /// RSS fields to be retrieved
    /// </summary>
    public List<string> RssFields { get; private set; }

    /// <summary>
    /// Number of RSS feed items to read. If set to 0, all RSS items will be read
    /// </summary>
    public int RssFeedItemLimit { get; private set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="feedChannel">RSS feed channel to read from</param>
    /// <param name="rssFields">RSS fields to retrieve data for</param>
    /// <param name="rssFeedItemLimit">[Optional] Number of items to read from the RSS feed. Defaults to 5. If set
    /// to 0, all RSS items will be read</param>
    /// <param name="readFeed">[Optional] Flag indicating whether to read the feed at initialization. Defaults to false</param>
    public RssReader(string feedChannel, IEnumerable<string> rssFields, int rssFeedItemLimit = 5, bool readFeed = false)
    {
      RssFeedChannel = feedChannel;
      RssFields = rssFields.ToList();
      RssData = new List<Dictionary<string, string>>();
      RssFeedItemLimit = rssFeedItemLimit;

      if (readFeed)
        ReadRssFeed();
    }

    /// <summary>
    /// Sets the RSS Data for the reader. This is typically useful when you need to post process the default
    /// RSS data read by the RSS reader
    /// </summary>
    /// <param name="newData">New data to be set</param>
    public void SetRssData(List<Dictionary<string, string>> newData)
    {
      RssData = newData;
    }

    /// <summary>
    /// Reads the RSS feed
    /// </summary>
    /// <returns>True if read was successful, else False</returns>
    public bool ReadRssFeed()
    {
      try
      {
        WebRequest request = WebRequest.Create(RssFeedChannel);
        WebResponse response = request.GetResponse();

        Stream responseStream = response.GetResponseStream();

        XmlDocument doc = new XmlDocument();
        if (responseStream != null)
          doc.Load(responseStream);

        XmlNodeList rssItems = doc.SelectNodes("rss/channel/item");
        int count = 0;
        if (rssItems != null)
          foreach (XmlNode item in rssItems)
          {
            if (RssFeedItemLimit > 0 && count == RssFeedItemLimit)
              break;

            Dictionary<string, string> record = new Dictionary<string, string>();
            foreach (string field in RssFields)
            {
              XmlNode node = item.SelectSingleNode(field);
              string text = (node != null) ? node.InnerText : "";

              if (field == "pubDate")
              {
                DateTime dt = DateTime.Parse(text);
                text = dt.ToLocalTime().ToString("dd MMM yyyy HH:mm");
              }

              record[field] = text;
            }
            RssData.Add(record);

            count++;
          }
        if (responseStream != null)
          responseStream.Close();

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}