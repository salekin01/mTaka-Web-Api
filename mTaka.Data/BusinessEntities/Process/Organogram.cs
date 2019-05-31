using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Process
{
    public class Organogram
    {
        [Key]
        public string EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Title { get; set; }

        public string AccTypeId { get; set; }

        public string TitleOfCourtesy { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string HomePhone { get; set; }

        public string ReportsTo { get; set; }
    }
}
