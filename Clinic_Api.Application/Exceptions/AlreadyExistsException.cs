﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Exceptions
{
    public class AlreadyExistsException(string message) : Exception(message)
    {
    }
}
