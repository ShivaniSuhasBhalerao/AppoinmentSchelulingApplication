using AppoinmentSchelulingProject.Localization;
using Volo.Abp.Application.Services;

namespace AppoinmentSchelulingProject;

/* Inherit your application services from this class.
 */
public abstract class AppoinmentSchelulingProjectAppService : ApplicationService
{
    protected AppoinmentSchelulingProjectAppService()
    {
        LocalizationResource = typeof(AppoinmentSchelulingProjectResource);
    }
}
