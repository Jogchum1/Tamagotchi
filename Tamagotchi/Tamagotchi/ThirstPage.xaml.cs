using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirstPage : ContentPage
    {
        
        public ThirstPage()
        {
            BindingContext = this;

            InitializeComponent();
        }

        private void Back_Button_Clicked(object sender, EventArgs e)
        {
            

            Navigation.PushAsync(new MainPage());
        }
    }
}