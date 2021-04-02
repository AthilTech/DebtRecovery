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
    public class RoleController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RoleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Bill
        [HttpGet]
        public IEnumerable<RoleDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Role>())
                .Result.Select(comp => _mapper.Map<RoleDTO>(comp));
        }


        [HttpGet("{id}")]
        public RoleDTO Get(Guid id)
        {
            Role Role = _mediator.Send(new GetQuery<Role>(condition: c => c.RoleId == id)).Result;
            return _mapper.Map<RoleDTO>(Role);
        }


        [HttpPost]
        public async Task<string> Post(Role Role)
        {
            return await _mediator.Send(new PostCommand<Role>(Role));
        }


        [HttpPut]
        public async Task<string> Put(Role Role)
        {
            return await _mediator.Send(new PutCommand<Role>(Role));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Role>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion

    }
}
