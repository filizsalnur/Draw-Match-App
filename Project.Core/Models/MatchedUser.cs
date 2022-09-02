using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Core.Models
{
    public partial class MatchedUser
    {
        public int FirstId { get; set; }
        public string FirstName { get; set; }
        public string FirstSurname { get; set; }
        public int? SecondId { get; set; }
        public string SecondName { get; set; }
        public int? SecondSurname { get; set; }
    }
}
