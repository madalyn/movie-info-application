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
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            Console.WriteLine("The movies currently in theaters are:");
            MoviesImpl impl = new MoviesImpl();

            //get # movies currently in theaters, give back the movies
            //need a catch if no movies, or less than input number          
            List<Movie> movies = impl.getMovies(5); //improve speed

            int i = 1;
            foreach(var movie in movies){
                Console.WriteLine(i + ".)" + movie.getTitle());
                Console.WriteLine("Average Age of Cast: " + movie.getAverageAgeOfCast());
                Console.WriteLine("");
                i++;              
            }             
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e) {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
