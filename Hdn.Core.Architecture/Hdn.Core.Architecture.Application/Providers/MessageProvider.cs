using Hdn.Core.Architecture.Application.Interfaces.Providers;

namespace Hdn.Core.Architecture.Application.Providers
{
    public class MessageProvider : IMessageProvider
    {
        public string RequiredParameter(string parameter) => $"Parâmetro {parameter} é obrigatório.";

        public string RequiredField(string field) => $"Campo {field} é obrigatório.";

        public string RegisterNotFound(string key, string value) => $"Registro com o {key} = {value} não foi encontrado.";

        public string IncorrectFormat(string field) => $"Campo {field} está no formato incorreto.";
    }
}
