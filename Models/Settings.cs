namespace TecnologicoApp.Models
{
    public static class Settings
    {
        public static bool IsAuthenticated
        {
            get => Preferences.Default.Get(nameof(IsAuthenticated), false);
            set => Preferences.Default.Set(nameof(IsAuthenticated), value);
        }

        public static string Email
        {
            get => Preferences.Default.Get(nameof(Email), string.Empty);
            set => Preferences.Default.Set(nameof(Email), value);
        }
        public static string EmailRegistro
        {
            get => Preferences.Default.Get(nameof(EmailRegistro), string.Empty);
            set => Preferences.Default.Set(nameof(EmailRegistro), value);
        }

        public static string PasswordRegistro
        {
            get => Preferences.Default.Get(nameof(PasswordRegistro), string.Empty);
            set => Preferences.Default.Set(nameof(PasswordRegistro), value);
        }
    }
    //public static bool IsAuthenticated { get; set; }
}

