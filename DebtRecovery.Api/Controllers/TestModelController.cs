using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DebtRecovery.Api.DTOs.LocalDTOs;
using DebtRecovery.Domain.Commands;
using DebtRecovery.Domain.Models;
using DebtRecovery.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DebtRecovery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestModelController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TestModelController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        #region Standard WebMethods
        // GET: api/TestModel
        [HttpGet]
        public IEnumerable<TestModelDTO> Get()
        {
            return _mediator.Send(new GetListQuery<TestModel>())
                .Result.Select(comp => _mapper.Map<TestModelDTO>(comp));
        }

        
        [HttpGet("{id}")]
        public TestModelDTO Get(Guid id)
        {
            TestModel testModel = _mediator.Send(new GetQuery<TestModel>(condition: c => c.TestModelId == id)).Result;
            return _mapper.Map<TestModelDTO>(testModel);
        }

       
        [HttpPost]
        public async Task<string> Post(TestModel TestModel)
        {
            return await _mediator.Send(new PostCommand<TestModel>(TestModel));
        }

   
        [HttpPut]
        public async Task<string> Put(TestModel TestModel)
        {
            return await _mediator.Send(new PutCommand<TestModel>(TestModel));
        }

       
        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<TestModel>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}
