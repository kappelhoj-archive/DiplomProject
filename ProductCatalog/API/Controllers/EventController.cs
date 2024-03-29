﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queries;
using Queries.Events;

namespace API.Controllers
{
    [Authorize("read:product")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet()]
        public IActionResult QueryEvents([FromQuery] int? eventCounter, [FromQuery] int? amount,[FromServices] QueryEvents queryEvents) {

            IEnumerable<EventDTO> events;
            if (eventCounter != null && amount != null)
            {
                events = queryEvents.Query((int)eventCounter, (int)amount);
            }
            else {
                events = queryEvents.Query();
            }
            

            if (!queryEvents.IsSuccesful) {
                return BadRequest(queryEvents.Errors);
            }

            return Ok(events);
        }
    }
}