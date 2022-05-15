using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.DbModels;
using Rental.Mappers;

namespace Rental.Repositories
{
    public class LoginRepository
    {
        private readonly zavrsniContext _dbContext;
        public LoginRepository(zavrsniContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int SignUpKlijent(Models.Klijent mkorisnik)
        {
            var dbKorisnik = KlijentMapper.ToDatabase(mkorisnik);
            _dbContext.Klijent.Add(dbKorisnik);
            _dbContext.SaveChanges();
            var k = _dbContext.Klijent.Where(x => x.Email == mkorisnik.EMail).FirstOrDefault();
            return k.Idklijent;
        }
        public bool UserExists(string email)
        {
            var dbKlij = _dbContext.Klijent.Where(x => x.Email.Equals(email)).FirstOrDefault();
            return dbKlij != null;
        }
        public Models.Klijent SignInKorisnik(string email,string lozinka)
        {
            var dbKlijent = _dbContext.Klijent.Where(x => (x.Email.Equals(email) && x.Lozinka.Equals(lozinka))).FirstOrDefault();
            if (dbKlijent == null)
                return null;
            return KlijentMapper.FromDatabase(dbKlijent);
        }
    }
}
