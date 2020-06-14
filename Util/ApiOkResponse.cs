namespace ManageUsersApi.Util
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result)
            :base(200)
        {
            Result = result;
        }
    }
}