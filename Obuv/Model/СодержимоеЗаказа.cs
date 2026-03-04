using System;
using System.Collections.Generic;

namespace Obuv.Model;

public partial class СодержимоеЗаказа
{
    public int Код { get; set; }

    public string Артикул_заказа { get; set; } = null!;

    public int Количество { get; set; }

    public int НомерЗаказа { get; set; }

    public virtual Товары Артикул_заказаNavigation { get; set; } = null!;

    public virtual Заказы НомерЗаказаNavigation { get; set; } = null!;
}
