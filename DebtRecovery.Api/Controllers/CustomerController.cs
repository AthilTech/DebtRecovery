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
    public class CustomerController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Customer>())
                .Result.Select(comp => _mapper.Map<CustomerDTO>(comp));
        }


        [HttpGet("{id}")]
        public CustomerDTO Get(Guid id)
        {
            Customer Customer= _mediator.Send(new GetQuery<Customer>(condition: c => c.CustomerId == id)).Result;
            return _mapper.Map<CustomerDTO>(Customer);
        }


        [HttpPost]
        public async Task<string> Post(Customer Customer)
        {
            return await _mediator.Send(new PostCommand<Customer>(Customer));
        }


        [HttpPut]
        public async Task<string> Put(Customer Customer)
        {
            return await _mediator.Send(new PutCommand<Customer>(Customer));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Customer>(id));
        }
        #endregion

        #region Custom Web Methods 
        [HttpGet("in-litigation")]
        public IEnumerable<CustomerDTO> GetLitigation()
        {
            return _mediator.Send(new GetListQuery<Customer>(condition: c => c.Litigation))
                .Result.Select(comp => _mapper.Map<CustomerDTO>(comp));

        }
        [HttpGet("customer-info")]
        public CustomerInfoDTO getCustomerInfo(Guid id)
        {
            Customer Customer= _mediator.Send(new GetQuery<Customer>(condition: c => c.CustomerId == id,
                includes: i => i.Include(c => c.Bills).ThenInclude(b=>b.Payments))).Result;
            return _mapper.Map<CustomerInfoDTO>(Customer);
        }


        #endregion

    }
}
