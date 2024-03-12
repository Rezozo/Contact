using Contact.models;
using Contact.provider;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Contact
{
    public partial class ContactList : Form
    {
        private List<Contacts> allContacts = new List<Contacts>();
        private ContactProvider contactProvider;

        public ContactList()
        {
            contactProvider = new ContactProvider();
            InitializeComponent();
            UpdateContacts();
        }

        private void UpdateContacts()
        {
            contactView.Rows.Clear();
            foreach (var contact in allContacts)
            {
                int index = contactView.Rows.Add(contact.Id, contact.FullName, contact.PhoneNumber, contact.LastModificationDate.ToShortDateString());
                contactView.Rows[index].Tag = "OLD";
            }
        }

        private void ContactList_Load(object sender, System.EventArgs e)
        {
            List<Contacts> contacts = contactProvider.getAllContacts();
            foreach (Contacts contact in contacts)
            {
                allContacts.Add(contact);
            }
            UpdateContacts();
        }

        private void contactView_SelectionChanged(object sender, EventArgs e)
        {
            if (contactView.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = contactView.SelectedRows[0];
                    row.Visible = false;

                    Contacts contact = allContacts.Cast<Contacts>().First(c => c.Id == (int)row.Cells["Id"].Value);
                    if (contact != null)
                    {
                        allContacts.Remove(contact);
                    }

                    contactProvider.deleteById(contact.Id);
                } catch
                {
                    MessageBox.Show("Выберите заполненную строку!");
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsWithEmptyTag = contactView.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Tag == null && !row.IsNewRow)
                .ToList();

            if (rowsWithEmptyTag.Count > 0)
            {
                foreach(DataGridViewRow row in rowsWithEmptyTag)
                {
                    Contacts contact = new Contacts();
                    string phoneNumber = (string)row.Cells["PhoneNumber"].Value;

                    if (!isValidData(phoneNumber))
                    {
                        return;
                    }

                    if (contactProvider.existsByPhoneNumber(phoneNumber))
                    {
                        MessageBox.Show("Контакт с таким номером телефона уже существует");
                        return;
                    }

                    contact.PhoneNumber = phoneNumber;
                    contact.FullName = (string)row.Cells["FullName"].Value;
                    contact.LastModificationDate = DateTime.Now;

                    int insertedId = contactProvider.addContact(contact);

                    contact.Id = insertedId;
                    allContacts.Add(contact);
                }
            }

            List<DataGridViewRow> rowsWithTag = contactView.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Tag == "UPDATED")
                .ToList();

            if (rowsWithTag.Count > 0)
            {
                foreach (DataGridViewRow row in rowsWithTag)
                {
                    Contacts contact = new Contacts();
                    string phoneNumber = (string)row.Cells["PhoneNumber"].Value;

                    if (!isValidData(phoneNumber))
                    {
                        return;
                    }

                    contact.Id = (int)row.Cells["Id"].Value;
                    contact.PhoneNumber = phoneNumber;
                    contact.FullName = (string)row.Cells["FullName"].Value;
                    contact.LastModificationDate = DateTime.Now;

                    contactProvider.updateContact(contact);

                    int index = allContacts.FindIndex(p => p.Id == contact.Id);

                    allContacts[index] = contact;
                }
            }

            UpdateContacts();
        }

        private void contactView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = contactView.Rows[e.RowIndex]; 

            if (row.Tag != null)
            {
                if (isValidData((string)row.Cells["PhoneNumber"].Value))
                {
                    row.Tag = "UPDATED";
                }
            }
        }

        public bool isValidData(string phoneNumber)
        {
            if (phoneNumber.Count(char.IsDigit) < 11)
            {
                MessageBox.Show("Номер телефона должен содержать 11 цифр");
                return false;
            }

            return true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text != "")
            {
                List<Contacts> contacts = contactProvider.searchByFullName(searchTxt.Text);

                contactView.Rows.Clear();
                foreach(Contacts contact in contacts)
                {
                    int index = contactView.Rows.Add(contact.Id, contact.FullName, contact.PhoneNumber, contact.LastModificationDate.ToShortDateString());
                    contactView.Rows[index].Tag = "OLD";
                }
            } else
            {
                UpdateContacts();
            }
        }

        private void contactView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
