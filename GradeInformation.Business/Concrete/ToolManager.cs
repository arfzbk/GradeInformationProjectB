using GradeInformation.Business.Abstract;
using GradeInformation.DataAccess.Abstract;
using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Concrete
{
    public class ToolManager : IToolService
    {
        private IToolDal _toolDal;
        public ToolManager(IToolDal toolDal)
        {
            _toolDal = toolDal;
        }

        public void Add(Tool tool)
        {
            _toolDal.Add(tool);
        }

        public void Delete(Tool tool)
        {
            _toolDal.Delete(tool);
        }

        public Tool Get(int toolId)
        {
            return _toolDal.Get(x => x.ToolId == toolId);
        }

        public List<Tool> GetAll()
        {
            return _toolDal.GetAll();
        }
    }
}
