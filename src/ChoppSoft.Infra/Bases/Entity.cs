using ChoppSoft.Infra.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ChoppSoft.Infra.Bases
{
    public class Entity : IHasTimestamps
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Active = true;
        }

        [Key]
        public Guid Id { get; private set; }
        public bool Active { get; private set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Activate() => Active = true;
        public void Disable() => Active = false;
    }
}
