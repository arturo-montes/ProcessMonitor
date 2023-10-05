using ProcessMonitor.Application.Features.ConfigurationStore.Queries.GetConfiguration;
using ProcessMonitor.Domain.Entities;

namespace ProcessMonitor.Application.Contracts;

public interface IGetConfigurationQueryHandler
{
    ConfigurationStore[] Handle(GetConfigurationDto request);
}