using DebtRecovery.Data.Repository;
using DebtRecovery.Domain.Commands;
using DebtRecovery.Domain.Handlers;
using DebtRecovery.Domain.Interfaces;
using DebtRecovery.Domain.Models;
using DebtRecovery.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DebtRecovery.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            

            #region TestModel

            services.AddTransient<IRepository<TestModel>, Repository<TestModel>>();
            services.AddTransient<IRequestHandler<PostCommand<TestModel>, string>, PostHandler<TestModel>>();
            services.AddTransient<IRequestHandler<PutCommand<TestModel>, string>, PutHandler<TestModel>>();
            services.AddTransient<IRequestHandler<DeleteCommand<TestModel>, string>, DeleteHandler<TestModel>>();
            services.AddTransient<IRequestHandler<GetListQuery<TestModel>, IEnumerable<TestModel>>, GetListHandler<TestModel>>();
            services.AddTransient<IRequestHandler<GetQuery<TestModel>, TestModel>, GetHandler<TestModel>>();

            #endregion


        }
    }
}
