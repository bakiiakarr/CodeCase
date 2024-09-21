using ConfigWebAPI.App.GetConfig;
using ConfigWebAPI.Response;
using MediatR;

namespace ConfigWebAPI.App.Config
{
    public class GetConfigCommand: IRequest<BaseListResponse<GetConfigResponseModel>>
    {
        public string ServiceName { get; set; }
    }
}
