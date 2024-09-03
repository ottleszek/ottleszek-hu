using System.Windows.Input;
using WillBeThere.Shared.Models;

namespace WillBeThere.Mobile.Controls;

public partial class MUIChip : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create($"Text", typeof(string), typeof(MUIChip), default(string), propertyChanged: (view, oldValue, newValue) =>
        {
            if (newValue is not string || newValue is null)
                return;
            var chip = view as MUIChip;
            if (chip is not null)
            {
                chip.Label.Text = newValue.ToString();
            }
        });

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create($"CommandParameter", typeof(string), typeof(MUIChip), null);

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MUIChip), default(ICommand));
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty SelectedBackgroundColorProperty =
    BindableProperty.Create($"SelectedBackgroundColor", typeof(Color), typeof(MUIChip), default(Color), propertyChanged: (view, oldValue, newValue) =>
    {
        if (newValue is not Color || newValue == null)
            return;

        var chip = view as MUIChip;
        if (chip is not null && chip.IsSelected)
            chip.MainLayout.BackgroundColor = newValue as Color;
    });
    public Color SelectedBackgroundColor
    {
        get => (Color)GetValue(SelectedBackgroundColorProperty);
        set => SetValue(SelectedBackgroundColorProperty, value);
    }
    public static readonly BindableProperty ChipBackgroundColorProperty =
    BindableProperty.Create($"ChipBackgroundColor", typeof(Color), typeof(MUIChip), default(Color), propertyChanged: (view, oldValue, newValue) =>
    {
        if (!(newValue is Color) || newValue == null)
            return;

        var chip = view as MUIChip;
        if (chip is not null && !chip.IsSelected)
            chip.MainLayout.BackgroundColor = newValue as Color;
    });
    public Color ChipBackgroundColor
    {
        get => (Color)GetValue(ChipBackgroundColorProperty);
        set => SetValue(ChipBackgroundColorProperty, value);
    }
    public static readonly BindableProperty IsSelectedProperty =
    BindableProperty.Create($"IsSelected", typeof(bool), typeof(MUIChip), false, propertyChanged: (view, oldValue, newValue) =>
    {
        if (!(newValue is bool) || newValue == null)
            return;

        var chip = view as MUIChip;
        if (chip is not null)
        {
            if ((bool)newValue)
            {
                chip.MainLayout.BackgroundColor = chip.SelectedBackgroundColor;
            }
            else
            {
                chip.MainLayout.BackgroundColor = chip.ChipBackgroundColor;
            }
        }
    });
    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public MUIChip()
    {
        InitializeComponent();

        TapGestureRecognizer chipTapped = new TapGestureRecognizer();
        chipTapped.Tapped += (s, e) =>
        {

            IsSelected = !IsSelected;
            MUIChipCommandParameter commandParameter = new MUIChipCommandParameter
            {
                ChipName = this.CommandParameter,
                IsSelected = this.IsSelected,
            };
            this.Command?.Execute(commandParameter);
        };
        this.MainLayout.GestureRecognizers.Add(chipTapped);
    }
}