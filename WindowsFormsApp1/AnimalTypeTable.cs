//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnimalTypeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnimalTypeTable()
        {
            this.AnimalsTables = new HashSet<AnimalsTable>();
        }
    
        public string Animal_Type { get; set; }
        public string Food_Type { get; set; }
        public double Food_Rate_Per_Day { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalsTable> AnimalsTables { get; set; }
        public virtual FoodPriceTable FoodPriceTable { get; set; }
    }
}
