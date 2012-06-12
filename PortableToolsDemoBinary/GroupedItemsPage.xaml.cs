using System;
using System.Collections.Generic;
using PortableToolsDemo.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PortableToolsDemo
{
    public sealed partial class GroupedItemsPage : PortableToolsDemo.Common.LayoutAwarePage
    {
        public GroupedItemsPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            this.DefaultViewModel["Groups"] = sampleDataGroups;
        }

        void Header_Click(object sender, RoutedEventArgs e)
        {
            var group = (sender as FrameworkElement).DataContext as SampleDataGroup;
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
        }
    }
}
