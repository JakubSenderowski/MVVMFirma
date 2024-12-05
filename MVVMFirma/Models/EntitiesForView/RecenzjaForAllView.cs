using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RecenzjaForAllView
    {
        public int RecenzjaID { get; set; }

        public string Autor {  get; set; }

        public int Ocena { get; set; }

        public string Komentarz { get; set; }   

        public string FilmTytul {  get; set; }

        public string FilmOpis { get; set; }

    }
}
