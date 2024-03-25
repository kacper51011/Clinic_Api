using Clinic_Api.Domain.Exceptions;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Domain.Entities
{
    public class Patient : AggregateRoot
    {
        [BsonId]
        [BsonElement("_id")]
        public string PatientId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Pesel { get; private set; }

        public string Street {  get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }

        private Patient(string firstName, string lastName, string pesel, string street, string city, string postalCode)
        {
            PatientId = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Street = street;
            City = city;
            PostalCode = postalCode;


        }

        public static Patient Create(string firstName, string lastName, string pesel, string street, string city, string postalCode)
        {

            Patient data = new Patient(firstName, lastName, pesel, street, city, postalCode);
            data.InitializeRoot();

            return data;

        }

        public void UpdatePersonalData(string firstName, string lastName, string pesel, string street, string city, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Street = street;
            City = city;
            PostalCode = postalCode;

            this.IncrementVersion();
        }

    }
}
