using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;

namespace Domain.Arquivos.S3;

public class AmazonS3Service
{
    public string AwsKeyId { get; private set; }
    public string AwsKeySecret { get; private set; }
    public BasicAWSCredentials AwsCredentials { get; private set; }
    private readonly IAmazonS3 _awsS3Client;

    public AmazonS3Service()
    {
        //Cria cliente para aws
        AwsKeyId = "";
        AwsKeySecret = "";
        AwsCredentials = new BasicAWSCredentials(AwsKeyId, AwsKeySecret);
        var config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.USEast2
        };

        _awsS3Client = new AmazonS3Client(AwsCredentials, config);
    }

    public async Task<bool> UploadFileAsync(string bucket, string key, IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var fileTransferUtility = new TransferUtility(_awsS3Client);

        await fileTransferUtility.UploadAsync(new TransferUtilityUploadRequest
        {
            InputStream = memoryStream,
            Key = key,
            BucketName = bucket,
            ContentType = file.ContentType
        });

        return true;
    }
}