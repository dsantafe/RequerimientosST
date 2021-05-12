using RequerimientosST.BL.Models;

namespace RequerimientosST.BL.Repositories.Implements
{
    public class PriorityRepository : GenericRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(DBContext context) : base(context)
        {

        }
    }
}
