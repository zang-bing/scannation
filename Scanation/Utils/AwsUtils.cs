using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Threading.Tasks;

namespace Scanation.Utils
{
    public class AwsUtils
    {

        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.APNortheast1;
        private static IAmazonS3 s3Client;
        private static string accessKeyID = "AKIATL7SAKMZEDE7ET54";
        private static string secretKeyID = "NssNRkvm8xIIFkIntYY0zY12qEaH9dgpuPrimklU";

        public static async Task UploadFileAsync(string bucketName, string filePath, string token, string filename)
        {
            try
            {
                s3Client = new AmazonS3Client(accessKeyID, secretKeyID, bucketRegion);
                var fileTransferUtility = new TransferUtility(s3Client);
                // Option 1. Upload a file. The file name is used as the object key name.

                var key = token + "/" + filename;
                await fileTransferUtility.UploadAsync(filePath, bucketName, key);
                Console.WriteLine("Upload 1 completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         }
    }
}

