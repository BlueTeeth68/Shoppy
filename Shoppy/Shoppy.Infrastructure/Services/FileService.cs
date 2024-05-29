using System.Net;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Exceptions;
using Shoppy.Infrastructure.Configurations;

namespace Shoppy.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly FireBaseSetting _firebase;

    private readonly ILogger<FileService> _logger;

    private static readonly List<string> SupportedImageFile =
    [
        ".jpg",
        ".jpeg",
        ".png",
        ".svg",
        ".webp",
        ".heic",
        ".heif",
        ".ico",
        ".gif"
    ];


    public FileService(IOptions<FireBaseSetting> firebase, ILogger<FileService> logger)
    {
        _firebase = firebase.Value;
        _logger = logger;
    }

    public async Task<string> UploadImageAsync(IFormFile file, string folderPath, string fileName)
    {
        var stream = file.OpenReadStream();

        var fileExtension = Path.GetExtension(file.FileName);

        //Check file extension for preventing malware
        if (!SupportedImageFile.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
        {
            throw new BadRequestException("Unsupported file type.");
        }

        fileName += fileExtension;

        var firebaseAuthLink = await GetAuthentication();

        // you can use CancellationTokenSource to cancel the upload midway
        var cancellation = new CancellationTokenSource();

        var task = new FirebaseStorage(
                _firebase.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthLink.FirebaseToken),
                    ThrowOnCancel =
                        true
                })
            .Child(folderPath)
            .Child(fileName)
            .PutAsync(stream, cancellation.Token);

        task.Progress.ProgressChanged += (_, e) => Console.WriteLine($"Progress: {e.Percentage} %");

        try
        {
            // cancel the upload
            // await cancellation.CancelAsync();

            return await task;
        }
        catch (Exception e)
        {
            _logger.LogError("Error when upload file to firebase. Detail:\n {}", e.Message);
            throw new Exception("Error when upload file to firebase.");
        }
    }

    public async Task RemoveFile(string fileUrl)
    {
        var firebaseAuthLink = await GetAuthentication();

        var storage = new FirebaseStorage(
            _firebase.Bucket,
            new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthLink.FirebaseToken)
            });

        // Extract the encoded file path from the Firebase Storage URL
        var uri = new Uri(fileUrl);
        var encodedFilePath = uri.Segments.Last();

        // URL decode the file path
        var decodedFilePath = WebUtility.UrlDecode(encodedFilePath);

        try
        {
            // Remove the file based on its path
            await storage.Child(decodedFilePath).DeleteAsync();
        }
        catch (Exception e)
        {
            throw new BadRequestException($"Error when remove file: \n{e.Message}");
        }
    }

    private async Task<FirebaseAuthLink> GetAuthentication()
    {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebase.ApiKey));
        return await auth.SignInWithEmailAndPasswordAsync(_firebase.AuthEmail,
            _firebase.AuthPassword);
    }
}