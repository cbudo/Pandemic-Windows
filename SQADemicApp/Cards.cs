using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQADemicApp
{
    public interface Cards
    {

        String CityName { get; set; }
        Color CityColor { get; set; }

        bool Equals(Object obj);

    }

}
