﻿using MediatR;
using Sonar.Player.Application.Tools;
using Sonar.Player.Application.Tools.Exceptions;
using Sonar.Player.Data;
using Sonar.Player.Domain.Entities;
using Sonar.Player.Domain.Models;

namespace Sonar.Player.Application.Queue.Commands;

public static class PurgeQueue
{
    public record Command(User User) : IRequest<Response>;

    public record Response();

    public class CommandHandler : IRequestHandler<Command, Response>
    {
        private readonly PlayerDbContext _dbContext;

        public CommandHandler(PlayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var context = _dbContext.Contexts.GetOrCreateContext(request.User);
            context.Queue.Purge();
            _dbContext.Contexts.Update(context);
            return new Response();
        }
    }
}