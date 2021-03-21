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
    public class PaymentController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PaymentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }


        #region Standard WebMethods
        // GET: api/Payment
        [HttpGet]
        public IEnumerable<PaymentDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Payment>())
                .Result.Select(comp => _mapper.Map<PaymentDTO>(comp));
        }


        [HttpGet("{id}")]
        public PaymentDTO Get(Guid id)
        {
            Payment payment = _mediator.Send(new GetQuery<Payment>(condition: c => c.PaymentID == id)).Result;
            return _mapper.Map<PaymentDTO>(payment);
        }


        [HttpPost]
        public async Task<string> Post(Payment payment)
        {
            return await _mediator.Send(new PostCommand<Payment>(payment));
        }


        [HttpPut]
        public async Task<string> Put(Payment payment)
        {
            return await _mediator.Send(new PutCommand<Payment>(payment));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Payment>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion


    }
}
