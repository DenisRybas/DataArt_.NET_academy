using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PollManager.DAL.MemoryStorage;
using PollManager.Filters;
using PollManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PollManager.Controllers
{
    public class PollController : Controller
    {
        private readonly ILogger<PollController> _logger;
        private readonly IPollStorage _pollStorage;

        public PollController(ILogger<PollController> logger, IPollStorage pollStorage)
        {
            _logger = logger;
            _pollStorage = pollStorage;
        }

        public IActionResult Index(PollModel model)
        {
            var polls = _pollStorage.Search(model.Name, model.Text, model.Options);

            return Ok(polls);
        }

        public IActionResult Details(int id)
        {
            var poll = _pollStorage.GetById(id);

            if (poll == null)
            {
                return NotFound();
            }

            if (poll.State == PollState.NotPublished && Request.Cookies["isCreator"] == "false")
            {
                return Forbid();
            }

            return Ok(poll);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PollModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pollStorage.Add(new DAL.Domain.Poll
            {
                Name = model.Name,
                Text = model.Text,
                Options = model.Options,
            });

            return Ok();
        }
        
        [HttpPost]
        public IActionResult Vote(int pollId, int answerId)
        {
            var poll = _pollStorage.GetById(pollId);

            if (poll == null)
            {
                return NotFound();
            }

            if (poll.State != PollState.Published || poll.VotedPeople.Contains(Request.Cookies["auth"])
                                                  || Request.Cookies["isCreator"].Equals("true"))
            {
                return Forbid();
            }

            var selectedOption = poll.Options.Where(o => o.Id == answerId).ToList();

            if (!selectedOption.Any())
            {
                return NotFound();
            }

            selectedOption.First().NumberOfVotes = selectedOption.First().NumberOfVotes++;
            poll.VotedPeople.Add(Request.Cookies["auth"]);

            return Ok(poll);
        }
    }
}