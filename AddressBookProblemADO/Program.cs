namespace AddressBookProblemADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("welcome to address book problem");
            AddressBookSystem addressBookSystem = new AddressBookSystem();
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter the option : 1.GetDetails \n 2.RetrieveEntriesFromAddresBookDB \n 3.UpdateDataInDataBase \n 4.DeleteDataFromDataBase");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
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
                        addressBookSystem.GetDetails(address);
                        break;
                    case 2:
                            addressBookSystem.RetrieveEntriesFromAddresBookDB();
                        break;
                    case 3:
                        AddressBook addressess = new AddressBook
                        {
                            FirstName = "sathvik",
                            LastName = "v"
                        };
                        addressBookSystem.UpdateDataInDataBase(addressess);
                        break;
                    case 4:
                        addressBookSystem.DeleteDataFromDataBase("ishu");
                        break;

                    case 5:
                        flag = false;
                        break;
                }
            }

        }
    }
}