using RefactorTest.Models;
using System.Collections.Generic;

namespace RefactorTest.Repositories
{
    public interface IRepresentativesRepository
    {
        List<RepresentativeDataModel> GetExistingRepresentatives(int dealerId);

        RepresentativeDataModel SaveRepresentative(RepresentativeDataModel model);
    }
}