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
        // GET: api/TestModel
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return _mediator.Send(new GetListQuery<User>(
                includes: i => i.Include(c => c.Role)))
                .Result.Select(comp => _mapper.Map<UserDTO>(comp));
        }
    

        [HttpGet("{id}")]
        public UserDTO Get(Guid id)
        {
            User User = _mediator.Send(new GetQuery<User>(condition: u => u.UserId == id)).Result;
            return _mapper.Map<UserDTO>(User);
        }


        [HttpPost]
        public async Task<string> Post(Payment Payment)
        {
            return await _mediator.Send(new PostCommand<Payment>(Payment));
        }


        [HttpPut]
        public async Task<string> Put(User User)
        {
            return await _mediator.Send(new PutCommand<User>(User));
        }


        [HttpDelete("{id}")]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<User>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}

