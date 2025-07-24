using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;

namespace BuggyTasks.Views;

public partial class LocationPage : ContentPage
{
    public LocationPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetLastKnownLocation();
    }

    async Task GetLastKnownLocation()
    {
        try
        {
            StatusLabel.Text = "Getting last known location...";
            var location = await Geolocation.GetLastKnownLocationAsync();
            
            if (location != null)
            {
                StatusLabel.Text = "Last known location found";
                LatitudeLabel.Text = $"Latitude: {location.Latitude:F6}";
                LongitudeLabel.Text = $"Longitude: {location.Longitude:F6}";
                AccuracyLabel.Text = $"Accuracy: {location.Accuracy:F2}m";
            }
            else
            {
                StatusLabel.Text = "No last known location available";
                LatitudeLabel.Text = "Latitude: --";
                LongitudeLabel.Text = "Longitude: --";
                AccuracyLabel.Text = "Accuracy: --";
            }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error: {ex.Message}";
        }
    }

    async void OnGetCurrentLocationClicked(object sender, EventArgs e)
    {
        try
        {
            StatusLabel.Text = "Getting current location...";
            
            var request = new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(10)
            };

            var location = await Geolocation.GetLocationAsync(request);
            
            if (location != null)
            {
                StatusLabel.Text = "Current location found";
                LatitudeLabel.Text = $"Latitude: {location.Latitude:F6}";
                LongitudeLabel.Text = $"Longitude: {location.Longitude:F6}";
                AccuracyLabel.Text = $"Accuracy: {location.Accuracy:F2}m";
            }
            else
            {
                StatusLabel.Text = "Unable to get current location";
            }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Error: {ex.Message}";
        }
    }

    async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}