using System;
using System.IO;
using CompactFormatter;

namespace PowerAwareBluetooth.Controller.IO
{
    /// <summary>
    /// handles the saving and loading of the saved data
    /// </summary>
    internal static class IOManager
    {
        internal const string DATA_FILE = @"Storage Card\BlueToothManager\Data.bin";

        internal static void Save(object dataToSave)
        {
            SerializeObject(DATA_FILE, dataToSave);
        }

        /// <summary>
        /// loads the object from the saved file.
        /// if an error occurred while trying to load the file then
        /// null is returned
        /// </summary>
        /// <returns></returns>
        internal static object Load()
        {
            try
            {
                return DeserializeObject(DATA_FILE);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// serializing a graph to a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="graph"></param>
        private static void SerializeObject(string filename, object graph)
        {
            using (Stream stream = new FileStream(DATA_FILE, FileMode.CreateNew))
            {
                CompactFormatter.CompactFormatter compactFormatter = 
                  new CompactFormatter.CompactFormatter(CFormatterMode.SAFE);
                compactFormatter.Serialize(stream, graph);
            }  
        }

        /// <summary>
        /// deserializing a file to a graph
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static object DeserializeObject(string filename)
        {
            using (Stream stream = new FileStream(DATA_FILE, FileMode.Open))
            {
                CompactFormatter.CompactFormatter compactFormatter =
                  new CompactFormatter.CompactFormatter(CFormatterMode.SAFE);
                return compactFormatter.Deserialize(stream);
            } 
        }


//        public ObjectToSerialize DeSerializeObject(string filename)
//        {
//            ObjectToSerialize objectToSerialize;
//            Stream stream = File.Open(filename, FileMode.Open);
//            BinaryFormatter bFormatter = new BinaryFormatter();
//            objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
//            stream.Close();
//            return objectToSerialize;
//        }
    }
}
