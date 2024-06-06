using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class TrasholdParameters : IParameters
    {
        [ParameterInfo(Name = "Порог",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 0.5,
                    Increment = 0.01)]
        public double Trashold {  get; set; }
    }
}
