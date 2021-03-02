using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProducerValidator : AbstractValidator<Producer>
    {
        public ProducerValidator()
        {
            RuleFor(p => p.ProducerName).NotEmpty();
            RuleFor(p => p.ProducerName).MinimumLength(2);
            RuleFor(p => p.ProducerOwner).NotEmpty();
            RuleFor(p => p.ProducerOwner).MinimumLength(2);
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.City).NotEmpty();

        }

        
    }
}
