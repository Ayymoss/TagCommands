namespace TagCommands.Configuration;

public class TagConfiguration
{
    public List<TagCommand> TagCommands { get; set; } =
    [
        new TagCommand
        {
            Tag = "VIP",
            Commands =
            [
                new TagCommandContext
                {
                    Command = "map",
                    Alias = "m",
                    TargetPlayerRequired = false
                },
                new TagCommandContext
                {
                    Command = "say",
                    Alias = "s",
                    TargetPlayerRequired = false
                }
            ]
        },
        new TagCommand
        {
            Tag = "PayToWin",
            Commands =
            [
                new TagCommandContext
                {
                    Command = "kick",
                    Alias = "k",
                    TargetPlayerRequired = true
                }
            ]
        }
    ];

    public Translations Translations { get; set; } = new();
}
