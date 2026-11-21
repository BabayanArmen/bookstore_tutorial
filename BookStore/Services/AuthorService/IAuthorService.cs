using BookStore.DTOs.Author;
using BookStore.Entities;
using BookStore.FIlters;
using BookStore.Models;

namespace BookStore.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorDto>>> GetAll(AuthorFilter filter);
        Task<Response<AuthorDto>> GetById(int id);
        Task<Response<AuthorDto>> Add(CreateAuthorDto dto);
        Task<Response<bool>> Update(UpdateAuthorDto dto);
        Task<Response<bool>> Delete(int id);
    }
}
