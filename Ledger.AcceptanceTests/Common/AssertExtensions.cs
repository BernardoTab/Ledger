using System.Reflection;

namespace Ledger.AcceptanceTests.Common
{
    public static class AssertExtensions
    {
        public static void AreEqualExcludingProperties<T1, T2>(
            this Assert _,
            T1 expected,
            T2 actual,
            params string[] propertiesToExclude)
        {
            PropertyInfo[] expectedProperties = typeof(T1).GetProperties();
            PropertyInfo[] actualProperties = typeof(T2).GetProperties();
            foreach (PropertyInfo expectedProperty in expectedProperties)
            {
                if (propertiesToExclude.Contains(expectedProperty.Name))
                {
                    continue;
                }
                PropertyInfo? actualProperty = actualProperties.FirstOrDefault(p => p.Name == expectedProperty.Name);
                if (actualProperty != null)
                {
                    object? expectedValue = expectedProperty.GetValue(expected);
                    object? actualValue = actualProperty.GetValue(actual);
                    Assert.AreEqual(expectedValue, actualValue, $"Property {expectedProperty.Name} does not match.");
                }
            }
        }
    }
}
