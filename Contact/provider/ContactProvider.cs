using Contact.models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contact.provider
{
    public  class ContactProvider
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=Contact;User Id=postgres;Password=0987");


        public List<Contacts> getAllContacts()
        {
            connection.Open();
            var command = new NpgsqlCommand("Select * from contact", connection);
            var reader = command.ExecuteReader();
            List <Contacts> contacts = new List<Contacts>();
            while (reader.Read())
            {
                Contacts contact = new Contacts();
                contact.Id = (int)reader["id"];
                contact.FullName = (string)reader["full_name"];
                contact.PhoneNumber = (string)reader["phone_number"];
                contact.LastModificationDate = (DateTime)reader["last_modification_date"];
                contacts.Add(contact);
            }

            reader.Close();
            connection.Close();

            return contacts;
        }

        public void deleteById(int id)
        {
            connection.Open();
            var command = new NpgsqlCommand("DELETE FROM contact WHERE id=@id", connection);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int addContact(Contacts contact)
        {
            connection.Open();
            var command = new NpgsqlCommand("INSERT INTO contact Values (DEFAULT, @FullName, @PhoneNumber, @ModificationDate) RETURNING id", connection);
            command.Parameters.AddWithValue("FullName", contact.FullName);
            command.Parameters.AddWithValue("PhoneNumber", contact.PhoneNumber);
            command.Parameters.AddWithValue("ModificationDate", contact.LastModificationDate);
            int insertedId = (int)command.ExecuteScalar();
            connection.Close();

            return insertedId;
        }

        public void updateContact(Contacts contact)
        {
            connection.Open();
            var command = new NpgsqlCommand("UPDATE contact SET last_modification_date=@ModificationDate, full_name=@FullName, phone_number=@PhoneNumber WHERE id=@id", connection);
            command.Parameters.AddWithValue("FullName", contact.FullName);
            command.Parameters.AddWithValue("PhoneNumber", contact.PhoneNumber);
            command.Parameters.AddWithValue("ModificationDate", contact.LastModificationDate);
            command.Parameters.AddWithValue("Id", contact.Id);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<Contacts> searchByFullName(string fullName)
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT * from contact WHERE full_name=@FullName", connection);
            command.Parameters.AddWithValue("FullName", fullName);
            var reader = command.ExecuteReader();
            List<Contacts> contacts = new List<Contacts>();
            while (reader.Read())
            {
                Contacts contact = new Contacts();
                contact.Id = (int)reader["id"];
                contact.FullName = (string)reader["full_name"];
                contact.PhoneNumber = (string)reader["phone_number"];
                contact.LastModificationDate = (DateTime)reader["last_modification_date"];
                contacts.Add(contact);
            }

            reader.Close();
            connection.Close();

            return contacts;
        }

        public bool existsByPhoneNumber(string phoneNumber)
        {
            connection.Open();
            var check = new NpgsqlCommand("SELECT id from contact where phone_number=@phoneNumber", connection);
            check.Parameters.AddWithValue("phoneNumber", phoneNumber);

            if (check.ExecuteScalar() != null)
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
    }
}
