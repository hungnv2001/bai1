using bai1.Models;

namespace bai1.Repo
{
    public interface ICompanyRepo
    {
        List<Company> GetAll();
        Company GetById(int id);
        bool Create(Company company);
        bool Update(Company company);
        bool Delete(int  id);

    }
}
