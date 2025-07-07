using FluentResults;
using MediatR;

namespace Application.Abstractions.CQS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
