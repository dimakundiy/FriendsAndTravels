﻿using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Photo FindClone(string url);
    }
}
