using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ConfigWebAPI.App.CreateConfig
{
    public class CreateConfigCommand: IRequest<CreateConfigResponseModel>
    {
        [Required]
        public string AppName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public bool? IsActıve { get; set; }
    }
}
