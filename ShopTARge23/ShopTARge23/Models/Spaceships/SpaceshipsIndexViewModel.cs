namespace ShopTARge23.Models.Spaceships
{
    public class SpaceshipsIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Typename { get; set; }
        public string SpaceshipModel { get; set; }
        public DateTime BuiltDate { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }
    }
}
