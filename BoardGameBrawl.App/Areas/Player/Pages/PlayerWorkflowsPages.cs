#nullable disable
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoardGameBrawl.App.Areas.Player.Pages
{
    public static class PlayerWorkflowsPages
    {
        public static string Index => "Index";

        public static string BGGCollection => "BGG Collection";

        public static string BoardgameFavourites => "Fav. Boardgames";

        public static string PlayerFriends => "Player Friends";

        public static string PlayerGroups => "Player Groups";

        public static string PlayerModeration => "Player Moderation";


        public static string IndexNavClass(ViewContext viewContext) => PageNavPlayerClass(viewContext, Index);

        public static string BGGCollectionNavClass(ViewContext viewContext) => PageNavPlayerClass(viewContext, BGGCollection);

        public static string BoardgameFavouritesNavClass(ViewContext viewContext) => PageNavPlayerClass(viewContext, BoardgameFavourites);

        public static string PlayerFriendsNavClass(ViewContext viewContext) => PageNavPlayerClass(viewContext, PlayerFriends);

        public static string PlayerGroupsNavClass(ViewContext viewContext) => PageNavPlayerClass(viewContext, PlayerGroups);

        public static string PlayerModerationNavClass(ViewContext viewContext) => PageNavPlayerClass(viewContext, PlayerModeration);



        public static string PageNavPlayerClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}