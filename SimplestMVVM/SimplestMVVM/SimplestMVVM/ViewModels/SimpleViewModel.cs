using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimplestMVVM.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        private string versionText = "2.0.0"; // 1. ciffer: major version | 2. ciffer: minor version | 3. ciffer: build version
        private string login;
        private bool loginOk = false;
        private string statusText = "Indtast telefonnummer";

        // Vi skal implementere denne event for at opfylde INotifyPropertyChanged-kontrakten
        public event PropertyChangedEventHandler PropertyChanged;

        public string VersionText
        {
            get
            {
                return versionText;
            }

            set
            {
                if (VersionText != value)
                {
                    versionText = value;
                    OnPropertyChanged("VersionText");
                }
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set // Kaldes for hvert tastetryk (set kaldes, fordi vi anvender OneWayToSource - havde vi anvendt OneWay ville get blive kaldt)
            {
                // Tjek at den nye værdi ikke er lig med den nuværende
                if (Login != value)
                {
                    login = value;
                    OnPropertyChanged("Login"); // property-navnet tildelt manuelt

                    if (String.IsNullOrEmpty(Login) || String.IsNullOrWhiteSpace(Login))
                    {
                        LoginOk = false;
                        StatusText = "Indtast telefonnummer";
                    }
                    else if (Login.Length < 8)
                    {
                        LoginOk = false;
                        StatusText = "Telefonnummer for kort";
                    }
                    else if (Login.Length > 8)
                    {
                        LoginOk = false;
                        StatusText = "Telefonnummer for langt";
                    }
                    else
                    {
                        LoginOk = true;
                        StatusText = "Klar til at logge ind";
                    }
                }
            }
        }

        public bool LoginOk
        {
            get
            {
                return loginOk;
            }

            set
            {
                if (loginOk != value)
                {
                    loginOk = value;
                    OnPropertyChanged(); // Compileren tildeler property-navnet;
                }
            }
        }

        public string StatusText
        {
            get
            {
                return statusText;
            }

            set
            {
                if (StatusText != value)
                {
                    statusText = value;
                    OnPropertyChanged();
                }
            }
        }

        // Simel funktion som vi kalder når vi vil fortælle bindings at
        // et givent property har ændret sig.
        // Note: CallerMemberName er blot compiler-sukker som indsætter navnet på
        // det kaldende property hvis der ikke er tildelt en værdi.    
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                ev(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
