using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<IDataStore<Creature>>(new LocalCreatureStore());

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart()
		{
			var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
			var wakeTime = DateTime.Now;

			TimeSpan timeAsleep = wakeTime - sleepTime;
		}

		protected override void OnSleep()
		{
			var sleepTime = DateTime.Now;
			Preferences.Set("SleepTime", sleepTime);
		}

		protected override void OnResume()
		{
		}

	}
}
