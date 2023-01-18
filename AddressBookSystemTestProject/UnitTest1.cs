using AddressBookProblemADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace AddressBookSystemTestProject
{
    public class Tests
    {
        [TestClass]
        public class UnitTest1
        {
            AddressBookSystem addressBookSystem = new AddressBookSystem();
            [TestMethod]
            public void GetDetails()
            {
                AddressBook address = new AddressBook()
                {
                    FirstName = "Riya",
                    LastName = "Chowdary",
                    Address = "Vikas Colony",
                    City = "HNK",
                    State = "TS",
                    ZipCode = 506164,
                    PhoneNumber = "7256426257",
                    Email = "riyachowdary@gmail.com",
                    BookName = "ice",
                    BookNames = "icebreak",
                    PersonType = "friend",
                    PersonTypes = "friends"
                };
                string result = AddressBookSystem.GetDetails(address);
                Assert.AreEqual("added Successfully", result);
            }
        }
        [TestMethod]
        public void RetriveDataFromDB()
        {
            string result = AddressBookSystem.RetrieveEntriesFromAddresBookDB();
            Assert.AreEqual("retrived Sucessfully", result);
        }
        [TestMethod]
        public void UpdateDetails(AddressBook address)
        {
            AddressBook addressess = new AddressBook
            {
                FirstName = "sathvik",
                LastName = "v"
            };
            string result = AddressBookSystem.UpdateDataInDataBase(addressess);
            Assert.AreEqual("updated Successfully", result);
        }
        [TestMethod]
        public void DeleteDetails(string name)
        {
            string result = AddressBookSystem.DeleteDataFromDataBase("Riya");
            Assert.AreEqual("deleted Successfully", result);
        }
    }
}