using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication
{
    public interface IActor
    {        
        /// <summary>
        /// A Method to return the actor's name
        /// </summary>
        /// <returns></returns>
        string getName();

        /// <summary>
        /// A Method to return the age of this actor
        /// </summary>
        /// <returns></returns>
        int getAge();
    }
}
