using GainzTrack.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Data
{
    public class ApplicationDbSeed
    {
        public static void Seed(ApplicationDbContext context, ILogger logger)
        {
            try
            {
                if (!context.Titles.Any())
                {
                    context.AddRange(GetConfiguredTitles());

                    context.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        private static IEnumerable<Title> GetConfiguredTitles()
        {
            return new List<Title>()
            {
                new Title(){ Name = "Newbie",RequiredAP = 0},
                new Title(){ Name = "Enthusiast",RequiredAP = 500}
            };
        }
    }
}
