using AutoMapper;
using DebtRecovery.Domain.Commands;
using DebtRecovery.Domain.Models;
using DebtRecovery.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtRecovery.Api.DTOs.LocalDTOs;
using Microsoft.EntityFrameworkCore;

namespace DebtRecovery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromiseController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PromiseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Promise
        [HttpGet]
        public IEnumerable<PromiseDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Promise>(
                includes: i => i.Include(c => c.Bill).ThenInclude(c => c.Client)
                ))
                .Result.Select(comp => _mapper.Map<PromiseDTO>(comp));
        }


        [HttpGet("{id}")]
        public PromiseDTO Get(Guid id)
        {
            Promise Promise = _mediator.Send(new GetQuery<Promise>(condition: c => c.PromiseId == id, 
                includes: i => i.Include(c => c.Bill).ThenInclude(c => c.Client))).Result;
            return _mapper.Map<PromiseDTO>(Promise);
        }


        [HttpPost]
        public async Task<string> Post(Promise Promise)
        {
            await _mediator.Send(new PostCommand<Promise>(Promise));

            BillDTO billWithCustomer = _mapper.Map<BillDTO>( _mediator.Send(new GetQuery<Bill>(condition: c => c.BillId==Promise.FK_Bill,i=>i.Include(b=>b.Client))).Result);
            History history = new History() { Activity = "Ajouter Prommesse", Client = billWithCustomer.CustomerName, Bill_Num = billWithCustomer.Number, FK_Bill = Promise.FK_Bill, Agent_Name = "Farah" };
            _mediator.Send(new PostCommand<History>(history));

            return "Adeed Done";
        }


        [HttpPut]
        public async Task<string> Put(Promise Promise)
        {
            return await _mediator.Send(new PutCommand<Promise>(Promise));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Promise>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion

    }
}

