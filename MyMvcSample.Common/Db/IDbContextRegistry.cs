using System.Data.Entity;

namespace MyMvcSample.Common.Db
{
    public interface IDbContextRegistry
    {
        DbContext CurrentContext { get; }
    }
}