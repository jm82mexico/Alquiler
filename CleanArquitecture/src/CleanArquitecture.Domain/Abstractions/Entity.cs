namespace CleanArquitecture.Domain.Abstractions
{
    // Clase base para las entidades
    // Se encarga de manejar el id de la entidad
    public class Entity
    {
        protected Entity( Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}