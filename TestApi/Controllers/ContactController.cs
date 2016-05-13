using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    public class ContactController : ApiController
    {

        private ContactRepository contactRepo;

        public ContactController()
        {
            this.contactRepo = new ContactRepository();
        }

        public Contact[] Get()
        {
            return this.contactRepo.GetAllContacts();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepo.SaveContact(contact);
            var res = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            return res;
        }

    }
}
