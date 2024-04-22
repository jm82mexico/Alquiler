using CleanArquitecture.Domain.Abstractions;
using MediatR;

namespace CleanArquitecture.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}
