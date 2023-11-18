using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologicoApp
{
    public class Util
    {
        public static async Task ShowToastAsync(string message)
        {
            // implement your logic here
            var toast = Toast.Make(message);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await toast.Show(cts.Token);
        }
    }
}
