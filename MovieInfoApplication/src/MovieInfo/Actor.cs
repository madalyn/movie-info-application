using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication.MovieInfo
{
    public class Actor : IActor
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Actor(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

    }
}
