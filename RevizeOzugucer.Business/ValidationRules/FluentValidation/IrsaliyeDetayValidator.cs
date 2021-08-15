using FluentValidation;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.ValidationRules.FluentValidation
{
    public class IrsaliyeDetayValidator : AbstractValidator<ONIrsaliyeDetay>
    {
        public IrsaliyeDetayValidator()
        {
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.HalNo).NotEmpty();
            RuleFor(p => p.Cinsi).NotEmpty();
            RuleFor(p => p.Fiyat).NotEmpty();
        
        }
    }
}
