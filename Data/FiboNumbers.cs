using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment1.Data
{
    internal class FiboNumbers
    {
        [Key] int Id { get; set; }
        int position { get; set; }
        int number { get; set; }
     }
}
