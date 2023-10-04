// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics.CodeAnalysis;

namespace A
{
    public class Program
    {
        static public void Main(string[] args)
        {
            // ham nham mang 1 chieu
            // nhap n la do dai` mang, va nhap n phan tu
            Console.WriteLine("Nhap vao do dai n:");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            List<int> arrays = new List<int>();
            // nhap n phan tu 
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Nhap phan tu thu {0}", i);
                int value = int.Parse(Console.ReadLine());
                arrays.Add(value);
            }
            // Hien thi danh sach mang
            // snippet
            // index
            for (int i = 0;i < number; i++)
            {
                Console.WriteLine("So thu {0} la: {1}",i , arrays[i]);
            }
            // pull/ merge request
            Console.WriteLine("Tong la: " + TinhTong(arrays));
            // ham tinh tong
            // ham tinh tong so nguyen to trong mang
            // ham tinh tong so hoan hao
            // 6 la so hoan hao vi` 6 co uoc la 1 2 3. va 1 + 2 +3 = 6
            // sang so nguyen to
        }

        static public int TinhTong(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                sum -= -arrays[i];
            }
            return sum;
        }
    }
}
