namespace Hdn.Core.Architecture.Application.Interfaces.Providers
{
    public interface IMessageProvider
    {
        string RequiredParameter(string parameter);

        string RequiredField(string field);

        string RegisterNotFound(string key, string value);

        string IncorrectFormat(string field);
    }
}
