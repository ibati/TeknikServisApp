//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServisApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrunKabul
    {
        public int ISLEMID { get; set; }
        public Nullable<int> URUN { get; set; }
        public Nullable<int> CARİ { get; set; }
        public Nullable<short> PERSONEL { get; set; }
        public Nullable<System.DateTime> GELISTARIHI { get; set; }
        public Nullable<System.DateTime> CIKISTARIHI { get; set; }
    
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel1 { get; set; }
        public virtual Urun Urun1 { get; set; }
    }
}