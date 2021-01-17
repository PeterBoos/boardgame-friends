using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BGF.App.Services
{
    public static class XmlHelper
    {
        /// <summary>
        /// Deserializes an XML file to the specified type of object.
        /// </summary>
        /// <typeparam name="T">The Type of object to deserialize</typeparam>
        /// <param name="xmlFilePath">The path to the XML file to deserialize</param>
        /// <returns>An object instance</returns>
        public static T DeserializeFromFile<T>(string xmlFilePath) where T : class
        {
            using (var reader = XmlReader.Create(xmlFilePath))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Deserializes an XML file to the specified type of object.
        /// </summary>
        /// <typeparam name="T">The Type of object to deserialize</typeparam>
        /// <param name="xmlString">String containing the XML data</param>
        /// <returns>An object instance</returns>
        public static T DeserializeFromString<T>(string xmlString) where T : class
        {
            using (var reader = XmlReader.Create(new StringReader(xmlString)))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }

        public static async Task ParseUserBoardgameList(string xmlString)
        {

        }
    }
}
