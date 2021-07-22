using AutoMapper;
using DTO;
using EntityForDatabase.Entity;
using IRepositoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopPakemon.Models.ModelForUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShopPakemon.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork UserServices;
        private IMapper Mapper;
        public UserController(IUnitOfWork userServices, IMapper mapper)
        {
            UserServices = userServices;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult AllUsersAndTheirOrders()
        {
            List<UserDTO> UsersWithOrder = UserServices.User.Get().Select(el => Mapper.Map<UserDTO>(el)).ToList();

            ViewModelForAllUser allUser = new ViewModelForAllUser() { AllUser = UsersWithOrder };
            return View(allUser);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(ViewModelForUser request)
        {
            User user = UserServices.User.GetBy(el => el.Email == request.Email);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    user.NumberEmailSent++;
                    UserServices.User.Update(user);
                    await UserServices.SaveChangesAsync();
                    //await SendEmailAsync ("Укажите емеил отправителя", "Укажите пароль от Email отправителя", request.Email, "Тема письма", "текст письма");// укажите Email тему и текст письма
                    return RedirectToAction(nameof(AllUsersAndTheirOrders));
                }
                else
                {
                    return View(request);
                }
            }

            UserDTO NewUserDTO = new UserDTO()
            {
                id = Guid.NewGuid(),
                OrderTime = DateTime.Now,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                NumberEmailSent = 1
            };

            await UserServices.User.Add(Mapper.Map<User>(NewUserDTO));
            await UserServices.SaveChangesAsync();
            //await SendEmailAsync("Укажите емеил отправителя", "Укажите пароль от Email отправителя", request.Email, "Тема письма", "текст письма"); // укажите Email тему и текст письма

            return RedirectToAction(nameof(AllUsersAndTheirOrders));

        }

        private async Task SendEmailAsync(string fromEmail, string youPassword, string toEmait, string subject, string body)
        {
            MailAddress from = new MailAddress($"{fromEmail}");
            MailAddress to = new MailAddress($"{toEmait}");
            MailMessage m = new MailMessage(from, to);
            m.Subject = $"{subject}";
            m.Body = $"{body}";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential($"{fromEmail}", $"{youPassword}");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);

        }
    }
}
