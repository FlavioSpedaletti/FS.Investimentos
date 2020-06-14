using Flunt.Notifications;

namespace Investimentos.Domain.Entities
{
    public abstract class EntityBase : Notifiable
    {
        public int Id { get; set; }
    }
}
