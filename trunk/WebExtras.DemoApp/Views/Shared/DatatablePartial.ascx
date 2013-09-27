<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebExtras.JQDataTables.Datatable>" %>
<%@ Import Namespace="WebExtras.JQDataTables" %>

<!--
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
-->

<table class="dataTable table table-bordered table-striped" id="<%= Model.ID %>">
  <thead>
    <tr>
      <% foreach (AOColumn col in Model.Settings.aoColumns)
         { %>
      <th><%= Html.Raw(col.sTitle)%></th>
      <% } %>
    </tr>
  </thead>
  <% if (!Model.Settings.bServerSide)
     { %>
  <tbody>
    <%= MvcHtmlString.Create(Model.Records.RenderAADataAsTableRows()) %>
  </tbody>
  <% } %>
</table>

<script type="text/javascript">    
  var dtSettings = <%= Html.Raw(string.Format("{0};", Model.Settings.ToString())) %>

  <% if (Model.Settings.bServerSide)
     { %>
  <%= Html.Raw("dtSettings['bServerSide'] = false; dtSettings['sAjaxSource'] = null;") %>
  <% } %>

      
  <%= Html.Raw(string.Format("var {0}_tbl = $('#{0}').dataTable(dtSettings);", Model.ID)) %>
    
  <% if (Model.Settings.Paging == EPagination.Bootstrap3)
     { %>
  <%= Html.Raw(string.Format("var {0}_search_input = {0}_tbl.closest('.dataTables_wrapper').find('div[id$=_filter] input'); {0}_search_input.attr('placeholder', 'Search'); {0}_search_input.addClass('form-control input-sm');", Model.ID)) %>
  <%= Html.Raw(string.Format("var {0}_length_sel = {0}_tbl.closest('.dataTables_wrapper').find('div[id$=_length] select'); {0}_length_sel.addClass('form-control input-sm');", Model.ID)) %>
  <% } %>

  <%if (Model.Settings.bServerSide)
    { %>
  <%= Html.Raw(string.Format("{0}_settings = {0}_tbl.fnSettings(); {0}_settings.oFeatures.bServerSide = true; {0}_settings.sAjaxSource = '{1}';", Model.ID, Model.Settings.sAjaxSource)) %>
        
  <%if (Model.Records != null)
    { %>
  <%= Html.Raw(string.Format("var firstPage = {0};", Model.Records.ToString())) %>
  <%= Html.Raw(string.Format("{0}_tbl.oApi._fnAjaxUpdateDraw({0}_settings, firstPage);", Model.ID)) %>
  <%}
    else
    { %>
  <%= Html.Raw(string.Format("{0}_tbl.fnDraw()", Model.ID)) %>
  <% }
    } %>
  
</script>
