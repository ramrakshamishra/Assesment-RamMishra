using Assessment_RaceTrack.Data;

namespace Assessment_RaceTrack.Core.Repository.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(RaceTrackContext _dbContext)
        {
            this.DBContext = _dbContext;
        }

        public RaceTrackContext DBContext { get; }

        public void Commit()
        {
            DBContext.SaveChanges();
        }
    }

}
