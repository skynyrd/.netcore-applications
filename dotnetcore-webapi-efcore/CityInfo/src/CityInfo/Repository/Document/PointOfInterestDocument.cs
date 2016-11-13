namespace CityInfo.Repository.Document
{
    public class PointOfInterestDocument
    {
        //[Key] is not required: EF Core auto detects key if it is named as Id or [DocumentName]Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Fully defined navigation convention
        // public CityDocument CityDocument { get; set; }
        // public int CityDocumentId { get; set; }

        //Single Navigation Property convention
        public int CityDocumentId { get; set; }
    }
}
