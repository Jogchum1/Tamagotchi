using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatureView : ContentView
    {
        public static readonly BindableProperty MyCreatureProperty = BindableProperty.Create(nameof(MyCreature), typeof(Creature), typeof(CreatureView), propertyChanged: HandlePropertyChanged);

        public Creature MyCreature
        {
            get => GetValue(MyCreatureProperty) as Creature;
            set => SetValue(MyCreatureProperty, value);
        }

        public CreatureView()
        {
            BindingContext = this;

			InitializeComponent();
		}

		private static void HandlePropertyChanged(BindableObject b, object oldValue, object newValue)
		{
			//(b as view).Property;
		}
	}

}