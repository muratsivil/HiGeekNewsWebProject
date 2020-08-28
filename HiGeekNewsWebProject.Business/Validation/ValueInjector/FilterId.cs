﻿using Omu.ValueInjecter.Injections;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Validation.ValueInjector
{
    public class FilterId : LoopInjection
    {
        protected override bool MatchTypes(Type source, Type target)
        {
            return source.Name != "Id" && source.Name == target.Name && source.BaseType == target.BaseType;
        }
    }
}
