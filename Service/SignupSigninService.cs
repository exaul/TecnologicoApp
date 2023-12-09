using TecnologicoApp.Models;
using TecnologicoApp.Service.Interface;

namespace TecnologicoApp.Service;

public class SignupSigninService : ISignupSigninService
{
    public async Task<bool> SignUpAsync(UsuarioRegistro usuario)
    {
        await Task.Delay(1000);
        if (usuario == null || 
            string.IsNullOrWhiteSpace(usuario.Email) || 
            string.IsNullOrWhiteSpace(usuario.Password)) 
        {
            return false;
        }
        
        Settings.EmailRegistro = usuario.Email;
        Settings.PasswordRegistro =usuario.Password;
        
        return true;
    }
}
