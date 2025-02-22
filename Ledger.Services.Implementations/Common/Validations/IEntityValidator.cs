using Ledger.Entities.Common;

namespace Ledger.Services.Implementations.Common.Validations
{
    public interface IEntityValidator<TEntity>
        where TEntity : Entity
    {
        void Validate(TEntity entity);
    }
}
