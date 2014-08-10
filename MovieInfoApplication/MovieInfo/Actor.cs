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

        /// <summary>
        /// A Method to return the actor's name
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// A Method to return the age of this actor
        /// </summary>
        /// <returns></returns>
        public int getAge()
        {
            return age;
        }
    }
}
