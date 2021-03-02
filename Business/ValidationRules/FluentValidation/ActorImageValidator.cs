using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ActorImageValidator : AbstractValidator<ActorImage>
    {
        public ActorImageValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty();
        }
    }
}
