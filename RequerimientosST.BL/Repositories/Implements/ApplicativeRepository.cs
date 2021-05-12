using RequerimientosST.BL.Models;

namespace RequerimientosST.BL.Repositories.Implements
{
    public class ApplicativeRepository : GenericRepository<Applicative>, IApplicativeRepository
    {
        public ApplicativeRepository(DBContext context) : base(context)
        {

        }
    }
}
