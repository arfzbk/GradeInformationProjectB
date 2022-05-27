using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Tool : IEntity
    {
        [Key]
        public int ToolId { get; set; }
        public string ToolName { get; set; }
    }
}
