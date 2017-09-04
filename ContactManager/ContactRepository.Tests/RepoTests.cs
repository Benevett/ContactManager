using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ContactRepository.Tests
{ 

    [TestClass]
    public class RepoTests
    {
        /****** LOTS MORE TESTS WOULD BE HERE TO COVER ALL CODE PATHS ***************/

        [TestMethod]
        public void GetReturnsValidData()
        {
            //usually this would not use the actual repository but a mocked instance using MOQ or similar
            var repo = new Contacts.ContactRepository();
            var contact = repo.Get(1);
            Assert.AreEqual(1, contact.Id);
        }

        [TestMethod]
        public void ListReturnsValidData()
        {
            //usually this would not use the actual repository but a mocked instance using MOQ or similar
            var repo = new Contacts.ContactRepository();
            var contacts = repo.List();

            Assert.IsNotNull(contacts);
        }

        /****** LOTS MORE TESTS WOULD BE HERE TO COVER ALL CODE PATHS ***************/

    }
}
