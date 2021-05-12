using RequerimientosST.BL.Models;

namespace RequerimientosST.BL.Repositories.Implements
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(DBContext context) : base(context)
        {

        }
    }
}
