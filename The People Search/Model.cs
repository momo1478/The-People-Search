using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_People_Search
{
    [Table("Person")]
    public class Person
    {
        [Key, Column(Order = 0)]
        public string FirstName { get; set; }
        [Key, Column(Order = 1)]
        public string LastName { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }
        public string Interests { get; set; }
    }

    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
