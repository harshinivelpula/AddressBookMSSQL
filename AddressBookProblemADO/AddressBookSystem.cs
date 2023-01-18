using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblemADO
{
    public class AddressBookSystem
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookServiceDB;";
        //create
        public void GetDetails(AddressBook addressBook)
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            try
            {
                using (sqlConnect)
                {
                    sqlConnect.Open();
                    SqlCommand command = new SqlCommand("SPGetAllDetails", sqlConnect); // sqlconnection
                    command.CommandType = CommandType.StoredProcedure;

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressBook.FirstName);
                    command.Parameters.AddWithValue("@LastName", addressBook.LastName);
                    command.Parameters.AddWithValue("@Address", addressBook.Address);
                    command.Parameters.AddWithValue("@City", addressBook.City);
                    command.Parameters.AddWithValue("@State", addressBook.State);
                    command.Parameters.AddWithValue("@ZipCode", addressBook.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", addressBook.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", addressBook.Email);
                    command.Parameters.AddWithValue("@BookName", addressBook.BookName);
                    command.Parameters.AddWithValue("BookNames", addressBook.BookNames);
                    command.Parameters.AddWithValue("PersonType", addressBook.PersonType);
                    command.Parameters.AddWithValue("PersonTypes", addressBook.PersonTypes);
                    int result = command.ExecuteNonQuery();
                    sqlConnect.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Details Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        //retieve
        public void RetrieveEntriesFromAddresBookDB()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<AddressBook> Book = new List<AddressBook>();
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveDetails", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBook addressBook = new AddressBook();
                            addressBook.FirstName = dr.GetString(0);
                            addressBook.LastName = dr.GetString(1);
                            addressBook.Address = dr.GetString(2);
                            addressBook.City = dr.GetString(3);
                            addressBook.State = dr.GetString(4);
                            addressBook.ZipCode = dr.GetInt16(5);
                            addressBook.PhoneNumber = dr.GetString(6);
                            addressBook.Email = dr.GetString(7);
                            addressBook.BookName = dr.GetString(8);
                            addressBook.BookNames = dr.GetString(9);
                            addressBook.PersonType = dr.GetString(10);
                            addressBook.PersonTypes = dr.GetString(11);
                            Book.Add(addressBook);
                        }
                        Console.WriteLine("FirstName" + " " + "LastName" + "  " + "Address" + "  " + "City" + "  " +
                         "State" + "  "+ "ZipCode"+" " + "PhoneNumber" + " " + "Email"+" "+ "BookName"+" "+
                         "BookNames"+" "+ "PersonType"+" "+ "PersonTypes"+" ");
                        foreach (var data in Book)
                        {
                            Console.WriteLine(data.FirstName + " " + data.LastName + "" + data.Address + "" + data.City
                            + " " + data.State + "" + data.ZipCode + "" + data.PhoneNumber+""+data.Email+""+data.BookName
                            +""+data.BookNames+""+data.PersonType+""+data.PersonTypes+"");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        //update
        public string UpdateDataInDataBase(AddressBook addressBook)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateData", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressBook.FirstName);
                    command.Parameters.AddWithValue("@LirstName", addressBook.LastName);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("name updated Successfully");
                        return "Contact Updated Successfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        //delete
        public string DeleteDataFromDataBase(string name)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPDelete", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", name);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("contact deleted successfully");
                        return "contact deleted successfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}