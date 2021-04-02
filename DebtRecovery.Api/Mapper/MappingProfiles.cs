using AutoMapper;
using DebtRecovery.Api.Controllers;
using DebtRecovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Bill 

            CreateMap<Bill, BillDTO>()
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
        }

    }
}


