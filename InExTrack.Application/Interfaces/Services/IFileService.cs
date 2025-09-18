using InExTrack.Application.DTOs;

namespace InExTrack.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task RemoveAsync(string fileName);
        Task<FileDto> SaveAsync(IFormFile file);
    }
}
