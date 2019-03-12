using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Renci.SshNet;

namespace PhysicalRecordsConnector.Implementation
{
    class FTPOperations
    {
        public FTPOperations() { }

        public bool UploadToSiteSFTP(string sourceFilePath, string destinationUrl,string destFolderPath, NetworkCredential credentials, string fileName)
        {
            SftpClient client = new SftpClient(destinationUrl, 22, credentials.UserName, credentials.Password);
            client.Connect();
            var fileStream = new FileStream(sourceFilePath,FileMode.Open);
            client.BufferSize = 4 * 1024;
            client.UploadFile(fileStream, destFolderPath + fileName, null);
            client.Dispose();
            fileStream.Close();
            return true;

        }
    }
}
