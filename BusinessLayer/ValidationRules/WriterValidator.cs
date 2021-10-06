using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.WriterName).NotEmpty().WithMessage(" Ad Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage(" Şifre Boş Geçilemez");
        }
    }
}
