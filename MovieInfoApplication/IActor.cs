using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication
{
    public interface IActor
    {
        /**
         * A Method to return the age of this actor
         * Note: this will either be a class property or come straight from JSON
         * */
        int getAge();
    }
}
