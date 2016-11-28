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
        private string versionText = "N/A";
        private string login;
        private bool loginOk = false;
        private string statusText = "Indtast telefonnummer";

        //We need to implement this event in order to fullfill INotifyPropertyChanged event
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

            set
            {
                //Check that the new value is not equal to the current
                if (Login != value)
                {
                    login = value;
                    OnPropertyChanged("Login"); //propertyname provided manually

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
                    OnPropertyChanged(); //compiler provides the property name;
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
                if(StatusText != value)
                {
                    statusText = value;
                    VersionText = "v2.00"; // Sæt versionsnummer, når status opdateres
                    OnPropertyChanged();
                }
            }
        }

        //Simple function that we call whenever we want to tell bindings that
        //some property has changed.
        //Note: CallerMemberName is just compiler-sugar that puts in the name of
        //the calling property if no value is provided.        
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
