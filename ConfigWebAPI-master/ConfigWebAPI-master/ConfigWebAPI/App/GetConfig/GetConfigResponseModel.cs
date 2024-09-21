namespace ConfigWebAPI.App.GetConfig
{
    public class GetConfigResponseModel
    {
        public string AppName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool? IsActıve { get; set; }
    }
}
