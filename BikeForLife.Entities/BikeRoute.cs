using RideService.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace BikeForLife.Entities
{
    public class BikeRoute
    {
        public int Id { get; set; }
        [Display(Name="Navn")]
        public string Name { get; set; }
        [Display(Name = "Længde")]
        public double Length { get; set; }
        [Display(Name = "Sværhedsgrad")]
        public Difficulty Difficulty { get; set; }
        [Display(Name = "Land")]
        public string Country { get; set; }
        [Display(Name = "By")]
        public string City { get; set; }

        public string GetIconUrl() // Retrieves a url for an icon for the City member in the class and returns it as a string
        {
            OpenWeatherMapAPI openWeatherMapAPI = new OpenWeatherMapAPI(); // Initializing required variables
            string iconUrl = "";
            try
            {
                iconUrl = openWeatherMapAPI.GetIconUrl(City); // Tries to run the code
            }
            catch (WebException) // If the code can't run and the data isn't retrieved, a WebException is thrown and caught
            {
                return @"\img\placeholder.png"; // A URL for a placeholder image is returned instead of the intended URL
            }
            return iconUrl; // If the code runs succesfully and the data is retrieved, the URL is returned
        }

        public string GetLocalTemperature() // Retrieves the temperature for the City member in the class and returns it as a string
        {
            OpenWeatherMapAPI openWeatherMapAPI = new OpenWeatherMapAPI(); // Intitializing required variables
            double temp = 0.0;
            try
            {
                temp = openWeatherMapAPI.GetCurrentTemperature(City); // Tries to run the code
            }
            catch (WebException) //If the code can't run and the data isn't retrieved, a WebException is thrown and caught
            {
                return "N/A"; // The output string is set to placeholder text
            }
            return $"{temp}°C"; // If the code runs succesfully and the data is retrieved, the text is set to the temperature
        }
    }
}
