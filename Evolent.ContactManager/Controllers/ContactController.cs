using Evolent.BusinessEntities;
using Evolent.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evolent.ContactManager.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactServices _contactServices;

        #region Public Constructor
        public ContactController(IContactServices contactService)
        {
            _contactServices = contactService;
        }
        #endregion

        // GET api/Contact
        public HttpResponseMessage Get()
        {
            var contacts = _contactServices.GetAllContacts();
            if(contacts!=null)
            {
                var contactsEntities = contacts as List<ContactEntity> ?? contacts.ToList();
                if (contactsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, contactsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contacts not found");
        }

        // GET api/Contact/id
        public HttpResponseMessage Get(int id)
        {
            var contacts = _contactServices.GetContactById(id);
            if (contacts != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, contacts);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contacts not found for ID : " + id);
        }

        // POST api/Contact
        public HttpResponseMessage Post([FromBody] ContactEntity contactEntity)
        {
            if (ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _contactServices.CreateContact(contactEntity));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Invalid Data");
            }
        }

        // PUT api/Contact/id
        public HttpResponseMessage Put(int id, [FromBody] ContactEntity contactEntity)
        {
            if (ModelState.IsValid && id > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK,_contactServices.UpdateContact(id, contactEntity));
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Invalid Data");

        }

        // DELETE api/Contact/id
        public bool Delete(int id)
        {
            if(id>0)
            {
                return _contactServices.DeleteContact(id);
            }
            return false;
        }


    }
}
