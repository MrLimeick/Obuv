using System;
using System.Collections.Generic;

namespace Obuv.Model;

public partial class Заказы
{
    public int Номер { get; set; }

    public DateOnly Дата_заказа { get; set; }

    public DateOnly? Дата_доставки { get; set; }

    public int КодПунктаВыдачи { get; set; }

    public int КодПользователя { get; set; }

    public string? КодДляПолучения { get; set; }

    public string Статус { get; set; } = null!;

    public virtual Пользователи КодПользователяNavigation { get; set; } = null!;

    public virtual ПунктыВыдачи КодПунктаВыдачиNavigation { get; set; } = null!;

    public virtual ICollection<СодержимоеЗаказа> СодержимоеЗаказаs { get; set; } = new List<СодержимоеЗаказа>();
}
