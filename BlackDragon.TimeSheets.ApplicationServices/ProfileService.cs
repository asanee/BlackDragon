﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.TimeSheets.Shared;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Applications
{
    public class ProfileService : IProfileService
    {
        public ProfileService(IContext context)
        {
            this.Context = context;
        }

        public IList<ProfileFacadeDto> Search(string query, int skip, int take)
        {
            var users = Context.Query<User>().Where(x => 
                x.UserName.Contains(query) || 
                x.FirstName.Contains(query) || 
                x.LastName.Contains(query))
                .OrderByDescending(x => x.ID)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users.Select(x => new ProfileFacadeDto
            {
                FullName = x.FirstName + " " + x.LastName,
                UserName = x.UserName
            }).ToList();
        }

        public IContext Context { get; set; }

        public FullProfileDto GetFullProfile(string userName)
        {
            var user = Context.Query<User>().FirstOrDefault(x => 
                x.UserName == userName);

            if (user == null)
                throw new ApplicationServiceException("User is not found.");

            return new FullProfileDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                OwnCircles = user.OwnCircles.Select(x=> x.Name).ToList()
            };
        }
    }
}
