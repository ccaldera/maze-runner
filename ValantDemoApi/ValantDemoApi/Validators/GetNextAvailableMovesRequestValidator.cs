using FluentValidation;
using ValantDemoApi.Models;

namespace ValantDemoApi.Validators
{
    public class GetNextAvailableMovesRequestValidator : AbstractValidator<GetNextAvailableMovesRequest>
    {
        public GetNextAvailableMovesRequestValidator()
        {
            RuleFor(x => x.Row)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Column)
                .GreaterThanOrEqualTo(0);
        }
    }
}
