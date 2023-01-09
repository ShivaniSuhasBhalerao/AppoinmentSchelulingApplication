using System.Threading.Tasks;

namespace AppoinmentSchelulingProject.Data;

public interface IAppoinmentSchelulingProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
