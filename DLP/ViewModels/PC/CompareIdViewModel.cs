using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.ViewModels.PC
{
    public class CompareIdViewModel
    {
        public int firstRequestId { get; set; }
        public int secondRequestId { get; set; }

        public List<int> ListRequestIds { get; set; }
    }
}
