using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sistem_Ventas.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Sistem_Ventas.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IServiceProvider serviceProvider)
        {
            // CreateRoles(serviceProvider);
            //ejecutarTareaAsync();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            String mensaje;
            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                String[] rolesName = { "Admin", "User" };
                foreach (var item in rolesName)
                {
                    var roleExist = await roleManager.RoleExistsAsync(item);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(item));
                    }
                }
                var user = await userManager.FindByIdAsync("0e2d2def-8f40-412f-8f6a-46da5f8af873");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
        }
        private async Task ejecutarTareaAsync()
        {
            var data = await Tareas();

            String tarea = "Ahora ejecutaremos las demas líneas de código porque la tarea ha finalizado";
        }
        private async Task<String> Tareas()
        {
            Thread.Sleep(20 * 1000);
            String tarea = "Tarea finalizada";
            return tarea;
        }
    }
}
