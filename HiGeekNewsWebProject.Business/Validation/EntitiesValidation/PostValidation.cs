using FluentValidation;
using HiGeekNewsWebProject.Associate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Validation.EntitiesValidation
{
    public class PostValidation : AbstractValidator<PostDTO>
    {
        public PostValidation()
        {
            RuleFor(x => x.Content).NotEmpty().When(x => x.ImagePath == null).WithMessage("This fields cannot be empty..!").MaximumLength(140).WithMessage("You cannot use more than 140 character..!");
        }
    }
}
