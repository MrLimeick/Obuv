using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using Obuv.Context;
using Obuv.Model;
using Color = System.Drawing.Color;

namespace Obuv;

public partial class AuthPage : UserControl
{
    public event Action<Пользователи?> Logged;

    public AuthPage(Action<Пользователи?> logged)
    {
        Logged = logged;

        InitializeComponent();
    }

    private void LoginClicked(object? sender, RoutedEventArgs e)
    {
        var login = Login.Text;
        var password = Password.Text;

        if (string.IsNullOrWhiteSpace(login))
        {
            ShowError("Введите логин!");
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            ShowError("Введите пароль!");
            return;
        }

        var user = DataBase.Shared.Пользователиs.FirstOrDefault(user => user.Логин == login && user.Пароль == password);
        if (user is null)
        {
            ShowError("Неверный логин или пароль!");
            return;
        }

        OnLogged(user);
    }

    private void ShowError(string message)
    {
        ErrorControl.Content = new TextBlock { Text = message, Foreground = SolidColorBrush.Parse("#ff0000") };
    }

    protected virtual void OnLogged(Пользователи? user)
    {
        Logged.Invoke(user);
    }

    private void GuestClicked(object? sender, RoutedEventArgs e)
    {
        Logged.Invoke(null);
    }
}