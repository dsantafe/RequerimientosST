using RequerimientosST.BL.Models;

namespace RequerimientosST.BL.Repositories.Implements
{
    public class RequirementRepository : GenericRepository<Requirement>, IRequirementRepository
    {
        public RequirementRepository(DBContext context) : base(context)
        {

        }
    }
}
