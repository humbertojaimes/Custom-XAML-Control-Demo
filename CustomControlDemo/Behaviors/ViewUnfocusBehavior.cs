using System;
using CustomControlDemo.Controls;
using Xamarin.Forms;

namespace CustomControlDemo.Behaviors
{

    public class ViewUnfocusBehavior : Behavior<VisualElement>
    {
        protected override void OnAttachedTo(VisualElement bindable)
        {
            bindable.Unfocused += Bindable_Unfocused;
            //bindable.Focused+= Bindable_Focused;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            bindable.Unfocused -= Bindable_Unfocused;
            //  bindable.Focused+= Bindable_Focused;
        }

        void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as VisualElement;

            if (entry.BindingContext is ErrorValidationEntry errorEntry)
                if(errorEntry.UnfocusCommand != null && errorEntry.UnfocusCommand.CanExecute(null))
                    errorEntry.UnfocusCommand?.Execute(null);
        }

    }
}
