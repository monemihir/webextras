/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.JQFlot;
using WebExtras.JQFlot.Graphs;
using WebExtras.JQFlot.SubOptions;
using WebExtras.JQPlot;
using WebExtras.JQPlot.RendererOptions;
using WebExtras.JQPlot.SubOptions;
using AxisOptions = WebExtras.JQFlot.SubOptions.AxisOptions;
using GridOptions = WebExtras.JQFlot.SubOptions.GridOptions;
using SeriesOptions = WebExtras.JQFlot.SubOptions.SeriesOptions;

namespace WebExtras.DemoApp.Models.Core
{
  /// <summary>
  /// jqPlot dummy data creator
  /// </summary>
  public class GraphDataGenerator
  {
    private readonly object[][] m_graphSampleTextData1, m_graphSampleTextData2, m_graphSampleDateData, m_graphSampleOHLCData;
    private readonly Random m_rand;

    /// <summary>
    /// Sample data for a default graph
    /// </summary>
    public readonly double[][] GraphSampleData;

    public GraphDataGenerator()
    {
      m_rand = new Random(DateTime.Now.Millisecond);
      GraphSampleData = Enumerable.Range(1, 10).Select(f => new double[] { f, m_rand.NextDouble() * 100 }).ToArray();

      m_graphSampleTextData1 = new object[][] { 
        new object[] { "Cup Holder Pinion Bob", m_rand.NextDouble() * 100 },
        new object[] { "Generic Fog Lamp", m_rand.NextDouble() * 100 },
        new object[] { "HDTV Receiver", m_rand.NextDouble() * 100 },
        new object[] { "8 Track Control Module", m_rand.NextDouble() * 100 },
        new object[] { "Sludge Pump Fourier Modulator", m_rand.NextDouble() * 100 },
        new object[] { "Transcender/Spice Rack", m_rand.NextDouble() * 100 },
        new object[] { "Hair Spray Danger Indicator", m_rand.NextDouble() * 100 }
      };

      m_graphSampleTextData2 = new object[][] { 
        new object[] { "Nickel", m_rand.NextDouble() * 100 },
        new object[] { "Aluminium", m_rand.NextDouble() * 100 },
        new object[] { "Xenon", m_rand.NextDouble() * 100 },
        new object[] { "Silver", m_rand.NextDouble() * 100 },
        new object[] { "Sulphur", m_rand.NextDouble() * 100 },
        new object[] { "Vanadium", m_rand.NextDouble() * 100 },
        new object[] { "Uranium", m_rand.NextDouble() * 100 }
      };

      m_graphSampleDateData = new object[][]{
        new object[] { "01-Jan-2014", 75 },
        new object[] { "01-Feb-2014", 91 },
        new object[] { "27-Jun-2014", 150 },
        new object[] { "17-July-2014", 112 },
        new object[] { "22-Sep-2014", 37 },
        new object[] { "08-Nov-2014", 66 },
        new object[] { "11-Dec-2014", 18 }
      };

      m_graphSampleOHLCData = Enumerable.Range(1, 25)
        .Select(i => new object[] {
          DateTime.Now.AddDays(3 * i).ToString("dd-MMM-yyyy hh:mm:ss"),
          m_rand.NextDouble() * 100,
          m_rand.NextDouble() * 100,
          m_rand.NextDouble() * 100,
          m_rand.NextDouble() * 100
        })
        .ToArray();
    }
    
