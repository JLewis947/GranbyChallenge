using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public abstract class JobTemplate
    {
        public abstract string Name { get; }
        public abstract int DispatchTime { get; set; }
        public abstract Stock WarehouseStock { get; set; }
        public abstract bool CheckStock();
        public abstract bool ProcessOrder();
    }
}
