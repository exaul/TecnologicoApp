namespace TecnologicoApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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
}