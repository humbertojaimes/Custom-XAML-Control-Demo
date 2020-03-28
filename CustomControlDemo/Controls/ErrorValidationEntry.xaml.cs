using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomControlDemo.Controls
{
    public partial class ErrorValidationEntry : StackLayout
    {
        public enum Valid
        {
            NoValidated,
            Valid,
            Invalid
        }

        public ErrorValidationEntry()
        {
            InitializeComponent();
            IsObligatory = false;
            entry.BindingContext = this;
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ErrorValidationEntry), string.Empty, propertyChanged: PlaceHolderPropertyChanged);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        static void PlaceHolderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var errorEntry = bindable as ErrorValidationEntry;
            errorEntry.entry.Placeholder = (string)newValue;
            errorEntry.lbTitle.Text = (string)newValue;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ErrorValidationEntry), string.Empty, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value?.ToUpperInvariant());
                IsValid = Valid.NoValidated;
            }
        }

        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ErrorValidationEntry), "El valor no es válido", propertyChanged: ErrorMessagePropertyChanged);

        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set
            {
                SetValue(ErrorMessageProperty, value);
            }
        }

        static void ErrorMessagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var errorEntry = bindable as ErrorValidationEntry;
            errorEntry.lbError.Text = (string)newValue;
        }


        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(Valid), typeof(ErrorValidationEntry), Valid.NoValidated, defaultBindingMode: BindingMode.TwoWay, propertyChanged: IsValidChanged);

        public Valid IsValid
        {
            get => (Valid)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        static void IsValidChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = (bindable as StackLayout).Children[1] as Entry;
            var errorLabel = (bindable as StackLayout).Children[2] as Label;
            if ((Valid)newValue == Valid.Invalid)
            {
                entry.BackgroundColor = Color.LightCoral;
                errorLabel.IsVisible = true;
            }
            else
            {
                entry.BackgroundColor = Color.White;
                errorLabel.IsVisible = false;
            }
        }


        public static readonly BindableProperty IsObligatoryProperty = BindableProperty.Create(nameof(IsObligatory), typeof(bool), typeof(ErrorValidationEntry), true, propertyChanged: IsObligatotyPropertyChanged);

        public bool IsObligatory
        {
            get => (bool)GetValue(IsObligatoryProperty);
            set => SetValue(IsObligatoryProperty, value);
        }


        static void IsObligatotyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var errorEntry = bindable as ErrorValidationEntry;
            errorEntry.lbIndicator.IsVisible = (bool)newValue;
        }

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(ErrorValidationEntry), Keyboard.Default, propertyChanged: KeyboardPropertyChanged);

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }


        static void KeyboardPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var errorEntry = bindable as ErrorValidationEntry;
            errorEntry.entry.Keyboard = (Keyboard)newValue;
        }

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(ErrorValidationEntry), 0, propertyChanged: MaxLengthPropertyChanged);

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        static void MaxLengthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var errorEntry = bindable as ErrorValidationEntry;
            errorEntry.entry.MaxLength = (int)newValue;
        }


        public static readonly BindableProperty UnfocusCommandProperty = BindableProperty.Create(nameof(UnfocusCommand), typeof(ICommand), typeof(ErrorValidationEntry), null, defaultBindingMode: BindingMode.TwoWay);

        public ICommand UnfocusCommand
        {
            get => (ICommand)GetValue(UnfocusCommandProperty);
            set => SetValue(UnfocusCommandProperty, value);
        }

        
    }
}
