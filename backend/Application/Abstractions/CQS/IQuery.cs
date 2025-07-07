using FluentResults;
using MediatR;

namespace Application.Abstractions.CQS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
