//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Printer.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ремонт
    {
        public int id_ремонт { get; set; }
        public System.DateTime Дата_ремонта { get; set; }
        public string Описание_ремонта { get; set; }
        public Nullable<int> id_неисправность { get; set; }
        public string Цена_ремонта { get; set; }
        public Nullable<int> id_принтера { get; set; }
        public string Модели_принтера { get; set; }
    
        public virtual Неисправность Неисправность { get; set; }
        public virtual Принтеры Принтеры { get; set; }
    }
}
