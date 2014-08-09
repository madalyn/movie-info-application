using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication.MovieInfo
{
    public class Actor : IActor
    {
        private string name;
        private int age;

        public Actor(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        /**
        * A Method to return the age of this actor
        * Note: this will either be a class property or come straight from JSON
        * */
        public int getAge()
        {
            return age;
        }
    }
}
