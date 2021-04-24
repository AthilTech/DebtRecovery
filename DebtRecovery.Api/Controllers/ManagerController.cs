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
    public class ManagerController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ManagerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Manager
        [HttpGet]
        public IEnumerable<ManagerDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Manager>())
                .Result.Select(comp => _mapper.Map<ManagerDTO>(comp));
        }


        [HttpGet("{id}")]
        public ManagerDTO Get(Guid id)
        {
            Manager Manager = _mediator.Send(new GetQuery<Manager>(condition: c => c.UserId == id)).Result;
            return _mapper.Map<ManagerDTO>(Manager);
        }


        [HttpPost]
        public async Task<string> Post(Manager Manager)
        {
            return await _mediator.Send(new PostCommand<Manager>(Manager));
        }


        [HttpPut]
        public async Task<string> Put(Manager Manager)
        {
            return await _mediator.Send(new PutCommand<Manager>(Manager));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Manager>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion

    }
}
