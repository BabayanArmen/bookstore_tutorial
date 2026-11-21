using BookStore.DTOs.Author;
using BookStore.Entities;
using BookStore.FIlters;
using BookStore.Models;

namespace BookStore.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorDto>>> GetAll(AuthorFilter filter);
        //Task<Result<AuthorDto>> GetById(int id);
        //Task<Result<AuthorDto>> Add(AuthorDto dto);
        //Task<Result<bool>> Update(UpdateAuthorDto dto);
        //Task<Result<bool>> Delete(int id);

    }
}
