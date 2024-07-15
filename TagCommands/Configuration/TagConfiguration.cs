namespace TagCommands.Configuration;

public class TagConfiguration
{
    public List<TagCommand> TagCommands { get; set; } =
    [
        new TagCommand
        {
            Tag = "VIP",
            Command = "map",
            Alias = "m",
            TargetPlayerRequired = false
        },
        new TagCommand
        {
            Tag = "PayToWin",
            Command = "kick",
            Alias = "k",
            TargetPlayerRequired = true
        }
    ];

    public Translations Translations { get; set; } = new();
}
