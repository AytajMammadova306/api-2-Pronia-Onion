using OnionPronia.Application.Interfaces.Repositories;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistance.Implementations.Repositories
{
    class TagRepository:Repository<Tag>,ITagRepository
    {
        public TagRepository(AppDbContext context):base(context)
        {
            
        }
    }
}   
