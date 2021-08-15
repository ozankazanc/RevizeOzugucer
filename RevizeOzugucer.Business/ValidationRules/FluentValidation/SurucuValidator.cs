using FluentValidation;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.ValidationRules.FluentValidation
{
    public class SurucuValidator : AbstractValidator<ONSurucu>
    {
        public SurucuValidator()
        {
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.SurucuAdi).NotEmpty();
            RuleFor(p => p.SurucuSoyadi).NotEmpty();

            RuleFor(p => p.SurucuAdi).MinimumLength(2);
            RuleFor(p => p.SurucuSoyadi).MinimumLength(2);

        }
    }
}
