using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    internal class CalculateHighVAT : ICalculateVAT
    {
        private double VATPercentage = 0.21;
        public double CalculateVAT(double price)
        {
           return price * VATPercentage;
        }
    }
}
