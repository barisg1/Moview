using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moview.Models;

namespace Moview.Controllers
{

    public class ProfileController : Controller
    {

        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // Profil bilgilerini görüntülemek için action metodu
        public IActionResult Index()
        {
            // Kullanıcıyı belirlemek için kimlik doğrulama işlemleri
            // Örnek olarak: var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userProfile = _context.Users.FirstOrDefault(); // Veritabanından kullanıcı bilgilerini çekin
            return View(userProfile);
        }

        // Profil bilgilerini düzenlemek için action metodu
        [HttpGet]
        public IActionResult Edit()
        {
            // Kullanıcıyı belirlemek için kimlik doğrulama işlemleri
            // Örnek olarak: var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userProfile = _context.Users.FirstOrDefault(); // Veritabanından kullanıcı bilgilerini çekin
            return View(userProfile);
        }

        [HttpPost]
        public IActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı belirlemek için kimlik doğrulama işlemleri
                // Örnek olarak: var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Kullanıcı profil bilgilerini güncelleme işlemleri
                var existingUser = _context.Users.FirstOrDefault(); // Veritabanından kullanıcı bilgilerini çekin
                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;

                    _context.SaveChanges(); // Veritabanındaki değişiklikleri kaydedin
                }
                return RedirectToAction("Index"); // Başarıyla güncelleme yapıldıktan sonra yönlendirme
            }
            return View(user);
        }
    }
}
