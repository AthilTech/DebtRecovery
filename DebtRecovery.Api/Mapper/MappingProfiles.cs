using AutoMapper;
using DebtRecovery.Api.Controllers;
using DebtRecovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtRecovery.Api.DTOs.LocalDTOs;
using DebtRecovery.Api.DTOs.ForeignDTOs;
using DebtRecovery.Api.HttpClientCommunications;
using System.Net.Http;



namespace DebtRecovery.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        TripCommunication TripCommunication = new TripCommunication();
        public MappingProfiles()
        {
            #region Bill 

            CreateMap<Bill, BillDTO>()
            .ForMember(c => c.FK_Customer, i => i.MapFrom(src => src.Customer.CustomerId))

             .ReverseMap();
            #endregion
            #region RecoveryAgent 

            CreateMap<Agent, AgentDTO>()
       .ReverseMap();
            #endregion
            #region Activity 

            CreateMap<Activity, ActivityDTO>()
       .ReverseMap();
            #endregion
            #region Promise 

            CreateMap<Promise, PromiseDTO>()
       .ReverseMap();
            #endregion
            #region Payment 

            CreateMap<Payment, PaymentDTO>()
       .ReverseMap();
            #endregion
            #region Role 

            CreateMap<Role, RoleDTO>()
       .ReverseMap();
            #endregion
            #region Scenario 

            CreateMap<Scenario, ScenarioDTO>()
       .ReverseMap();
            #endregion
            #region Note 

            CreateMap<Note, NoteDTO>()
       .ReverseMap();
            #endregion
            #region History 

            CreateMap<History, HistoryDTO>()
       .ReverseMap();
            #endregion
            #region RecoveryManager 

            CreateMap<Manager, ManagerDTO>()
       .ReverseMap();
            #endregion
            #region User 

            CreateMap<User, UserDTO>()
       .ReverseMap();
            #endregion
            #region Customer 
            CreateMap<Customer, CustomerDTO>()
               .ReverseMap();
            CreateMap<Customer, CustomerInfoDTO>()
             .ForMember(b => b.TotalPayed, i => i.MapFrom(src => src.Bills.Select(o => o.Payments.Sum(p => p.PayedAmount)).Sum()))
             .ReverseMap();


            #endregion



        }

    }
}


