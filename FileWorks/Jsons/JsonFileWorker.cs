
using Newtonsoft.Json;

using System.IO;

namespace FileWork.Jsons
{
    public class JsonFileWorker
    {
        public static T Open<T> ( string file )
        {
            var text = File.ReadAllText( file );
            return JsonConvert.DeserializeObject<T>( text );
        }

        public static void Save ( object value, string file )
        {
            var json = JsonConvert.SerializeObject( value, Formatting.Indented );
            File.WriteAllText( file, json );
        }
    }
}
