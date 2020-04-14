using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Services.Mapping
{

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
