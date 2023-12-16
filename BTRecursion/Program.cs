using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BTRecursion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Input: ");
            //string n = (Console.ReadLine());
            //char maxChar = n[n.Length - 1];
            int n = int.Parse(Console.ReadLine());
            //int m = int.Parse(Console.ReadLine());
            int number = 0;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("{0} --> {1}", i, ChuyenDoiSangNhiPhan(i));

                //Console.WriteLine(ChuyenDoiSangNhiPhan(n));
            }
        } 
        // Bai 1
        public static int DaoNguocSo(int n, int number)
        {
            if (n / 10 == 0) return number += n % 10;
            return DaoNguocSo(n / 10, (number + n % 10) * 10);
        }

        // Bai 2
        public static int DemChuSo(int n)
        {
            if (n / 10 == 0) return 1;
            return 1 + DemChuSo(n / 10);
        }

        // Bai 3 
        public static char TimChuSoGiaTriLonNhat(string n, char maxChar)
        {
            if (n == string.Empty) return maxChar;
            char lastChar = n[n.Length - 1];
            bool isNumber = '0' <= lastChar && lastChar <= '9';
            if (maxChar < n[n.Length - 1] && isNumber) maxChar = n[n.Length - 1];
            return TimChuSoGiaTriLonNhat(n.Remove(n.Length - 1), maxChar);
        }
        public static char TimChuSoGiaTriNhoNhat(string n, char minChar)
        {
            if (n == string.Empty) return minChar;
            char lastChar = n[n.Length - 1];
            bool isNumber = '0' <= lastChar && lastChar <= '9';
            if (minChar > lastChar && isNumber) minChar = lastChar;
            return TimChuSoGiaTriNhoNhat(n.Remove(n.Length - 1), minChar);
        }

        // Bai 4
        public static int ChuyenDoiSangNhiPhan(int n)
        {
            if (n / 2 == 0) return n;
            return (n % 2 == 0) ? ChuyenDoiSangNhiPhan(n / 2) * 10 : ChuyenDoiSangNhiPhan(n / 2) * 10 + 1;
        }
        public static string ChuyenDoiSangNhiPhanBangString(int n)
        {
            if (n / 2 == 0) return n.ToString();
            return ChuyenDoiSangNhiPhanBangString(n / 2) + (n % 2).ToString();
        }

        // Bai 5
        public static int TinhTheoCongThucBai5(int n)  //P(n)=1.3.5…(2n+1)
        {
            if (n == 0) return 1;
            return (2 * n + 1) * TinhTheoCongThucBai5(--n);
        }

        // Bai 6
        public static int TinhTheoCongThucBai6(int n)  //S(n)=1-2+3-4+…+ ((-1)^(n+1)).n với n>0
        {
            if (n == 1) return 1;
            return (n % 2 != 0) ? n + TinhTheoCongThucBai6(--n) : -n + TinhTheoCongThucBai6(--n);
        }

        // Bai 7
        public static int TinhTheoCongThucBai7(int n)  //S(n)=1+1.2+1.2.3+…+1.2.3…n với n>0
        {
            if (n == 1) return 1;
            return MultiplicationByCount(n) + TinhTheoCongThucBai7(--n);
        }
        private static int MultiplicationByCount(int n)
        {
            int multiplication = 1;
            for (int i = 1; i <= n; i++)
            {
                multiplication *= i;
            }
            return multiplication;
        }

        // Bai 8
        public static int TinhTheoCongThucBai8(int n)  //S(n)=1^2+2^2+3^2+….+n^2
        {
            if (n == 1) return 1;
            return n * n + TinhTheoCongThucBai8(--n);
        }

        // Bai 9
        public static int TinhTheoCongThucBai9(int n, int m)  //P(x, y)=x^y
        {
            if (m == 1) return n;
            return n * TinhTheoCongThucBai9(n, --m);
        }

        // Bai 10
        public static int ChuSoDauTien(int n)
        {
            if (n / 10 == 0) return n % 10;
            return ChuSoDauTien(n / 10);
        }

        // Bai 11
        public static int UCLN(int n, int m)
        {
            if (n == 0) return m;
            if (m == 0) return n;
            return (n > m) ? UCLN(n % m, m) : UCLN(n, m % n);
        }
    }
}