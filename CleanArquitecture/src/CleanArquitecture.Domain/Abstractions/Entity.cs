namespace CleanArquitecture.Domain.Abstractions;

// Clase base para las entidades
// Se encarga de manejar el id de la entidad
public class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity( Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }

    //Metodos para manejar los eventos de dominio
    //Estos eventos se usan para notificar a otras partes de la aplicacion que algo ha ocurrido
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    //Limpiar los eventos de dominio
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    //Agregar un evento de dominio
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
