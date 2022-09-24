using walks.Models.Domain;

namespace walks.Models.Dto
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //Navigation properties
        public RegionDto Region { get; set; }
        public WalkDifficultyDto WalkDifficulty { get; set; }
    }
}
