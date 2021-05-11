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
            return _mediator.Send(new GetListQuery<Payment>(null, includes: i => i.Include(b => b.Bill).ThenInclude(b => b.Customer)))
                .Result.Select(comp => _mapper.Map<PaymentDTO>(comp));

        }


        [HttpGet("{id}")]
        public PaymentDTO Get(Guid id)
        {
            Payment Payment = _mediator.Send(new GetQuery<Payment>(condition: c => c.PaymentId == id, includes: i => i.Include(b => b.Bill).ThenInclude(b => b.Customer))).Result;
            return _mapper.Map<PaymentDTO>(Payment);
        }


        [HttpPost]
        public async Task<string> Post(Payment Payment)
        {
            return await _mediator.Send(new PostCommand<Payment>(Payment));
        }


        [HttpPut]
        public async Task<string> Put(Payment Payment)
        {
            return await _mediator.Send(new PutCommand<Payment>(Payment));
        }


        [HttpDelete("{id}")]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Payment>(id));
        }
        #endregion

        #region Custom Web Methods
        // GET: api/Payment
        [HttpGet("payments-by-date-today")]

        public IEnumerable<PaymentDTO> GetPaymentsForToday()
        {

            return _mediator.Send(new GetListQuery<Payment>(condition: src => src.DueDate.Date== DateTime.Now.Date, includes: i => i.Include(b => b.Bill).ThenInclude(b => b.Customer)))
                .Result.Select(comp => _mapper.Map<PaymentDTO>(comp));

        }

        // GET: api/Payment
        [HttpGet("payments-by-date")]

        public IEnumerable<PaymentDTO> GetPaymentsByDate(DateTime datetocompare)
        {

            return _mediator.Send(new GetListQuery<Payment>(condition: src => src.DueDate.Date == datetocompare.Date, includes: i => i.Include(b => b.Bill).ThenInclude(b => b.Customer)))
                .Result.Select(comp => _mapper.Map<PaymentDTO>(comp));

        }


        #endregion

    }
}