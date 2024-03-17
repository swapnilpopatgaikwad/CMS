using CMS.Model;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CMS.Tables
{
    public class Expence : BaseTable
    {

        [MaxLength(20)]
        public string ExpenceName { get; set; }
        public string Amount { get; set; }

        [ForeignKey(typeof(Login))]
        public int CreatedBy { get; set; }

        [ForeignKey(typeof(Login))]
        public int ModifiedBy { get; set; }
        [Ignore]
        public Login User { get; set; }

        public ExpenceModel ToExpenceModel()
        {
            return new ExpenceModel()
            {
                Id = Id,
                ExpenceName = ExpenceName,
                Amount = Amount,
                CreatedDate = CreatedDate,
                LastModifyDate = LastModifyDate,
                CreatedBy = CreatedBy,
                ModifiedBy = ModifiedBy
            };
        }
    }
}
