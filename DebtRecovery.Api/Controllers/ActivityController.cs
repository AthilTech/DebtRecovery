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
    public class ActivityController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ActivityController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }



        #region Standard WebMethods
        // GET: api/Activity
        [HttpGet]
        public IEnumerable<ActivityDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Activity>())
                .Result.Select(comp => _mapper.Map<ActivityDTO>(comp));
        }


        [HttpGet("{id}")]
        public ActivityDTO Get(Guid id)
        {
            Activity Activity = _mediator.Send(new GetQuery<Activity>(condition: c => c.ActivityId == id)).Result;
            return _mapper.Map<ActivityDTO>(Activity);
        }


        [HttpPost]
        public async Task<string> Post(Activity Activity)
        {
            return await _mediator.Send(new PostCommand<Activity>(Activity));
        }


        [HttpPut]
        public async Task<string> Put(Activity Activity)
        {
            return await _mediator.Send(new PutCommand<Activity>(Activity));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Activity>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion

    }
}
