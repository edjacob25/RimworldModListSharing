using System.Collections.Generic;

namespace WebApplication.Models.Database
{
    public class Mod
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string? SteamUrl { get; set; }

        public string? ForumUrl { get; set; }

        public List<ModListMod> ModLists { get; set; }
    }
}