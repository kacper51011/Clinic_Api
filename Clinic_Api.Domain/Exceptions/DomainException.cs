﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Domain.Exceptions
{
    public class DomainException(string message) : Exception(message)
    {
    }
}
