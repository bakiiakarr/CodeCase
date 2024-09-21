using ConfigWebAPI.App.Config;
using ConfigWebAPI.App.CreateConfig;
using ConfigWebAPI.App.GetConfig;
using ConfigWebAPI.App.UpdateConfig;
using ConfigWebAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConfigWebAPI.Controllers
{
    [ApiController]
    public class ConfigController : BaseController
    {
        [HttpPost("config")]
        public async Task<CreateConfigResponseModel> CreateConfig([FromQuery] CreateConfigCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("config/{configId}")]
        public async Task<UpdateConfigResponseModel> UpdateConfig([FromQuery] UpdateConfigCommand command, [FromRoute] int configId)
        {
            command.ConfigId = configId;

            return await Mediator.Send(command);
        }
        [HttpGet("config/{serviceName}")]
        public async Task<BaseListResponse<GetConfigResponseModel>> GetConfig([FromQuery] GetConfigCommand command, [FromRoute] string serviceName)
        {
            command.ServiceName = serviceName;

            return await Mediator.Send(command);
        }
    }
}
