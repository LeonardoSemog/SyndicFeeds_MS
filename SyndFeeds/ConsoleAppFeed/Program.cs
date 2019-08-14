using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SyndFeeds;

namespace ConsoleAppFeed
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlPath = "http://www.minutoseguros.com.br/blog/feed/";
  
             var lista = Feed1.GetFeed(urlPath);


            var cat = new Dictionary<string,int>();
            string categ ="";

            for (int i = 0; i < lista.Count; i++) {

                List<string> cats = lista[i].category.ToList();

                foreach (var catg in cats)
                {
                    categ = catg.ToString();
                    if(cat.ContainsKey(categ))
                        cat[categ] = cat[categ] + 1;
                    else
                        cat[categ] = 1;
                }
            }

            var topTen = cat.OrderByDescending(categoria => categoria.Value).Take(10).ToList();
            Console.WriteLine("As 10 categorias mais usadas foram: ");
            for (int i = 0; i < topTen.Count; i++)
            {
                Console.WriteLine(topTen[i].Value.ToString() + "-" + topTen[i].Key);
            }

            //var x = new Dictionary<string, int>();

            //x["categoria"] = x["categoria"] + 1;

            //var topTen = x.OrderByDescending(categoria => categoria.Value).Take(10).ToList();
            Console.WriteLine("");
            Console.WriteLine("Total de Feeds lidos: " + lista.Count.ToString());
            Console.Write("");
            Console.ReadKey();
        }
    }
}
