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

namespace DebtRecovery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AgentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Agent
        [HttpGet]
        public IEnumerable<AgentDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Agent>())
                .Result.Select(comp => _mapper.Map<AgentDTO>(comp));
        }


        [HttpGet("{id}")]
        public AgentDTO Get(Guid id)
        {
            Agent Agent = _mediator.Send(new GetQuery<Agent>(condition: c => c.AgentId == id)).Result;
            return _mapper.Map<AgentDTO>(Agent);
        }


        [HttpPost]
        public async Task<string> Post(Agent Agent)
        {
            return await _mediator.Send(new PostCommand<Agent>(Agent));
        }


        [HttpPut]
        public async Task<string> Put(Agent Agent)
        {
            return await _mediator.Send(new PutCommand<Agent>(Agent));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Agent>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion

    }
}
