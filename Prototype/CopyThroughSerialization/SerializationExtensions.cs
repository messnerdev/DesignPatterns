using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype.CopyThroughSerialization
{
    public static class SerializationExtensions
    {
        // Will require [Serializable] attribute
        public static T DeepCopy<T>(this T self)
        {
            IFormatter formatter = new BinaryFormatter();
            return DeepCopy(self, formatter);
        }

        public static T DeepCopy<T>(this T self, IFormatter formatter)
        {
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(stream, self);

                stream.Seek(0, SeekOrigin.Begin);
                return (T) s.Deserialize(stream);
            }
        }
    }
}