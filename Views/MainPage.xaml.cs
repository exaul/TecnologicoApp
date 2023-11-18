namespace TecnologicoApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
