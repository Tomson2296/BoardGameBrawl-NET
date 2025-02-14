#nullable disable
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoardGameBrawl.App.Areas.Player.Pages
{
    public static class PlayerWorkflowsPages
    {
        public static string Index => "Index";

        public static string BGGCollection => "BGG Collection";

        public static string BoardgameFavourites => "Fav. Boardgames";

        public static string PlayerVotes => "Player Votes";

        public static string PlayerFriends => "Player Friends";

        public static string PlayerGroups => "Player Groups";

        public static string PlayerModeration => "Player Moderation";


        public static string IndexNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, Index, playerName);

        public static string BGGCollectionNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, BGGCollection, playerName);

        public static string BoardgameFavouritesNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, BoardgameFavourites, playerName);

        public static string PlayerVotesNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, PlayerVotes, playerName);

        public static string PlayerFriendsNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, PlayerFriends, playerName);

        public static string PlayerGroupsNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, PlayerGroups, playerName);

        public static string PlayerModerationNavClass(ViewContext viewContext, string playerName) =>
            PageNavGroupClassWithPlayerNameParamether(viewContext, PlayerModeration, playerName);


        public static string PageNavGroupClassWithPlayerNameParamether(ViewContext viewContext, string page, string playerName)
        {
            var activePage = viewContext.RouteData.Values["page"]?.ToString();
            var activeUser = viewContext.RouteData.Values["UserName"]?.ToString();
            var targetUser = viewContext.HttpContext.Request.Query["GroupName"].ToString();

            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase)
                && string.Equals(activeUser ?? targetUser, playerName, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static string PageNavPlayerClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}