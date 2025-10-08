using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_LINQ

{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }
        }
         
        //Inicio de videos 17 - 26
        public long CantidadDeLibrosEntre200y500Pag()
        {
            return librosCollection.LongCount(p => p.PageCount > 200 && p.PageCount <= 500);
        }

        public DateTime FechaDePublicacionMenor()
        {
            return librosCollection.Min(p => p.PublishedDate);
        }

        public int NumPagLibroMayor()
        {
            return librosCollection.Max(p => p.PageCount);
        }

        public Book LibroConMenorNumPag()
        {
            return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        public Book LibroConFechaPublicacionMasReciente()
        {
            return librosCollection.MaxBy(p => p.PublishedDate);
        }

        public int SumaDeTodasPagLibrosEntre0y500()
        {
            return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
        }
        public string TitulosDeLibrosDespuesDel2015Concatenados()
        {
            return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
            {
                if (TitulosLibros != string.Empty)
                {
                    TitulosLibros += " - " + next.Title;

                }
                else
                {
                    TitulosLibros += next.Title;

                }
                return TitulosLibros;
            });
        }

        public double PromedioCarateresTitulo()
        {
            return librosCollection.Average(p => p.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAño()
        {
            return librosCollection.Where(p => p.PublishedDate.Year > 2000).GroupBy(p => p.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionarioDeLibrosPorLetras()
        {
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Pag()
        {
            var LibrosDespuesDel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);
            var LibrosConMasDe500Pag = librosCollection.Where(p => p.PageCount > 500);

            return LibrosDespuesDel2005;
           // return LibrosDespuesDel2005.Join(LibrosConMasDe500Pag, p => p.Title, x => x.Title, (p, x) => p);
        }
    }
}