using System.Collections.Generic;
using System.Linq;

namespace WinRT_MVVM_GridView_SemanticZoom
{
    public class MoviesPageViewModel
    {
        public List<MovieCategory> Items { get; set; }

        public MoviesPageViewModel()
        {
            var movies = new List<Movie>
                             {
                                 new Movie {Title = "The Ewok Adventure", Category = "Adventure", Subtitle = "The Towani family civilian shuttlecraft crashes on the forest moon of Endor.", Image = "http://cf2.imgobject.com/t/p/w500/y6HdTlqgcZ6EdsKR1uP03WgBe0C.jpg"},
                                 new Movie {Title = "The In-Laws", Category = "Adventure", Subtitle = "In preparation for his daughter's wedding, dentist Sheldon ", Image = "http://cf2.imgobject.com/t/p/w500/9FlFW9zhuoOpS8frAFR9cCnJ6Sg.jpg"},
                                 new Movie {Title = "The Man Called Flintstone", Category = "Adventure", Subtitle = "In this feature-length film based on the Flintstones TV show", Image = "http://cf2.imgobject.com/t/p/w500/6qyVUkbDBuBOUVVplIDGaQf6jZL.jpg"},

                                 new Movie {Title = "Super Fuzz", Category = "Comedy", Subtitle = "Dave Speed is no ordinary Miami cop--he is an irradiated Miami cop ", Image = "http://cf2.imgobject.com/t/p/w500/bueVXkpCDPX0TlsWd3Uk7QKO3kD.jpg"},
                                 new Movie {Title = "The Knock Out Cop", Category = "Comedy", Subtitle = "This cop doesn't carry a gun - his fist is loaded!", Image = "http://cf2.imgobject.com/t/p/w500/mzlw8rHGUSDobS1MJgz8jXXPM06.jpg"},
                                 new Movie {Title = "Best Worst Movie", Category = "Comedy", Subtitle = "A look at the making of the film Troll 2 (1990) ", Image = "http://cf2.imgobject.com/t/p/w500/5LjbAjkPBUOD9N2QFPSuTyhomx4.jpg"},

                                 new Movie {Title = "The Last Unicorn", Category = "Fantasy", Subtitle = "A brave unicorn and a magician fight an evil king", Image = "http://cf2.imgobject.com/t/p/w500/iO6P5vV1TMwSuisZDtNBDNpOxwR.jpg"},
                                 new Movie {Title = "Blithe Spirit", Category = "Fantasy", Subtitle = "An English mystery novelist invites a medium", Image = "http://cf2.imgobject.com/t/p/w500/gwu4c10lpgHUrMqr9CBNq2FYTpN.jpg"},
                                 new Movie {Title = "Here Comes Mr. Jordan", Category = "Fantasy", Subtitle = "Boxer Joe Pendleton, flying to his next fight", Image = "http://cf2.imgobject.com/t/p/w500/9cnWl7inQVX6wznjYNmQmJXVD6J.jpg"},
                             };

            var moviesByCategories = movies.GroupBy(x => x.Category)
                .Select(x => new MovieCategory { Title = x.Key, Items = x.ToList() });

            Items = moviesByCategories.ToList();
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }

    public class MovieCategory
    {
        public string Title { get; set; }
        public List<Movie> Items { get; set; }
    }

}
