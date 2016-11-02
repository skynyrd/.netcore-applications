namespace NancyApplication
{
    using Domain;
    using FluentValidation;

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Name).Must(BeAValidName).WithMessage("Name cannot be 'invalidname'");
        }

        private bool BeAValidName(string arg)
        {
            return arg == "invalidname" ? false : true;
        }
    }
}