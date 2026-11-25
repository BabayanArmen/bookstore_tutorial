using BookStore.DTOs.Author;
using FluentValidation;

namespace BookStore.Validators.AuthorValidators
{
    public class AuthorDtoValidator : AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.Name))
                .WithMessage("Author name is not valid");
        }
    }
}
