using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Strings
{
    public class Program
    {
        static public void Main(string[] args)
        {
            Console.Write("Nhap xau: ");
            string str = Console.ReadLine();

            //Goi ham:
            //XoaKiTu(str);

            string result = InHoaKiTuDau(str);
            Console.WriteLine(":" + result + ":");
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

        //static public void ChuoiCon(string str)
        //{
        //    int count = 0;
        //    Console.Write("Nhap chuoi can kiem tra: ");
        //    string chuoiCon = Console.ReadLine();        
        //    for (int i = 0; i < chuoiCon.Length; i++)
        //    {
        //        if (chuoiCon[i] != str[i])
        //        {
        //            break;
        //        }
        //        else 
        //        {
        //            count++;
        //        }
        //    }
        //    if (count == chuoiCon.Length)
        //    {
        //        Console.WriteLine("True");
        //    }
        //    else
        //    {
        //        Console.WriteLine("False");
        //    }
        //}


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


        static public string InHoaKiTuDau(string str)
        {
            char space = ' ';
            string result = string.Empty;
            string chuanHoa = ChuanHoaChuoi(str);
            if (chuanHoa[0] != space)
            {
                if (KiemTraInThuong(chuanHoa[0]))
                {
                    result += InHoa(chuanHoa[0]);
                }
                else
                {
                    result += chuanHoa[0];
                }
            }
            else
            {
                result += chuanHoa[0];
            }
            for (int i = 1; i < chuanHoa.Length; i++)
            {
                if (chuanHoa[i] == space && chuanHoa[i + 1] != space)
                {
                    if (KiemTraInThuong(chuanHoa[i]))
                    {
                        result += InHoa(chuanHoa[i]);
                    }
                    else
                    {
                        result += chuanHoa[i];
                    }
                }
                else
                {
                    result += chuanHoa[i];
                }
            }
            return result;
        }

        //9 Cắt chuỗi thành danh sách các từ (" nguyen van A " => ["Nguyen", "Van", "A"]


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
    }
}