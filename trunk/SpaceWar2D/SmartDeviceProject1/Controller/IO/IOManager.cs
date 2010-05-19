using System;
using System.IO;
using System.Windows.Forms;
using CompactFormatter;

namespace PowerAwareBluetooth.Controller.IO
{
    // TODO: adam - lock the file before interacting with it - DO WE HAVE TO ?
    /// <summary>
    /// handles the saving and loading of the saved data
    /// </summary>
    public static class IOManager
    {
        private const string DATA_FILE = @"Storage Card\BlueToothManager\UserDefinedRules.bin";

        public static void Save(object dataToSave)
        {
            try
            {
                SerializeObject(DATA_FILE, dataToSave);
            }
            catch (Exception e)
            {
                int x;
                x = 10;
            }

        }

        /// <summary>
        /// loads the object from the saved file.
        /// if an error occurred while trying to load the file then
        /// null is returned
        /// </summary>
        /// <returns></returns>
        public static object Load()
        {
            try
            {
                return DeserializeObject(DATA_FILE);
            }
            catch (Exception e)
            {
//                Console.WriteLine(e.StackTrace);
//                MessageBox.Show(e.StackTrace);
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
            Directory.CreateDirectory(Path.GetDirectoryName(DATA_FILE));
            using (Stream stream = new FileStream(DATA_FILE, FileMode.OpenOrCreate))
            {
                BinaryWriter binaryWriter = new BinaryWriter(stream);
                CompactFormatterPlus compactFormatterPlus = new CompactFormatterPlus();
                compactFormatterPlus.Serialize(stream, graph);
//                CompactFormatter.CompactFormatter compactFormatter = 
//                  new CompactFormatter.CompactFormatter(CFormatterMode.SAFE);
//                //compactFormatter.Serialize(stream, graph);
//                compactFormatter.Serialize();
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
                CompactFormatterPlus compactFormatterPlus = new CompactFormatterPlus();
                object obj = compactFormatterPlus.Deserialize(stream);
                return obj;
//                CompactFormatter.CompactFormatter compactFormatter =
//                  new CompactFormatter.CompactFormatter(CFormatterMode.SAFE);
//                return compactFormatter.Deserialize(stream);
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
