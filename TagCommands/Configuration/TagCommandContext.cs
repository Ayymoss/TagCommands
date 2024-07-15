namespace TagCommands.Configuration;

public class TagCommandContext
{
    public required string Command { get; set; }
    public required string Alias { get; set; }
    public required bool TargetPlayerRequired { get; set; }
}
