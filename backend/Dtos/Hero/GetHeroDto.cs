namespace backend.Dtos.Hero
{
    public class GetHeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Card1 { get; set; }
        public string Card2 { get; set; }
        public string Card3 { get; set; }
        public string Card4 { get; set; }
        public string DeathToken { get; set; }
    }
}