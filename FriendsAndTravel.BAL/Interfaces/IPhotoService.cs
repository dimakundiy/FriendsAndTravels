using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface IPhotoService 
    {
        int Create(IFormFile photo, string userId);

        bool PhotoExists(int photoId);

        byte[] PhotoAsBytes(IFormFile photo);
    }
}
