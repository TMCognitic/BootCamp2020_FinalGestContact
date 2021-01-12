using GestContact.API.Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.API.Models.Global.Repositories.Mappers
{
    static class DataRecordExtensions
    {
        internal static Customer ToCustomer(this IDataRecord dataRecord)
        {
            return new Customer { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"], Email = (string)dataRecord["Email"] };
        }

        internal static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact() { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"], Email = (string)dataRecord["Email"], Phone = (string)dataRecord["Phone"], BirthDate = (DateTime)dataRecord["BirthDate"], CustomerId = (int)dataRecord["CustomerId"] };
        }
    }
}
