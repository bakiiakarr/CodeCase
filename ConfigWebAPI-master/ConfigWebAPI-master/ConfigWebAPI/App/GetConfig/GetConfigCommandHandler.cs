using ConfigWebAPI.App.Config;
using ConfigWebAPI.Models;
using ConfigWebAPI.Response;
using MediatR;
using System.Reflection.Emit;

namespace ConfigWebAPI.App.GetConfig
{
    public class GetConfigCommandHandler: IRequestHandler<GetConfigCommand,BaseListResponse<GetConfigResponseModel>>
    {
        public ConfigDb1Context DbContext { get; set; }
        private readonly IConfiguration configuration;
        public GetConfigCommandHandler(ConfigDb1Context _dbContext,IConfiguration _configuration) 
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }

        public async Task<BaseListResponse<GetConfigResponseModel>> Handle (GetConfigCommand request,CancellationToken cancellationToken)
        {
            var serviceList = DbContext.Configurations.ToList();

            var service = serviceList.Where(x => x.ApplicationName == request.ServiceName).ToList().Select(q => new GetConfigResponseModel
            {
                AppName = q.ApplicationName,
                Name = q.Name,
                Type = q.Type,
                Value = q.Value,
                IsActıve = q.IsActive
            }).ToList();

            if (service == null)
            {
                throw new BadHttpRequestException("Service Configurations Not Found !");
            }

            return new BaseListResponse<GetConfigResponseModel>
            {
                Items = service,
                Total = service.Count()
            };
        }
    }
}
