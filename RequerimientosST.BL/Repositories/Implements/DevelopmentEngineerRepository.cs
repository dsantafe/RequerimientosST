using RequerimientosST.BL.Models;

namespace RequerimientosST.BL.Repositories.Implements
{
    public class DevelopmentEngineerRepository : GenericRepository<DevelopmentEngineer>, IDevelopmentEngineerRepository
    {
        public DevelopmentEngineerRepository(DBContext context) : base(context)
        {

        }
    }
}
