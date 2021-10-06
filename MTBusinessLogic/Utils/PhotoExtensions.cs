using System.Configuration;

namespace MTBusinessLogic.Utils
{
    public class PhotoExtensions
    {
        public static string[] GetPhotoExtensions()
        {
         return ConfigurationManager.AppSettings["PhotoSettings:Extensions"].Split(',');
        }

        public static int GetPhotoLength()
        {
            int number;

            int.TryParse(ConfigurationManager.AppSettings["PhotoSettings:photoLength"], out number);

            return number;
        }
    }
}
