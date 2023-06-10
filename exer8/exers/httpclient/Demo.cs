namespace Exer08.exers.httpclient
{
    public static class Demo
    {
        public static async Task Run()
        {
            var client = new StarWarsMoviesClient();
            var filmsResponse = await client.GetFilms();
            var films = filmsResponse.Data;
            foreach (var film in films)
            {
                Console.WriteLine($"{film.ReleaseDate} {film.Title}");
            }
        }
    }
}