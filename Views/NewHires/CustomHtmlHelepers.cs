using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IT_Control_Tower.Views.NewHires.Helpers
{
    public static class CustomHtmlHelepers
    {

        public static IHtmlString ImageActionLink(this HtmlHelper htmlHelper,
     string linkText, string action, string controller,
     object routeValues, object htmlAttributes, int lockStatus)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            //Unlocked
            if (lockStatus == 0)
            {
                img.Attributes.Add("src", VirtualPathUtility.ToAbsolute("~/Content/images/unlocked.png"));
            }
            else {
                img.Attributes.Add("src", VirtualPathUtility.ToAbsolute("~/Content/images/lock.png"));
            }
            img.Attributes.Add("style", "width:10px; margin-left: 15% ");
            var anchor = new TagBuilder("a")
            { InnerHtml = img.ToString(TagRenderMode.SelfClosing) };
            anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(anchor.ToString());
        }
    }

    }
