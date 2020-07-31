using Microsoft.EntityFrameworkCore;

namespace Tandem.Repository.EntityFramework.Configurations.Base
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ModelBuilder builder);
    }
}
