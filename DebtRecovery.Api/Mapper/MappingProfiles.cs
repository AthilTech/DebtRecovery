using AutoMapper;
using DebtRecovery.Api.DTOs.LocalDTOs;
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
            CreateMap<Role, RoleDTO>()
                .ReverseMap();

            CreateMap<History, HistoryDTO>()
                    .ReverseMap();


            CreateMap<Payment, PaymentDTO>()
                   .ReverseMap();



            CreateMap<Promise, PromiseDTO>()
                 .ReverseMap();


            CreateMap<Bill, BillDTO>()
               .ReverseMap();


            CreateMap<Note, NoteDTO>()
               .ReverseMap();

            CreateMap<RecoveryAgent, RecoveryAgentDTO>()
               .ReverseMap();

            CreateMap<User, UserDTO>()
               .ReverseMap();



            CreateMap<RecoveryManager, RecoveryManagerDTO>()
               .ReverseMap();



            CreateMap<Scenario, ScenarioDTO>()
               .ReverseMap();


            CreateMap<Activity,ActivityDTO>()
               .ReverseMap();


            CreateMap<Client, ClientDTO>()
               .ReverseMap();


            CreateMap<Bill_Trip, Bill_TripDTO>()
               .ReverseMap();
        }
    }
}
