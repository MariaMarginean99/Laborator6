using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddPersoane(Persoana p);
        Persoana[] GetPersoane(out int nrPersoane);
        ArrayList Get_Persoane();
        Persoana GetPersoana(string nume, string prenume);
        bool UpdatePersoana(Persoana p);
    }
}
