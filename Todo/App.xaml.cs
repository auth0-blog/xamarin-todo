using System;
using Todo.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
    public partial class App : Application
    {
        private static object lockObj = new object();
        private static MemoryDataRepository dataRepository;

        /// <summary>
        /// Gets the data repository used by the whole app
        /// </summary>
        public static IDataRepository DataRepository
        {
            get
            {
                if (dataRepository == null)
                {
                    lock (lockObj)
                    {
                        if (dataRepository == null)
                            dataRepository = new MemoryDataRepository();
                    }
                }

                return dataRepository;
            }
        }

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
