
using CleanArquitecture.Application.Abstractions.Messaging;

namespace CleanArquitecture.Application.Alquileres.GetAlquiler;

public sealed record GetAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;
