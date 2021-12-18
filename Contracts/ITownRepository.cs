using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ITownRepository
    {
        IEnumerable<Town> GetAllTowns(bool trackChenges);
    }
}
