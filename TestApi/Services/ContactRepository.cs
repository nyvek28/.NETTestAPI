using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Models;

namespace TestApi.Services
{
    public class ContactRepository
    {

        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                var contacts = new Contact[]
                {
                    new Contact
                    {
                        Id = 1,
                        Name = "Nicole Acosta"
                    },
                    new Contact
                    {
                        Id = 2,
                        Name = "Armando Quesada"
                    }
                };

                ctx.Cache[CacheKey] = contacts;
            }
        }

        public Contact[] GetAllContacts()
        {

            var ctx = HttpContext.Current;
            Contact[] contacts;

            if (ctx != null)
            {
                contacts = (Contact[])ctx.Cache[CacheKey];
            }
            else
            {
                contacts = new Contact[]
                {
                    new Contact
                    {
                        Id = 0,
                        Name = "Placeholder"
                    }
                };
            }
            

            return contacts;
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;
            bool saved = false;

            if(ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    saved = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return saved;
        }
    }
}