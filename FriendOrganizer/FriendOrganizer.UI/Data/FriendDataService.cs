﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == friendId);
            }
        }
    }
}
