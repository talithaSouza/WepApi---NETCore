using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntities
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set
            {
                _createAt = (value != null ? value : DateTime.Now);
            }
        }
        public DateTime? UpdateAt { get; set; }

    }
}
