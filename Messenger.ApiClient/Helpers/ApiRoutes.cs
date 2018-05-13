namespace Messenger.ApiClient.Helpers
{
    public static class ApiRoutes
    {
        public static string Login => @"api/auth/login";

        public static string Logout => @"api/auth/logout";

        public static string Regiser => @"api/auth/register";

        public static string CurrentUser => @"api/auth/currentuser";

        public static string AllMessages => @"api/messages/all";

        public static string AllUserMessages => @"api/user-messages/";
    }
}
