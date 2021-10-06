namespace MTBusinessLogic.Utils
{
   public class RouteNavigator
   {
        public static string GetRout(string val)
        {
            switch (val)
            {
                case "login":
                    return "/login.aspx";

                case "sigUp":
                    return "SignUp.aspx";

               default:
                    break;
            }

            return val;
        }

   }

    public enum HTTPMethods
    {
        POST,
        GET
    }

    public enum Route
    {
        login = 1,
        SignUp = 2
    }
}
