using AutoMapper;
using DebtRecovery.Api.DTOs.LocalDTOs;
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

namespace DebtRecovery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bill_TripController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public Bill_TripController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/bill_trip
        [HttpGet]
        public IEnumerable<Bill_TripDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Bill_Trip>())
                .Result.Select(comp => _mapper.Map<Bill_TripDTO>(comp));
        }


        [HttpGet("{id}")]
        public Bill_TripDTO Get(Guid id)
        {
            Bill_Trip bill  = _mediator.Send(new GetQuery<Bill_Trip>(condition: c => c.Bill_TripId == id)).Result;
            return _mapper.Map<Bill_TripDTO>(bill);
        }


        [HttpPost]
        public async Task<string> Post(Bill_Trip bill)
        {
            return await _mediator.Send(new PostCommand<Bill_Trip>(bill));
        }


        [HttpPut]
        public async Task<string> Put(Bill_Trip bill)
        {
            return await _mediator.Send(new PutCommand<Bill_Trip>(bill));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Bill_Trip>(id));
        }
        #endregion




    }
}
