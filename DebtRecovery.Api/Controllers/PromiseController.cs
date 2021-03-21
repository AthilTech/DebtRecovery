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
    public class PromiseController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PromiseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/promise
        [HttpGet]
        public IEnumerable<PromiseDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Promise>())
                .Result.Select(comp => _mapper.Map<PromiseDTO>(comp));
        }


        [HttpGet("{id}")]
        public PromiseDTO Get(Guid id)
        {
            Promise promise = _mediator.Send(new GetQuery<Promise>(condition: c => c.PromissId == id)).Result;
            return _mapper.Map<PromiseDTO>(promise);
        }


        [HttpPost]
        public async Task<string> Post(Promise promise)
        {
            return await _mediator.Send(new PostCommand<Promise>(promise));
        }


        [HttpPut]
        public async Task<string> Put(Promise promise)
        {
            return await _mediator.Send(new PutCommand<Promise>(promise));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Promise>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}
