//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopVodovoz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class division
    {
        public int iddivision { get; set; }
        public string namedivision { get; set; }
        public Nullable<int> iduser { get; set; }
    
        public virtual users users { get; set; }
    }
}
