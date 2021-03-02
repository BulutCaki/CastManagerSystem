using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(Messages.ActorNameInvalid);
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage(Messages.ActorNameInvalid);
            RuleFor(x => x.Job).Equal(true).WithMessage(Messages.ActorIsNotSuitable);
            RuleFor(x => x.Lenght).MinimumLength(1).WithMessage(Messages.InvalidValue);
            RuleFor(x => x.Lenght).MaximumLength(4).WithMessage(Messages.InvalidValue);
            RuleFor(x => x.Kilo).MaximumLength(4).WithMessage(Messages.InvalidValue);
            RuleFor(x => x.Kilo).MinimumLength(1).WithMessage(Messages.InvalidValue);
        }
    }
}
