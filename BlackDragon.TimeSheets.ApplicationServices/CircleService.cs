﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Shared;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Applications
{
    public class CircleService : BaseService, ICircleService
    {
        public CircleService(IContext context)
            : base(context)
        {

        }

        public ICircle Create(string name, string userName)
        {
            var user = Context.Query<User>().FirstOrDefault(x =>
                x.UserName == userName);

            if (user == null)
                throw new ApplicationServiceException("User not found");

            if (Context.Query<Circle>().Any(x =>
                x.Name == name &&
                x.OwnerId == user.ID))
            {
                throw new ApplicationServiceException("Duplicate Circle");
            }

            var circle = Circle.Create(name, user);

            Context.Add(circle);

            Context.Save();

            return circle;
        }

        public CircleFullDto GetCircle(long id, string userName)
        {
            var circle = Context.Query<Circle>()
                .FirstOrDefault(x => x.ID == id);

            if (circle == null)
                throw new ApplicationServiceException("Circle not found");

            bool isOwner = circle.Owner.UserName == userName;
            bool isAdded = circle.Users.Any(x => x.UserName == userName);

            if (!(circle.IsPublic || isOwner || isAdded))
                throw new ApplicationServiceException("Unauthorized to access circle");

            var dto = new CircleFullDto();

            dto.Documents = circle.Documents
                .Select(GetFacadeDto).ToList();

            dto.ID = circle.ID;
            dto.Members = circle.Users
                .Select(GetFacadeDto).ToList();

            dto.Name = circle.Name;
            dto.Owner = GetFacadeDto(circle.Owner);

            return dto;
        }

        private static DocumentFacadeDto GetFacadeDto(Document x)
        {
            return new DocumentFacadeDto
            {
                Size = x.Size
            };
        }
    }
}
