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
    public class RecoveryManagerController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RecoveryManagerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        #region Standard WebMethods
        // GET: api/Manager
        [HttpGet]
        public IEnumerable<RecoveryManagerDTO> Get()
        {
            return _mediator.Send(new GetListQuery<RecoveryManager>())
                .Result.Select(comp => _mapper.Map<RecoveryManagerDTO>(comp));
        }


        [HttpGet("{id}")]
        public RecoveryManagerDTO Get(Guid id)
        {
            RecoveryManager manager = _mediator.Send(new GetQuery<RecoveryManager>(condition: c => c.UserId == id)).Result;
            return _mapper.Map<RecoveryManagerDTO>(manager);
        }


        [HttpPost]
        public async Task<string> Post(RecoveryManager manager)
        {
            return await _mediator.Send(new PostCommand<RecoveryManager>(manager));
        }


        [HttpPut]
        public async Task<string> Put(RecoveryManager manager)
        {
            return await _mediator.Send(new PutCommand<RecoveryManager>(manager));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<RecoveryManager>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}
