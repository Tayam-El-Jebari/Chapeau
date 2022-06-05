using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    internal class CalculateLowVAT : IVATCalculation
    {
        private double VATPercentage = 0.06;
        public double CalculateVAT(double price)
        {
            return price * VATPercentage;
        }
    }
}
