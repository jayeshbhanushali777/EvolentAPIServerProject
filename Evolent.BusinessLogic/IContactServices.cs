using Evolent.BusinessEntities;
using System.Collections.Generic;

namespace Evolent.BusinessLogic
{
    public interface IContactServices
    {
        ContactEntity GetContactById(int Id);
        IEnumerable<ContactEntity> GetAllContacts();
        int CreateContact(ContactEntity contactEntity);
        bool UpdateContact(int Id, ContactEntity contactEntity);
        bool DeleteContact(int Id);
    }
}
