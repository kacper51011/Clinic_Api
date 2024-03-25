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

        public DateTimeOffset HospitalizedFrom { get; private set; }
        public DateTimeOffset HospitalizedTo { get; private set; }

        private Patient(string firstName, string lastName, string pesel, DateTimeOffset hospitalizedFrom, DateTimeOffset hospitalizedTo)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            HospitalizedFrom = hospitalizedFrom;
            HospitalizedTo = hospitalizedTo;
        }

        public Patient Create(string firstName, string lastName, string pesel, DateTimeOffset hospitalizedFrom, DateTimeOffset hospitalizedTo)
        {
            if(hospitalizedFrom.AddDays(10) > hospitalizedTo)
            {
                throw new DomainException("Patient can`t be hospitalized that longer than 10 days");
            }

            Patient data = new Patient(firstName, lastName, pesel, hospitalizedFrom, hospitalizedTo);
            data.InitializeRoot();

            return data;

        }

    }
}
