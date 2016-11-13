using System.Collections.Generic;
using CityInfo.Repository.Document;

namespace CityInfo.Repository
{
    public interface ICityInfoRepository
    {
        IEnumerable<CityDocument> GetCities();
        CityDocument GetCity(int cityId, bool includePointOfInterests);
        PointOfInterestDocument GetPointsPointOfInterestDocumentsForCity(int cityId, int pId);
        IEnumerable<PointOfInterestDocument> GetPointsPointOfInterestDocumentsForCity(int cityId);
        void DeletePointOfInterest(PointOfInterestDocument pDoc);
        bool Save();
    }
}