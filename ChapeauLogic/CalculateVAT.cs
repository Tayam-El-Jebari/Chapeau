using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class CalculateVAT
    {
        private IVATCalculation vatCalculation;
        public double Price { get; set; }
        public IVATCalculation VATCalculation
        {
            get { return vatCalculation; }
            set { vatCalculation = value; }
        }

        public CalculateVAT()
        {
            Price = 0;
        }
        public double ExecuteCalculation()
        {
            return vatCalculation.CalculateVAT(Price);
        }
    }
}
