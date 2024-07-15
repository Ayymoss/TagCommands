using Microsoft.Extensions.DependencyInjection;
using SharedLibraryCore;
using SharedLibraryCore.Interfaces;
using SharedLibraryCore.Interfaces.Events;
using TagCommands.Configuration;

namespace TagCommands;

public class Plugin : IPluginV2
{
    public string Name => "Tag Commands";
    public string Author => "Amos";
    public string Version => "2024-07-15";

    public Plugin()
    {
        IManagementEventSubscriptions.Load += OnLoad;
    }

    public static void RegisterDependencies(IServiceCollection serviceProvider)
    {
        serviceProvider.AddConfiguration("TagConfiguration", new TagConfiguration());
    }

    private Task OnLoad(IManager manager, CancellationToken token)
    {
        Console.WriteLine($"[{Name}] loaded. Version: {Version}");
        return Task.CompletedTask;
    }
}
