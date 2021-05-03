using hdn.net._base.Application.DTOs.Email;
using System.Threading.Tasks;

namespace hdn.net._base.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
