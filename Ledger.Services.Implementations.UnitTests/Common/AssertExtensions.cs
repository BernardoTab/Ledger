using Ledger.Entities.Exceptions;

namespace Ledger.Services.Implementations.UnitTests.Common
{
    public static class AssertExtensions
    {
        public static async Task ThrowsMissingRequiredPropertyExceptionAsync(
            this Assert _,
            Func<Task> testAction,
            string ownerName,
            string propertyName)
        {
            MissingRequiredPropertyException exception =
                await Assert.ThrowsExceptionAsync<MissingRequiredPropertyException>(testAction);
            Assert.AreEqual(expected: ownerName, actual: exception.OwnerName);
            Assert.AreEqual(expected: propertyName, actual: exception.PropertyName);
        }

        public static async Task ThrowsValueNotSupportedExceptionAsync(
            this Assert _,
            Func<Task> testAction,
            object value,
            string ownerName,
            string propertyName)
        {
            ValueNotSupportedException exception =
                await Assert.ThrowsExceptionAsync<ValueNotSupportedException>(testAction);
            Assert.AreEqual(expected: ownerName, actual: exception.OwnerName);
            Assert.AreEqual(expected: propertyName, actual: exception.PropertyName);
            Assert.AreEqual(expected: value, actual: exception.Value);
        }
    }
}
