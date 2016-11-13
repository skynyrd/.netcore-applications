using System.Collections.Generic;
using System.Linq;
using CityInfo.Document;
using CityInfo.Repository.Document;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Repository
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext context;

        public CityInfoRepository(CityInfoContext context)
        {
            this.context = context;
        }

        public IEnumerable<CityDocument> GetCities()
        {
            return context.CityDocuments.OrderBy(c => c.Name).ToList();
        }

        public CityDocument GetCity(int cityId, bool includePointOfInterests)
        {
            return includePointOfInterests ? 
                context.CityDocuments.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId) : 
                context.CityDocuments.FirstOrDefault(c => c.Id == cityId);
        }

        public PointOfInterestDocument GetPointsPointOfInterestDocumentsForCity(int cityId, int pId)
        {
            return context.PointOfInterestDocuments.FirstOrDefault(p => p.CityDocumentId == cityId && p.Id == pId);
        }

        public IEnumerable<PointOfInterestDocument> GetPointsPointOfInterestDocumentsForCity(int cityId)
        {
            return context.PointOfInterestDocuments.Where(p => p.CityDocumentId == cityId);
        }

        public void DeletePointOfInterest(PointOfInterestDocument pDoc)
        {
            context.PointOfInterestDocuments.Remove(pDoc);
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0; //returns number of rows affected.
        }
    }
}
