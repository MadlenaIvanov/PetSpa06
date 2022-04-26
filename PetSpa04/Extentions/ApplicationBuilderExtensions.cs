using PetSpa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PetSpa04.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedServicesInfo(services);
            SeedPetTypesInfo(services);
            SeedLocationsInfo(services);
            //SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        //seed Services
        private static void SeedServicesInfo(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Services.Any())
            {
                return;
            }

            data.Services.AddRange(new[]
            {
                new Service { Name = "Grooming", Description = "Includes warm bath, fluff dry, brush/comb, ear cleaning/plucking, nail trim/file, brush teeth, full haircut, style, shave, or shampoo (flea and tick, hypoallergenic, detangling, or de-shedding).", ImageUrl = "https://www.dogtime.com/assets/uploads/2019/04/DogGrooming1-1280x720.jpg" },
                new Service { Name = "Hospital", Description = "Veterinary hospital, your pets' first choice for veterinary care. Experienced team of qualified vets & nurses run to the standards and clinical excellence.", ImageUrl = "https://www.aaha.org/globalassets/05-pet-health-resources/ask-aaha/ask_aaha_vetvisits_teaser.jpg" },
                new Service { Name = "Hotel", Description = "In our pet hotel, your dogs and cats will feel surrounded by lots of love and good attitude. They will have fun and will create new friendships. With us, your pet will feel the warmth of the home environment, they will feel at home.", ImageUrl = "https://cdn2.howtostartanllc.com/images/business-ideas/business-idea-images/pet-hotel.jpg" },
                new Service { Name = "Spa", Description = "Pet Spa is a luxury spa for dog grooming and cat grooming. We have no breed restrictions and offer a wide range of services. Now offering fur colouring.", ImageUrl = "https://i.ibb.co/sV3JRxY/658d5659cae4d6930940f9bfc7564df1.jpg" }
            });

            data.SaveChanges();
        }

        //seed PetTypes
        private static void SeedPetTypesInfo(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.PetTypes.Any())
            {
                return;
            }

            data.PetTypes.AddRange(new[]
            {
                new PetType { Name = "Dog" },
                new PetType { Name = "Cat" },
                new PetType { Name = "Bird" },
                new PetType { Name = "Guinea Pig" },
                new PetType { Name = "Other"}
            });

            data.SaveChanges();
        }

        //seed Locations

        private static void SeedLocationsInfo(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Locations.Any())
            {
                return;
            }

            data.Locations.AddRange(new[]
            {
                new Location { LocationTown = "Sofia", Address = "Crow's view 193" },
                new Location { LocationTown = "Varna", Address = "Seagull's corner 943" },
                new Location { LocationTown = "Plovdiv", Address = "Old town center 329" },
                new Location { LocationTown = "Burgas", Address = "Cobblestone path 123" }
            });

            data.SaveChanges();
        }
    }
}