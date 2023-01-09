using AppoinmentSchelulingProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AppoinmentSchelulingProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AppoinmentSchelulingProjectController : AbpControllerBase
{
    protected AppoinmentSchelulingProjectController()
    {
        LocalizationResource = typeof(AppoinmentSchelulingProjectResource);
    }
}
