namespace Shoppy.Domain.Repositories.Base;

//handle concurrency in  EF core
public interface IConcurrencyHandler<in TEntity>
{
    void SetRowVersion(TEntity entity, byte[] version);
    
    bool IsDbUpdateConcurrencyException(Exception ex);
}