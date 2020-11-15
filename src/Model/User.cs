using System;
using System.Collections.Generic;

namespace IMPA
{
    public class User : IIdentifiable
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
