using System;
using IRIS.Domain.Entities;

namespace IRIS.TestUtils
{
    public static class TestData
    {
        public class Users
        {
            public static User Default { get; } = new(Guid.Empty, "system@test.com", "system");
            public static User John { get; } = new(Guid.NewGuid(), "j.fly@test.com", "John Fly");
            public static User Sarah { get; } = new(Guid.NewGuid(), "s.parker-smith@test.org", "Sarah Parker-Smith");
        }
    }
}