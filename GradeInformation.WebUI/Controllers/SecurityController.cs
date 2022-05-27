using GradeInformation.Business.Abstract;
using GradeInformation.DataAccess.Concrete.Identity;
using GradeInformation.WebUI.Model;
using GradeInformation.WebUI.Model.Security;
using GradeInformation.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private IStudentService _studentManager;
        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, IStudentService studentManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _studentManager = studentManager;
        }
        public IActionResult Index()
        {
            return View();
        }
       //Login 
        public async Task<IActionResult> Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index2","Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("errorMessage", "Emailinizi Lütfen Doğrulayın");
                    TempData["errorMessage"] = "Emailinizi Lütfen Doğrulayın";
                    return View(loginViewModel);
                }
            }
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.IsPersistent, false);
            if (result.Succeeded)
            {
                string userString = user.UserName;
                var student = _studentManager.GetByStudentNumber(userString);
                HttpContext.Session.SetObject("user", student);
                return RedirectToAction("Index2", "Home");
            }
            ModelState.AddModelError("errorMessage", "Giriş yapılamadı.");
            TempData.Add("errorMessage", "Giriş yapılamadı.");
            return View(loginViewModel); 
        }
        //Logout
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Register()
        {
            TempData.Add("message", "Kullanıcı eğer sistemde var ise ilk şifresi son 4 hanesi olmaktadır");
            return View();
        }
        //Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var student = _studentManager.GetByTcNo(registerViewModel.TC);
            if (student == null)
            {
                TempData.Add("errorMessage", "Kimlik numarası verilen öğrenci bulunamadı");
                return View(registerViewModel);
            }
            var user = new AppIdentityUser
            {
                UserName = student.StudentNumber,
                Email = student.Email,
                TC = student.Tc
            };
            string userPassword = student.StudentNumber.Substring(5,4);
            var result = await _userManager.CreateAsync(user, userPassword);
            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callBackUrl = Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode.Result });

                SendEmail("Yeni Hesap Doğrulama", "arfzbk00708@gmail.com", callBackUrl);

                TempData.Add("message", "Email Doğrulama Kodu Kullanıcının Emailine Gönderildi.");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Add("errorMessage", "Kullanıcı Sisteme Kayıt Edilemedi");
                return View(registerViewModel);
            }

            return View(registerViewModel);
        }
        //Confirm Email
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Index", "Student");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException("User cant find by id");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }
            return View("Index", "Student");
        }
        public IActionResult ForgotPassword()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index2", "Home");
            }
            return View();
        }

        //Forgot Password
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(SecurityForgotPasswordViewModel viewModel)
        {
            string email = viewModel.Email;
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["errorMessage"] = "Herhangi bir öğrenci bulunamadı";
                return View();
            }
            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callBackUrl = Url.Action("ResetPassword", "Security", new { userId = user.Id, code = confirmationCode });
            SendEmail("Şifremi Unuttum", "arfzbk00708@gmail.com", callBackUrl);
            return RedirectToAction("ForgotPasswordEmailSent");
        }
        //Forgot Password Email Sent
        public IActionResult ForgotPasswordEmailSent()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index2", "Home");
            }
            return View();
        }
        //Reset Password
        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new ApplicationException("UserId or Code must be supplied for password reset");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }
        //Reset Password Screen
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }
            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                TempData["errorMessage"] = "Geçersiz Kullanıcı";
                return View(resetPasswordViewModel);
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirm");
            }
            TempData["errorMessage"] = "Şifre Sıfırlanırken Hata Oluştu";
            return View();
        }
        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }
        private void SendEmail(string subject,string userMail, string bodyMessage)
        {
            string to = userMail; //To address    
            string from = "arfzbk200708@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = bodyMessage ;
            
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("arfzbk200708@gmail.com", "AorZiBfEk6401.");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
