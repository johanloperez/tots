﻿using System.Reflection;

namespace Challenge.bootstrapper.layer.api.Helpers
{
    public static class CustomValidations
    {
        public static bool AnyPropertyNullOrEmpty(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);

                if (value is null || (value is string stringValue && string.IsNullOrEmpty(stringValue)))
                {
                    return true; 
                }
            }

            return false;
        }
    }
}
