using System;
using System.Text.RegularExpressions;
using CustomControlDemo.BaseClasses;
using Xamarin.Forms;
using static CustomControlDemo.Controls.ErrorValidationEntry;

namespace CustomControlDemo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
        }


        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        private string email;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }


        private Valid isValidEmail;

        public Valid IsValidEmail
        {
            get => isValidEmail;
            set => SetProperty(ref isValidEmail, value);
        }


        public Command UnfocusCommand => new Command
            (() =>
            {
                if (Email != null)
                {
                    var mailRegex = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
                    Regex regex = new Regex(mailRegex);

                    if (regex.Match(Email).Success)
                        IsValidEmail = Valid.Valid;
                    else
                        IsValidEmail = Valid.Invalid;
                }
            });

    }
}
