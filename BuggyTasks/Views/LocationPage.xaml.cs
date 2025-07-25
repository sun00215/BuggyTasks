using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;

namespace BuggyTasks.Views;

public partial class LocationPage: ContentPage
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

    async Task<bool> CheckAndRequestLocationPermission()
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return true;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
              
                StatusLabel.Text = "Location permission denied. Please enable in Settings.";
                return false;
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status == PermissionStatus.Granted;
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Permission error: {ex.Message}";
            return false;
        }
    }

    async Task GetLastKnownLocation()
    {
        try
        {
            StatusLabel.Text = "Checking permissions...";
            
            var hasPermission = await CheckAndRequestLocationPermission();
            if (!hasPermission)
            {
                StatusLabel.Text = "Location permission required but not granted.";
                return;
            }

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
                StatusLabel.Text = "No last known location available. Try getting current location.";
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
            StatusLabel.Text = "Checking permissions...";
            
            var hasPermission = await CheckAndRequestLocationPermission();
            if (!hasPermission)
            {
                StatusLabel.Text = "Location permission required but not granted.";
                return;
            }

            StatusLabel.Text = "Getting current location...";
            
            var request = new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(10)
            };

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var location = await Geolocation.GetLocationAsync(request, cts.Token);
            
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
        catch (OperationCanceledException)
        {
            StatusLabel.Text = "Location request timed out";
        }
        catch (FeatureNotSupportedException)
        {
            StatusLabel.Text = "Location is not supported on this device";
        }
        catch (FeatureNotEnabledException)
        {
            StatusLabel.Text = "Location is not enabled on this device";
        }
        catch (PermissionException)
        {
            StatusLabel.Text = "Location permission denied";
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