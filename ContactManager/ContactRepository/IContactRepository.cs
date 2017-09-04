using ContactRepository.DomainModel;
using System.Collections.Generic;

namespace Contacts
{
    public interface IContactRepository
    {

        Contact Get(int id);
        IEnumerable<Contact> List();
        Contact Update(Contact contact);
        Contact Create(Contact contact);
        void Delete(Contact contact);
    }
}