namespace TagCommands.Configuration;

public class TagConfiguration
{
    public List<TagCommand> TagCommands { get; set; } =
    [
        new TagCommand
        {
            Tag = "VIP",
            Command = "map",
            Aliases = ["m"],
            TargetPlayerRequired = false
        },
        new TagCommand
        {
            Tag = "PayToWin",
            Command = "kick",
            Aliases = ["k"],
            TargetPlayerRequired = true
        }
    ];

    public Translations Translations { get; set; } = new();
}
