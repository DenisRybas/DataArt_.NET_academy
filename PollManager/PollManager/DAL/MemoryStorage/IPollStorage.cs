using PollManager.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollManager.Models;

namespace PollManager.DAL.MemoryStorage
{
    public interface IPollStorage
    {
        void Add(Poll poll);
        void Delete(int id);
        bool IsNameUnique(string name);
        IReadOnlyCollection<Poll> GetAll();
        IReadOnlyCollection<Poll> Search(string nameSearch, string textSearch, HashSet<PollOption> options);
        Poll GetById(int id);
        bool IsIdUnique(int id);
    }
}
