﻿using AutoMapper;
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
    public class NoteController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public NoteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        #region Standard WebMethods
        // GET: api/Note
        [HttpGet]
        public IEnumerable<NoteDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Note>())
                .Result.Select(comp => _mapper.Map<NoteDTO>(comp));
        }


        [HttpGet("{id}")]
        public NoteDTO Get(Guid id)
        {
            Note note = _mediator.Send(new GetQuery<Note>(condition: c => c.NoteId == id)).Result;
            return _mapper.Map<NoteDTO>(note);
        }


        [HttpPost]
        public async Task<string> Post(Note note)
        {
            return await _mediator.Send(new PostCommand<Note>(note));
        }


        [HttpPut]
        public async Task<string> Put(Note note)
        {
            return await _mediator.Send(new PutCommand<Note>(note));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Note>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion



    }
}