using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabbit.Models.Entities;

namespace Rabbit.BLL.Repository
{
    public class CustomerRepo : RepositoryBase<Customer, Guid> { }
    public class MailLogRepo : RepositoryBase<MailLog, Guid> { }
}
