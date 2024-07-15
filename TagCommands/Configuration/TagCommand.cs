namespace TagCommands.Configuration;

public class TagCommand
{
    public required string Tag { get; set; }
    public required string Command { get; set; }
    public required List<string> Aliases { get; set; }
    public required bool TargetPlayerRequired { get; set; }
}
