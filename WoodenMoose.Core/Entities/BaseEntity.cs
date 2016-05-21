using SQLite.Net.Attributes;

namespace WoodenMoose.Core.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
