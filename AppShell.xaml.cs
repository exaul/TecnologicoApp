namespace TecnologicoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.SignupPage),typeof(Views.SignupPage));
        }
    }
}