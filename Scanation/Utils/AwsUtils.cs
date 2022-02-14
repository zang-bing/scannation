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
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 s3Client;

        private static async Task UploadFileAsync(string bucketName, string filePath)
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);
                var fileTransferUtility = new TransferUtility(s3Client);
                // Option 1. Upload a file. The file name is used as the object key name.
                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Upload 1 completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         }
    }
}

