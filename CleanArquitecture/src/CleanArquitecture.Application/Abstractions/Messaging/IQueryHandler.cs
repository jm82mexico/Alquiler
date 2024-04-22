
using CleanArquitecture.Domain.Abstractions;
using MediatR;

namespace CleanArquitecture.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery,TResponse>
: IRequestHandler<TQuery,Result<TResponse>>
where TQuery : IQuery<TResponse>
{
    
}
