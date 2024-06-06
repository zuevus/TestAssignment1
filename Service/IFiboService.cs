using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment1.Service
{
    public interface IFiboService
    {
        Task<List<int>> GetFiboAsync(CancellationToken stoppingToken, int count);
    }
}
