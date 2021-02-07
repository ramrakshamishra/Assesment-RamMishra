using Assessment_RaceTrack.Data;

namespace Assessment_RaceTrack.Core.Repository.Common
{
    public interface IUnitOfWork
    {
        RaceTrackContext DBContext { get; }

        void Commit();
    }
}
