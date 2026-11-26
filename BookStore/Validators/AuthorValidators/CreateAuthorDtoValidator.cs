using BookStore.DTOs.Author;
using FluentValidation;

namespace BookStore.Validators.AuthorValidators
{
    public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Author name is required")
                .MaximumLength(5)
                .WithMessage("Author name is not valid");
        }
    }
}
