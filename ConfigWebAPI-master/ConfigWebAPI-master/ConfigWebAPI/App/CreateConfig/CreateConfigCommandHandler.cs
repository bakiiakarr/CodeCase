using ConfigWebAPI.App.Config;
using ConfigWebAPI.App.GetConfig;
using ConfigWebAPI.Models;
using ConfigWebAPI.Response;
using MediatR;

namespace ConfigWebAPI.App.CreateConfig
{
    public class CreateConfigCommandHandler : IRequestHandler<CreateConfigCommand, CreateConfigResponseModel>
    {
        public ConfigDb1Context DbContext { get; set; }
        private readonly IConfiguration configuration;
        public CreateConfigCommandHandler(ConfigDb1Context _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }

        public async Task<CreateConfigResponseModel> Handle(CreateConfigCommand request, CancellationToken cancellationToken)
        {
            var newConfig = new Configuration
            {
                Name = request.Name,
                ApplicationName = request.AppName,
                IsActive = request.IsActıve,
                Type = request.Type,
                Value = request.Value
            };

            DbContext.Configurations.Add(newConfig);
            DbContext.SaveChanges();

            return new CreateConfigResponseModel
            {
                ID = newConfig.Id,
                Name = newConfig.Name,
                Type = newConfig.Type,
                Value = newConfig.Value,
                IsActıve = newConfig.IsActive,
                AppName = newConfig.ApplicationName
            };
        }
    } 
}

