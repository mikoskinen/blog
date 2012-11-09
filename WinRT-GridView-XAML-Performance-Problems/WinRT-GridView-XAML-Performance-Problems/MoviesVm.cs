using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WinRT_GridView_XAML_Performance_Problems.Data;

namespace WinRT_GridView_XAML_Performance_Problems
{
    public class MoviesVm
    {
        /// <summary>
        /// This is used when the grouping is enabled. It will give a horrible performance
        /// </summary>
        public ObservableCollection<Category> MoviesByYear { get; set; }

        /// <summary>
        /// These two are used when the grouping is done manually
        /// </summary>
        public ObservableCollection<object> Items { get; set; }
        public ObservableCollection<string> Groups { get; set; }

        public MoviesVm()
        {
            this.MoviesByYear = new ObservableCollection<Category>();
            this.Items = new ObservableCollection<object>();
            this.Groups = new ObservableCollection<string>();
        }

        public async void CreateBadPerformingData()
        {
            var movies = await GetMovies();

            var moviesByYear = movies.GroupBy(x => x.Year);

            foreach (var group in moviesByYear)
            {
                var movieGroup = new Category(group.Key.ToString(), group.ToList());
                MoviesByYear.Add(movieGroup);
            }
        }

        public async void CreateDataWithGreatPerformance()
        {
            var movies = await GetMovies();

            var moviesByYear = movies.GroupBy(x => x.Year);
            foreach (var group in moviesByYear)
            {
                // The group is added to two collections: Collection containing only the groups and the collection containing movies and the groups
                this.Groups.Add(group.Key.ToString());
                this.Items.Add(group.Key.ToString());

                // The movies are only added to the collection containing movies and groups
                foreach (var movieInfo in group)
                {
                    this.Items.Add(movieInfo);
                }
            }
        }

        private static async Task<List<MovieInfo>> GetMovies()
        {
            var service = new MovieService();

            var movies = await service.GetMovies();
            return movies;
        }

    }


    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<MovieInfo> Movies { get; set; }

        public Category(string name, IEnumerable<MovieInfo> movies)
        {
            Name = name;
            this.Movies = new ObservableCollection<MovieInfo>();

            foreach (var movieInfo in movies)
            {
                Movies.Add(movieInfo);
            }
        }
    }
}