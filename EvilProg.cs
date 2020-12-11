using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Kursach
{
    public class EvilProg
    {
        public static string EvilEncode(string start, string key)
        {
            char[] ch = start.ToCharArray();

            string alfLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alfUp = alfLower.ToUpper();
            string otvet = "";
            int count = 0;

            key = key.ToLower();
            char[] keyCh = key.ToCharArray();
            int[] keys = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                if (alfLower.Contains(keyCh[i]))
                {
                    keys[i] = alfLower.IndexOf(keyCh[i]);
                }
                else
                {
                    return "Ключ";
                }
            }

            for (int i = 0; i < start.Length; i++)
            {
                if (alfLower.Contains(ch[i]))
                {
                    if (count == key.Length - 1)
                    {
                        otvet = otvet + alfLower[(alfLower.IndexOf(ch[i]) + keys[count]) % 33].ToString();
                        count = 0;
                    }
                    else
                    {

                        otvet = otvet + alfLower[(alfLower.IndexOf(ch[i]) + keys[count]) % 33].ToString();
                        count++;
                    }
                }
                else if (alfUp.Contains(ch[i]))
                {
                    if (count == key.Length - 1)
                    {
                        otvet = otvet + alfUp[(alfUp.IndexOf(ch[i]) + keys[count]) % 33].ToString();
                        count = 0;
                    }
                    else
                    {

                        otvet = otvet + alfUp[(alfUp.IndexOf(ch[i]) + keys[count]) % 33].ToString();
                        count++;
                    }
                }
                else
                {
                    otvet += ch[i].ToString();
                }
            }
            return otvet;
        }
        public static string EvilAntiEncode(string start, string key)
        {
            char[] ch = start.ToCharArray();

            string alfLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alfUp = alfLower.ToUpper();
            string otvet = "";

            key = key.ToLower();
            if (key.Length == 0)
            {
                return "Ключ";
            }
            char[] keyCh = key.ToCharArray();
            int[] keys = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                if (alfLower.Contains(keyCh[i]))
                {
                    keys[i] = alfLower.IndexOf(keyCh[i]);
                }
                else
                {
                    return "Ключ";
                }
            }

            int count = 0;

            for (int i = 0; i < start.Length; i++)
            {
                if (alfLower.Contains(ch[i]))
                {
                    if (count == key.Length - 1)
                    {
                        otvet = otvet + alfLower[(alfLower.IndexOf(ch[i]) + 33 - keys[count]) % 33].ToString();
                        count = 0;
                    }
                    else
                    {

                        otvet = otvet + alfLower[(alfLower.IndexOf(ch[i]) + 33 - keys[count]) % 33].ToString();
                        count++;
                    }
                }
                else if (alfUp.Contains(ch[i]))
                {
                    if (count == key.Length - 1)
                    {
                        otvet = otvet + alfUp[(alfUp.IndexOf(ch[i]) + 33 - keys[count]) % 33].ToString();
                        count = 0;
                    }
                    else
                    {

                        otvet = otvet + alfUp[(alfUp.IndexOf(ch[i]) + 33 - keys[count]) % 33].ToString();
                        count++;
                    }
                }
                else
                {
                    otvet += ch[i].ToString();
                }
            }
            return otvet;
        }
        public static string EvilDownLoadText(string path)
        {
            if (File.Exists(path))
            {
                string rasshirenie = path.Split('.').Last();
                if (rasshirenie == "txt")
                {
                    BinaryReader instr = new BinaryReader(File.OpenRead(path));
                    byte[] data = instr.ReadBytes((int)instr.BaseStream.Length);
                    instr.Close();
                    string start = "";
                    
                    byte[] by = Encoding.Convert(Encoding.GetEncoding("windows-1251"), Encoding.GetEncoding("utf-8"), data);

                    
                    start = Encoding.UTF8.GetString(by);
                    
                    return start;
                }
                else if (rasshirenie == "docx")
                {
                    var wordApp = new Word.Application();
                    object file = path;
                    var wordDoc = wordApp.Documents.Open(ref file);

                    string text = "";
                    for (int i = 0; i < wordDoc.Paragraphs.Count; i++)
                    {
                        text += wordDoc.Paragraphs[i + 1].Range.Text;
                    }

                    // Получение основного текста со страниц (без учёта сносок и колонтитулов)
                    string start = text;

                    wordDoc.Close();
                    return start;
                }
                else
                {
                    return "Расширение";
                }
            }
            else
            {
                return "Наличие";
            }
            
        }
        public static string EvilUpLoadText(string path,string otvet)
        {
            string rasshirenie = path.Split('.').Last();
            if (rasshirenie == "txt")
            {
                otvet = Encoding.GetEncoding("windows-1251").GetString(Encoding.Convert(Encoding.GetEncoding("utf-8"), Encoding.GetEncoding("windows-1251"), (Encoding.GetEncoding("utf-8").GetBytes(otvet))));
                File.WriteAllText(path, otvet, Encoding.GetEncoding("windows-1251"));
                return null;
            }
            else if (rasshirenie == "docx")
            {
                var wordApp = new Word.Application();
                object file = path;
                var wordDoc = wordApp.Documents.Add();

                wordDoc.Range().Text = otvet;
                object filename = path;
                wordDoc.SaveAs2(ref filename);
                wordDoc.Close();
                wordDoc = null;
                return null;
            }
            else
            {
                return "Расширение";
            }
           
        }
    }
}
