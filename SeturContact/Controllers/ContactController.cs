using Microsoft.AspNetCore.Mvc;
using SeturContact.Models;

namespace SeturContact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContactResponse GetContacts(int contactId)
        {
            var contact = new Contact();

            try
            {

                using (var ctx = new ContactDbContext())
                {
                    contact = ctx.Contacts.Find(contactId);

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return new ContactResponse { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }

            return new ContactResponse() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
        }

        [HttpGet]
        public ContactResponse CreateContact(Contact contact)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.Contacts.Add(contact);

                    ctx.SaveChanges();
                }

                return new ContactResponse() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpGet]
        public ContactResponse UpdateContact(Contact contact)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.Contacts.Update(contact);

                    ctx.SaveChanges();
                }

                return new ContactResponse() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }

        [HttpGet]
        public ContactResponse DeleteContact(Contact contact)
        {
            try
            {
                using (var ctx = new ContactDbContext())
                {
                    ctx.Contacts.Remove(contact);

                    ctx.SaveChanges();
                }

                return new ContactResponse() { Result = new List<Contact>() { contact }, Type = ResponseType.Succes };
            }
            catch (Exception ex)
            {

                return new ContactResponse { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }
    }
}