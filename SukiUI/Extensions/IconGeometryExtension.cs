using Avalonia.Markup.Xaml;
using Material.Icons.Avalonia;
using Material.Icons;
using Avalonia.Media;

namespace Alvz.Avalonia.Desktop;

public class IconGeometryExtension : MarkupExtension
{
    public IconGeometryExtension() { }
    public IconGeometryExtension(MaterialIconKind kind)
    {
        Kind = kind;
    }

    [ConstructorArgument("kind")]
    public MaterialIconKind Kind { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => StreamGeometry.Parse(MaterialIconDataProvider.GetData(Kind));
}
