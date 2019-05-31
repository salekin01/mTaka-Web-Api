using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.OtherEntities
{
    public class UserCredentials
    {
        [Required(ErrorMessage = "User Id is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        public string Password { get; set; }

        public List<Menu> LIST_MENU_MAP { get; set; }
        public List<Permission> PERMISSIONS { get; set; }
    }

    public class Permission
    {
        public string PERMISSION_DETAILS { get; set; }
    }
}
