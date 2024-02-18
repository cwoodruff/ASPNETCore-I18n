using Microsoft.Extensions.Localization;

namespace CustomProvider;

public class CustomStringLocalizerFactory : IStringLocalizerFactory
{
    public IStringLocalizer Create(Type resourceSource)
    {
        return new CustomStringLocalizer();
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return new CustomStringLocalizer();
    }
}