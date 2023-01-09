namespace AppoinmentSchelulingProject.Permissions;

public static class AppoinmentSchelulingProjectPermissions
{
    public const string GroupName = "AppoinmentSchelulingProject";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Customers
    {
        public const string Default = GroupName + ".Customers";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Calenders
    {
        public const string Default = GroupName + ".Calenders";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Calenderss
    {
        public const string Default = GroupName + ".Calenderss";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class MyCalenders
    {
        public const string Default = GroupName + ".MyCalenders";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class MyCalenderss
    {
        public const string Default = GroupName + ".MyCalenderss";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}