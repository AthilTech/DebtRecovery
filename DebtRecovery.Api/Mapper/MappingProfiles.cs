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
                .ForMember(b => b.FK_Customer, i => i.MapFrom(src => src.Customer.CustomerId))
                .ForMember(c => c.CustomerName, i => i.MapFrom(src => src.Customer.Name))

             .ReverseMap();
               


        CreateMap<BillTrip, BillTripDTO>()
            .ForMember(c => c.FK_Bill, i => i.MapFrom(src => src.Bill.BillId)) 
            .ForMember(d => d.FK_Trip, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).TripId)) 
            .ReverseMap();

            CreateMap<BillTrip, TripInfoDTO>()
                //trip
                
                .ForMember(d => d.FK_Trip, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).TripId))
                .ForMember(d => d.Date, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).Date))
                .ForMember(d => d.Location, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).Location))
                .ForMember(d => d.Plannified, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).plannified))
                .ForMember(d => d.Description, i => i.MapFrom(src => TripCommunication.GetTripById(src.FK_Trip).Description))
                //bill
                .ForMember(c => c.FK_Bill, i => i.MapFrom(src => src.Bill.BillId))
                .ForMember(c => c.BillNumber, i => i.MapFrom(src => src.Bill.Number))
                //customer
                .ForMember(c => c.FK_Customer, i => i.MapFrom(src => src.Bill.Customer.CustomerId))
                .ForMember(c => c.CustomerName, i => i.MapFrom(src => src.Bill.Customer.Name))





                 .ReverseMap();
            #endregion
            #region RecoveryAgent 

            CreateMap<Agent, AgentDTO>()
       .ReverseMap();
            #endregion
            #region Activity 

            CreateMap<Activity, ActivityDTO>()
                .ForMember(a => a.date, opt => opt.MapFrom(src => src.BeforeDays == 0?src.date.AddDays(src.AfterDays ): src.date.AddDays(-src.BeforeDays)))
                .ReverseMap();
            
            #endregion
            #region Promise 

            CreateMap<Promise, PromiseDTO>()
               .ForMember(d => d.CustomerName, i => i.MapFrom(src => src.Bill.Customer.Name))
                 .ForMember(d => d.BillNumber, i => i.MapFrom(src => src.Bill.Number.ToString()))
                 .ReverseMap();
            #endregion
            #region Payment  

            CreateMap<Payment, PaymentDTO>()
                .ForMember(c =>c.FK_Bill, i=> i.MapFrom(src => src.Bill.BillId))
                .ForMember(c => c.BillNumber, i => i.MapFrom(src => src.Bill.Number))
                .ForMember(c => c.FK_Customer, i => i.MapFrom(src => src.Bill.Customer.CustomerId))
                .ForMember(c => c.CustomerName, i => i.MapFrom(src => src.Bill.Customer.Name))



       .ReverseMap();


            #endregion
            #region Role 

            CreateMap<Role, RoleDTO>()
       .ReverseMap();
            #endregion
            #region Scenario 

            CreateMap<Scenario, ScenarioDTO>()
                .ForMember(d => d.ActivitiesCount, i => i.MapFrom(src => src.Activities.Count))
                .ReverseMap();
            #endregion
            #region Note 

            CreateMap<Note, NoteDTO>()
                .ForMember(c => c.FK_Bill, i => i.MapFrom(src => src.Bill.BillId))
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
                .ForMember(d => d.CustomerAbreviation, i => i.MapFrom(src => src.Name.Trim()[0].ToString() + src.Name[src.Name.IndexOf(' ') + 1].ToString()))
                .ForMember(b => b.TotalPayed, i => i.MapFrom(src => src.Bills.Select(o => o.Payments.Sum(p => p.PayedAmount)).Sum()))
      
               .ReverseMap(); 
            CreateMap<Customer, CustomerInfoDTO>()

             .ForMember(b => b.TotalPayed, i => i.MapFrom(src => src.Bills.Select(o => o.Payments.Sum(p => p.PayedAmount)).Sum()))
             .ForMember(d => d.CustomerAbreviation, i => i.MapFrom(src => src.Name.Trim()[0].ToString() + src.Name[src.Name.IndexOf(' ') + 1].ToString()))
              .ForMember(b => b.NotPayed, i => i.MapFrom(src => src.Bills.Sum(b => b.Total) - src.Bills.Select(o => o.Payments.Sum(p => p.PayedAmount)).Sum())) //we need to find out what a bill has exactly thats how we can figure out how to do the amount needed
             .ReverseMap();
            #endregion



        }

    }
}





