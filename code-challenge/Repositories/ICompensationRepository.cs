using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;

namespace challenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation Add(string id, double salary, DateTime date);
        Compensation Remove(Compensation compensation);
        Compensation GetById(String id);
        Task SaveAsync();
    }
}
