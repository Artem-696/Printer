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
    
    public partial class Поставщики
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Поставщики()
        {
            this.Принтеры = new HashSet<Принтеры>();
        }
    
        public int id_поставщика { get; set; }
        public string Название_организации { get; set; }
        public string ФИО_поставщика { get; set; }
        public string Телефон { get; set; }
        public string Адрес { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Принтеры> Принтеры { get; set; }
    }
}
