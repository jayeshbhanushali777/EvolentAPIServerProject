using Evolent.ContactManager.Controllers;
using Evolent.DataModel;
using Evolent.DataModel.GenericRepository;
using Evolent.DataModel.UnitOfWork;
using Evolent.TestHelper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.BusinessLogic.Tests
{
    [TestFixture]
    public class ContactControllerTest
    {
        #region Variables
        private IContactServices _contactService;
        private IUnitOfWork _unitOfWork;
        private List<Contact> _contacts;
        private GenericRepository<Contact> _contactRepository;
        private WebApiDbEntities _dbEntities;
        private HttpClient _client;

        private HttpResponseMessage _response;
        private const string ServiceBaseURL = "http://localhost:60249//";
        #endregion


        public void Setup()
        {
            _contacts = SetUpContacts();
            _dbEntities = new Mock<WebApiDbEntities>().Object;
            _contactRepository = SetUpContactRepository();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.SetupGet(s => s.ContactRepository).Returns(_contactRepository);
            _unitOfWork = unitOfWork.Object;
            _contactService = new ContactService(_unitOfWork);
            _client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };

        }
        #region Unit Tests

        /// <summary>
        /// Get all contacts test
        /// </summary>
        [Test]
        public void GetAllContactsApiTest()
        {
            
        }

        /// <summary>
        /// Get contact by Id
        /// </summary>
        [Test]
        public void GetcontactByIdApiTest()
        {
            
        }


        /// <summary>
        /// Create contact test
        /// </summary>
        [Test]
        public void CreateProductApiTest()
        {
            
        }

        /// <summary>
        /// Update Contact test
        /// </summary>
        [Test]
        public void UpdateContactApiTest()
        {
            
        }

        /// <summary>
        /// Delete contact test
        /// </summary>
        [Test]
        public void DeleteContactApiTest()
        {
           
        }

        #endregion
        /// <summary>
        /// Setup dummy contacts data
        /// </summary>
        /// <returns></returns>
        private static List<Contact> SetUpContacts()
        {
            var Id = new int();
            var contacts = DataInitializer.GetAllContacts();
            foreach (Contact cont in contacts)
                cont.ID = ++Id;
            return contacts;
        }

        private GenericRepository<Contact> SetUpContactRepository()
        {
            // Initialise repository
            var mockRepo = new Mock<GenericRepository<Contact>>(MockBehavior.Default, _dbEntities);

            // Setup mocking behavior
            mockRepo.Setup(p => p.GetAll()).Returns(_contacts);

            mockRepo.Setup(p => p.GetByID(It.IsAny<int>()))
            .Returns(new Func<int, Contact>(
            id => _contacts.Find(p => p.ID.Equals(id))));

            mockRepo.Setup(p => p.Insert((It.IsAny<Contact>())))
            .Callback(new Action<Contact>(newContact =>
            {
                dynamic maxContactID = _contacts.Last().ID;
                dynamic nextContactID = maxContactID + 1;
                newContact.ID = nextContactID;
                _contacts.Add(newContact);
            }));

            mockRepo.Setup(p => p.Update(It.IsAny<Contact>()))
            .Callback(new Action<Contact>(cont =>
            {
                var oldContact = _contacts.Find(a => a.ID == cont.ID);
                oldContact = cont;
            }));

            mockRepo.Setup(p => p.Delete(It.IsAny<Contact>()))
            .Callback(new Action<Contact>(cont =>
            {
                var contactToRemove =
        _contacts.Find(a => a.ID == cont.ID);

                if (contactToRemove != null)
                    _contacts.Remove(contactToRemove);
            }));

            // Return mock implementation object
            return mockRepo.Object;
        }

        public void DisposeAllObjects()
        {
            _contactService = null;
            _unitOfWork = null;
            _contactRepository = null;
            _contacts = null;
            if (_response != null)
                _response.Dispose();
            if (_client != null)
                _client.Dispose();
        }

    }
}
