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

            // Bindings-konteksten refererer til objektet vi binder mod.
            // Dette kan også sættes fra XAML
            BindingContext = this.simpleViewModel;

            // Skab XAML objekter (skal gøres FØR bindings sættes)
            InitializeComponent();

            // Sæt versions-binding vha. lambda og autokorrektur
            versionsTekst.SetBinding<SimpleViewModel>(Label.TextProperty, vm => vm.VersionText, BindingMode.OneWay);

            // Sæt status-binding vha. lambda og autokorrektur
            statusTekst.SetBinding<SimpleViewModel>(Label.TextProperty, vm => vm.StatusText, BindingMode.OneWay);

            // Bindings-metode #2 Sæt binding vha. lambda og autokorrektur
            loginEntry.SetBinding<SimpleViewModel>(Entry.TextProperty, vm => vm.Login, BindingMode.OneWayToSource);

            // Bindings-metode #1: Sæt bindinger vha. usikker tekst
            //loginKnap.SetBinding(Button.IsEnabledProperty, "LoginOk", BindingMode.OneWay);

            // Sæt login-binding vha. lambda og autokorrektur
            loginKnap.SetBinding<SimpleViewModel>(Button.IsEnabledProperty, vm => vm.LoginOk, BindingMode.OneWay);

            // Binding-metode #3 - se XAML-filen ;)
        }
    }
}
