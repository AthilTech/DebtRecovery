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
    public class CommentController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CommentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        #region Standard WebMethods
        // GET: api/TestModel
        [HttpGet]
        public IEnumerable<CommentDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Comment>())
                .Result.Select(comp => _mapper.Map<CommentDTO>(comp));
        }


        [HttpGet("{id}")]
        public CommentDTO Get(Guid id)
        {
            Comment Comment = _mediator.Send(new GetQuery<Comment>(condition: n => n.CommentId == id)).Result;
            return _mapper.Map<CommentDTO>(Comment);
        }


        [HttpPost]
        public async Task<string> Post(Comment Comment)
        {
            return await _mediator.Send(new PostCommand<Comment>(Comment));
        }


        [HttpPut]
        public async Task<string> Put(Comment Comment)
        {
            return await _mediator.Send(new PutCommand<Comment>(Comment));
        }


        [HttpDelete("{id}")]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Comment>(id));
        }
        #endregion

        #region Custom Web Methods

        [HttpGet("Comments-by-customer-id")]
        public async Task<IEnumerable<CommentDTO>> GetCommentsByCustomerId(Guid customerId)
        {
            return _mediator.Send(new GetListQuery<Comment>(condition: c => c.FK_Customer == customerId))
              .Result.Select(Comment => _mapper.Map<CommentDTO>(Comment));
        }

        #endregion
    }
}



