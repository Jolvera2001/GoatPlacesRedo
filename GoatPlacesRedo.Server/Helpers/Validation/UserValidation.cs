using FluentValidation;
using GoatPlacesRedo.Server.DTOs;

namespace GoatPlacesRedo.Server.Helpers.Validation;

public class UserValidation : AbstractValidator<ClientUser>
{
    public UserValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is missing");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is missing");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is missing");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is missing");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email missing or not correct");
    }
}