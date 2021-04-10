namespace Elevations.RoomCategory.Dto
{
    using Elevations.EntityFrameworkCore.HotelDto;

    public class UpdateRoomDto
    {
        public long Bath { get; set; }

        public long Bed { get; set; }

        public RoomsCategory Category { get; set; }

        public string Description { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public int ImageSequence { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
    }
}