using FlixsterApp.data;
using FlixsterApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


/// <summary>
/// Name : Mydleyka Dimanche
/// Devoir: 5
/// </summary>
namespace FlixsterApp
{
    public partial class MainPage : ContentPage
    {
        public static List<Film> films;
        public static int index = 0;


        public MainPage()
        {
            
            InitializeComponent();
            AddToDatabase();
            Film film = films.ElementAt(index);
            display_film();

        }


        /// <summary>
        /// Method to display the movies
        /// </summary>
        private void display_film()
        {

            Film film = films.ElementAt(index);
            lbTitle.Text = film.title;
            lbOverview.Text = film.overview;

            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                pbImageFilm.Source = "https://image.tmdb.org/t/p/w342" + film.backdrop_path;
            }
            

            if (index == 0)
            {
                btnPrevious.IsEnabled = false;
            }
            else
            {
                btnPrevious.IsEnabled = true;
            }

            if (index == films.Count - 1)
            {
                btnNext.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index--;
            display_film();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            display_film();
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Detail());
        }

        /// <summary>
        /// Method to add the movies in the database 
        /// </summary>
        public void AddToDatabase()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                films = Utilities.getMovieDbList();
                foreach (Film film1 in films)
                {
                    DatabaseClass.SaveFilm(film1);
                }
                btnInternet.BackgroundColor = Color.Blue
                    ;
            }
            else
            {
                films = DatabaseClass.GetFilms();
                btnInternet.BackgroundColor = Color.Red;

            }
        }
       


    }
}

