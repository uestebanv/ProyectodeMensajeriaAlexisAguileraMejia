using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class Usuarios : Controller
    {
		[HttpGet]
        public IActionResult Index()
        {
			ML.Usuarios usuarios = new ML.Usuarios();
			ML.Result result = BL.Usuarios.GetAll();
			usuarios.UsuariosObject = result.Objects;
            return View(usuarios);
        }
		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }
		[HttpPost]
        public IActionResult VerificacionLogin(string Email, string Password)
        {
			ML.Result result = BL.Usuarios.GetByEmail(Email);

			if (result != null)
			{
				ML.Usuarios usuarios = (ML.Usuarios)result.Object;
				if (Password == usuarios.Password)
				{
					return RedirectToAction("index", "Home");
				}
				else
				{
					ViewBag.Mensaje = "Contraseña Incorrecta";
					ViewBag.Correo = false;
					return RedirectToAction("Login", "Usuarios");
				}
			}
			else
			{
				ViewBag.Mensaje = "No existe la cuenta";
				ViewBag.Correo = false;
				return PartialView("Modal");
			}
		}
    }
	public class ChatHub : Hub
	{
		public async Task SendMessage(string user, string message)
		{
     		await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}