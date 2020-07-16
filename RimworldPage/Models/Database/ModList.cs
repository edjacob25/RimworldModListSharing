using System;
using System.Collections.Generic;

namespace WebApplication.Models.Database
{
    public class ModList
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Version { get; set; }
        public List<Expansions>? Expansions { get; set; }

        public List<ModListMod> Mods { get; set; }
    }
}