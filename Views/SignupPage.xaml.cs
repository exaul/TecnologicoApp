using TecnologicoApp.ViewModels;

namespace TecnologicoApp.Views;

public partial class SignupPage : ContentPage
{
	public SignupPage(SignupPageViewModel signupPageViewModel)
	{
		try
		{
			InitializeComponent();
            BindingContext = signupPageViewModel;
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
}