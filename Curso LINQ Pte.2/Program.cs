using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_LINQ

{
    internal class Program
    {
        static void Main(string[] args)
        {

            LinqQueries queries = new LinqQueries();

            //Inicio de videos 17 - 26

            // System.Console.WriteLine($"Cantidad de libros que tienen entre de 200 y 500 pag {queries.CantidadDeLibrosEntre200y500Pag()}"); ;

            //Fecha de publicacion de todos los libros 
            //System.Console.WriteLine($"Fecha de publicacion menor: { queries.FechaDePublicacionMenor()}");

            //Numero de paginas del libro con mayor numero de paginas 
            // System.Console.WriteLine($"El libro con mayor numero de paginas tiene: {queries.NumPagLibroMayor()} paginas");    

            //LibroCon menor numero de paginas
            // var libroMenorPag = queries.LibroConMenorNumPag();
            //System.Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}" );

            //Libro con fecha de publicacion mas reciente
            // var libroFechaPubReciente = queries.LibroConFechaPublicacionMasReciente();
            //  System.Console.WriteLine($"{libroFechaPubReciente.Title} - {libroFechaPubReciente.PublishedDate}" );

            //Suma de paginas de libros entre 0 y 500 
            // System.Console.WriteLine($"Suma total de paginas {queries.SumaDeTodasPagLibrosEntre0y500()}");

            //Libros publicados despues del 2015
            // System.Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());  

            //Promedio de cacrateres de los titulos de los libros 
            //System.Console.WriteLine($"Promedio de carateres de los titulos: {queries.PromedioCarateresTitulo()}");

            //Lirbos publicados a partir del 2000 agrupados por año

            // ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAño());

            //Diccionario de libros agrupados por primera letra del titulo
            // var DiccionarioLookUp = queries.DiccionarioDeLibrosPorLetras();
            // ImprimirDiccionario(DiccionarioLookUp, 'A');

            //Libros filtrados con la clausula join
            ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Pag());


            void ImprimirValores(IEnumerable<Book> listadelibros)
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.paginas", "Fecha publicacion");
                foreach (var item in listadelibros)
                {
                    Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
                }

            }

            void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
            {
                foreach (var grupo in ListadeLibros)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Grupo: {grupo.Key}");
                    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
                    foreach (var item in grupo)
                    {
                        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
                    }
                }
            }

            void ImprimirDiccionario (ILookup<char, Book> ListaDeLibros, char letra)
            {
                Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
                foreach (var item in ListaDeLibros[letra])
                {
                    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
                }

            }

        }

    }
}