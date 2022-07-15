using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectMahasiswa
{
    internal class Program
    {
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

        private static void Main(string[] args)
        {
            Console.Title = "Responsi UAS Matakuliah Pemrograman";
            while (true)
            {
                Program.TampilMenu();
                Console.Write("\nNomor Menu [1..3]: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Program.TambahMahasiswa();
                        break;
                    case 2:
                        Program.TampilMahasiswa();
                        break;
                    case 3: //keluar dari program
                        return;
                    default:
                        break;
                }
            }
        }

        private static void TampilMenu()
        {
            Console.Clear();
            Console.WriteLine("Pilih Menu Aplikasi\n");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Tampilkan Mahasiswa");
            Console.WriteLine("3. Keluar");
        }

        private static void TambahMahasiswa()
        {
            Console.Clear();
            Console.WriteLine("Tambah Data Mahasiswa\n");
            Mahasiswa mahasiswa = new Mahasiswa();
            Console.Write("NIM: ");
            mahasiswa.Nim = Console.ReadLine();
            Console.Write("Nama: ");
            mahasiswa.Nama = Console.ReadLine();
            Console.Write("Jenis Kelamin [L/P]: ");
            mahasiswa.JenisKelamin = Console.ReadLine();
            Console.Write("IPK: ");
            mahasiswa.IPK = Convert.ToSingle(Console.ReadLine());
            Program.daftarMahasiswa.Add(mahasiswa);
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
            Console.ReadKey();
        }

        private static void HapusMahasiswa()
        {
            Console.Clear();
            Console.WriteLine("Hapus Data Mahasiswa\n");
            Console.Write("NIM: ");
            string nim = Console.ReadLine();
            Mahasiswa mahasiswa = Program.daftarMahasiswa.SingleOrDefault<Mahasiswa>((Func<Mahasiswa, bool>)(f => f.Nim == nim));
            if (mahasiswa == null)
            {
                Console.WriteLine("\nNIM tidak ditemukan");
            }
            else
            {
                Program.daftarMahasiswa.Remove(mahasiswa);
                Console.WriteLine("\nData mahasiswa berhasil di hapus");
            }
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
            Console.ReadKey();
        }

        private static void TampilMahasiswa()
        {
            Console.Clear();
            Console.WriteLine("Data Mahasiswa\n");
            int num = 1;
            foreach (Mahasiswa mahasiswa in Program.daftarMahasiswa)
            {
                string str = mahasiswa.JenisKelamin == "L" ? "Laki-laki" : "Perempuan";
                Console.WriteLine("{0}. {1}, {2}, {3}, {4}", (object)num, (object)mahasiswa.Nim, (object)mahasiswa.Nama, (object)str, (object)mahasiswa.IPK);
                ++num;
            }
            Console.WriteLine("\nTekan enter untuk kembali ke menu");
            Console.ReadKey();
        }
    }
}