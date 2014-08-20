using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication
{
    public interface IActor
    {        
        /// <summary>
        /// The property to access the actor's name
        /// </summary>
        /// <returns></returns>
        string Name { get; set; }
        
        /// <summary>
        /// The property to access the age of this actor
        /// </summary>
        /// <returns></returns>
        int Age { get; set; }
    }
}
