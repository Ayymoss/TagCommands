namespace TagCommands.Configuration;

public class TagCommand
{
    public required string Tag { get; set; }
    public required string Command { get; set; }
    public required string Alias { get; set; }
    public required bool TargetPlayerRequired { get; set; }
}
