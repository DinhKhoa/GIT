using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Strings
{
    public class Program
    {
        private const char space = ' ';
        static public void Main(string[] args)
        {
            Console.Write("Nhap xau: ");
            string str = Console.ReadLine();

            //Goi ham:
            ChuoiCon_C2(str);

            //string result = CatChuoi(str);
            //Console.WriteLine(":" + result + ":");

            //List<string> result = CatChuoi(str);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
        }


        static public string DaoNguoc(string str)
        {
            string result = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result = string.Concat(result, str[i]);
            }
            return result;
        }


        static public void DemChuSoKiTuDacBiet(string str)
        {
            int countOfCharacter = 0;
            int countOfNumber = 0;
            int countOfSpecialCharacter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    countOfNumber++;
                }
                else if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                {
                    countOfCharacter++;
                }
                else countOfSpecialCharacter++;
            }
            Console.WriteLine($" {countOfNumber} so\n {countOfCharacter} chu\n {countOfSpecialCharacter} ki tu dac biet\n");
        }


        static public void SoTu(string str)
        {
            int sum = 1;
            char space = ' ';
            string result = ChuanHoaChuoi(str);
            for (int i = 1; i < result.Length - 1; i++)
            {
                if (result[i] == space) sum += 1;
            }
            Console.WriteLine(sum);
        }


        static public string ChuanHoaChuoi(string str)
        {
            string result = string.Empty;
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    startIndex = i;
                    break;
                }
            }
            for (int i = str.Length - 1; i >= startIndex; i--)
            {
                if (str[i] != ' ')
                {
                    endIndex = i + 1;
                    break;
                }
            }
            for (int i = startIndex; i < endIndex; i++)
            {
                result += str[i];
            }
            string deleteSpace = XoaKhoangTrongLienTiep(result);
            return deleteSpace;
        }
        static private string XoaKhoangTrongLienTiep(string str)
        {
            string result = string.Empty;
            char space = ' ';
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != space)
                {
                    result += str[i];
                }
                if (str[i] == space && str[i + 1] != space)
                {
                    result += space;
                }
            }
            return result;
        }


        static public void ChuoiCon_C1(string str)
        {
            List<string> tapHopCon = new List<string>();
            Console.Write("Nhap chuoi con can kiem tra: ");
            string chuoiCon = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 1; j <= str.Length - i; j++)
                {
                    tapHopCon.Add(CatChuoi(str, i, j));
                }
            }
            bool KT = false;
            for (int i = 0; i < tapHopCon.Count; i++)
            {
                if (chuoiCon == tapHopCon[i])
                {
                    KT = true;
                    break;
                }
            }
            if (KT)
            {
                Console.WriteLine("Chuoi con");
            }
            else
            {
                Console.WriteLine("Khong phai chuoi con");
            }
        }
        static public void ChuoiCon_C2(string str)
        {
            List<string> tapHopCon = new List<string>();
            Console.Write("Nhap chuoi con can kiem tra: ");
            string chuoiCon = Console.ReadLine();
            for (int i = 1; i <= str.Length; i++)
            {
                for (int j = 0; j <= str.Length - i; j++)
                {
                    tapHopCon.Add(CatChuoi(str, j, i));
                }
            }
            bool KT = false;
            for (int i = 0; i < tapHopCon.Count; i++)
            {
                if (chuoiCon == tapHopCon[i])
                {
                    KT = true;
                    break;
                }
            }
            if (KT)
            {
                Console.WriteLine("Chuoi con");
            }
            else
            {
                Console.WriteLine("Khong phai chuoi con");
            }
        }
        static private string CatChuoi(string str, int index, int count)
        {
            string result = string.Empty;
            for (int i = index; i < count + index; i++)
            {
                result += str[i];
            }
            return result;
        }


        static public string KiemTraInHoaInThuong(string str)
        {
            string result = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (!KiemTraInHoa(str[i]) && !KiemTraInThuong(str[i]))
                {
                    result += str[i];
                }
                else if (KiemTraInHoa(str[i]))
                {
                    result += InThuong(str[i]);
                }
                else
                {
                    result += InHoa(str[i]);
                }
            }
            return result;
        }
        static private bool KiemTraInHoa(char ch)
        {
            return 'A' <= ch && ch <= 'Z';
        }
        static private bool KiemTraInThuong(char ch)
        {
            return 'a' <= ch && ch <= 'z';
        }
        static private char InHoa(char ch)
        {
            return (char)((int)ch - 32);
        }
        static private char InThuong(char ch)
        {
            return (char)((int)ch + 32);
        }


        static public void KiemTraDoiXung_C1(string str)
        {
            string result = string.Empty;
            int count = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            Console.WriteLine(result);
            if (str == result)
            {
                Console.WriteLine("Doi xung");
            }
            else
            {
                Console.WriteLine("Khong doi xung");
            }
        }
        static public void KiemTraDoiXung_C2(string str)
        {
            bool KT = true;
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    KT = false;
                    break;
                }
            }
            if (KT)
            {
                Console.WriteLine("Doi xung");
            }
            else
            {
                Console.WriteLine("Khong doi xung");
            }
        }


        static public string InHoaKiTuDau_C1(string str)
        {
            char space = ' ';
            string result = string.Empty;
            string chuanHoa = ChuanHoaChuoi(str);
            if (KiemTraInThuong(chuanHoa[0]))
            {
                result += InHoa(chuanHoa[0]);
            }
            else
            {
                result += chuanHoa[0];
            }
            for (int i = 1; i < chuanHoa.Length; i++)
            {
                if (chuanHoa[i - 1] == space)
                {
                    result += KiemTraInThuong(chuanHoa[i]) ? InHoa(chuanHoa[i]) : chuanHoa[i]; 
                }
                else
                {
                    result += chuanHoa[i];
                }
            }
            return result;
        }
        static public string InHoaKiTuDau_C2(string str)
        {
            int j = 0;
            string chuanHoa = ChuanHoaChuoi(str);
            string result = string.Empty;
            List<int> indexes = new List<int>() { 0 };
            for (int i = 1; i < chuanHoa.Length; i++)
            {
                if (chuanHoa[i - 1] == space)
                {
                    indexes.Add(i);
                }
            }
            for (int i = 0; i < chuanHoa.Length; i++)
            {
                if (i == indexes[j])
                {
                    result += KiemTraInThuong(chuanHoa[i]) ? InHoa(chuanHoa[i]) : chuanHoa[i];
                    j++;
                }
                else
                {
                    result += chuanHoa[i];
                }
            }
            return result;
        }


        static public List<string> CatChuoi(string str)
        {
            string chuanHoa = ChuanHoaChuoi(str);
            List<string> result = new List<string>();
            List<int> indexes = new List<int>() { 0 };
            for (int i = 1; i < chuanHoa.Length - 1; i++)
            {
                if (chuanHoa[i - 1] == space || chuanHoa[i + 1] == space)
                {
                    indexes.Add(i);
                }
            }
            indexes.Add(chuanHoa.Length - 1);
            int j = 0;
            for (int i = 0; i < indexes.Count; i += 2)
            {
                int start = indexes[i];
                int end = indexes[i + 1];
                result.Add(CatChuoiTheoViTri(chuanHoa, start, end));
            }
            return result;
        }
        static private string CatChuoiTheoViTri(string str, int start, int end)
        {
            string result = string.Empty;
            for (int i = start; i <= end; i++)
            {
                result += str[i];
            }
            return result;
        }


        static public void XoaKiTu(string str)
        {
            string result = string.Empty;
            Console.Write("Vi tri: ");
            int index = int.Parse(Console.ReadLine());
            Console.Write("So luong ki tu can xoa: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < str.Length; i++)
            {
                if (i < index || count + index <= i) result += str[i];
            }
            Console.WriteLine(result);
        }


        //11. Nhập vào 1 chuỗi, xoá các kí tự liền kề giống nhau: "aaabbbccccddaa" => "abcda"
        
        //12. Nhập vào 1 chuỗi, xoá các kí tự bị trùng có trong chuỗi: "aaabbbccccddaa" => "abcd"
        
        //13. Nhập 1 chuỗi, in ra tất cả các chuỗi có thể tạo từ các kí tự đó và có cùng độ dài: "abc" => aaa, aab, aac, aba,....., ccc
       
        //14. tìm độ dài chuỗi con lớn nhất mà các ký tự không trùng lặp: “pickoutthelongestsubstring” => “ubstring”
        
        //15. Tìm chuỗi đối xứng dài nhất của 1 chuỗi cho trước
    }
}