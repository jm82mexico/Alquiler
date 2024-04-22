
using CleanArquitecture.Application.Abstractions.Email;
using CleanArquitecture.Domain.Alquiler.Events;
using CleanArquitecture.Domain.User;
using MediatR;

namespace CleanArquitecture.Application.ReservarAlquiler;

public class ReservarAlquilerDomainEventHandler
: INotificationHandler<AlquilerReservadoDomainEvent>
{
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public ReservarAlquilerDomainEventHandler(
        IAlquilerRepository alquilerRepository,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _alquilerRepository = alquilerRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }
    public async Task Handle(AlquilerReservadoDomainEvent notification, CancellationToken cancellationToken)
    {
        var alquiler = await _alquilerRepository.GetByIdAsync(notification.AlquilerId,cancellationToken);

        if (alquiler == null)
        {
            return;
        }

        var user = await _userRepository.GetByIdAsync(alquiler.UserId, cancellationToken);

        if (user == null)
        {
            return;
        }

        await _emailService.SendAsync
        (user.Email!, "Alquiler Reservado", 
        $"El alquiler {alquiler.Id} ha sido reservado correctamente");
    }
}
