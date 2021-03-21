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
    public class HistoryController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public HistoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }


        #region Standard WebMethods
        // GET: api/history
        [HttpGet]
        public IEnumerable<HistoryDTO> Get()
        {
            return _mediator.Send(new GetListQuery<History>())
                .Result.Select(comp => _mapper.Map<HistoryDTO>(comp));
        }


        [HttpGet("{id}")]
        public HistoryDTO Get(Guid id)
        {
            History history = _mediator.Send(new GetQuery<History>(condition: c => c.HistoryId == id)).Result;
            return _mapper.Map<HistoryDTO>(history);
        }


        [HttpPost]
        public async Task<string> Post(History history)
        {
            return await _mediator.Send(new PostCommand<History>(history));
        }


        [HttpPut]
        public async Task<string> Put(History history)
        {
            return await _mediator.Send(new PutCommand<History>(history));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<History>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}
