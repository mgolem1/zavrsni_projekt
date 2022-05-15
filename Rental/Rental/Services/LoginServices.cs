using Rental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Services
{
    public class LoginServices
    {
        public LoginRepository logRepository;
        public LoginServices(LoginRepository logRepo)
        {
            logRepository = logRepo;
        }
        public int SignUpKlijent(Models.Klijent k)
        {
            return logRepository.SignUpKlijent(k);
        }
        public Models.Klijent VerifyKlijent(string ime,string prezime,string email,string lozinka)
        {
            //kreiranje korisnika
            //potvrda
            if(ime==null || prezime==null || lozinka==null || email == null)
            {
                return null;
            }
            if (ime.Length <= 3)
            {
                return null;
            }
            if (logRepository.UserExists(email)==false)
                return new Models.Klijent(null, ime, prezime, email, lozinka);
            return null;
        }

        public Models.Klijent SignIn(string email,string lozinka)
        {
            return logRepository.SignInKorisnik(email, lozinka);
        }
    }
}
