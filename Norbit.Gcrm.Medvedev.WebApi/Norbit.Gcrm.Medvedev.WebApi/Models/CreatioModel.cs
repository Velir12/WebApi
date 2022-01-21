using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norbit.Gcrm.Medvedev.WebApi.Models
{
    /// <summary>
    /// Модель для работы с объектом Creatio.
    /// </summary>
    public class CreatioModel
    {
        private List<CreatioObject> creatioList = new List<CreatioObject>();

        public CreatioModel()
        {
            AddRecord(new CreatioObject(Guid.NewGuid(), "Первый объект"));
            AddRecord(new CreatioObject(Guid.NewGuid(), "Второй объект"));
        }

        /// <summary>
        /// Получить все записи Creatio.
        /// </summary>
        /// <returns> Перечисление записей Creatio.</returns>
        public IEnumerable<CreatioObject> GetAllRecords()
        {
            return creatioList;
        }

        /// <summary>
        /// Получить запись Creatio.
        /// </summary>
        /// <param name="index"> Инедкс записи.</param>
        /// <returns> Запись Creatio.</returns>
        public CreatioObject GetRecord(Guid id)
        {
            return creatioList.Find(creatio => creatio.Id == id);
        }

        /// <summary>
        /// Добавить одну запись в Creatio.
        /// </summary>
        /// <param name="creatioObject"> Запись Creatio.</param>
        public void AddRecord(CreatioObject creatioObject)
        {
            if (creatioObject == null)
            {
                throw new ArgumentNullException("Некорректное тело запроса");
            }

            creatioList.Add(creatioObject);
        }

        /// <summary>
        /// Добавить несколько записей Creatio.
        /// </summary>
        /// <param name="creatioObjects"> Записи Creatio.</param>
        public void AddRecords(List<CreatioObject> creatioObjects)
        {
            if (creatioObjects == null)
            {
                throw new ArgumentNullException("Некорректное тело запроса");
            }
            foreach (var creatioObject in creatioObjects)
            {
                AddRecord(creatioObject);
            }
        }

        /// <summary>
        /// Обновить запись в Creatio.
        /// </summary>
        /// <param name="id"> Идентификатор записи.</param>
        /// <param name="creatioObject"> Новая запись.</param>
        public void UpdateRecord(Guid id, CreatioObject creatioObject)
        {
            if (creatioObject == null)
            {
                throw new ArgumentNullException("Некорректное тело запроса");
            }

            var index = creatioList.FindIndex(creatio => creatio.Id == id);
            if (index == -1)
            {
                throw new ArgumentOutOfRangeException("Записи с таким Id не существует");
            }

            creatioList.RemoveAt(index);
            creatioList.Add(creatioObject);
        }

        /// <summary>
        /// Частичное обновление записи Creatio.
        /// </summary>
        /// <param name="id"> Идентификатор записи.</param>
        /// <param name="creatioObject"> Запись Creatio.</param>
        public void UpdateRows(Guid id, CreatioObject creatioObject)
        {

            if (creatioObject == null)
            {
                throw new ArgumentNullException("Некорректное тело запроса");
            }
            var oldCreatioObject = GetRecord(id);
            if (oldCreatioObject == null)
            {
                throw new NullReferenceException("Запись не найдена");
            }

            oldCreatioObject.Id = creatioObject.Id != Guid.Empty
                    ? creatioObject.Id
                    : oldCreatioObject.Id;

            oldCreatioObject.Name = !String.IsNullOrEmpty(creatioObject.Name)
                    ? creatioObject.Name
                    : oldCreatioObject.Name;
        }

        /// <summary>
        /// Удалить запись Creatio.
        /// </summary>
        /// <param name="index"> Индекс записи Creatio.</param>
        public void DeleteRecord(int index)
        {
            creatioList.RemoveAt(index);
        }
    }
}