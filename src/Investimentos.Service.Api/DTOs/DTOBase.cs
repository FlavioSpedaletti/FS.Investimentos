using Flunt.Notifications;

namespace Investimentos.Service.Api.DTOs
{
    public class DTOBase : Notifiable
    {
        public int Id { get; set; }
    }
}
