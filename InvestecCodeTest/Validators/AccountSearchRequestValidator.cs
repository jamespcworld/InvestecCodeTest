using FluentValidation;
using InvestecCodeTest.Models;

namespace InvestecCodeTest.Validators
{
    public class AccountSearchRequestValidator : AbstractValidator<AccountSearchRequest>
    {
        public AccountSearchRequestValidator()
        {
            When(x => x.AccountName != null, () =>
            {
                RuleFor(x => x.AccountName.Length)
               .LessThanOrEqualTo(20).WithMessage("The account name search is limited to 20 characters.");
                RuleFor(x => x.AccountName)
                   .Matches(@"^[a-zA-Z\s]+$").WithMessage("No special characters");
            });

        }
    }
}
