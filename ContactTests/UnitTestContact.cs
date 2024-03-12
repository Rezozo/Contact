using Contact;
using Contact.models;
using Contact.provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactTests
{
    [TestClass]
    public class UnitTestContact
    {
        private ContactProvider provider;
        private ContactList contactList;

        [TestInitialize]
        public void Init()
        {
            provider = new ContactProvider();
            contactList = new ContactList();
        }

        [TestMethod]
        public void GetAllContactsTest()
        {
            List<Contacts> contacts = provider.getAllContacts();
            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count > 0);
        }

        [TestMethod]
        public void DeleteByIdTest()
        {
            int contactIdToDelete = 999;

            provider.deleteById(contactIdToDelete);
            List<Contacts> remainingContacts = provider.getAllContacts();

            Assert.IsFalse(remainingContacts.Any(c => c.Id == contactIdToDelete));
        }

        [TestMethod]
        public void AddContactTest()
        {
            Contacts newContact = new Contacts();
            newContact.PhoneNumber = "12345678900";
            newContact.FullName = "Test";
            newContact.LastModificationDate = DateTime.Now;

            int insertedId = provider.addContact(newContact);
            List<Contacts> updatedContacts = provider.getAllContacts();

            Assert.IsTrue(insertedId > 0);
            Assert.IsTrue(updatedContacts.Any(c => c.Id == insertedId));
        }

        [TestMethod]
        public void UpdateContactTest()
        {
            Contacts newContact = new Contacts();
            newContact.Id = 1;
            newContact.PhoneNumber = "77777777772";
            newContact.FullName = "Антон";
            newContact.LastModificationDate = DateTime.Now;

            provider.updateContact(newContact);
            List<Contacts> updatedContacts = provider.getAllContacts();
            Contacts updatedContact = updatedContacts.FirstOrDefault(c => c.Id == newContact.Id);

            Assert.IsNotNull(updatedContact);
            Assert.AreEqual(newContact.FullName, updatedContact.FullName);
            Assert.AreEqual(newContact.PhoneNumber, updatedContact.PhoneNumber);
        }

        [TestMethod]
        public void SearchByFullNameTest()
        {
            string searchName = "Антон";

            List<Contacts> matchingContacts = provider.searchByFullName(searchName);

            Assert.IsNotNull(matchingContacts);
            Assert.IsTrue(matchingContacts.Any(c => c.FullName.Contains(searchName)));
        }

        [TestMethod]
        public void ExistsByPhoneNumberTest_Exists()
        {
            string existingPhoneNumber = "77777777777";

            bool exists = provider.existsByPhoneNumber(existingPhoneNumber);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void ExistsByPhoneNumberTest_NotExists()
        {
            string existingPhoneNumber = "77777777711";

            bool exists = provider.existsByPhoneNumber(existingPhoneNumber);

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void ValidatePhoneNumberTest_Valid()
        {
            string rightPhoneNumber = "79003012343";

            bool isValid = contactList.isValidData(rightPhoneNumber);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidatePhoneNumberTest_NotValid()
        {
            string notValidPhoneNumber = "79003012";

            bool isValid = contactList.isValidData(notValidPhoneNumber);
            Assert.IsFalse(isValid);
        }
    }
}
