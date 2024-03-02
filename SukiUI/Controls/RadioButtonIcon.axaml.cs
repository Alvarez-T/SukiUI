using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Alvz.Avalonia.Desktop
{
    public class RadioButtonIcon : RadioButton
    {
        public static readonly StyledProperty<Geometry> IconProperty =
            AvaloniaProperty.Register<RadioButtonIcon, Geometry>(nameof(Icon));

        public static readonly StyledProperty<double> IconHeightProperty =
            AvaloniaProperty.Register<RadioButtonIcon, double>(nameof(IconHeight), defaultValue: 25);

        public static readonly StyledProperty<double> IconWidthProperty =
            AvaloniaProperty.Register<RadioButtonIcon, double>(nameof(IconWidth), defaultValue: 20);

        public static readonly StyledProperty<IconPosition> IconPositionProperty =
            AvaloniaProperty.Register<RadioButtonIcon, IconPosition>(nameof(IconPosition), defaultValue: IconPosition.Left);

        public Geometry Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public double IconHeight
        {
            get => GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public double IconWidth
        {
            get => GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public IconPosition IconPosition
        {
            get => GetValue(IconPositionProperty);
            set => SetValue(IconPositionProperty, value);
        }
        
    }
}
