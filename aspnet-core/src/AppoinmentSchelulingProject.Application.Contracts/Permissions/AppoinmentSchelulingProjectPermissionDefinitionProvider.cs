using AppoinmentSchelulingProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AppoinmentSchelulingProject.Permissions;

public class AppoinmentSchelulingProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AppoinmentSchelulingProjectPermissions.GroupName);

        myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.MyPermission1, L("Permission:MyPermission1"));

        var customerPermission = myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.Customers.Default, L("Permission:Customers"));
        customerPermission.AddChild(AppoinmentSchelulingProjectPermissions.Customers.Create, L("Permission:Create"));
        customerPermission.AddChild(AppoinmentSchelulingProjectPermissions.Customers.Edit, L("Permission:Edit"));
        customerPermission.AddChild(AppoinmentSchelulingProjectPermissions.Customers.Delete, L("Permission:Delete"));

        var calenderPermission = myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.Calenders.Default, L("Permission:Calenders"));
        calenderPermission.AddChild(AppoinmentSchelulingProjectPermissions.Calenders.Create, L("Permission:Create"));
        calenderPermission.AddChild(AppoinmentSchelulingProjectPermissions.Calenders.Edit, L("Permission:Edit"));
        calenderPermission.AddChild(AppoinmentSchelulingProjectPermissions.Calenders.Delete, L("Permission:Delete"));

        var calendersPermission = myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.Calenderss.Default, L("Permission:Calenderss"));
        calendersPermission.AddChild(AppoinmentSchelulingProjectPermissions.Calenderss.Create, L("Permission:Create"));
        calendersPermission.AddChild(AppoinmentSchelulingProjectPermissions.Calenderss.Edit, L("Permission:Edit"));
        calendersPermission.AddChild(AppoinmentSchelulingProjectPermissions.Calenderss.Delete, L("Permission:Delete"));

        var myCalenderPermission = myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.MyCalenders.Default, L("Permission:MyCalenders"));
        myCalenderPermission.AddChild(AppoinmentSchelulingProjectPermissions.MyCalenders.Create, L("Permission:Create"));
        myCalenderPermission.AddChild(AppoinmentSchelulingProjectPermissions.MyCalenders.Edit, L("Permission:Edit"));
        myCalenderPermission.AddChild(AppoinmentSchelulingProjectPermissions.MyCalenders.Delete, L("Permission:Delete"));

        var myCalendersPermission = myGroup.AddPermission(AppoinmentSchelulingProjectPermissions.MyCalenderss.Default, L("Permission:MyCalenderss"));
        myCalendersPermission.AddChild(AppoinmentSchelulingProjectPermissions.MyCalenderss.Create, L("Permission:Create"));
        myCalendersPermission.AddChild(AppoinmentSchelulingProjectPermissions.MyCalenderss.Edit, L("Permission:Edit"));
        myCalendersPermission.AddChild(AppoinmentSchelulingProjectPermissions.MyCalenderss.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AppoinmentSchelulingProjectResource>(name);
    }
}