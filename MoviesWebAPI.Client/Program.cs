using MoviesWebAPI.Client.Models;
using System.Net.Http.Json;

public class Program
{
    public  static async Task Main(string[] args)
    {Console.WriteLine("Please enter the movie you like to watch!");
        string movie = Console.ReadLine();
        Console.WriteLine("Please enter the genre of the movie you like to watch!");
        string genre = Console.ReadLine();
        Console.WriteLine("Please enter the release date of the movie you like to watch!");
        DateTime releaseDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("The movie you like to watch is: " + movie);
        Console.WriteLine("The genre of the movie you like to watch is: " + genre);
        Console.WriteLine("The release date of the movie you like to watch is: " + releaseDate);

        Movie _movie = new Movie();
        _movie.Title = movie;
        _movie.Genre = genre;
        _movie.ReleaseDate = releaseDate;

        string baseUrl = "https://localhost:5021/api/movies";
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using (var client = new HttpClient(handler))
        {
            try
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.PostAsync(baseUrl, JsonContent.Create(_movie));
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Movie added successfully");
                }
                else
                {
                    Console.WriteLine("Failed to add movie");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

}
