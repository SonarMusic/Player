using Sonar.Player.Domain.Tools;

namespace Sonar.Player.Domain.Enumerations;

public class MediaFormat : Enumeration<string, MediaFormat>
{
    protected MediaFormat(string name, string format) 
        : base(name, format) { }

    protected MediaFormat() {}
}