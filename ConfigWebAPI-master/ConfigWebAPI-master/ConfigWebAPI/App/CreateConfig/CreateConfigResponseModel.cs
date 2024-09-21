namespace ConfigWebAPI.App.CreateConfig
{
    public class CreateConfigResponseModel
    {
        public int ID { get; set; }
        public string AppName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool? IsActıve { get; set; }
    }
}
