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
    public class BillController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BillController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Bill
        [HttpGet]
        public IEnumerable<BillDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Bill>())
                .Result.Select(comp => _mapper.Map<BillDTO>(comp));
        }


        [HttpGet("{id}")]
        public BillDTO Get(Guid id)
        {
            Bill Bill = _mediator.Send(new GetQuery<Bill>(condition: c => c.BillId == id)).Result;
            return _mapper.Map<BillDTO>(Bill);
        }


        [HttpPost]
        public async Task<string> Post(Bill Bill)
        {
            return await _mediator.Send(new PostCommand<Bill>(Bill));
        }


        [HttpPut]
        public async Task<string> Put(Bill Bill)
        {
            return await _mediator.Send(new PutCommand<Bill>(Bill));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Bill>(id));
        }
        #endregion

        #region Custom Web Methods

        [HttpGet("GetBillbycostumerId")]
        public async Task<IEnumerable<BillDTO>> GetBillbycostumerId(Guid ClientId)
        {
            return _mediator.Send(new GetListQuery<Bill>(condition: c => c.FK_Client == ClientId, includes: i => i.Include(e => e.Client)))
              .Result.Select(bill => _mapper.Map<BillDTO>(bill));
        }



        #endregion

    }
}
