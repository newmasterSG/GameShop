using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Importer
{
    public class DeveloperImporter
    {
        public static async Task<DevelopersEntity> CreateDeveloper(DevelopersEntity developer)
        {
            DevelopersEntity developersModel = new DevelopersEntity()
            {
                Slug = developer.Slug,
                Name = developer.Name,
            };

            return developersModel;
        }
    }
}
