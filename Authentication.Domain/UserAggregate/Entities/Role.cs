using Ardalis.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.UserAggregate.Entities
{
    public class Role : EntityBase, IAggregateRoot
    {
        public int Id { get; set; }
        public string Description { get;set; }
        public ICollection<User> Users { get; set; }
    }
}
