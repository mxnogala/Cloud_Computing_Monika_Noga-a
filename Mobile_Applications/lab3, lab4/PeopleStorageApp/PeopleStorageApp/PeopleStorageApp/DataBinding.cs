using PeopleStorageApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PeopleStorageApp
{
    public class DataBinding : INotifyPropertyChanged
    {
        private readonly Person person;
        public DataBinding(Person person)
        {
            this.person = person;
        }

        string firstName = string.Empty;
        string lastName = string.Empty;
        string phoneNumber = string.Empty;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value)
                    return;
                firstName = value;
                person.FirstName = firstName;
                OnPropertyChaned(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value)
                    return;
                lastName = value;
                person.LastName = lastName;
                OnPropertyChaned(nameof(LastName));
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber == value)
                    return;
                phoneNumber = value;
                person.PhoneNumber = phoneNumber;
                OnPropertyChaned(nameof(PhoneNumber));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChaned(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
