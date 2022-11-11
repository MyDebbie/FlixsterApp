using FlixsterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
/// Name : Mydleyka Dimanche
/// Devoir: 5
/// </summary>
namespace FlixsterApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        Film film = MainPage.films.ElementAt(MainPage.index);
        public const string stringVideo = @"https://api.themoviedb.org/3/movie/{0}/videos?api_key=a07e22bc18f5cb106bfe4cc1f83ad8ed";


        public Detail()
        {
            InitializeComponent();

            String reponse = "";
            string youtubeKey = "";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    reponse = webClient.DownloadString(String.Format(stringVideo, film.id));
                }
                //Console.WriteLine(retVal);
                using (JsonDocument document = JsonDocument.Parse(reponse))
                {
                    JsonElement root = document.RootElement;
                    JsonElement resultsList = root.GetProperty("results");

                    int i = 0;
                    while (true)
                    {
                        String type = resultsList[i].GetProperty("type").ToString();
                        youtubeKey = resultsList[i].GetProperty("key").ToString();
                        if (type.Equals("Clip"))
                        {
                            break;
                        }
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            displayVideo(youtubeKey);
            display_film();


        }

        /// <summary>
        /// Method to display the video trailer of the movies
        /// </summary>
        /// <param name="id"></param>
        private void displayVideo(String id)
        {
            youtubeVideo.Source= "https://www.youtube.com/watch?v=" + id;
        }


        /// <summary>
        /// Method to display the movies
        /// </summary>
        private void display_film()
        {
            lbTitle.Text = film.title;
            lbOverview.Text = film.overview;
            lbOriginalLanguange.Text = "OriginalLanguange: " + film.original_language;
            lbReleaseDate.Text = "ReleaseDate: " + film.release_date;
            lbVoteAverage.Text = "VoteAverage: " + film.vote_average.ToString();
            lbVoteCount.Text = "VoteCount: " + film.vote_count.ToString();
        }
    }
}