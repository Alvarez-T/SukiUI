using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Material.Icons;

namespace SukiUI.Extensions;

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
