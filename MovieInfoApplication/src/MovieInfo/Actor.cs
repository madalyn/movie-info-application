using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication.MovieInfo
{
    //The Actor class, which contains information about an actor object
    //The info for an actor is parsed from JSON recieved for that actor
    //The actor's name comes from Rotton Tomatoes
    //The actor's age is found from Freebase by using the actor's name
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
