using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Core.Models
{
    public partial class DrawedUser
    {
        public int ChoserId { get; set; }
        public string ChoserName { get; set; }
        public string ChoserSurname { get; set; }
        public int? ChosenId { get; set; }
        public string ChosenName { get; set; }
        public string ChosenSurname { get; set; }
    }
}
