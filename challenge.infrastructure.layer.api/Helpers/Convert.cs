using System.Reflection;

namespace challenge.infrastructure.layer.api.Helpers
{
    public static class Convert
    {
        private static Dictionary<string, string?> ConvertToDictionary(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var result = properties.ToDictionary(prop => prop.Name, prop => prop.GetValue(obj)?.ToString());

            return result;
        }
    }
}
