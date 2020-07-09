using Chat.Domain.Models;
using Chat.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Repository
{
    public class InterestRepository : Repository<Interest>
    {
        public InterestRepository(ChatDbContext context) : base(context)
        {
        }
    }
}
