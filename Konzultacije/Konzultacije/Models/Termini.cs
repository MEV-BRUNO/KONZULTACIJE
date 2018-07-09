using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Termini")]
    public class Termini : IConvertible
    {

        [Display(Name ="ID Termina")]
        [Key]
        [Column("id_termina")]
        public int TerminiID { get; set; }

        
        [Display(Name = "ID Profesora")]
        [Column("id_profesor")]
        [ForeignKey("Profesor")]
        public int ProfesorID { get; set; }
        public virtual Profesor Profesor { get; set; }
        

        [Display(Name = "ID Kolegija")]
        [Column("id_kolegij")]
        [ForeignKey("Kolegij")]
        public int KolegijID { get; set; }
        public virtual Kolegij Kolegij { get; set; }
        


        [Column("dan_tjedan")]
        [Display(Name = "Datum termina")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Niste popunili {0}.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dan_Tjedan { get; set; }

        [Column("vrijeme_od")]
        [Display(Name = "Vrijeme od")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Polje {0} je nepopunjeno.")]
        public DateTime? Vrijeme_Od { get; set; }

        [Column("vrijeme_do")]
        [Display(Name = "Vrijeme do")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Polje {0} je nepopunjeno")]
        public DateTime? Vrijeme_Do { get; set; }

        public virtual ICollection<Upit> Upits { get; set; }




        public TypeCode GetTypeCode()
        {
            return TerminiID.GetTypeCode();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToBoolean(provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToByte(provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToChar(provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToDateTime(provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToDecimal(provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToDouble(provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToInt16(provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToInt32(provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToInt64(provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToSByte(provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToSingle(provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return TerminiID.ToString(provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToType(conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToUInt16(provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToUInt32(provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)TerminiID).ToUInt64(provider);
        }
    }
}