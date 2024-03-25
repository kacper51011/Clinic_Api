﻿using Clinic_Api.Domain.Exceptions;
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

        private Patient(string firstName, string lastName, string pesel)
        {
            PatientId = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            HospitalizedFrom = DateTimeOffset.UtcNow;
            HospitalizedTo = HospitalizedFrom.AddDays(7);
        }

        public static Patient Create(string firstName, string lastName, string pesel)
        {

            Patient data = new Patient(firstName, lastName, pesel);
            data.InitializeRoot();

            return data;

        }

        public void UpdatePersonalData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            this.IncrementVersion();
        }

        public void ExtendHospitalizationDuration()
        {

        }

    }
}
