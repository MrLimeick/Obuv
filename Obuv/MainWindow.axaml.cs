using System;
using System.Diagnostics;
using Avalonia.Controls;
using Obuv.Model;

namespace Obuv;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());

        InitializeComponent();

        OpenAuth();
    }

    private void OnLogged(Пользователи? user)
    {
        Debug.WriteLine($"Произведён вход в {user?.Логин ?? "Гость"}.");

        Test.Content = new Catalog(user, OpenAuth);
    }

    private void OpenAuth()
    {
        Debug.WriteLine($"Открытие окна авторизации.");

        Test.Content = new AuthPage(OnLogged);
    }
}