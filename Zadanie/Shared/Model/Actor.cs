using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Actor
    {   
        public required string Name { get; set; }
        public int Age { get; set; }
        public int Rating { get; set; }
    }
}