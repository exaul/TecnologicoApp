using TecnologicoApp.Models;
namespace TecnologicoApp.Views;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
    {
        try
        {
            InitializeComponent();
        }
        catch (XamlParseException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await CheckAuthentication();
    }

    private async Task CheckAuthentication()
    {
        await Task.Delay(2500);

        if (Settings.IsAuthenticated)
        {
            await Shell.Current.GoToAsync($"///Main/{nameof(WelcomePage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
        }
    }
}