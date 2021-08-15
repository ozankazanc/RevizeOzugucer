using FluentValidation;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.ValidationRules.FluentValidation
{
    public class IrsaliyeValidator : AbstractValidator<ONIrsaliye>
    {
        public IrsaliyeValidator()
        {
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.PlakaNo).NotEmpty();
            RuleFor(p => p.SurucuId).NotEmpty();

        }
    }
}
