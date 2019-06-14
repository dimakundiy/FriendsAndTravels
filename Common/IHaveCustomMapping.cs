using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace Common
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
