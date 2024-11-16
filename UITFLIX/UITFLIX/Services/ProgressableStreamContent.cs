using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UITFLIX.Services
{
    public class ProgressableStreamContent : HttpContent
{
    private readonly Stream _content;
    private readonly IProgress<int> _progress;
    private readonly int _bufferSize;


    //Cai nay toi xai gpt nen dung hoi toi gi ca :(
    public ProgressableStreamContent(Stream content, IProgress<int> progress, int bufferSize = 8192)
    {
        _content = content;
        _progress = progress;
        _bufferSize = bufferSize;
    }

    // Implementing the abstract method TryComputeLength
    protected override bool TryComputeLength(out long length)
    {
        length = 0;

        // Check if the stream is seekable (has a length)
        if (_content.CanSeek)
        {
            length = _content.Length; // Set the length of the content
            return true; // Successfully computed length
        }

        // If the stream is not seekable, we can't compute the length
        return false;
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
    {
        byte[] buffer = new byte[_bufferSize];
        int bytesRead;
        long totalBytesRead = 0;
        long contentLength = _content.Length;

        while ((bytesRead = await _content.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            await stream.WriteAsync(buffer, 0, bytesRead);

            totalBytesRead += bytesRead;

            // Report progress
            var progressPercentage = (int)((double)totalBytesRead / contentLength * 100);
            _progress?.Report(progressPercentage);
        }
    }

    protected override Task<Stream> CreateContentReadStreamAsync()
    {
        // Just return the underlying content stream
        return Task.FromResult(_content);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _content?.Dispose();
        }

        base.Dispose(disposing);
    }
}


}
