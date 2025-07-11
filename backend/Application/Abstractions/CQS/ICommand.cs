﻿using FluentResults;
using MediatR;

namespace Application.Abstractions.CQS;

public interface IBaseCommand;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;
