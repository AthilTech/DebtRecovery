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
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        #region Standard WebMethods
        // GET: api/USER
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return _mediator.Send(new GetListQuery<User>())
                .Result.Select(comp => _mapper.Map<UserDTO>(comp));
        }


        [HttpGet("{id}")]
        public UserDTO Get(Guid id)
        {
            User user = _mediator.Send(new GetQuery<User>(condition: c => c.UserId == id)).Result;
            return _mapper.Map<UserDTO>(user);
        }


        [HttpPost]
        public async Task<string> Post(User user)
        {
            return await _mediator.Send(new PostCommand<User>(user));
        }


        [HttpPut]
        public async Task<string> Put(User user)
        {
            return await _mediator.Send(new PutCommand<User>(user));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<User>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion




    }
}
