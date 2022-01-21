using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace Norbit.Gcrm.Medvedev.WebApi.Models
{
    /// <summary>
    /// Сущность Creatio.
    /// </summary>
    [DataContract]
    public class CreatioObject
    {

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [DataMember]
        public DateTime CreatedOn {get; set;}

        /// <summary>
        /// Дата последнего изменения.
        /// </summary>
        [DataMember]
        public DateTime ModifiredOn { get; set; }

        /// <summary>
        /// Название объекта.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        public CreatioObject(Guid id, string name)
        {
            Id = id;
            Name = name;
            CreatedOn = DateTime.Now;
            ModifiredOn = DateTime.Now;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Id: {Id}\n");
            sb.Append($"Дата создания: {CreatedOn}\n");
            sb.Append($"дата изменения: {ModifiredOn}\n");
            sb.Append($"Имя: {Name}\n");
            return sb.ToString();
        }
    }
}