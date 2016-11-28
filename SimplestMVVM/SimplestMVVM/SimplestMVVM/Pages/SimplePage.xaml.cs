using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplestMVVM.ViewModels;
using Xamarin.Forms;

namespace SimplestMVVM.Pages
{
    public partial class SimplePage : ContentPage
    {
        private SimpleViewModel simpleViewModel;

        public SimplePage(SimpleViewModel simpleViewModel)
        {
            this.simpleViewModel = simpleViewModel;

            //The binding context refers to the object we are binding against.
            //This can also be set from XAML
            BindingContext = this.simpleViewModel;

            //Create XAML objects
            InitializeComponent();

            //Sæt versions-binding vha. lambda og sikkerhed
            versionsTekst.SetBinding<SimpleViewModel>(Label.TextProperty, vm => vm.VersionText, BindingMode.OneWay);

            //Sæt status-binding vha. lambda og sikkerhed
            statusTekst.SetBinding<SimpleViewModel>(Label.TextProperty, vm => vm.StatusText, BindingMode.OneWay);

            //Binding method #2 Set binding using lambda and typesafety
            loginEntry.SetBinding<SimpleViewModel>(Entry.TextProperty, vm => vm.Login, BindingMode.OneWayToSource);

            //Binding method #1: Set bindings using unsafe Text
            //loginKnap.SetBinding(Button.IsEnabledProperty, "LoginOk", BindingMode.OneWay);

            //Sæt login-binding vha. lambda og sikkerhed
            loginKnap.SetBinding<SimpleViewModel>(Button.IsEnabledProperty, vm => vm.LoginOk, BindingMode.OneWay);

            //Binding method #3 - see the XAML file ;)
        }
    }
}
