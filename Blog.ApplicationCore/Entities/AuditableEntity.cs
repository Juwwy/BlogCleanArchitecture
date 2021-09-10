using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class AuditableEntity
    {
        //Base class entity
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; set; }
    }
}
