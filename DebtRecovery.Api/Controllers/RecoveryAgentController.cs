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
    public class RecoveryAgentController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RecoveryAgentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }


        #region Standard WebMethods
        // GET: api/agent
        [HttpGet]
        public IEnumerable<RecoveryAgentDTO> Get()
        {
            return _mediator.Send(new GetListQuery<RecoveryAgent>())
                .Result.Select(comp => _mapper.Map<RecoveryAgentDTO>(comp));
        }


        [HttpGet("{id}")]
        public RecoveryAgentDTO Get(Guid id)
        {
            RecoveryAgent recoveryAgent = _mediator.Send(new GetQuery<RecoveryAgent>(condition: c => c.UserId == id)).Result;
            return _mapper.Map<RecoveryAgentDTO>(recoveryAgent);
        }


        [HttpPost]
        public async Task<string> Post(RecoveryAgent recoveryAgent)
        {
            return await _mediator.Send(new PostCommand<RecoveryAgent>(recoveryAgent));
        }


        [HttpPut]
        public async Task<string> Put(RecoveryAgent recoveryAgent)
        {
            return await _mediator.Send(new PutCommand<RecoveryAgent>(recoveryAgent));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<RecoveryAgent>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}

