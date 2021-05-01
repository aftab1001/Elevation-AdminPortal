namespace Elevations.Services.Dto
{
    public class UpdateRoomDto
    {
        public long Bath { get; set; }

        public long Bed { get; set; }

        public string CategoryName { get; set; }

        public string CityFee { get; set; }

        public string CleaningFee { get; set; }

        public string Description { get; set; }

        public string Facilities { get; set; }

        public string Features { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public int ImageSequence { get; set; }

        public long Length { get; set; }

        public string Location { get; set; }

        public string MaxNumberOfDays { get; set; }

        public string MinNumberOfDays { get; set; }

        public string MonthlyPlan { get; set; }

        public string Name { get; set; }

        public string NightlyPlan { get; set; }

        public string Price { get; set; }

        public string WeekendPlan { get; set; }

        public string WeeklyPlan { get; set; }
    }
}