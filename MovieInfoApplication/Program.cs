using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MovieInfoApplication.MovieInfo;
using System.Runtime;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MovieInfoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The movies currently in theaters are:");
            MoviesImpl impl = new MoviesImpl();

            //get 10 movies currently in theaters, give back the JSON (limit=10 var later)
            //perhaps do as user input if time
            //need a catch if no movies, or less than input number
            string moviesJSON = impl.getMoviesJSON(5);
                      
            //dynamically make all 10 movies elsewhere - C# properties           
            List<Movie> movies = impl.createMoviesFromJSON(moviesJSON);

            int i = 1;
            foreach(var movie in movies){
                Console.WriteLine(i + ".)" + movie.getTitle());
                Console.WriteLine("Average Age of Cast: " + movie.getAverageAgeOfCast());
                Console.WriteLine("");
                i++;              
            }             
        }

    }
}
