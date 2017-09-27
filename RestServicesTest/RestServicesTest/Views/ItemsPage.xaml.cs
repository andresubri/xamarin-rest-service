using System;

using RestServicesTest.Models;
using RestServicesTest.ViewModels;

using Xamarin.Forms;
using RestServicesTest.Helpers;
using System.Collections.Generic;

namespace RestServicesTest.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        RestService restService;
        List<Post> PostList; 
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            PostList = new List<Post>();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            restService = new RestService();
            PostList = await restService.GetPostList();
            ItemsListView.ItemsSource = PostList;
        }
    }
}
