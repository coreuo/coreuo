using System;
using System.Collections.Generic;
using Shard.Server.Validation.Domain;

namespace Shard.Server.Validation
{
    public static class Handlers<TValidation>
        where TValidation : IValidation, new()
    {
        public static Dictionary<object, Dictionary<string, TValidation>> Collection = new Dictionary<object, Dictionary<string, TValidation>>();

        public static void Set<TInstance, TValue>(TInstance instance, string property, TValue value, Func<TValue> defaultValueFactory = null, int permission = 0, Action<TInstance, TValue> callback = null)
        {
            if (!Collection.TryGetValue(instance, out var properties)) properties = Collection[instance] = new Dictionary<string, TValidation>();

            if (!properties.TryGetValue(property, out var validation)) validation = properties[property] = new TValidation{Permission = permission, Instance = instance, Property = property};

            var result = EqualityComparer<TValue>.Default.Equals(value, default) && defaultValueFactory != null ? defaultValueFactory() : value;

            validation.Value = result;

            callback?.Invoke(instance, result);
        }

        public static TValue Get<TValue>(object instance, string property)
        {
            if (!Collection.TryGetValue(instance, out var properties)) throw new InvalidOperationException($"Invalid instance of type {instance.GetType()}, instance not found.");

            if(!properties.TryGetValue(property, out var validation)) throw new InvalidOperationException($"Invalid property {property} of type {instance.GetType()}, property not found.");

            if(!(validation.Value is TValue value) && !TryConvert(out value)) throw new InvalidOperationException($"Invalid property type {typeof(TValue)}, correct type is {validation.Value.GetType()}.");

            return value;

            bool TryConvert(out TValue result)
            {
                try
                {
                    result = Convert.ChangeType(validation.Value, typeof(TValue)) is TValue correct ? correct : default;

                    return true;
                }
                catch
                {
                    result = default;

                    return false;
                }
            }
        }
    }
}
