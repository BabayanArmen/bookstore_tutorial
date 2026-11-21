using BookStore.Data;
using BookStore.DTOs.Author;
using BookStore.Entities;
using BookStore.FIlters;
using BookStore.Mappers;
using BookStore.Models;
using BookStore.Repositories.AuthorRepo;

namespace BookStore.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {

        private readonly AuthorRepo _repo;
        AuthorService(AuthorRepo repo)
        {
            _repo = repo;
        }

        //public Task<Result<AuthorDto>> Add(AuthorDto dto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<bool>> Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Response<List<AuthorDto>>> GetAll(AuthorFilter filter)
        {
            var result = await _repo.GetAllAsync(filter);

            if (result == null)
            {
                return Result.Fail<List<AuthorDto>>(string.Empty);
            }

            return Result.Success<List<AuthorDto>>(
                result?.Data?.Select(x => x.ToDto()).ToList(),
                result?.PageInfo
            );
        }

        //public Task<Result<AuthorDto>> GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<bool>> Update(UpdateAuthorDto dto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
