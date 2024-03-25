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
        // I Feel like working with DateTimeOffset than DateTime is a bit more save
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public int Version { get; private set; }


        protected void InitializeRoot()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
            Version = 1;
        }

        protected void IncrementVersion()
        {
            Version++;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

    }
}
