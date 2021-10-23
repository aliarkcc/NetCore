using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidatior:AbstractValidator<Blog>
    {
        public BlogValidatior()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görseli Boş Geçilemez.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("150 karakterden daha az veri girmeniz gerekmektedir");
            RuleFor(x => x.BlogTitle).MinimumLength(4).WithMessage("150 karakterden daha fazla veri girmeniz gerekmektedir");
        }
    }
}
