using FluentValidation;
using ValantDemoApi.Models;

namespace ValantDemoApi.Validators
{
    public class CreateMazeRequestValidator : AbstractValidator<CreateMazeRequest>
    {
        public CreateMazeRequestValidator()
        {
            RuleFor(x => x.Maze)
                .NotEmpty();

            RuleFor(x => x.Maze)
                .Must(x => x.Contains("S"));

            RuleFor(x => x.Maze)
                .Must(x => x.Contains("E"));
        }
    }
}
