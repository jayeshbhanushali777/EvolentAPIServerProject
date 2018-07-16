using AutoMapper;
using Evolent.BusinessEntities;
using Evolent.DataModel;
using Evolent.DataModel.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Evolent.BusinessLogic
{
    public class ContactService : IContactServices
    {
        private readonly IUnitOfWork _unitOfWork;
       

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ContactEntity GetContactById(int contactId)
        {
            var contact = _unitOfWork.ContactRepository.GetByID(contactId);
            if(contact!=null)
            {
                //Mapper.CreateMap<Contact, ContactEntity>();
                var mapConfig = new MapperConfiguration(x => { x.CreateMap<Contact, ContactEntity>(); });
                IMapper mapper = mapConfig.CreateMapper();
                var contactModel = mapper.Map<Contact, ContactEntity>(contact);
                return contactModel;
            }
            return null;
        }


        public IEnumerable<ContactEntity> GetAllContacts()
        {
            var contacts = _unitOfWork.ContactRepository.GetAll().ToList();
            if (contacts.Any())
            {
                //Mapper.CreateMap<Contact, ContactEntity>();
                var mapConfig = new MapperConfiguration(x => { x.CreateMap<Contact, ContactEntity>(); });
                IMapper mapper = mapConfig.CreateMapper();
                var contactModel = mapper.Map<List<Contact>, List<ContactEntity>>(contacts);
                return contactModel;
            }
            return null;
        }

        public int CreateContact(ContactEntity contactEntity)
        {
            using (var scope = new TransactionScope())
            {
                var contact = new Contact
                {
                    FirstName = contactEntity.FirstName,
                    LastName = contactEntity.LastName,
                    Address = contactEntity.Address,
                    Email = contactEntity.Email,
                    PhoneNumber = contactEntity.PhoneNumber,
                    Status = contactEntity.Status.ToString()
                };
                _unitOfWork.ContactRepository.Insert(contact);
                _unitOfWork.Save();
                scope.Complete();
                return contact.ID;
            }
        }

        public bool UpdateContact(int Id, ContactEntity contactEntity)
        {
            var success = false;
            if (contactEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var contact = _unitOfWork.ContactRepository.GetByID(Id);
                    if (contact != null)
                    {
                        contact.FirstName = contactEntity.FirstName;
                        contact.LastName = contactEntity.LastName;
                        contact.Address = contactEntity.Address;
                        contact.Email = contactEntity.Email;
                        contact.PhoneNumber = contactEntity.PhoneNumber;
                        contact.Status = contactEntity.Status.ToString();
                        _unitOfWork.ContactRepository.Update(contact);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteContact(int Id)
        {
            var success = false;
            if (Id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var contact = _unitOfWork.ContactRepository.GetByID(Id);
                    if (contact != null)
                    {
                        _unitOfWork.ContactRepository.Delete(contact);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
