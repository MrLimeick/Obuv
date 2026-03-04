using System;
using System.Collections.Generic;

namespace Obuv.Model;

public partial class Пользователи
{
    public int Код { get; set; }

    public string Роль_сотрудника { get; set; } = null!;

    public string ФИО { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();
}
