using System.Collections.Generic;

namespace GradeInformation.WebUI.Model
{
    public class StatisticalViewModel
    {
        public int CountOfGraduate { get; internal set; }
        public Dictionary<string, int> Tools { get; internal set; }
        public Dictionary<string, int> Fields { get; internal set; }
        public Dictionary<string, int> Sectors { get; internal set; }
        public decimal Ortalama { get; internal set; }
        public decimal AverageGPA { get; internal set; }
    }
}
