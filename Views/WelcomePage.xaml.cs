namespace TecnologicoApp.Views;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
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
}