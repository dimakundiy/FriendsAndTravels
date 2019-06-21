using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.BAL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly FriendsAndTravelDbContext db;

        public PhotoService(FriendsAndTravelDbContext db)
        {
            this.db = db;
        }

        public int Create(IFormFile photo, string userId)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);

                var instanceOfPhoto = new Photo
                {
                    IsProfilePicture = false,
                    PhotoAsBytes = memoryStream.ToArray(),
                    UserId = userId
                };

                db.Photos.Add(instanceOfPhoto);
                db.SaveChanges();

                return instanceOfPhoto.Id;
            }
        }

        public byte[] PhotoAsBytes(IFormFile photo)
        {
            byte[] photoAsBytes;

            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                photoAsBytes = memoryStream.ToArray();
            };

            return photoAsBytes;
        }

        public bool PhotoExists(int photoId) => this.db.Photos.Any(p => p.Id == photoId);
    }
}
