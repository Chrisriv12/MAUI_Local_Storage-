using System.Collections.ObjectModel;
using MAUI_Local_Storage.DataAccess;
using MAUI_Local_Storage.Models;
using System; 
using Microsoft.Maui.Controls;
namespace MAUI_Local_Storage
{
    public partial class MainPage : ContentPage
    {
        PersonData personData; public ObservableCollection<Person> People { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            personData = new PersonData();
            BindingContext = this;
            UpdatePeopleList();
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                await DisplayAlert("Error", "First name cannot be empty", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                await DisplayAlert("Error", "Last name cannot be empty", "OK");
                return;
            }
            if (dpDateOfBirth.Date > DateTime.Today)
            {

                await DisplayAlert("Error", "Date of Birth cannot be in the future", "OK");
                return;
            }

            var person = new Person
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DoB = dpDateOfBirth.Date
            };
            await personData.SavePersonAsync(person);
            UpdatePeopleList();
        }
        private async void UpdatePeopleList()
        {
            var people = await personData.GetPeopleAsync();
            People.Clear();
            foreach (var person in people)
            {
                People.Add(person);
            }
        }
    }
}