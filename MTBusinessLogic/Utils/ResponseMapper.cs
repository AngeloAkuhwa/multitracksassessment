using MTBusinessLogic.Model.Common;
using Newtonsoft.Json;

namespace MTBusinessLogic.Utils
{
    public class ResponseMapper
    {
        public static Response<T> Success<T>(dynamic param)
        {
            Response<T> response = new Response<T>();
            response.Message = "retrieved successfully";
            response.StatusCode = 200;
            response.Success = true;
            response.Data = JsonConvert.DeserializeObject<T>(param.ToString());
            return response;
        }

        public static Response<T> Error<T>()
        {
            return new Response<T>()
            {
                Message = "oops something went wrong",
                StatusCode = 400,
                Success = false,
            };
        }
    }
}
