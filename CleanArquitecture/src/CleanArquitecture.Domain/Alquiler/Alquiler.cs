using CleanArquitecture.Domain.Abstractions;
using CleanArquitecture.Domain.Alquiler.Events;
using CleanArquitecture.Domain.Shared;
using CleanArquitecture.Domain.Vehiculos;

namespace CleanArquitecture.Domain.Alquiler;

public sealed class Alquiler : Entity
{
    private Alquiler(
        Guid id,
        Guid vehiculoId,
        Guid userId,
        DateRange? duracion,
        Moneda? precioPorPeriodo,
        Moneda? mantenimiento,
        Moneda? accesorios,
        Moneda? precioTotal,
        AlquilerStatus status,
        DateTime? fechaCreacion
        
    ):base(id)
    {
        VehiculoId = vehiculoId;
        UserId = userId;
        Duracion = duracion;
        PrecioPorPeriodo = precioPorPeriodo;
        Mantenimiento = mantenimiento;
        Accesorios = accesorios;
        PrecioTotal = precioTotal;
        Status = status;
        FechaCreacion = fechaCreacion;
    }

    public Guid VehiculoId { get; private set; }

    public Guid UserId { get; private set; }

    public Moneda? PrecioPorPeriodo { get; set; }
    public Moneda? Mantenimiento { get; set; }

    public Moneda? Accesorios { get; set; }
    public Moneda?  PrecioTotal { get; set; }

    public AlquilerStatus Status { get; set; }

    public DateRange? Duracion { get; set; }

    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaConfirmacion { get; set; }
    public DateTime? FechaDenegacion { get; set; }
    public DateTime? FechaCancelacion { get; set; }
    public DateTime? FechaFinalizacion { get; set; }

    public static Alquiler Reservar(
        Vehiculo vehiculo,
        Guid userId,
        DateRange? duracion,
        DateTime? fechaCreacion,
        PrecioService precioService
    )
    {
        var precioDetalle = precioService.CalcularPrecio(vehiculo,duracion!);

        var alquiler = new Alquiler(
            Guid.NewGuid(),
            vehiculo.Id,
            userId,
            duracion,
            precioDetalle.PrecioPorPeriodo,
            precioDetalle.Mantenimiento,
            precioDetalle.Accesorios,
            precioDetalle.PrecioTotal,
            AlquilerStatus.Reservado,
            fechaCreacion
        );

        alquiler.RaiseDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id!));
        vehiculo.FechaUltimaAlquiler = fechaCreacion;

        return alquiler;
    }

    public Result Confirmar(DateTime utcNow)
    {
        if (Status != AlquilerStatus.Reservado)
        {
            return Result.Failure(AlquilerErrors.NotReserved);
        }

        Status = AlquilerStatus.Confirmado;
        FechaConfirmacion = utcNow;

        RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(Id!));

        return Result.Success();
    }

    public Result Rechazar(DateTime utcNow)
    {
        if (Status != AlquilerStatus.Reservado)
        {
            return Result.Failure(AlquilerErrors.NotReserved);
        }

        Status = AlquilerStatus.Rechazado;
        FechaDenegacion = utcNow;

        RaiseDomainEvent(new AlquilerRechazadoDomainEvent(Id!));

        return Result.Success();
    }

    public Result Cancelar(DateTime utcNow)
    {
        if (Status != AlquilerStatus.Confirmado)
        {
            return Result.Failure(AlquilerErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if(currentDate > Duracion!.Inicio)
        {
            return Result.Failure(AlquilerErrors.AlReadyStarted);
        }

        Status = AlquilerStatus.Cancelado;
        FechaCancelacion = utcNow;

        RaiseDomainEvent(new AlquilerCanceladoDomainEvent(Id!));

        return Result.Success();
    }

    public Result Finalizar(DateTime utcNow)
    {
        if (Status != AlquilerStatus.Confirmado)
        {
            return Result.Failure(AlquilerErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if(currentDate < Duracion!.Inicio)
        {
            return Result.Failure(AlquilerErrors.AlReadyStarted);
        }

        Status = AlquilerStatus.Finalizado;
        FechaFinalizacion = utcNow;
        RaiseDomainEvent(new AlquilerFinalizadoDomainEvent(Id!));

        return Result.Success();
    }
}
