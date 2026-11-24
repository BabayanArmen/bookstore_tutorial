using BookStore.DTOs.Author;
using BookStore.FIlters;
using BookStore.Mappers;
using BookStore.Models;
using BookStore.Repositories.AuthorRepo;

namespace BookStore.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepo _repo;
        public AuthorService(IAuthorRepo repo)
        {
            _repo = repo;
        }

        public async Task<Response<AuthorDto>> Add(CreateAuthorDto dto)
        {
            if (await _repo.IsNameExists(dto.Name))
            {
                return Result.Fail<AuthorDto>("Name is already exists");
            }

            var author = await _repo.AddAsync(dto.CreateToEntity());

            if (author == null)
            {
                return Result.Fail<AuthorDto>("some error");
            }

            return Result.Success<AuthorDto>(author.ToDto());
        }

        public async Task<Response<bool>> Delete(int id)
        {
            bool result = await _repo.DeleteAsync(id);

            if (!result)
            {
                return Result.Fail<bool>("Author not found");
            }

            return Result.Success<bool>(result);
        }

        public async Task<Response<List<AuthorDto>>> GetAll(AuthorFilter filter)
        {
            var result = await _repo.GetAllAsync(filter);

            if (result == null)
            {
                return Result.Fail<List<AuthorDto>>("Result not found");
            }

            return Result.Success<List<AuthorDto>>
            (
                result?.Data?.Select(x => x.ToDto()).ToList(),
                result?.PageInfo
            );
        }

        public async Task<Response<AuthorDto>> GetById(int id)
        {
            var author = await _repo.GetByIdAsync(id);

            if (author == null)
            {
                return Result.Fail<AuthorDto>("Author not found");
            }

            return Result.Success<AuthorDto>(author.ToDto());
        }

        public async Task<Response<bool>> Update(UpdateAuthorDto dto)
        {
            bool result = await _repo.UpdateAsync(dto);

            if (!result)
            {
                return Result.Fail<bool>("Author not found");
            }

            return Result.Success<bool>(result);
        }
    }
}
