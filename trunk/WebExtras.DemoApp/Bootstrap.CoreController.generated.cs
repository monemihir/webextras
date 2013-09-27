// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace WebExtras.DemoApp.Areas.Bootstrap.Controllers
{
    public partial class CoreController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CoreController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Datatables()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Datatables);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult GetAjaxData()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetAjaxData);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult GetPagedData()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetPagedData);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult GetSortedData()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetSortedData);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult GetPostbackData()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetPostbackData);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Flot()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Flot);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CoreController Actions { get { return MVC.Bootstrap.Core; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "bootstrap";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "core";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "core";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = ("Index").ToLowerInvariant();
            public readonly string Generic = ("Generic").ToLowerInvariant();
            public readonly string Datatables = ("Datatables").ToLowerInvariant();
            public readonly string GetAjaxData = ("GetAjaxData").ToLowerInvariant();
            public readonly string GetPagedData = ("GetPagedData").ToLowerInvariant();
            public readonly string GetSortedData = ("GetSortedData").ToLowerInvariant();
            public readonly string GetPostbackData = ("GetPostbackData").ToLowerInvariant();
            public readonly string Flot = ("Flot").ToLowerInvariant();
        }


        static readonly ActionParamsClass_Datatables s_params_Datatables = new ActionParamsClass_Datatables();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Datatables DatatablesParams { get { return s_params_Datatables; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Datatables
        {
            public readonly string mode = ("mode").ToLowerInvariant();
            public readonly string viewModel = ("viewModel").ToLowerInvariant();
        }
        static readonly ActionParamsClass_GetAjaxData s_params_GetAjaxData = new ActionParamsClass_GetAjaxData();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetAjaxData GetAjaxDataParams { get { return s_params_GetAjaxData; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetAjaxData
        {
            public readonly string filters = ("filters").ToLowerInvariant();
        }
        static readonly ActionParamsClass_GetPagedData s_params_GetPagedData = new ActionParamsClass_GetPagedData();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetPagedData GetPagedDataParams { get { return s_params_GetPagedData; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetPagedData
        {
            public readonly string filters = ("filters").ToLowerInvariant();
        }
        static readonly ActionParamsClass_GetSortedData s_params_GetSortedData = new ActionParamsClass_GetSortedData();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetSortedData GetSortedDataParams { get { return s_params_GetSortedData; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetSortedData
        {
            public readonly string filters = ("filters").ToLowerInvariant();
        }
        static readonly ActionParamsClass_GetPostbackData s_params_GetPostbackData = new ActionParamsClass_GetPostbackData();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetPostbackData GetPostbackDataParams { get { return s_params_GetPostbackData; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetPostbackData
        {
            public readonly string filters = ("filters").ToLowerInvariant();
            public readonly string postbacks = ("postbacks").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Flot s_params_Flot = new ActionParamsClass_Flot();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Flot FlotParams { get { return s_params_Flot; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Flot
        {
            public readonly string mode = ("mode").ToLowerInvariant();
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _AjaxSetup = "_AjaxSetup";
                public readonly string _AxisLabels = "_AxisLabels";
                public readonly string _BarGraph = "_BarGraph";
                public readonly string _BasicSetup = "_BasicSetup";
                public readonly string _CurvedLineGraph = "_CurvedLineGraph";
                public readonly string _CustomFlotFormatters = "_CustomFlotFormatters";
                public readonly string _DashedGraph = "_DashedGraph";
                public readonly string _LineGraph = "_LineGraph";
                public readonly string _PagedSetup = "_PagedSetup";
                public readonly string _PieGraph = "_PieGraph";
                public readonly string _PostbackResult = "_PostbackResult";
                public readonly string _PostbackSetup = "_PostbackSetup";
                public readonly string _SortedSetup = "_SortedSetup";
                public readonly string _StatusSetup = "_StatusSetup";
                public readonly string Datatables = "Datatables";
                public readonly string Flot = "Flot";
                public readonly string Generic = "Generic";
            }
            public readonly string _AjaxSetup = "~/Areas/Bootstrap/Views/Core/_AjaxSetup.cshtml";
            public readonly string _AxisLabels = "~/Areas/Bootstrap/Views/Core/_AxisLabels.cshtml";
            public readonly string _BarGraph = "~/Areas/Bootstrap/Views/Core/_BarGraph.cshtml";
            public readonly string _BasicSetup = "~/Areas/Bootstrap/Views/Core/_BasicSetup.cshtml";
            public readonly string _CurvedLineGraph = "~/Areas/Bootstrap/Views/Core/_CurvedLineGraph.cshtml";
            public readonly string _CustomFlotFormatters = "~/Areas/Bootstrap/Views/Core/_CustomFlotFormatters.cshtml";
            public readonly string _DashedGraph = "~/Areas/Bootstrap/Views/Core/_DashedGraph.cshtml";
            public readonly string _LineGraph = "~/Areas/Bootstrap/Views/Core/_LineGraph.cshtml";
            public readonly string _PagedSetup = "~/Areas/Bootstrap/Views/Core/_PagedSetup.cshtml";
            public readonly string _PieGraph = "~/Areas/Bootstrap/Views/Core/_PieGraph.cshtml";
            public readonly string _PostbackResult = "~/Areas/Bootstrap/Views/Core/_PostbackResult.cshtml";
            public readonly string _PostbackSetup = "~/Areas/Bootstrap/Views/Core/_PostbackSetup.cshtml";
            public readonly string _SortedSetup = "~/Areas/Bootstrap/Views/Core/_SortedSetup.cshtml";
            public readonly string _StatusSetup = "~/Areas/Bootstrap/Views/Core/_StatusSetup.cshtml";
            public readonly string Datatables = "~/Areas/Bootstrap/Views/Core/Datatables.cshtml";
            public readonly string Flot = "~/Areas/Bootstrap/Views/Core/Flot.cshtml";
            public readonly string Generic = "~/Areas/Bootstrap/Views/Core/Generic.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_CoreController : WebExtras.DemoApp.Areas.Bootstrap.Controllers.CoreController
    {
        public T4MVC_CoreController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Generic()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Generic);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Datatables(int? mode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Datatables);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mode", mode);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Datatables(WebExtras.DemoApp.Models.Core.DatatablesViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Datatables);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult GetAjaxData(WebExtras.JQDataTables.DatatableFilters filters)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetAjaxData);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "filters", filters);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult GetPagedData(WebExtras.JQDataTables.DatatableFilters filters)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetPagedData);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "filters", filters);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult GetSortedData(WebExtras.JQDataTables.DatatableFilters filters)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetSortedData);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "filters", filters);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult GetPostbackData(WebExtras.JQDataTables.DatatableFilters filters, WebExtras.DemoApp.Models.Core.PostbackSetupViewModel postbacks)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetPostbackData);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "filters", filters);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "postbacks", postbacks);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Flot(int? mode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Flot);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mode", mode);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
