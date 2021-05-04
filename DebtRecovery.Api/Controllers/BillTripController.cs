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
    public class BillTripController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BillTripController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/BillTrip
        [HttpGet]
        public IEnumerable<BillTripDTO> Get()
        {
            return _mediator.Send(new GetListQuery<BillTrip>())
                .Result.Select(comp => _mapper.Map<BillTripDTO>(comp));
        }


        [HttpGet("{id}")]
        public BillTripDTO Get(Guid id)
        {
            BillTrip bill  = _mediator.Send(new GetQuery<BillTrip>(condition: c => c.BillTripId == id)).Result;
            return _mapper.Map<BillTripDTO>(bill);
        }


        [HttpPost]
        public async Task<string> Post(BillTrip bill)
        {
            return await _mediator.Send(new PostCommand<BillTrip>(bill));
        }


        [HttpPut]
        public async Task<string> Put(BillTrip bill)
        {
            return await _mediator.Send(new PutCommand<BillTrip>(bill));
        }


        [HttpDelete("{id}")]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<BillTrip>(id));
        }
        #endregion




    }
}
