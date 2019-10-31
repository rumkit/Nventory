using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventory.Models
{

    public class Result
    {
        public Result(bool succeed)
        {
            Succeeded = succeed;
        }

        public Result(bool succeed, IEnumerable<string> errors) : this(succeed)
        {
            ErrorsList = new List<string>(errors); 
        }
        public bool Succeeded { get; private set; }
        public bool Error => !Succeeded;
        public IEnumerable<string> ErrorsList { get; private set;}
    }
}