    /// <summary>
    /// Get canned/dummy jqPlot charts
    /// </summary>
    /// <param name="mode">Mode for which to get the chart</param>
    /// <param name="url">Current UrlHelper to generate any AJAX call urls</param>
    /// <returns>jqPlot charts</returns>
    public JQPlotChartBase[] GetJQPlotCharts(int mode, UrlHelper url)
    {
      object data;
      JQPlotOptions options;
      List<JQPlotChartBase> charts = new List<JQPlotChartBase>();

      switch (mode)
      {
        // non numeric data graphs - text data, date data
        case 1:
          data = new List<object[][]> { m_graphSampleTextData1 };
          options = new JQPlotOptions
          {
            title = new TitleOptions("Concern vs Occurance"),
            axesDefaults = new JQPlot.SubOptions.AxisOptions
            {
              tickRenderer = EJQPlotRenderer.CanvasAxisTickRenderer,
              tickOptions = new CanvasAxisTickRendererOptions
              {
                angle = -30
              }
            },
            axes = new JQPlotAxes
            {
              xaxis = new JQPlot.SubOptions.AxisOptions { renderer = EJQPlotRenderer.CategoryAxisRenderer },
              yaxis = new JQPlot.SubOptions.AxisOptions
              {
                tickOptions = new CanvasAxisTickRendererOptions
                {
                  angle = 0
                }
              }
            }
          };

          charts.Add(new JQPlotChartBase
          {
            chartData = data,
            chartOptions = options
          });

          data = new List<object[][]> { m_graphSampleDateData };
          options = new JQPlotOptions
          {
            title = new TitleOptions("Date Data Rendering"),
            axes = new JQPlotAxes
            {
              xaxis = new JQPlot.SubOptions.AxisOptions
              {
                renderer = EJQPlotRenderer.DateAxisRenderer,
                tickOptions = new AxisTickRendererOptions
                {
                  formatString = "%b&nbsp;%#d"
                },
                min = "25-Dec-2013"
              }
            }
          };

          charts.Add(new JQPlotChartBase
          {
            chartData = data,
            chartOptions = options
          });
          break;

        // Multiple axes chart
        case 3:
          data = new List<object[][]> { m_graphSampleTextData1, m_graphSampleTextData2 };
          options = new JQPlotOptions
          {
            title = new TitleOptions("Concern vs Occurance"),
            axesDefaults = new JQPlot.SubOptions.AxisOptions
            {
              tickRenderer = EJQPlotRenderer.CanvasAxisTickRenderer,
              tickOptions = new CanvasAxisTickRendererOptions
              {
                angle = 30
              }
            },
            axes = new JQPlotAxes
            {
              xaxis = new JQPlot.SubOptions.AxisOptions { renderer = EJQPlotRenderer.CategoryAxisRenderer },
              x2axis = new JQPlot.SubOptions.AxisOptions { renderer = EJQPlotRenderer.CategoryAxisRenderer },
              yaxis = new JQPlot.SubOptions.AxisOptions
              {
                tickOptions = new CanvasAxisTickRendererOptions
                {
                  angle = 0
                },
                autoscale = true
              },
              y2axis = new JQPlot.SubOptions.AxisOptions
              {
                tickOptions = new CanvasAxisTickRendererOptions
                {
                  angle = 0
                },
                autoscale = true
              }
            },
            series = new JQPlot.SubOptions.SeriesOptions[]
            {
              new JQPlot.SubOptions.SeriesOptions {
                renderer = EJQPlotChartRenderer.BarRenderer
              },
              new JQPlot.SubOptions.SeriesOptions {
                xaxis = "x2axis",
                yaxis = "y2axis"
              }
            }
          };

          charts.Add(new JQPlotChartBase
          {
            chartData = data,
            chartOptions = options
          });
          break;

        // AJAX data chart
        case 4:
          data = url.Action(MVC.GraphData.GetJQPlotData());
          options = new JQPlotOptions
          {
            title = new TitleOptions("AJAX JSON Data Renderer"),
            axesDefaults = new JQPlot.SubOptions.AxisOptions
            {
              labelRenderer = EJQPlotRenderer.CanvasAxisLabelRenderer,
              labelOptions = new Dictionary<string, object> { 
                { "fontSize", "12px" },
                { "fontFamily", "Arial" }
              }
            }
          };

          charts.Add(new JQPlotChartBase
          {
            chartData = data,
            chartOptions = options
          });
          break;

        // OHLC charts
        case 5:
          StringBuilder formatStringBuilder = new StringBuilder();
          formatStringBuilder.Append("<table class='jqplot-highlighter'>");
          formatStringBuilder.Append("<tr><td>date:</td><td>%s</td></tr>");
          formatStringBuilder.Append("<tr><td>open:</td><td>%s</td></tr>");
          formatStringBuilder.Append("<tr><td>hi:</td><td>%s</td></tr>");
          formatStringBuilder.Append("<tr><td>low:</td><td>%s</td></tr>");
          formatStringBuilder.Append("<tr><td>close:</td><td>%s</td></tr>");
          formatStringBuilder.Append("</table>");

          data = new List<object[][]> { m_graphSampleOHLCData };
          options = new JQPlotOptions
          {
            seriesDefaults = new JQPlot.SubOptions.SeriesOptions
            {
              yaxis = "y2axis"
            },
            axes = new JQPlotAxes
            {
              xaxis = new JQPlot.SubOptions.AxisOptions
              {
                renderer = EJQPlotRenderer.DateAxisRenderer,
                tickOptions = new AxisTickRendererOptions
                {
                  formatString = "%b %e"
                },
                tickInterval = "6 weeks"
              },
              y2axis = new JQPlot.SubOptions.AxisOptions
              {
                tickOptions = new AxisTickRendererOptions
                {
                  formatString = "$%d"
                }
              }
            },
            series = new JQPlot.SubOptions.SeriesOptions[] {
              new JQPlot.SubOptions.SeriesOptions {
                renderer = EJQPlotChartRenderer.OHLCRenderer,
                rendererOptions = new OHLCRendererOptions {
                  candleStick = true
                }
              }
            },
            highlighter = new HighlighterOptions
            {
              show = true,
              showMarker = false,
              tooltipAxes = "xy",
              yvalues = 4,
              formatString = formatStringBuilder.ToString()
            }
          };
          charts.Add(new JQPlotChartBase
          {
            chartData = data,
            chartOptions = options
          });
          break;

        // default line graphs
        default:
          data = new List<double[][]> { GraphSampleData };
          options = new JQPlotOptions
          {
            title = new TitleOptions("Basic Line Graph")
            
          };

          charts.Add(new JQPlotChartBase
          {
            chartData = data,
            chartOptions = options
          });
          break;
      }
      
      return charts.ToArray();
    }

