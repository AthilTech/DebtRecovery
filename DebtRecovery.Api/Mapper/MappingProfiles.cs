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
        SubsidiaryCommunication subsidiaryCommunication = new SubsidiaryCommunication();

        public MappingProfiles()
        {
            #region Bill 

            CreateMap<Bill, BillDTO>()
            .ForMember(c => c.FK_Customer, i => i.MapFrom(src => src.Customer.CustomerId))

             .ReverseMap();
               


        CreateMap<BillTrip, BillTripDTO>()
            .ForMember(c => c.FK_Bill, i => i.MapFrom(src => src.Bill.BillId)) 
            .ForMember(d => d.FK_Trip, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).TripId)) 
            .ForMember(d => d.Number, i => i.MapFrom(src => src.Bill.Number))
            .ForMember(d => d.Date, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).Date))


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
               .ForMember(d=>d.CustomerName,i=>i.MapFrom(src=>src.Bill.Customer.Name))
                 .ForMember(d => d.BillNumber, i => i.MapFrom(src => src.Bill.Number.ToString()))
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
            #region Customer

            CreateMap<Customer, CustomerDTO>()
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
            .ForMember(d => d.FK_Subsidiary, i => i.MapFrom(src => subsidiaryCommunication.GetSubsidiaryById(src.FK_Subsidiary).SubsidiaryId))
             .ForMember(f => f.SubsidiaryCode, i => i.MapFrom(src => subsidiaryCommunication.GetSubsidiaryById(src.FK_Subsidiary).SubsidiaryCode))
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


