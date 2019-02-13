using System;
using Todo.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
    public partial class App : Application
    {
        public static IDataRepository DataRepository
        {
            get
            {
                if (dataRepository == null)
                {
                    lock (dataRepository)
                    {
                        if (dataRepository == null)
                            dataRepository = new MemoryDataRepository();
                    }
                }

                return dataRepository;
            }
        }

        private static MemoryDataRepository dataRepository;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
