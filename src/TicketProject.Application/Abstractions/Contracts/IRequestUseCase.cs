using FastResults.Results;
using MediatR;

namespace TicketProject.Application.Abstractions.Contracts;

public interface IRequestUseCase : IRequest<BaseResult>
{
}

public interface IRequestUseCase<TResponse> : IRequest<BaseResult<TResponse>>
{
}