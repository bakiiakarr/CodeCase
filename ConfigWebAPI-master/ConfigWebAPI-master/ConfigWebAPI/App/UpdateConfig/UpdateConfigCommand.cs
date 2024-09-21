using MediatR;

namespace ConfigWebAPI.App.UpdateConfig
{
    public class UpdateConfigCommand:  IRequest<UpdateConfigResponseModel>
    {
        public int ConfigId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool? IsActıve { get; set; }
    }
}
