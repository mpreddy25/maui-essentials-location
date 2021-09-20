using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;
using System;

namespace MauiGetLocation
{
    public partial class MainPage : ContentPage
    {
        private Location location;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //GetCurrentLocationButton.IsEnabled = false;
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                CounterLabel.Text = "Location permission not granted";
                return;
            }
            else if (location == null)
            {
                try
                {
                    location = await Geolocation.GetLocationAsync();
                    CounterLabel.Text = $"Current Location Longitude - {location.Longitude} And Latitude - {location?.Latitude}";
                    GetCurrentLocationButton.IsEnabled = false;
                    GetCurrentLocationButton.BackgroundColor = Color.FromArgb("#C8C8C3");
                }
                catch (Exception ex)
                {
                    CounterLabel.Text = ex.Message;
                }
            }
            else
            {
                CounterLabel.Text = $"Current Location Longitude - {location.Longitude} And Latitude - {location?.Latitude}";
                GetCurrentLocationButton.IsEnabled = false;
                GetCurrentLocationButton.BackgroundColor = Color.FromArgb("#C8C8C3");
            }
            SemanticScreenReader.Announce(CounterLabel.Text);
        }
    }
}
