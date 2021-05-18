using PollManager.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollManager.Models;

namespace PollManager.DAL.MemoryStorage
{
    public class PollMemoryStorage : IPollStorage
    {
        private readonly List<Poll> _polls;
        private int _lastId;

        public PollMemoryStorage()
        {
            _lastId = 1;
            _polls = new List<Poll>
            {
                new Poll
                {
                    Id = _lastId++,
                    Name = "Test poll",
                    Text =
                        "How are you doing?",
                    Options = new HashSet<PollOption>()
                    {
                        new PollOption(0, "Good", 0),
                        new PollOption(1, "Bad", 0)
                    },
                    State = PollState.Published
                },
            };
        }

        public void Add(Poll poll)
        {
            poll.Id = _lastId++;
            _polls.Add(poll);
        }

        public void Delete(int id)
        {
            Poll poll = _polls.FirstOrDefault(x => x.Id == id);
            _polls.Remove(poll);
        }

        public IReadOnlyCollection<Poll> GetAll()
        {
            return _polls;
        }


        public IReadOnlyCollection<Poll> Search(string nameSearch, string textSearch, HashSet<PollOption> options)
        {
            var result = _polls.AsQueryable();

            if (!string.IsNullOrEmpty(nameSearch))
            {
                result = result.Where(x => x.Name.Contains(nameSearch.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(textSearch))
            {
                result = result.Where(x => x.Text.Contains(textSearch.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            if (options != null)
            {
                result = result.Where(x => x.Options.Equals(options));
            }

            return result.ToList();
        }


        public Poll GetById(int id)
        {
            return _polls.FirstOrDefault(x => x.Id == id);
        }

        public bool IsNameUnique(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            return !_polls.Any(x => x.Name.Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool IsIdUnique(int id)
        {
            return _polls.All(x => x.Id != id);
        }
    }
}