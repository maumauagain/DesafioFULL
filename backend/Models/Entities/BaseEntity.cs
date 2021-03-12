using System;

namespace backend.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Removed { get; set; }
        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdateAt { get; set; }

    }
}
