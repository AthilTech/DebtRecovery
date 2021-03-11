﻿using DebtRecovery.Domain.Commands;
using DebtRecovery.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DebtRecovery.Domain.Handlers
{
   public class DeleteHandler<T> : IRequestHandler<DeleteCommand<T>, string> where T : class
    {

        private readonly IRepository<T> repository;
        public DeleteHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            var result = repository.RemoveById(request.Id);
            return Task.FromResult(result);
        }


    }

}
