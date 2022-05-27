using GradeInformation.Business.Abstract;
using GradeInformation.Business.Concrete;
using GradeInformation.DataAccess.Abstract;
using GradeInformation.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace GradeInformation.WebUI.Services
{
    public static class ServiceExtensions  
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            if (services != null)
            {
                services.AddScoped<ICityService, CityManager>();
                services.AddScoped<ICityDal, EfCityDal>();

                services.AddScoped<ICompanyService, CompanyManager>();
                services.AddScoped<ICompanyDal, EfCompanyDal>();

                services.AddScoped<ICompanyFieldService, CompanyFieldManager>();
                services.AddScoped<ICompanyFieldDal, EfCompanyFieldDal>();

                services.AddScoped<IDegreeService, DegreeManager>();
                services.AddScoped<IDegreeDal, EfDegreeDal>();

                services.AddScoped<IFacultyService, FacultyManager>();
                services.AddScoped<IFacultyDal, EfFacultyDal>();

                services.AddScoped<IFieldService, FieldManager>();
                services.AddScoped<IFieldDal, EfFieldDal>();


                services.AddScoped<ISectorCompanyService, SectorCompanyManager>();
                services.AddScoped<ISectorCompanyDal, EfSectorCompanyDal>();

                services.AddScoped<ISectorService, SectorManager>();
                services.AddScoped<ISectorDal, EfSectorDal>();

                services.AddScoped<IStudentCompanyService, StudentCompanyManager>();
                services.AddScoped<IStudentCompanyDal, EfStudentCompanyDal>();

                services.AddScoped<IStudentCompanyToolService, StudentCompanyToolManager>();
                services.AddScoped<IStudentCompanyToolDal, EfStudentCompanyToolDal>();

                services.AddScoped<IStudentService, StudentManager>();
                services.AddScoped<IStudentDal, EfStudentDal>();

                services.AddScoped<IToolService, ToolManager>();
                services.AddScoped<IToolDal, EfToolDal>();
                
            }
        }
    }
}
