namespace TagCommands.Configuration;

public class TagCommand
{
    public required string Tag { get; set; }
    public required List<TagCommandContext> Commands { get; set; }
}
