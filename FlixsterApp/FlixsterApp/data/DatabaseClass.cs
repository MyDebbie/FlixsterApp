using FlixsterApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Name : Mydleyka Dimanche
/// Devoir: 5
/// </summary>
namespace FlixsterApp.data
{
    public class DatabaseClass
    {
        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {


            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        /// <summary>
        /// Method to create database
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection Connection()
        {
            String libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(libraryPath, "films.db3");

            SQLiteConnection connection = new SQLiteConnection(path);
            connection.CreateTable<Film>();

            return connection;
        }

        /// <summary>
        /// Method to save data in the database
        /// </summary>
        /// <param name="film"></param>

        public static void SaveFilm(Film film)
        {
            if (!GetFilmID().Contains(film.id))
            {
                Connection().Insert(film);
            }
        }

        /// <summary>
        /// Method to get data from database
        /// </summary>
        /// <returns></returns>
        public static List<Film> GetFilms()
        {
            List<Film> lesfilms = new List<Film>();

            var films = Connection().Table<Film>();

            foreach (Film film in films)
            {
                lesfilms.Add(film);
            }
            return lesfilms;
        }

        /// <summary>
        /// Method to get data from database
        /// </summary>
        /// <returns></returns>
        public static List<int> GetFilmID()
        {
            List<int> lesfilms = new List<int>();

            var films = Connection().Table<Film>();

            foreach (Film film in films)
            {
                lesfilms.Add(film.id);
            }
            return lesfilms;
        }

    }
}
