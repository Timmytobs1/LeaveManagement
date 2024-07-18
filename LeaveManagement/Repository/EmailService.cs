using LeaveManagement.Interface;
using FluentEmail.Core;
namespace LeaveManagement.Repository
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _email;

        public EmailService (IFluentEmail email)
        {
            _email = email;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            await _email
                .To(to)
                .Subject(subject)
                .Body(body)
                .SendAsync();
        }

    }
}
