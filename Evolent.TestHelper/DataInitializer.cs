using Evolent.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.TestHelper
{
    public class DataInitializer
    {
        /// <summary>
        /// Dummy contacts
        /// </summary>
        /// <returns></returns>
        public static List<Contact> GetAllContacts()
        {

            var contacts = new List<Contact>
                               {
                                   new Contact()
                                   {
                                     FirstName = "Tommy",LastName= "Sey",Address= "UK 16",
                                     Email ="Tommy.Sey@gmail.com", Status="0",
                                    PhoneNumber = "7799654599"                                    
                                   },

                                   new Contact()
                                   {
                                     FirstName = "Sam",LastName= "Puri",Address= "USA 16",
                                     Email ="Sam.Sey@gmail.com",Status="1",
                                     PhoneNumber= "7799654599"
                                     
                                   },
                                   new Contact()
                                   {
                                       FirstName = "Jal",LastName= "Band",Address= "SA 16",
                                     Email ="Band.Jal@gmail.com",Status="0",
                                     PhoneNumber = "8899654599"                                     
                                   },

                               };
            return contacts;
        }
    }
}
