using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using SukiUI.Controls;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Alvz.Avalonia.Desktop;

public class SideMenu : SelectingItemsControl
{
    public static readonly StyledProperty<double> HeaderMinHeightProperty =
    AvaloniaProperty.Register<SideMenu, double>(nameof(HeaderMinHeight));

    public static readonly StyledProperty<object?> HeaderContentProperty =
    AvaloniaProperty.Register<SideMenu, object?>(nameof(HeaderContent));

    public double HeaderMinHeight
    {
        get => GetValue(HeaderMinHeightProperty);
        set => SetValue(HeaderMinHeightProperty, value);
    }

    public object? HeaderContent
    {
        get => GetValue(HeaderContentProperty);
        set => SetValue(HeaderContentProperty, value);
    }

    private IDisposable? _contentDisposable;

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        if (e.NameScope.Get<SukiTransitioningContentControl>("PART_TransitioningContentControl") is { } contentControl)
        {
            _contentDisposable = this.GetObservable(SelectedItemProperty)
                .ObserveOn(new AvaloniaSynchronizationContext())
                .Do(obj =>
                {
                    contentControl.PushContent(obj switch
                    {
                        SideMenuItem { PageContent: { } menuPageContent } => menuPageContent,
                        _ => obj
                    });
                })
                .Subscribe();
        }
    }
    
    public bool UpdateSelectionFromPointerEvent(Control source, PointerEventArgs e)
    {
        return UpdateSelectionFromEventSource(source);
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        if (ItemTemplate != null && ItemTemplate.Match(item) && ItemTemplate.Build(item) is SideMenuItem sukiMenuItem)
            return sukiMenuItem;
        return new SideMenuItem();
    }

    protected override bool NeedsContainerOverride(object? item, int index, out object? recycleKey)
    {
        return NeedsContainer<SideMenuItem>(item, out recycleKey);
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        _contentDisposable?.Dispose();
    }
}

