using Data.Models.Client;
using SharedLibraryCore;
using SharedLibraryCore.Commands;
using SharedLibraryCore.Configuration;
using SharedLibraryCore.Interfaces;
using TagCommands.Configuration;

namespace TagCommands.Commands;

public class TagCommand : Command
{
    private readonly IRemoteCommandService _remoteCommandService;
    private readonly TagConfiguration _tagConfig;

    public TagCommand(IRemoteCommandService remoteCommandService, TagConfiguration tagConfig, CommandConfiguration config,
        ITranslationLookup layout) : base(config, layout)
    {
        _remoteCommandService = remoteCommandService;
        _tagConfig = tagConfig;
        Name = "tagcommand";
        Description = tagConfig.Translations.CommandDescription ;
        Alias = "tc";
        Permission = EFClient.Permission.User;
        RequiresTarget = false;
        Arguments =
        [
            new CommandArgument
            {
                Name = tagConfig.Translations.CommandArgument,
                Required = true
            },
            new CommandArgument
            {
                Name = tagConfig.Translations.ArgumentsArgument,
                Required = false
            }
        ];
    }

    public override async Task ExecuteAsync(GameEvent gameEvent)
    {
        var fullArgs = gameEvent.Data.Split(' ');
        var parsedCommand = fullArgs.First();
        var arguments = fullArgs.Skip(1).ToArray();

        var userCommands = _tagConfig.TagCommands.Where(x => x.Tag.Equals(gameEvent.Origin.Tag, StringComparison.CurrentCultureIgnoreCase));
        var tagCommand = userCommands.FirstOrDefault(x => x.Command.Equals(parsedCommand, StringComparison.CurrentCultureIgnoreCase));
        tagCommand ??= _tagConfig.TagCommands
            .FirstOrDefault(x => x.Aliases.Contains(parsedCommand, StringComparer.CurrentCultureIgnoreCase));

        if (string.IsNullOrWhiteSpace(tagCommand?.Command))
        {
            gameEvent.Origin.Tell(_tagConfig.Translations.NoCommandOrAccess);
            return;
        }

        int? targetId = null;
        if (tagCommand.TargetPlayerRequired)
        {
            var player = arguments.First();
            var target = gameEvent.Owner.GetClientByName(player).FirstOrDefault();
            if (target is null)
            {
                gameEvent.Origin.Tell(_tagConfig.Translations.PlayerNotFound);
                return;
            }

            targetId = target.ClientId;
            arguments = arguments.Skip(1).ToArray();
        }

        var results = await _remoteCommandService
            .Execute(1, targetId, tagCommand.Command, arguments, gameEvent.Owner);

        if (results is null) return;

        foreach (var result in results)
        {
            gameEvent.Origin.Tell(result.Response);
        }
    }
}
