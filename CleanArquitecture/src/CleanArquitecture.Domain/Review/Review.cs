using CleanArquitecture.Domain.Abstractions;
using CleanArquitecture.Domain.Alquiler;
using CleanArquitecture.Domain.Review.Events;

namespace CleanArquitecture.Domain.Review;

public sealed class Review : Entity
{

    private Review(
        Guid id,
        Guid vehiculoId,
        Guid alquilerId,
        Guid userId,
        Rating rating,
        Comentario comentario,
        DateTime? fechaCreacion
    ) : base(id)
    {
        VehiculoId = vehiculoId;
        AlquilerId = alquilerId;
        UserId = userId;
        Rating = rating;
        Comentario = comentario;
        FechaCreacion = fechaCreacion;
    }
    
    public Guid VehiculoId {get; private set;}
    public Guid AlquilerId {get;private set;}
    public Guid UserId {get;private set;}

    public Rating Rating {get; private set;}

    public Comentario Comentario {get; private set;}   

    public DateTime? FechaCreacion {get; private set;}   




    public static Result<Review> Create(
        Alquiler.Alquiler alquiler,
        Rating rating,
        Comentario comentario,
        DateTime fechaCreacion
    )
    {
        if(alquiler.Status != AlquilerStatus.Finalizado)
        {
            return Result.Failure<Review>(ReviewErrors.NotElegible);
        }

        var review = new Review(
            Guid.NewGuid(),
            alquiler.VehiculoId,
            alquiler.Id,
            alquiler.UserId,
            rating,
            comentario,
            fechaCreacion
        );

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return Result.Success(review);
    }


}