using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace BuggyTasks.Views;

public partial class DeviceInfoPage: ContentPage
{
    public DeviceInfoPage()
    {
        InitializeComponent();
        LoadDeviceInfo();
    }

    void LoadDeviceInfo()
    {
        try
        {
            ModelLabel.Text = $"Model: {DeviceInfo.Model}";
            PlatformLabel.Text = $"Platform: {DeviceInfo.Platform}";
            VersionLabel.Text = $"Version: {DeviceInfo.VersionString}";
            ManufacturerLabel.Text = $"Manufacturer: {DeviceInfo.Manufacturer}";
        }
        catch (Exception ex)
        {
            ModelLabel.Text = $"Error loading device info: {ex.Message}";
        }
    }

    async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}