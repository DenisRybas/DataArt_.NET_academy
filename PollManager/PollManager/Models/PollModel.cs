using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollManager.Models
{
    public class PollModel
    {
        [Required] [MaxLength(100)] public string Name { get; set; }

        [Required] public string Text { get; set; }

        [Required] public HashSet<PollOption> Options { get; set; }
        public PollState State { get; set; } = PollState.NotPublished;
    }
}