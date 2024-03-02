using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Mixins;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using SukiUI.Controls;
using System.Reactive.Disposables;

namespace Alvz.Avalonia.Desktop;

[PseudoClasses(":pressed", ":selected")]
public class SideMenuItem : ItemsControl, ISelectable
{
    public static readonly StyledProperty<Geometry> IconProperty =
        AvaloniaProperty.Register<SideMenuItem, Geometry>(nameof(Icon));

    public static readonly StyledProperty<string> HeaderProperty =
        AvaloniaProperty.Register<SideMenuItem, string>(nameof(Header));

    public static readonly StyledProperty<object> PageContentProperty =
        AvaloniaProperty.Register<SideMenuItem, object>(nameof(PageContent));

    public static readonly StyledProperty<bool> IsSelectedProperty =
        SelectingItemsControl.IsSelectedProperty.AddOwner<SideMenuItem>();

    static SideMenuItem()
    {
        SelectableMixin.Attach<SideMenuItem>(IsSelectedProperty);
        PressedMixin.Attach<SideMenuItem>();
    }

    public Geometry Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public object PageContent
    {
        get => GetValue(PageContentProperty);
        set => SetValue(PageContentProperty, value);
    }

    public bool IsSelected
    {
        get => GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        //if (e.NameScope.Get<ContentPresenter>("PART_AltDisplay") is { } contentControl)
        //{
        //    if (Header is not null || Icon is not null)
        //    {
        //        contentControl.IsVisible = false;
        //    }
        //}


    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        if (e.Handled)
            return;

        if (!e.Handled && ItemsControl.ItemsControlFromItemContaner(this) is SideMenu owner)
        {
            var p = e.GetCurrentPoint(this);

            if (p.Properties.PointerUpdateKind is PointerUpdateKind.LeftButtonPressed)
            {
                if (p.Pointer.Type == PointerType.Mouse)
                {
                    // If the pressed point comes from a mouse, perform the selection immediately.
                    e.Handled = owner.UpdateSelectionFromPointerEvent(this, e);
                }
            }
        }
    }
}
