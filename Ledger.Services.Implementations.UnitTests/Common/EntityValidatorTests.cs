using Ledger.Entities.Common;
using Ledger.Services.Implementations.Common.Validations;

namespace Ledger.Services.Implementations.UnitTests.Common
{
    public abstract class EntityValidatorTests<TEntityValidator, TEntity>
        where TEntityValidator : IEntityValidator<TEntity>
        where TEntity : Entity
    {
        protected TEntityValidator EntityValidator { get; set; }
        protected TEntity Entity { get; set; }

        protected EntityValidatorTests()
        {
            InitializeDependencyMocks();
            EntityValidator = CreateValidator();
            Entity = CreateValidEntity();
            SetupDependencyMocks();
        }

        protected virtual void InitializeDependencyMocks()
        {
        }

        protected abstract TEntityValidator CreateValidator();

        protected abstract TEntity CreateValidEntity();

        protected virtual void SetupDependencyMocks()
        {
        }

        [TestMethod]
        public async Task ValidateAsync_IdIsDefault_MissingRequiredPropertyExceptionIsThrown()
        {
            Entity.Id = default;

            Func<Task> testAction = async () => await EntityValidator.ValidateAsync(Entity);

            await Assert.That.ThrowsMissingRequiredPropertyExceptionAsync(
                testAction,
                typeof(TEntity).Name,
                nameof(Entity.Id));
        }
    }
}
