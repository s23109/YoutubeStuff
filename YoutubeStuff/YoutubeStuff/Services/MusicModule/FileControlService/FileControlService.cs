namespace YoutubeStuff.Services.MusicModule.FileControlService
{
    public class FileControlService : IFileControlService
    {
        //used for managing buffered files etc (ie delete not used, init)

        private static string _operationFolder { get; set; }

        public FileControlService()
        {
            //set server buffor 
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            _operationFolder = config["OperationFolder"];

            //if folder does not exist, then create it 

            if (!Directory.Exists(_operationFolder))
            {
                //folder does not exist
                Directory.CreateDirectory(_operationFolder);
            }
            else
            {
                //folder exists, delete buffered operations 
                var folders = Directory.GetDirectories(_operationFolder);

                foreach (var item in folders)
                {
                    Directory.Delete(item);
                }
            }


        }

    }
}
