using System;
using System.Collections.Generic;

namespace Obuv.Model;

public partial class ПунктыВыдачи
{
    public int Код { get; set; }

    public string Адрес { get; set; } = null!;

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();
}
