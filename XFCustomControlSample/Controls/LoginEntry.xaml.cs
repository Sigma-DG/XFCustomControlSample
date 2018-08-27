using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControlSample.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginEntry : ContentView
	{
		public LoginEntry ()
		{
			InitializeComponent ();

            textbox.TextChanged += OnTextChanged;

        }

        public string Hint { get; set; }

        public static readonly BindableProperty HintProperty = BindableProperty.Create(
                                                         propertyName: "Hint",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(LoginEntry),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: HintPropertyChanged);

        private static void HintPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoginEntry)bindable;
            if(newValue != null)
                control.hintLabel.Text = newValue.ToString();
        }

        public static BindableProperty ValueProperty = BindableProperty.Create(
                                                        propertyName: "Value",
                                                        returnType: typeof(string),
                                                        declaringType: typeof(LoginEntry),
                                                        defaultValue: "",
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: ValuePropertyChanged);
        
        public string Value
        {
            get { return (string)base.GetValue(ValueProperty); }
            set { base.SetValue(ValueProperty, value); }
        }

        private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoginEntry)bindable;
            if(newValue != null)
                control.textbox.Text = newValue.ToString();
        }
        
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(
                                                        propertyName: "IsPassword",
                                                        returnType: typeof(bool),
                                                        declaringType: typeof(LoginEntry),
                                                        defaultValue: false,
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: IsPasswordPropertyChanged);

        public bool IsPassword
        {
            get { return (bool)base.GetValue(IsPasswordProperty); }
            set { base.SetValue(IsPasswordProperty, value); }
        }

        private static void IsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoginEntry)bindable;
            control.textbox.IsPassword = (bool)newValue;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ValueProperty.PropertyName)
            {
                textbox.Text = Value;
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Value = e.NewTextValue;
        }
    }
}