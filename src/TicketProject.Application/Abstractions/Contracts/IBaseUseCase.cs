using FastResults.Results;
using MediatR;

namespace TicketProject.Application.Abstractions.Contracts;

public interface IBaseUseCase<in TRequest> : IRequestHandler<TRequest, BaseResult>
    where TRequest : IRequestUseCase
{
}

public interface IBaseUseCase<in TRequest, TResponse> : IRequestHandler<TRequest, BaseResult<TResponse>>
    where TRequest : IRequestUseCase<TResponse>
{
}