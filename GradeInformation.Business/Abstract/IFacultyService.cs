﻿using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface IFacultyService
    {
        List<Faculty> GetAll();
    }
}
