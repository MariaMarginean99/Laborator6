using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Collections;

namespace NivelAccesDate
{
    public class AdministrarePersoane_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrarePersoane_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddPersoane(Persoana p)
        {
            throw new Exception("Optiunea AddPersoane nu este implementata");
        }

        public ArrayList Get_Persoane()
        {
            throw new Exception("Optiunea GetPersoane nu este implementata");
        }

        public Persoana[] GetPersoane(out int nrPersoane)
        {
            throw new Exception("Optiunea GetPersoane nu este implementata");
        }
        public Persoana GetPersoana (string nume, string prenume)
        {
            throw new Exception("Optiunea GetPersoana nu este implementata");
        }
        public bool UpdatePersoana(Persoana p )
        {
            throw new Exception("Optiunea UpdatePersoana nu este implementata");
        }
    }
}
