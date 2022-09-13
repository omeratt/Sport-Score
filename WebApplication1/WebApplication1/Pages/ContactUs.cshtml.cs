using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public EmailAttachmentModel Model { get; set; }
        public ContactUsModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;     
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(EmailAttachmentModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            Model.From = user.Email;
            using (MailMessage mm = new MailMessage(Global.CONTACT_US_EMAIL, Global.CONTACT_US_EMAIL))
            {
                mm.Subject = Model.From + ", " + model.Subject;
                mm.Body = "from " + Model.From + ", " + model.Body;
                if (Request.Form.Files.Count > 0)
                {
                    string fileName = System.IO.Path.GetFileName(model.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attachment.OpenReadStream(), fileName));
                }
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    NetworkCredential NetworkCred = new NetworkCredential(Global.CONTACT_US_EMAIL, Global.CONTACT_US_PASSWORD);
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }

            return RedirectToPage("Index");
        }

    }
}
