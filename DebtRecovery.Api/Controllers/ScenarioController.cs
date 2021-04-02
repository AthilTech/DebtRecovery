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
    public class ScenarioController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ScenarioController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Scenario
        [HttpGet]
        public IEnumerable<ScenarioDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Scenario>())
                .Result.Select(comp => _mapper.Map<ScenarioDTO>(comp));
        }


        [HttpGet("{id}")]
        public ScenarioDTO Get(Guid id)
        {
            Scenario Scenario = _mediator.Send(new GetQuery<Scenario>(condition: c => c.ScenarioId == id)).Result;
            return _mapper.Map<ScenarioDTO>(Scenario);
        }


        [HttpPost]
        public async Task<string> Post(Scenario Scenario)
        {
            return await _mediator.Send(new PostCommand<Scenario>(Scenario));
        }


        [HttpPut]
        public async Task<string> Put(Scenario Scenario)
        {
            return await _mediator.Send(new PutCommand<Scenario>(Scenario));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Scenario>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion

    }
}
