using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Commands
{
    public class PostCommand<T> : IRequest<string> where T : class
    {
        public T Obj { get; }
        public PostCommand(T obj)
        {
            Obj = obj;
        }

    }

}
