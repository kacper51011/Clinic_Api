using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Api.Domain
{
    // for metadata
    public class AggregateRoot
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int Version { get; private set; }


        protected void InitializeRoot()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
        }

        protected void IncrementVersion()
        {
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
