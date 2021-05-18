using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollManager.Models;

namespace PollManager.DAL.Domain
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public HashSet<PollOption> Options { get; set; }
        public PollState State { get; set; } = PollState.NotPublished;
        public HashSet<string> VotedPeople { get; set; }
    }
}
