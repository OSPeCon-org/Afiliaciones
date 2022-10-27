using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork
{

    public class SingleValueObjectConverter : JsonConverter
    {
        private static readonly ConcurrentDictionary<Type, Type> ConstructorArgumentTypes = new ConcurrentDictionary<Type, Type>();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is ISingleValueObject singleValueObject))
            {
                return;
            }

            serializer.Serialize(writer, singleValueObject.GetValue());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var parameterType = ConstructorArgumentTypes.GetOrAdd(
               objectType,
               t =>
                   {
                       var constructorInfo = objectType.GetTypeInfo().GetConstructors(BindingFlags.Public | BindingFlags.Instance).Single();
                       var parameterInfo = constructorInfo.GetParameters().Single();
                       return parameterInfo.ParameterType;
                   });

            Cuit ob = (Cuit)Activator.CreateInstance(objectType, (string)"123456789");

            return Activator.CreateInstance(objectType, serializer.Deserialize(reader, parameterType));
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ISingleValueObject).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
}
