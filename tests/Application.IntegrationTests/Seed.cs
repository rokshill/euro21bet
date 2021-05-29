using System;
using System.Collections.ObjectModel;
using IRIS.Domain.Entities;
using IRIS.Domain.ValueObjects;

namespace IRIS.Application.IntegrationTests
{
    public static class Seed
    {
        public static Guid DefaultUserGuid { get; } = Guid.NewGuid();

        public static void Generic()
        {
            using var context = Testing.GetContext();

            var user = new User(DefaultUserGuid, "john@test.com", "John Test");
            context.Users.Add(user);
            context.SaveChanges();

            Assay assay1 = new("Test Assay 1", user, AssayStatus.Ready(), "Test Assay 1 Description", "Red");
            Assay assay2 = new("Test Assay 2", user, AssayStatus.Uploading(10, 100), "Test Assay 2 Description", "Red");
            var assays = new Collection<Assay> { 
                assay1,
                assay2
            };
            context.Assays.AddRange(assays);

            context.Sessions.Add(new Session
            {
                Owner = user,
                Assay = assay1,
                Name = "Session 1"
            });

            context.SaveChanges();
        }
    }
}