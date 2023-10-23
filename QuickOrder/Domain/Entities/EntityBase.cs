using Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities
{
    public abstract class EntityBase : Notifiable, IValidatable
    {
        protected EntityBase(NomeVo nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Validate();
        }
        public Guid Id { get; set; }
        public NomeVo Nome { get; set; }

        public void Validate()
        {
            AddNotifications(
          new Contract()
          .IsTrue(Nome.Valid, "Nome", "Nome inválido"));
        }

        public override bool Equals(object obj)
        {
            EntityBase entity = obj as EntityBase;
            if ((object)this == entity)
            {
                return true;
            }

            if ((object)entity == null)
            {
                return false;
            }

            return Id.Equals(entity.Id);
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 0x5D) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
