using FriendsAndTravel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(DbContextOptions<FriendsAndTravelDbContext> options);
    }
}
