namespace WebApplication.Models.Database
{
    public class ModListMod
    {
        public string ModListId { get; set; }
        public string ModId { get; set; }
        public string ModName { get; set; }
        public int Position { get; set; }

        public ModList ModList { get; set; }
        public Mod Mod { get; set; }
    }
}