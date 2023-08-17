using Domain.Entities.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Importer
{
    public class DeveloperImporter
    {
        public static async Task<DevelopersModel> CreateDeveloper(DevelopersModel developer)
        {
            DevelopersModel developersModel = new DevelopersModel()
            {
                Slug = developer.Slug,
                Name = developer.Name,
            };

            return developersModel;
        }
    }
}
