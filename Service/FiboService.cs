using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignment1.Data;

namespace TestAssignment1.Service
{
    public class FiboService
    {

        private readonly ILogger<TestAssignmentContext> _logger;
      
        public FiboService(IConfiguration configuration, ILogger<TestAssignmentContext> logger)
        {
            _logger = logger;
        }

        public async Task<List<int>> GetFibo(int count)
        {
            Dictionary<int, int> test = new() {
                    {0,0},
                    {1,1}
                    };
            int fib(int n)
            {
                if (test.Keys.Contains(n))
                    return test[n];
                test[n] = fib(n - 1) + fib(n - 2);
                return test[n];

            }
            List<int> result = new();
            for (int i = 0; i < count; i++)
            {
                result.Add(fib(i));
            }
            return result;
        }
         
    }
}
