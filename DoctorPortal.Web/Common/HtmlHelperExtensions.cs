using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Models;
// ReSharper disable All

namespace DoctorPortal.Web.Common
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GenerateMenu(this HtmlHelper helper)
        {
            var parentMenuList = ProjectSession.UserAccessPermissions.Where(x => x.ParentMenuId == null).OrderBy(item => item.DisplayOrder).ToList();
            var childMenuList = ProjectSession.UserAccessPermissions.Where(x => x.ParentMenuId != null).OrderBy(item => item.DisplayOrder).ToList();

            if (parentMenuList.Any())
            {
                var ul = new TagBuilder("ul");
                ul.MergeAttribute("class", "nav nav-sidebar");
                ul.MergeAttribute("data-nav-type", "accordion");

                var sb = new StringBuilder();

                var maintagfirstspan = itag("icon-menu");

                var divtag = new TagBuilder("div");
                divtag.MergeAttribute("class", "text-uppercase font-size-xs line-height-xs");
                divtag.InnerHtml = "Main";

                var liWithformaintag = new TagBuilder("li");
                liWithformaintag.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(divtag), Convert.ToString(maintagfirstspan));
                liWithformaintag.AddCssClass("nav-item-header");

                sb.Append(Convert.ToString(liWithformaintag));

                foreach (var menu in parentMenuList)
                {
                    var childList = childMenuList.Where(x => x.ParentMenuId == menu.MenuId).ToList();

                    if (childList.Any())
                    {
                        var sbChild = new StringBuilder();

                        var liWithChild = new TagBuilder("li");
                        liWithChild.AddCssClass("nav-item nav-item-submenu");

                        var firstSpan = itag(menu.ImagePath);

                        var secondSpan = SpanTag("");
                        secondSpan.InnerHtml = Convert.ToString(menu.MenuName);

                        var aLink = AnchorLink(menu.Action, menu.Controller, false);
                        aLink.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(firstSpan), Convert.ToString(secondSpan));

                        var ulChild = new TagBuilder("ul");
                        ulChild.AddCssClass("nav nav-group-sub");
                        ulChild.MergeAttribute("data-submenu-title", Convert.ToString(menu.MenuName));

                        foreach (var childMenu in childList)
                        {

                            var firstSpanchild = itag(childMenu.ImagePath);

                            var secondSpanchild = SpanTag("");
                            secondSpanchild.InnerHtml = Convert.ToString(childMenu.MenuName);

                            var aLinkchild = AnchorLink(childMenu.Action, childMenu.Controller, false);
                            aLinkchild.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(firstSpanchild), Convert.ToString(secondSpanchild));

                            var liWithforchild = new TagBuilder("li");
                            liWithforchild.InnerHtml = Convert.ToString(aLinkchild);
                            liWithforchild.AddCssClass("nav-item");
                            
                            sbChild.Append(Convert.ToString(liWithforchild));

                        }

                        ulChild.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}", Convert.ToString(sbChild));
                        liWithChild.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(aLink), Convert.ToString(ulChild));
                        sb.Append(Convert.ToString(liWithChild));
                    }
                    else
                    {
                        var firstSpan = itag(menu.ImagePath);

                        var secondSpan = SpanTag("");
                        secondSpan.InnerHtml = Convert.ToString(menu.MenuName);

                        var aLink = AnchorLink(menu.Action, menu.Controller, false);
                        aLink.InnerHtml = string.Format(CultureInfo.InvariantCulture, "{0}{1}", Convert.ToString(firstSpan), Convert.ToString(secondSpan));

                        var liWithChild = new TagBuilder("li");
                        liWithChild.InnerHtml = Convert.ToString(aLink);
                        liWithChild.AddCssClass("nav-item");
                        sb.Append(Convert.ToString(liWithChild));
                    }
                }

                ul.InnerHtml = sb.ToString();
                return MvcHtmlString.Create(ul.ToString());
            }

            return MvcHtmlString.Empty;
        }

        private static TagBuilder AnchorLink(string actionName, string controllerName, bool isParent)
        {
            var aLink = new TagBuilder("a");
            aLink.MergeAttribute("class", "nav-link");

            //if (isParent)
            //{
            //    aLink.MergeAttribute("class", "dropdown-toggle");
            //    aLink.MergeAttribute("data-action", "click-trigger");
            //}

            if (string.IsNullOrEmpty(actionName) || string.IsNullOrEmpty(controllerName))
            {
                aLink.MergeAttribute("href", "javascript:void(0);");
            }
            else
            {
                aLink.MergeAttribute("id", controllerName);
                aLink.MergeAttribute("href", ConfigItems.SiteRootPathUrl + "/" + controllerName + "/" + actionName);
            }
            return aLink;
        }

        private static TagBuilder SpanTag(string className)
        {
            var span = new TagBuilder("span");
            span.MergeAttribute("class", className);
            return span;
        }

        private static TagBuilder itag(string className)
        {
            var itag = new TagBuilder("i");
            itag.MergeAttribute("class", className);
            return itag;
        }
    }
}