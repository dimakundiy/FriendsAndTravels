using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAndTravel.Views.ProfileEdit
{
    public static class ManageNavPages
    {

        public static string ActivePageKey => "ActivePage";
        public static string Index => "Index";
        public static string ChooseCategories => "ChooseCategories";
        public static string ChangePassword => "ChangePassword";
        public static string ChangeAvatar => "ChangeAvatar";
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string ChangeAvatarNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangeAvatar);
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
        public static string ChooseCategoriesNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChooseCategories);
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
