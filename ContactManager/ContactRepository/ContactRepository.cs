using System;
using System.Collections.Generic;
using System.Linq;
using ContactRepository.DomainModel;

namespace Contacts
{
    public class ContactRepository : IContactRepository
    {
        //this is so we get the same list each time the API calls the repository and not something usual to do in production but OK for this demo
        private static  ICollection<Contact> _contacts = new List<Contact> {
            new Contact { Email = "test1@test.com", Id = 1, Firstname = "Fred", Surname = "Bloggs", HomeNumber = "01423332238", MobileNumber = "0795665665" },
            new Contact { Email = "test2@test.com", Id = 2, Firstname = "Liz", Surname = "Smith", HomeNumber = "01423332236", MobileNumber = "0795665676" },
            new Contact { Email = "test3@test.com", Id = 3, Firstname = "Fred", Surname = "Jones", HomeNumber = "01422131233", MobileNumber = "0795555665" },
            new Contact { Email = "test4@test.com", Id = 4, Firstname = "Mo", Surname = "Davis", HomeNumber = "01423364238", MobileNumber = "0795665665" },
            new Contact { Email = "test5@test.com", Id = 5, Firstname = "Lance", Surname = "Armstrong", HomeNumber = "01423332235", MobileNumber = "079534345" },
            new Contact { Email = "test6@test.com", Id = 6, Firstname = "Chris", Surname = "Farah", HomeNumber = "01423332243", MobileNumber = "0795665665" },
            new Contact { Email = "test7@test.com", Id = 7, Firstname = "Fred", Surname = "Froome", HomeNumber = "01423332237", MobileNumber = "0795665090" }
        };

        public Contact Create(Contact contact)
        {

            // lock on the list incase other thread is accessing. we need to work out the Id  
            { // probably a better way to do this but ...
                contact.Id = _contacts.Max(x => x.Id + 1);  // we need to create the Id 

                _contacts.Add(contact);

            }

            return contact;

        }

        public void Delete(Contact contact)
        {
            _contacts.Remove(contact);

        }

        public Contact Get(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<Contact> List()
        {
            return _contacts;

        }

        public Contact Update(Contact contact)
        {
            var updated = _contacts.Where(x => x.Id == contact.Id).FirstOrDefault();

            // normally would use Automapper to map the objects but not for now
            if (updated != null)
            {
                updated.Firstname = contact.Firstname;
                updated.Surname = contact.Surname;
                updated.HomeNumber = contact.HomeNumber;
                updated.Email = contact.Email;
                updated.MobileNumber = contact.MobileNumber;
                //only update if it has a value ( bit dodgy but...)
                updated.Photo = (contact.Photo!=null)?contact.Photo :updated.Photo;
            }

            return updated;


        }
    }
}
