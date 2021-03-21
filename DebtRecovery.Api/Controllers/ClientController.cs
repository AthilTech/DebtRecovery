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
    public class ClientController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClientController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }


        #region Standard WebMethods
        // GET: api/client
        [HttpGet]
        public IEnumerable<ClientDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Client>())
                .Result.Select(comp => _mapper.Map<ClientDTO>(comp));
        }


        [HttpGet("{id}")]
        public ClientDTO Get(Guid id)
        {
            Client client = _mediator.Send(new GetQuery<Client>(condition: c => c.ClientId == id)).Result;
            return _mapper.Map<ClientDTO>(client);
        }


        [HttpPost]
        public async Task<string> Post(Client client)
        {
            return await _mediator.Send(new PostCommand<Client>(client));
        }


        [HttpPut]
        public async Task<string> Put(Client client)
        {
            return await _mediator.Send(new PutCommand<Client>(client));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Client>(id));
        }
        #endregion

        #region Custom Web Methods

        #endregion

    }
}