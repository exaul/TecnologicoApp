using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Settings = TecnologicoApp.Models.Settings;

namespace TecnologicoApp.ViewModels
{
    public class WelcomePageViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }
        public WelcomePageViewModel()
        {
            Email = Settings.Email;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}