    /// <summary>
    /// Get canned/dummy flot chart
    /// </summary>
    /// <param name="mode">Mode for which to get the chart</param>
    /// <returns>Flot chart</returns>
    public FlotChart GetFlotChart(int mode)
    {
      FlotOptions options = new FlotOptions
      {
        xaxis = new JQFlot.SubOptions.AxisOptions { axisLabel = "X axis label", axisLabelColor = "#222222" },
        yaxis = new JQFlot.SubOptions.AxisOptions { axisLabel = "Y axis label", axisLabelColor = "#222222" },
        grid = new JQFlot.SubOptions.GridOptions { borderWidth = 1 }
      };

      List<FlotSeries> series = new List<FlotSeries>();
      FlotSeries serie = null;

      switch (mode)
      {
        case 6:
          serie = new FlotSeries
          {
            label = "Sample Line Graph",
            data = GraphSampleData,
            lines = new LineGraph { show = true }
          };
          series.Add(serie);
          options = new FlotOptions
          {
            grid = new JQFlot.SubOptions.GridOptions
            {
              borderWidth = 1
            },
            xaxis = new JQFlot.SubOptions.AxisOptions
            {
              tickDecimals = 2,
              tickFormatter = new JsFunc
              {
                ParameterNames = new string[] { "val", "axis" },
                Body = "return val.toFixed(axis.tickDecimals);"
              },
              axisLabel = "X Axis - Ticks to two decimals",
              axisLabelColor = "#222222"
            },
            yaxis = new JQFlot.SubOptions.AxisOptions
            {
              axisLabel = "Y Axis Label",
              axisLabelColor = "#222222"
            }
          };
          break;

        case 5:
          goto default;

        case 4:
          series = Enumerable.Range(1, 5).Select(f => new FlotSeries
          {
            label = "Serie" + f.ToString(CultureInfo.InvariantCulture),
            data = m_rand.NextDouble() * 100
          }).ToList();

          options = new FlotOptions
          {
            series = new JQFlot.SubOptions.SeriesOptions
            {
              pie = new PieGraph { show = true }
            }
          };
          break;

        case 3:
          serie = new FlotSeries
          {
            label = "Sample Bar Graph",
            data = GraphSampleData,
            bars = new BarGraph { show = true }
          };
          series.Add(serie);
          break;

        case 2:
          serie = new FlotSeries
          {
            label = "Sample Curved Line Graph",
            data = GraphSampleData,
            curvedLines = new CurvedLineGraph { show = true }
          };

          options = new FlotOptions
          {
            xaxis = new JQFlot.SubOptions.AxisOptions { axisLabel = "X axis label", axisLabelColor = "#222222" },
            yaxis = new AxisOptions { axisLabel = "Y axis label", axisLabelColor = "#222222" },
            grid = new GridOptions { borderWidth = 1 },
            series = new SeriesOptions { curvedLines = new CurvedLineOptions { active = true } }
          };
          series.Add(serie);
          break;

        case 1:
          serie = new FlotSeries
          {
            label = "Sample Dashed Line Graph",
            data = GraphSampleData,
            dashes = new DashedLineGraph { show = true }
          };
          series.Add(serie);
          break;

        case 0:
        default:
          serie = new FlotSeries
          {
            label = "Sample Line Graph",
            data = GraphSampleData,
            lines = new LineGraph { show = true }
          };
          series.Add(serie);
          break;

      }

      FlotChart chart = new FlotChart
      {
        chartOptions = options,
        chartSeries = series.ToArray()
      };

      return chart;
    }
  }
}