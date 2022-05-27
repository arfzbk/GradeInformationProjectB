using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.DataAccess.Concrete.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public string TC { get; set; }
    }
}
