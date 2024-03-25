using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Domain
{
    public class PaginationParameters
    {
        private const int maxPageSize = 50;
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

    }
}
