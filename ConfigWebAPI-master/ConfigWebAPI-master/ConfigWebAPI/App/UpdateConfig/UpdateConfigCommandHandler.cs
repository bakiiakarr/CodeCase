using ConfigWebAPI.Models;
using MediatR;

namespace ConfigWebAPI.App.UpdateConfig
{
    public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, UpdateConfigResponseModel>
    {
        public ConfigDb1Context DbContext { get; set; }
        private readonly IConfiguration configuration;

        public UpdateConfigCommandHandler(ConfigDb1Context _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<UpdateConfigResponseModel> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            var service = DbContext.Configurations.FirstOrDefault(x => x.Id == request.ConfigId);

            if (service == null)
            {
                throw new BadHttpRequestException("ServiceId Not Found!");
            }

            if (request.Name != null)
            {
                service.Name = request.Name;
            }
            else if (request.Type != null)
            {
                service.Type = request.Type;
            }
            else if (request.Value != null)
            {
                service.Value = request.Value;
            }
            else if (request.IsActıve != null)
            {
                service.IsActive = request.IsActıve;
            }

            DbContext.Configurations.Update(service);
            await DbContext.SaveChangesAsync();

            return new UpdateConfigResponseModel { IsSuccess = true };
        }
    }
}
