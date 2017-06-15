using System;
using ConsoleApp1.LinkedList;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public void SimpleElement()
        {

        }

        static void Main(string[] args)
        {
            string choice = "";
            Linked link = new Linked();
            while ((choice = Console.ReadLine()) != "quit")
            {
                string[] argmnts = choice.Split(' ');
                if (argmnts[0] == "add")
                {
                    for (int i = 1; i < argmnts.Length; i++)
                        if (!String.IsNullOrEmpty(argmnts[i]))
                            link.Add(int.Parse(argmnts[i]));
                }
                else if (argmnts[0] == "display")
                {
                    link.Display();
                }
                else if (argmnts[0] == "delete")
                {
                    for (int i = 1; i < argmnts.Length; i++)
                        if (!String.IsNullOrEmpty(argmnts[i]))
                            link.Delete(int.Parse(argmnts[i]));
                }
                else if (argmnts[0] == "empty")
                    link.Empty();
                else if (argmnts[0] == "count")
                    Console.WriteLine("La liste contient " + link.count + " éléments.");
                else if(argmnts[0] == "save")
                {
                    if(argmnts.Count() == 2 && !String.IsNullOrEmpty(argmnts[1]))
                        link.Save(argmnts[1]);
                }
                else if(argmnts[0] == "load")
                {
                    if(argmnts.Count() == 2 && !String.IsNullOrEmpty(argmnts[1]))
                        link.Load(argmnts[1]);
                }
            }
        }
    }
}
