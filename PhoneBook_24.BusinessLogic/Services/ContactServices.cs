﻿using PhoneBook_24.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_24.BusinessLogic.Services
{
    interface IContactService
    {
        int Create(Contact contact);

        void Update(Contact contact);

        void Delete(Contact contact);

        List<Contact> GetAll();

        Contact Get(int id);
    }

    public static class ContactService
    {
     private static List<Contact> _contacts = new List<Contact>
        {
           new Contact
           {
               Email= "ads@djk.com",
               Id =1,
               Name = "Vitalii Che",
               Phones = new List<Phone>
               {
                   new Phone
                   {
                       Id = 0,
                       Type = 1,
                       Number = "0501234567"
                   }
               }

           }
        };

        private static List<Phone> GetMokckedPhone()
        {
            return new List<Phone>
            {
                new Phone
                {
                    Id=1,
                    Number="0757483864",
                    Type = 2
                },

                new Phone
                {
                    Id = 2,
                    Number="0674539217",
                    Type = 3
                    
                },

                new Phone
                {
                    Id = 3,
                    Number="0506371938",
                    Type = 1
                }
            };
        }

        public static int Create(Contact contact)
        {
            contact.Id = GetMax();
            contact.Phones = GetMokckedPhone();

            _contacts.Add(contact);

            return contact.Id;
        }


        public static void Delete(int id)
        {
            var contact = Get(id);

            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static Contact Get(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public static List<Contact> GetAll()
        {
            return _contacts.OrderBy(x => x.Name).ToList();
        }

        public static void Update(Contact contact)
        {
            var oldContact = Get(contact.Id);

            oldContact.Name = contact.Name;
            oldContact.Email = contact.Email;
        }

        private static int GetMax()
        {
            return _contacts.Any() ? _contacts.Max(x => x.Id) + 1:1;
        }
    }
}
