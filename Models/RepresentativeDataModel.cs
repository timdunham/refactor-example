using RefactorTest.ViewModels;

namespace RefactorTest.Models
{
    public class RepresentativeDataModel
    {
        public RepresentativeDataModel(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public RepresentativeDataModel(RepresentativeViewModel viewModel)
        {
            Name = viewModel.Name;
            Email = viewModel.Email;
            PhoneNumber = viewModel.PhoneNumber;
        }

        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
    }
}