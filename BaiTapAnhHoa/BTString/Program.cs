using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace BTString
{
    public class Program
    {
        private const char space = ' ';
        static public void Main(string[] args)
        {
            Console.Write("Nhap xau: ");
            string str = Console.ReadLine();

            //Goi ham:
            TimChuoiDoiXungDaiNhat(str);


            //int count = DemSoLuongTuChuaItNhatHaiNguyenAm(str);
            //Console.WriteLine(count);


            //string result = XoaKiTuGiongNhau(str);
            //Console.WriteLine(":" + result + ":");

            //List<string> result = CatCacTuTrongChuoi(str);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
        }

        // Bai 1
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

        // Bai 2
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

        // Bai 3
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

        // Bai 4
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
        static public void ChuoiCon_C3(string str)
        {
            bool KT = false;
            string result = string.Empty;
            Console.Write("Nhap chuoi con can kiem tra: ");
            string chuoiCon = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == chuoiCon[0])
                {
                    result = CatChuoiTheoChuoiCon(str, i, chuoiCon.Length);
                    if (chuoiCon == result)
                    {
                        KT = true;
                        break;
                    }
                }
            }
            if (KT)
            {
                Console.WriteLine("Chuoi con");
            }
            else
            {
                Console.WriteLine("Khong phai la chuoi con");
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
        static private string CatChuoiTheoChuoiCon(string str, int index, int count)
        {
            string result = string.Empty;
            for (int i = index; i < count + index; i++)
            {
                result += str[i];
            }
            return result;
        }

        // Bai 5
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

        // Bai 6
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

        // Bai 7
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

        // Bai 8
        static public List<string> CatCacTuTrongChuoi(string str)
        {
            string chuanHoa = ChuanHoaChuoi(str);
            List<string> result = new List<string>();
            List<int> indexes = new List<int>() { 0 };
            for (int i = 1; i < chuanHoa.Length; i++)
            {
                if (chuanHoa[i] == space)
                {
                    indexes.Add(i - 1);
                    indexes.Add(i + 1);
                }
            }
            indexes.Add(chuanHoa.Length - 1);
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

        // Bai 9
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

        // Bai 10
        static public string XoaKiTuLienKeGiongNhau(string str)
        {
            string result = string.Empty;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1]) result += str[i];
            }
            result += str[str.Length - 1];
            return result;
        }

        // Bai 11
        static public string XoaKiTuGiongNhau_C1(string str)
        {
            List<char> existedChars = new List<char>();
            string result = string.Empty;
            foreach (char ch in str)
            {
                if (!existedChars.Contains(ch))
                {
                    existedChars.Add(ch);
                    result += ch;
                }
            }
            return result;
        }
        static public string XoaKiTuGiongNhau_C2(string str)
        {
            List<char> existedChars = new List<char>();
            string result = string.Empty;
            foreach (char ch in str)
            {
                if (!existedChars.Contains(ch))
                {
                    existedChars.Add(ch);
                    result += ch;
                }
            }
            return result;
        }


        //12. Nhập 1 chuỗi, in ra tất cả các chuỗi có thể tạo từ các kí tự đó và có cùng độ dài: "abc" => aaa, aab, aac, aba,....., ccc

        // Bai 13
        static public void TimDoDaiChuoiConCoKiTuKhongTrungLapLonNhat(string str)
        {
            List<string> chuoiCons = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                List<char> existedChars = new List<char>();
                string result = string.Empty;
                for (int j = i; j < str.Length; j++)
                {
                    if (!existedChars.Contains(str[j]))
                    {
                        existedChars.Add(str[j]);
                        result += str[j];
                    }
                    else break;
                }
                chuoiCons.Add(result);
            }
            string longestString = chuoiCons[0];
            for (int i = 1; i < chuoiCons.Count; i++)
            {
                if (longestString.Length < chuoiCons[i].Length) longestString = chuoiCons[i];
            }
            Console.WriteLine(longestString);
        }

        // Bai 14
        static public void TimChuoiDoiXungDaiNhat(string str)
        {
            List<string> chuoiDoiXung = new List<string>();
            string longestString = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = str.Length - 1; j >= 1; j--)
                {
                    string result = TimChuoi(str, i, j);
                    if (KiemTraDoiXung(result))
                    {
                        if (longestString.Length < result.Length) longestString = result;
                        break;
                    }
                }
            }
            Console.WriteLine(longestString);
        }
        static private string TimChuoi(string str, int start, int end)
        {
            string result = string.Empty;
            for (int i = start; i <= end; i++)
            {
                result += str[i];
            }
            return result;
        }
        static private bool KiemTraDoiXung(string str)
        {
            string result = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            bool KT = false;
            if (str == result) KT = true;
            return KT;
        }

        // Bai 15
        static public void TuDaiNhat(string str)
        {
            List<string> cacTu = CatCacTuTrongChuoi(str);
            List<int> doDai = new List<int>();
            for (int i = 0; i < cacTu.Count; i++)
            {
                doDai.Add(cacTu[i].Length);
            }
            int maxLength = TimPhanTuLonNhat(doDai);
            for (int i = 0; i < cacTu.Count; i++)
            {
                if (maxLength == cacTu[i].Length)
                {
                    Console.WriteLine(cacTu[i]);
                }
            }
            for (int i = 0; i < cacTu.Count; i++)
            {
                if (maxLength == cacTu[i].Length) Console.WriteLine(cacTu[i]);
            }
        }
        static private int TimPhanTuLonNhat(List<int> arrays)
        {
            int max = arrays[0];
            for (int i = 1; i < arrays.Count; i++)
            {
                if (max < arrays[i]) max = arrays[i];
            }
            return max;
        }

        // Bai 16
        static public int DemSoLuongTuChuaItNhatHaiNguyenAm(string str)
        {
            bool KT = false;
            int count = 0;
            List<string> listTu = CatCacTuTrongChuoi(str);
            for (int i = 0; i < listTu.Count; i++)
            {
                KT = KiemTraSoLuongNguyenAm(listTu[i]);
                if (KT) count++;
            }
            return count;
        }
        static private bool KiemTraSoLuongNguyenAm(string str)
        {
            bool KT = false;
            int count = 0;
            List<char> nguyenAms = new List<char>() { 'u', 'e', 'o', 'a', 'i', 'U', 'E', 'O', 'A', 'I', };
            for (int i = 0; i < str.Length; i++)
            {
                if (nguyenAms.Contains(str[i])) count++;
            }
            if (count >= 2) KT = true;
            return KT;
        }

        // Bai 17
        static public void DaoNguocCacTuVaCacChuTrongChuoi(string str)
        {
            List<string> listTu = CatCacTuTrongChuoi(str);
            List<string> listDaoNguocChuoi = new List<string>();
            for (int i = listTu.Count - 1; i >= 0; i--)
            {
                listDaoNguocChuoi.Add(DaoNguocChuoi(listTu[i]));
            }
            Console.WriteLine(":" + string.Join(" ",listDaoNguocChuoi) + ":");
        }
        static private string DaoNguocChuoi(string str)
        {
            string result = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result = string.Concat(result, str[i]);
            }
            return result;
        }
    }
}