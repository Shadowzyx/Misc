using System;
using ConsoleApp1.FileManager;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1.LinkedList
{
    class Linked
    {
        Element root;
        Element end;
        public int count { get; set; }

        public Linked()
        {
            count = 0;
            this.root = null;
            end = null;
        }

        public Linked(Element root)
        {
            count = 0;
            this.root = this.end = root;
        }

        public Linked(int item) : this(new Element(item))
        {
            count = 0;
            end = root;
        }

        public void Add(Element elt)
        {
            if (end != null)
            {
                end.next = elt;
                end = end.next;
            }
            else if (root != null)
            {
                root.next = elt;
                end = elt;
            }
            else if (root == null)
            {
                root = elt;
            }
            count++;
            Console.WriteLine("L'élément " + elt.item + " a été ajouté avec succès.");
        }

        public void Add(int elt)
        {
            this.Add(new Element(elt));
        }

        public void Display()
        {
            if (root == null)
                Console.WriteLine("L'arbre est vide : Impossible de l'afficher");
            else
            {
                Element elt = root;
                while (elt != null)
                {
                    Console.WriteLine(elt.ToString());
                    elt = elt.next;
                }
            }
        }

        public void Delete(Element elt)
        {
            if (root != null)
            {
                if (root.Equals(elt))
                {
                    if (root.Equals(end))
                        end = null;
                    root = root.next;
                }
                else if (!this.Find(elt))
                {
                    Console.WriteLine("L'élément n'existe pas, il n'a donc pas pu être supprimé.");
                    return;
                }
                else
                {
                    Element tmp = root;
                    while (!tmp.next.Equals(elt))
                        tmp = tmp.next;
                    if (tmp.next.Equals(end))
                        end = tmp;
                    tmp.next = (tmp.next).next;
                }
                count--;
                Console.WriteLine("L'élément " + elt.item + " a été supprimé avec succès.");
            }
        }

        public void Delete(int elt)
        {
            this.Delete(new Element(elt));
        }

        public bool Find(Element elt)
        {
            if (root.Equals(elt))
                return true;
            else
            {
                Element tmp = root;
                while (tmp != null && !tmp.Equals(elt))
                    tmp = tmp.next;
                return tmp != null;
            }
        }

        public void Empty()
        {
            root = null;
            end = null;
            count = 0;
            Console.WriteLine("La liste as bien été vidée.");
        }

        public void Save(string filename)
        {
            FileWriter writer = new FileWriter(filename);
            Element tmp = root;
            while(tmp != null)
            {
                if (tmp.Equals(root))
                    writer.Serialize(tmp);
                else
                    writer.Serialize(tmp, true);
                tmp = tmp.next;
            }
            Console.WriteLine("La liste a bien été sauvegardée.");
        }

        public void Load(string filename)
        {
            if(!File.Exists(filename))
            {
                Console.WriteLine("Le fichier n'existe pas, impossible de charger la liste.");
                return;
            }
            root = null;
            end = null;
            FileWriter writer = new FileWriter(filename);
            List<Element> list = writer.Deserialize<Element>().ToList();
            foreach(Element elt in list)
            {
                Add(elt);
            }
        }
    }
}
