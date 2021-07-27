namespace FileWork.Jsons
{   
    public class ConfigFileWorker<T>
    {
        public readonly string File;

        public T Object { get; set; }

        public ConfigFileWorker ( string file )
        {
            File = file;
        }

        public T Open ( )
        {
            return Object = JsonFileWorker.Open<T>( File );
        }

        public void Save ( )
        {
            JsonFileWorker.Save( Object, File );
        }
    }
}
