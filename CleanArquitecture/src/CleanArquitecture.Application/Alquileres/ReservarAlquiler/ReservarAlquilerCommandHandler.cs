using CleanArquitecture.Application.Abstractions.Clock;
using CleanArquitecture.Application.Abstractions.Messaging;
using CleanArquitecture.Domain.Abstractions;
using CleanArquitecture.Domain.Alquiler;
using CleanArquitecture.Domain.Alquiler.Events;
using CleanArquitecture.Domain.User;
using CleanArquitecture.Domain.Vehiculos;

namespace CleanArquitecture.Application.Alquiler.ReservarAlquiler;

internal sealed class ReservarAlquilerCommandHandler :
    ICommandHandler<ReservarAlquilerCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly PrecioService _precioService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ReservarAlquilerCommandHandler(
        IUserRepository userRepository,
        IVehiculoRepository vehiculoRepository,
        IAlquilerRepository alquilerRepository,
        PrecioService precioService,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _precioService = precioService;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }


    
    
    public async Task<Result<Guid>> Handle(ReservarAlquilerCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result<Guid>.Failure<Guid>(UserErrors.NotFound);
        }

        var vehiculo = await _vehiculoRepository.GetByIdAsync(request.VehiculoId, cancellationToken);

        if (vehiculo is null)
        {
            return Result<Guid>.Failure<Guid>(VehiculoErrors.NotFound);
        }

        var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);

        if(await _alquilerRepository.IsOverlapAsync(vehiculo,duracion, cancellationToken))
        {
            return Result<Guid>.Failure<Guid>(AlquilerErrors.Overlap);
        }

        var alquiler = Domain.Alquiler.Alquiler.Reservar(
            vehiculo,
            user.Id,
            duracion,
            _dateTimeProvider.CurrentTime,
            _precioService
        );

        _alquilerRepository.Add(alquiler);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(alquiler.Id);

    }
}
