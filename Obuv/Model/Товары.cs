using System;
using System.Collections.Generic;

namespace Obuv.Model;

public partial class Товары
{
    public string Артикул { get; set; } = null!;

    public string Наименование { get; set; } = null!;

    public string ЕдиницаИзмерения { get; set; } = null!;

    public decimal Цена { get; set; }

    public string Поставщик { get; set; } = null!;

    public string Производитель { get; set; } = null!;

    public string Категория { get; set; } = null!;

    public int Скидка { get; set; }

    public int КоличествоНаСкладе { get; set; }

    public string? Описание { get; set; }

    public string? Фото { get; set; }

    public virtual ICollection<СодержимоеЗаказа> СодержимоеЗаказаs { get; set; } = new List<СодержимоеЗаказа>();
}
