using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Common.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
