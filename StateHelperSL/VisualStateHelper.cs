using System;
using System.Windows;
using System.Windows.Controls;

namespace StateHelperSL
{
    public class VisualStateHelper : DependencyObject
    {
        public static readonly DependencyProperty VisualStatePropertyProperty = DependencyProperty.RegisterAttached(
            "VisualStateProperty",
            typeof(string),
            typeof(VisualStateHelper),
            new PropertyMetadata(VisualStatePropertyChangedCallback));

        private static void VisualStatePropertyChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = s as Control;
            if (ctrl == null)
                throw new InvalidOperationException("This attached property only supports types derived from Control.");
            
            VisualStateManager.GoToState(ctrl, e.NewValue.ToString(), true);
        }

        public static string GetVisualStateProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(VisualStatePropertyProperty);
        }

        public static void SetVisualStateProperty(DependencyObject obj, string value)
        {
            obj.SetValue(VisualStatePropertyProperty, value);
        }
    }
}