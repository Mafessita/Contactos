using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace telefono
{
    public partial class Inicial : ContentPage
    {
        // ObservableCollection to hold the contacts
        private ObservableCollection<Contact> _contacts;

        public Inicial()
        {
            InitializeComponent();

            // Initialize the ObservableCollection and bind it to the CollectionView
            _contacts = new ObservableCollection<Contact>();
            ContactsListView.ItemsSource = _contacts;
        }

        // Event handler for the Add Contact button
        private void OnAddContactClicked(object sender, EventArgs e)
        {
            // Show the AddContactPanel
            AddContactPanel.IsVisible = true;
            AddContactPanel.TranslateTo(0, 0, 300, Easing.CubicInOut);
        }

        // Event handler for the Save Contact button
        private void OnSaveContactClicked(object sender, EventArgs e)
        {
            // Create a new contact from the user inputs
            var newContact = new Contact
            {
                Name = NameEntry.Text,
                Occupation = OccupationEntry.Text,
                Phone = PhoneEntry.Text,
                Address = AddressEntry.Text,
                Email = EmailEntry.Text
            };

            // Add the new contact to the ObservableCollection
            _contacts.Add(newContact);

            // Hide the AddContactPanel
            AddContactPanel.TranslateTo(0, 400, 300, Easing.CubicInOut).ContinueWith((t) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    AddContactPanel.IsVisible = false;
                });
            });

            // Clear the input fields
            NameEntry.Text = string.Empty;
            OccupationEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
        }

        // Event handler for the Cancel button
        private void OnCancelClicked(object sender, EventArgs e)
        {
            // Hide the AddContactPanel
            AddContactPanel.TranslateTo(0, 400, 300, Easing.CubicInOut).ContinueWith((t) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    AddContactPanel.IsVisible = false;
                });
            });
        }
    }

    // Contact model
    public class Contact
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
