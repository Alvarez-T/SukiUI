using Avalonia;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace SukiUI.Controls
{
    [PseudoClasses(":checked", ":unchecked", ":indeterminate")]
    public class ToggleButtonIcon : ToggleButton
    {
        public static readonly StyledProperty<Geometry> IconProperty =
            AvaloniaProperty.Register<ToggleButtonIcon, Geometry>(nameof(Icon));

        public Geometry Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public ToggleButtonIcon() : base()
        {

        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
        }
    }
}
