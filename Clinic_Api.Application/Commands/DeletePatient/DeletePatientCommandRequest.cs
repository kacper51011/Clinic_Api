﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Application.Commands.DeletePatient
{
    public class DeletePatientCommandRequest(string id): IRequest
    {
    }
}
