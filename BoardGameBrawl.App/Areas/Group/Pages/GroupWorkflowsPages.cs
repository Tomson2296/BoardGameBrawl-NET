#nullable disable
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoardGameBrawl.App.Areas.Group.Pages
{
    public static class GroupWorkflowsPages
    {
        public static string Index => "Index";

        public static string GroupParticipants => "Group Participants";

        public static string GroupTournaments => "Group Tournaments";

        public static string GroupAdmins => "Group Admins";


        public static string IndexNavClass(ViewContext viewContext, string groupName) =>
            PageNavGroupClassWithGroupNameParamether(viewContext, Index, groupName);

        public static string GroupParticipantsNavClass(ViewContext viewContext, string groupName) => 
            PageNavGroupClassWithGroupNameParamether(viewContext, GroupParticipants, groupName);

        public static string GroupTournamentsNavClass(ViewContext viewContext, string groupName) => 
            PageNavGroupClassWithGroupNameParamether(viewContext, GroupTournaments, groupName);

        public static string GroupAdminsNavClass(ViewContext viewContext, string groupName) =>
        PageNavGroupClassWithGroupNameParamether(viewContext, GroupAdmins, groupName);


        public static string PageNavGroupClassWithGroupNameParamether(ViewContext viewContext, string page, string groupName)
        {
            var activePage = viewContext.RouteData.Values["page"]?.ToString();
            var activeGroup = viewContext.RouteData.Values["GroupName"]?.ToString();
            var targetGroup = viewContext.HttpContext.Request.Query["GroupName"].ToString();

            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase)
                && string.Equals(activeGroup ?? targetGroup, groupName, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static string PageNavGroupClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
