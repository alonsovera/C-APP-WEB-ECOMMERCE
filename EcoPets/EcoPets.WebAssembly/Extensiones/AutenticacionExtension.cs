using Blazored.LocalStorage;
using EcoPets.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace EcoPets.WebAssembly.Extensiones
{
    public class AutenticacionExtension  : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal classPrincipal;
            if (sesionUsuario != null)
            {
                classPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                   new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                   new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                   new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                   new Claim(ClaimTypes.Role, sesionUsuario.Rol),

                }, "JwtAuth"));

                await _localStorageService.SetItemAsync("sesionUsuario", sesionUsuario);
            }
            else
            {
                classPrincipal = _sinInformacion;
                await _localStorageService.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(classPrincipal)));

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorageService.GetItemAsync<SesionDTO>("sesionUsuario");

            if(sesionUsuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                   new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                   new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                   new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                   new Claim(ClaimTypes.Role, sesionUsuario.Rol),

                }, "JwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }
    }
}
