using DIO.Series.Enum;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> seriesList = new List<Series>();

        public void Update(int id, Series serie)
        {
            seriesList[id] = serie;
            ChangeDeletion(id, DeletionStatusEnum.Include);
        }

        public void ChangeDeletion(int id, DeletionStatusEnum state)
        {
            bool deletionStatus;
            switch (state)
            {
                case DeletionStatusEnum.Delete:
                    deletionStatus = true;
                    break;
                default:
                    deletionStatus = false;
                    break;
            }
            seriesList[id].changeDeletion(deletionStatus);
        }

        public void Create(Series serie)
        {
            seriesList.Add(serie);   
        }

        public List<Series> Listed()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Series GetById(int id)
        {
            return seriesList[id];
        }
    }
}