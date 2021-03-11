﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Commands
{
  public  class DeleteCommand<T> : IRequest<string> where T : class
    {
        public DeleteCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }


    }
  
}
