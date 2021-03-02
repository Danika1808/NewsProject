using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string DateOfBirth { get; private set; }
    }
}
