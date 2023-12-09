using TecnologicoApp.Models;

namespace TecnologicoApp.Service.Interface
{
    public interface ISignupSigninService
    {
        public Task<bool>SignUpAsync(UsuarioRegistro usuario);

    }
}
