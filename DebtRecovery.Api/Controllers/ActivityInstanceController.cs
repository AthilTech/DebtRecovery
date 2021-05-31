﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DebtRecovery.Api.DTOs.LocalDTOs;
using DebtRecovery.Api.statics;
using DebtRecovery.Domain.Commands;
using DebtRecovery.Domain.Models;
using DebtRecovery.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DebtRecovery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityInstanceController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ActivityInstanceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region standard WebMethods
        // GET: api/ActivityInstance
        [HttpGet]
        public IEnumerable<ActivityInstanceDTO> Get()
        {

            return _mediator.Send(new GetListQuery<ActivityInstance>())
                .Result.Select(comp => _mapper.Map<ActivityInstanceDTO>(comp));
        }

        // GET: api/ActivityInstance/5
        [HttpGet("{id}")]
        public ActivityInstanceDTO Get(Guid id)
        {
            ActivityInstance activityInstance = _mediator.Send(new GetQuery<ActivityInstance>(condition: ai => ai.ActivityInstanceId == id)).Result;
            return _mapper.Map<ActivityInstanceDTO>(activityInstance);
        }

        // POST: api/ActivityInstance
        [HttpPost]
        public async Task<string> Post(ActivityInstance activityInstance)
        {
            activityInstance.ActionDate = DateTime.Now;
            return await _mediator.Send(new PostCommand<ActivityInstance>(activityInstance));
        }

        // PUT: api/ActivityInstance/5
        [HttpPut]
        public async Task<string> Put(ActivityInstance activityInstance)
        {
            return await _mediator.Send(new PutCommand<ActivityInstance>(activityInstance));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<ActivityInstance>(id));
        }

        #endregion

        #region Custom WebMethods
        [HttpGet("generated-activity-instances")]
        public IEnumerable<GeneratedActivityInstanceDTO> GetGeneratedActivityInstances()
        {

            List<GeneratedActivityInstanceDTO> allGeneratedActivityInstanceDTOs = new List<GeneratedActivityInstanceDTO>() { };
            var allBills = _mediator.Send(new GetListQuery<Bill>(includes: i => i.Include(e => e.Customer)
             .ThenInclude(c => c.Scenario).ThenInclude(s => s.Activities))).Result;
            foreach (var bill in allBills)
            {
                allGeneratedActivityInstanceDTOs.AddRange(GenerateActivitiInstances(bill, DateTime.Now, DateTime.Now));
            }
            return allGeneratedActivityInstanceDTOs;


        }
        [HttpGet("generated-activity-instances-by-date")]
        public IEnumerable<GeneratedActivityInstanceDTO> GetGeneratedTodayActivityInstances(DateTime? startdate, DateTime? enddate)
        {

            List<GeneratedActivityInstanceDTO> allGeneratedActivityInstanceDTOs = new List<GeneratedActivityInstanceDTO>() { };
            var allBills = _mediator.Send(new GetListQuery<Bill>(includes: i => i.Include(e => e.Customer)
             .ThenInclude(c => c.Scenario).ThenInclude(s => s.Activities))).Result;
            if (startdate != null && enddate != null)
            {
                foreach (var bill in allBills)
                {
                    allGeneratedActivityInstanceDTOs.AddRange(GenerateActivitiInstances(bill, startdate.Value, enddate.Value));
                }

            }
            else
            {
                foreach (var bill in allBills)
                {
                    allGeneratedActivityInstanceDTOs.AddRange(GenerateActivitiInstances(bill, DateTime.Now, DateTime.Now));
                }
            }

            return allGeneratedActivityInstanceDTOs;





        }



        [HttpGet("Acivity-by-customer-id")]
        public async Task<IEnumerable<GeneratedActivityInstanceDTO>> GetActivitybycostumerId(Guid customerId)
        {
            return _mediator.Send(new GetListQuery<ActivityInstance>(condition: c => c.CustomerId == customerId, includes: i => i.Include(e => e.Bill)))

             .Result.Select(activity => _mapper.Map<GeneratedActivityInstanceDTO>(activity));
        }
        #endregion

        #region Not web Methods
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<GeneratedActivityInstanceDTO> GenerateActivitiInstances(Bill bill, DateTime startdate, DateTime enddate)
        {
            //Expression<Func<Activity, bool>> condition = null,
            //Func< IQueryable<T>, IIncludableQueryable<T, object> > includes = null
            List<GeneratedActivityInstanceDTO> generatedActivityInstanceDTOs = new List<GeneratedActivityInstanceDTO>() { };
            var currentCustomerScenarioActivities = bill.Customer.Scenario.Activities.Where(a => a.IsAuto == false && a.isActive && a.Scenario.IsActive);

            foreach (var activity in currentCustomerScenarioActivities)
            {
                ActivityInstance activityInstance = _mediator.Send(new GetQuery<ActivityInstance>(condition: ai => ai.FK_bill == bill.BillId && ai.Fk_ScenarioActivity == activity.ActivityId)).Result;

                if(activityInstance!=null)
                {
                    generatedActivityInstanceDTOs.Add(new GeneratedActivityInstanceDTO()
                    {
                        //activityInstance
                        ActivityInstanceId=activityInstance.ActivityInstanceId,
                        PlanedDate =activityInstance.PlanedDate,
                        Description = activityInstance.Description,
                        MediaType = activityInstance.MediaType,
                        ScenarioActivityName = activityInstance.ScenarioActivityName,
                        Fk_ScenarioActivity = activityInstance.Fk_ScenarioActivity,
                        IsAchieved = true,
                        SuccessState=activityInstance.SuccessState,
                        Type = activity.Type,

                        //bill
                        BillNumber = bill.Number,
                        FK_bill = bill.BillId,
                        BillAmount = bill.Total,

                        //Customer
                        CustomerName = bill.Customer.Name,
                        CustomerId = bill.FK_Customer,
                        CustomerPhoneNumber = bill.Customer.PhoneNumber,
                        CustumerEmail = bill.Customer.Email,

                        //scenario
                        ScenarioLabel = activity.Scenario.ScenarioLabel


                    });
                }
                else if (bill.Deadline.AddDays(activity.Type == "thoughtfulness" ? activity.BeforeDays * -1 : activity.AfterDays).Date.InRange(startdate, enddate))
                {
                    generatedActivityInstanceDTOs.Add(new GeneratedActivityInstanceDTO()
                    {
                        //activityInstance

                        PlanedDate = bill.Deadline.AddDays(activity.Type == "thoughtfulness" ? activity.BeforeDays * -1 : activity.AfterDays).Date,
                       
                        MediaType = activity.Media,
                        ScenarioActivityName = activity.ActivityLabel,
                        Fk_ScenarioActivity = activity.ActivityId,
                        IsAchieved = false,
                        Type =activity.Type,

                        //bill
                        BillNumber = bill.Number,
                        FK_bill = bill.BillId,
                        BillAmount = bill.Total,

                        //Customer
                        CustomerName = bill.Customer.Name,
                        CustomerId = bill.FK_Customer,
                        CustomerPhoneNumber=bill.Customer.PhoneNumber,
                        CustumerEmail=bill.Customer.Email,
                        //scenario
                        ScenarioLabel = activity.Scenario.ScenarioLabel


                    });
                }

            }
            return generatedActivityInstanceDTOs;

        }
        #endregion
    }
}