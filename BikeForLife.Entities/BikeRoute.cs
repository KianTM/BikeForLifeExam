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

        public string GetIconUrl()
        {
            OpenWeatherMapAPI openWeatherMapAPI = new OpenWeatherMapAPI();
            string iconUrl = "";
            try
            {
                iconUrl = openWeatherMapAPI.GetIconUrl(City);
            }
            catch (WebException)
            {
                return @"\img\placeholder.png";
            }
            return iconUrl;
        }

        public string GetLocalTemperature()
        {
            OpenWeatherMapAPI openWeatherMapAPI = new OpenWeatherMapAPI();
            double temp = 0.0;
            try
            {
                temp = openWeatherMapAPI.GetCurrentTemperature(City);
            }
            catch (WebException)
            {
                return "N/A";
            }
            return $"{temp}°C";
        }
    }
}
