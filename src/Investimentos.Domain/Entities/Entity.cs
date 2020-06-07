using Flunt.Notifications;

namespace Investimentos.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public int Id { get; set; }
    }
}
