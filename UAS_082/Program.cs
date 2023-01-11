using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UAS_082
{
    internal class Program
    {
        class Node
        {
            public int nb;
            public string jb;
            public string np;
            public int tahun;
            public Node next;
        }
        class List
        {
            public Node START;
            public List()
            {
                START = null;
            }
            public void addNode()
            {
                string judul;
                int th;
                string namap;
                int nomorb;

                Console.Write("\n Masukkan Judul Buku : ");
                judul = Convert.ToString(Console.ReadLine());
                Console.Write("\n Masukkan Tahun Terbit Buku : ");
                th = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n Masukkan  Nama Pengarang : ");
                namap = Convert.ToString(Console.ReadLine());
                Console.Write("\n Masukkan Nomor Buku : ");
                nomorb = Convert.ToInt32(Console.ReadLine());
                Node nodeBaru = new Node();
                nodeBaru.jb = judul;
                nodeBaru.tahun = th;
                nodeBaru.np = namap;
                nodeBaru.nb = nomorb;

                if (START == null || th <= START.tahun)
                {
                    if ((START != null) && (th == START.tahun))
                    {
                        Console.WriteLine("\n Tahun Terbit salah\n");
                        return;
                    }
                    nodeBaru.next = START;
                    START = nodeBaru;
                    return;
                }
                Node previous, current;
                previous = START;
                current = START;

                while ((current == current.next) && (th >= current.tahun))
                {
                    if (judul == current.jb)
                    {
                        Console.WriteLine("\n Tahun Terbit salah");
                        return;
                    }
                    previous = current;
                    current = current.next;
                }
                nodeBaru.next = current;
                previous.next = nodeBaru;
            }
            public bool Search(int th, ref Node previous, ref Node current)
            {
                previous = START;
                current = START;

                while ((current != null) && (th != current.tahun))
                {
                    previous = current;
                    current = current.next;
                }
                if (current == null)

                    return (false);
                else
                    return (true);

            }

            public void traverse()
            {
                if (ListEmpty())
                    Console.WriteLine("\n Data Buku Kosong. \n");
                else
                {
                    Console.WriteLine("\n Data Buku adalah : \n");
                    Node currentNode;
                    for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                        Console.Write(currentNode.jb + "" + currentNode.tahun + "" + currentNode.np + "" + currentNode.nb + "\n");
                    Console.WriteLine();
                }
            }
            public bool ListEmpty()
            {
                if (START == null)
                    return true;
                else
                    return false;
            }

        }
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("1. Mencari Buku");
                    Console.WriteLine("2. Exit");
                    Console.WriteLine("--------------------");
                    Console.Write("\nMasukkan Pilihan Anda (1-2): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nData kosong !");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Tahun Terbit Buku yang akan dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\ndata tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\ndata ketemu");
                                    Console.WriteLine("\nTahun Terbit:" + current.tahun);
                                    Console.WriteLine("\nJudul Buku:" + current.jb);


                                }

                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck data yang anda masukkan.");
                }
            }
        }
        
    }
    
}

//2.saya menggunakan 
//3.push,pop
//4.
//5.
