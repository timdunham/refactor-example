using RefactorTest.Models;
using RefactorTest.Repositories;
using RefactorTest.ViewModels;
using System.Collections.Generic;

namespace RefactorTest.Services
{
    public interface IRepresentativesService
    {
        RepresentativeDataModel AddNewRepresentative(RepresentativeViewModel r, int dealerId);
    }

    public sealed class RepresentativesService : IRepresentativesService
    {
        private readonly IRepresentativesRepository _representativeRepository;

        public RepresentativesService(IRepresentativesRepository representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        public RepresentativeDataModel AddNewRepresentative(RepresentativeViewModel r, int DealerId)
        {
            var viewModel = r;
            var canSave = ValidateRepresentative(viewModel);
            canSave = ValidateRepresentativeEmail(viewModel);
            if (canSave == true)
            {
                var modelToSave = ValidateRepresentative3(viewModel)
                _representativeRepository.SaveRepresentative(modelToSave);
            }
        }
        private bool ValidateRepresentative(RepresentativeViewModel r, int dealerId)
        {
            List<RepresentativeDataModel> representatives = _representativeRepository.GetExistingRepresentatives(dealerId);
            foreach (var representative in representatives)
            {
                if (representative.Name == r.Name)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private bool ValidateRepresentativeEmail(RepresentativeViewModel r, int dealerId)
        {
            List<RepresentativeViewModel> representatives = _representativeRepository.GetExistingRepresentatives(dealerId);
            foreach (var representative in representatives)
            {
                if (representative.Email = r.Email)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// Phone number will come in with dashes: 1-234-234-7777, 0-123-456-7777 or 123-456-7777
        //  Format for storing with the data model is without a leading 0 or 1 and no dashes: 1242347777 or 1234567777
        private RepresentativeViewModel ValidateRepresentative3(RepresentativeViewModel r, int DealerId)
        {
            var Rep = new RepresentativeDataModel(r);
            if (Rep.PhoneNumber != null)
            {
                if (Rep.PhoneNumber.Length > 10)
                {
                    Rep.PhoneNumber.Substring(1, 9);
                }
                if (!Rep.PhoneNumber.All(char.IsDigit))
                {
                    var newNumber = "";
                    var tempArray = Rep.PhoneNumber.ToCharArray();
                    foreach (var numberChar in tempArray)
                    {
                        if (!numberChar.IsDigit)
                        {
                            var index = tempArray.FindIndex(numberChar)
                            tempArray.RemoveAt(index);
                        }
                    }
                    Rep.PhoneNumber = tempArray;
                }
            }
            return Rep;
        }
    }
}



