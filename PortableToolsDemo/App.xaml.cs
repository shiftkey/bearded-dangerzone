using System;
using PortableClassLibrary;
using PortableToolsDemo.Common;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PortableToolsDemo
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            // testing code here
            var result = ReflectionTest.HasConstructors<SomeClass>();

            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            var rootFrame = new Frame();
            SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                await SuspensionManager.RestoreAsync();
            }

            if (rootFrame.Content == null)
            {
                if (!rootFrame.Navigate(typeof(GroupedItemsPage), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
