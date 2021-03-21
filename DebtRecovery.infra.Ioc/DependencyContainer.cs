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
            

           

            #region User
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRequestHandler<PostCommand<User>, string>, PostHandler<User>>();
            services.AddTransient<IRequestHandler<PutCommand<User>, string>, PutHandler<User>>();
            services.AddTransient<IRequestHandler<DeleteCommand<User>, string>, DeleteHandler<User>>();
            services.AddTransient<IRequestHandler<GetListQuery<User>, IEnumerable<User>>, GetListHandler<User>>();
            services.AddTransient<IRequestHandler<GetQuery<User>, User>, GetHandler<User>>();

            #endregion

            #region Agent
            services.AddTransient<IRepository<RecoveryAgent>, Repository<RecoveryAgent>>();
            services.AddTransient<IRequestHandler<PostCommand<RecoveryAgent>, string>, PostHandler<RecoveryAgent>>();
            services.AddTransient<IRequestHandler<PutCommand<RecoveryAgent>, string>, PutHandler<RecoveryAgent>>();
            services.AddTransient<IRequestHandler<DeleteCommand<RecoveryAgent>, string>, DeleteHandler<RecoveryAgent>>();
            services.AddTransient<IRequestHandler<GetListQuery<RecoveryAgent>, IEnumerable<RecoveryAgent>>, GetListHandler<RecoveryAgent>>();
            services.AddTransient<IRequestHandler<GetQuery<RecoveryAgent>, RecoveryAgent>, GetHandler<RecoveryAgent>>();

            #endregion
            #region role
            services.AddTransient<IRepository<Role>, Repository<Role>>();
            services.AddTransient<IRequestHandler<PostCommand<Role>, string>, PostHandler<Role>>();
            services.AddTransient<IRequestHandler<PutCommand<Role>, string>, PutHandler<Role>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Role>, string>, DeleteHandler<Role>>();
            services.AddTransient<IRequestHandler<GetListQuery<Role>, IEnumerable<Role>>, GetListHandler<Role>>();
            services.AddTransient<IRequestHandler<GetQuery<Role>, Role>, GetHandler<Role>>();

            #endregion

            #region Promise
            services.AddTransient<IRepository<Promise>, Repository<Promise>>();
            services.AddTransient<IRequestHandler<PostCommand<Promise>, string>, PostHandler<Promise>>();
            services.AddTransient<IRequestHandler<PutCommand<Promise>, string>, PutHandler<Promise>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Promise>, string>, DeleteHandler<Promise>>();
            services.AddTransient<IRequestHandler<GetListQuery<Promise>, IEnumerable<Promise>>, GetListHandler<Promise>>();
            services.AddTransient<IRequestHandler<GetQuery<Promise>, Promise>, GetHandler<Promise>>();

            #endregion

            #region Bill
            services.AddTransient<IRepository<Bill>, Repository<Bill>>();
            services.AddTransient<IRequestHandler<PostCommand<Bill>, string>, PostHandler<Bill>>();
            services.AddTransient<IRequestHandler<PutCommand<Bill>, string>, PutHandler<Bill>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Bill>, string>, DeleteHandler<Bill>>();
            services.AddTransient<IRequestHandler<GetListQuery<Bill>, IEnumerable<Bill>>, GetListHandler<Bill>>();
            services.AddTransient<IRequestHandler<GetQuery<Bill>, Bill>, GetHandler<Bill>>();

            #endregion



            #region Note
            services.AddTransient<IRepository<Note>, Repository<Note>>();
            services.AddTransient<IRequestHandler<PostCommand<Note>, string>, PostHandler<Note>>();
            services.AddTransient<IRequestHandler<PutCommand<Note>, string>, PutHandler<Note>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Note>, string>, DeleteHandler<Note>>();
            services.AddTransient<IRequestHandler<GetListQuery<Note>, IEnumerable<Note>>, GetListHandler<Note>>();
            services.AddTransient<IRequestHandler<GetQuery<Note>, Note>, GetHandler<Note>>();

            #endregion

            #region History
            services.AddTransient<IRepository<History>, Repository<History>>();
            services.AddTransient<IRequestHandler<PostCommand<History>, string>, PostHandler<History>>();
            services.AddTransient<IRequestHandler<PutCommand<History>, string>, PutHandler<History>>();
            services.AddTransient<IRequestHandler<DeleteCommand<History>, string>, DeleteHandler<History>>();
            services.AddTransient<IRequestHandler<GetListQuery<History>, IEnumerable<History>>, GetListHandler<History>>();
            services.AddTransient<IRequestHandler<GetQuery<History>, History>, GetHandler<History>>();

            #endregion

            #region Payment
            services.AddTransient<IRepository<Payment>, Repository<Payment>>();
            services.AddTransient<IRequestHandler<PostCommand<Payment>, string>, PostHandler<Payment>>();
            services.AddTransient<IRequestHandler<PutCommand<Payment>, string>, PutHandler<Payment>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Payment>, string>, DeleteHandler<Payment>>();
            services.AddTransient<IRequestHandler<GetListQuery<Payment>, IEnumerable<Payment>>, GetListHandler<Payment>>();
            services.AddTransient<IRequestHandler<GetQuery<Payment>, Payment>, GetHandler<Payment>>();

            #endregion

            #region Scenario
            services.AddTransient<IRepository<Scenario>, Repository<Scenario>>();
            services.AddTransient<IRequestHandler<PostCommand<Scenario>, string>, PostHandler<Scenario>>();
            services.AddTransient<IRequestHandler<PutCommand<Scenario>, string>, PutHandler<Scenario>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Scenario>, string>, DeleteHandler<Scenario>>();
            services.AddTransient<IRequestHandler<GetListQuery<Scenario>, IEnumerable<Scenario>>, GetListHandler<Scenario>>();
            services.AddTransient<IRequestHandler<GetQuery<Scenario>, Scenario>, GetHandler<Scenario>>();

            #endregion


            #region RecovreyManager
            services.AddTransient<IRepository<RecoveryManager>, Repository<RecoveryManager>>();
            services.AddTransient<IRequestHandler<PostCommand<RecoveryManager>, string>, PostHandler<RecoveryManager>>();
            services.AddTransient<IRequestHandler<PutCommand<RecoveryManager>, string>, PutHandler<RecoveryManager>>();
            services.AddTransient<IRequestHandler<DeleteCommand<RecoveryManager>, string>, DeleteHandler<RecoveryManager>>();
            services.AddTransient<IRequestHandler<GetListQuery<RecoveryManager>, IEnumerable<RecoveryManager>>, GetListHandler<RecoveryManager>>();
            services.AddTransient<IRequestHandler<GetQuery<RecoveryManager>, RecoveryManager>, GetHandler<RecoveryManager>>();

            #endregion


            #region Activity
            services.AddTransient<IRepository<Activity>, Repository<Activity>>();
            services.AddTransient<IRequestHandler<PostCommand<Activity>, string>, PostHandler<Activity>>();
            services.AddTransient<IRequestHandler<PutCommand<Activity>, string>, PutHandler<Activity>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Activity>, string>, DeleteHandler<Activity>>();
            services.AddTransient<IRequestHandler<GetListQuery<Activity>, IEnumerable<Activity>>, GetListHandler<Activity>>();
            services.AddTransient<IRequestHandler<GetQuery<Activity>, Activity>, GetHandler<Activity>>();

            #endregion

            #region Client
            services.AddTransient<IRepository<Client>, Repository<Client>>();
            services.AddTransient<IRequestHandler<PostCommand<Client>, string>, PostHandler<Client>>();
            services.AddTransient<IRequestHandler<PutCommand<Client>, string>, PutHandler<Client>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Client>, string>, DeleteHandler<Client>>();
            services.AddTransient<IRequestHandler<GetListQuery<Client>, IEnumerable<Client>>, GetListHandler<Client>>();
            services.AddTransient<IRequestHandler<GetQuery<Client>, Client>, GetHandler<Client>>();

            #endregion


            #region Bill_trip
            services.AddTransient<IRepository<Bill_Trip>, Repository<Bill_Trip>>();
            services.AddTransient<IRequestHandler<PostCommand<Bill_Trip>, string>, PostHandler<Bill_Trip>>();
            services.AddTransient<IRequestHandler<PutCommand<Bill_Trip>, string>, PutHandler<Bill_Trip>>();
            services.AddTransient<IRequestHandler<DeleteCommand<Bill_Trip>, string>, DeleteHandler<Bill_Trip>>();
            services.AddTransient<IRequestHandler<GetListQuery<Bill_Trip>, IEnumerable<Bill_Trip>>, GetListHandler<Bill_Trip>>();
            services.AddTransient<IRequestHandler<GetQuery<Bill_Trip>, Bill_Trip>, GetHandler<Bill_Trip>>();

            #endregion

        }
    }
}
