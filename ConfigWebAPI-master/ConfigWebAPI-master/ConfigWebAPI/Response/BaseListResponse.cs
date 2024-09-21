namespace ConfigWebAPI.Response
{
    public class BaseListResponse<T>
    {
        public List<T> Items { get; set; }

        public int Total { get; set; }
    }
}
