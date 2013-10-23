using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sports.Domain.Entities
{
    public partial class Tournament
    {
        public Tournament()
        {
            this.Schedule = new HashSet<Schedule>();
        }

        //Primary Key Id
        [HiddenInput(DisplayValue=false)]
        public int TournamentId { get; set; }

        [Required(ErrorMessage="Please enter a tournament name")]
        public string TournamentName { get; set; }

        //public string Description { get; set; }
        [Required(ErrorMessage="Please enter start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter end date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Flags { get; set; }

        //Navigation Properties
        public virtual ICollection<Schedule> Schedule { get; private set; }
    }
}
