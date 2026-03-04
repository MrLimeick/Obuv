using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Obuv.Model;

namespace Obuv;

public partial class Catalog : UserControl
{
    public Catalog(Пользователи? user, Action changeUserRequested)
    {
        User = user;
        ChangeUserRequested = changeUserRequested;
        DataContext = this;

        InitializeComponent();
    }

    public Пользователи? User { get; }
    public Action ChangeUserRequested { get; }
    public string RoleString => $"Привет, {User?.Роль_сотрудника ?? "Гость"}";
    public string FIO => User?.ФИО ?? "Гость";

    private void ChangeUserClicked(object? sender, RoutedEventArgs e)
    {
        ChangeUserRequested();
    }
}