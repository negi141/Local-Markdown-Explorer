using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LocalMarkdownExplorer
{
    public class Util
    {
        public class IO
        {
            // ﾌｧｲﾙ読み込み
            public static string GetFileReadToEnd(string getFileName, Encoding enc)
            {
                string str = "";
                try
                {
                    StreamReader sr = new StreamReader(getFileName, enc);
                    str = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                return str;
            }

            public static void SaveFile(string filePath, string content, Encoding enc)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath, false, enc))
                    {
                        sw.Write(content);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }

            public static void ProcessStart(string path)
            {
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }

            public static void DeleteFile(string path)
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        public class String
        {
            public static bool MultiContain(string src, string[] searchWords)
            {
                bool hit = true;
                foreach (var s in searchWords)
                {
                    if (src.Contains(s) == false)
                    {
                        hit = false;
                        break;
                    }
                }
                return hit;
            }
        }

        public class IniFile
        {
            private string filename_fullpath;
            private Encoding enc;

            public Dictionary<string, string> data = new System.Collections.Generic.Dictionary<string, string>();

            public IniFile(string filename)
            {
                this.filename_fullpath = Util.Path.GetLocalPath() + filename;
                this.enc = Encoding.GetEncoding("UTF-8");
                if (!File.Exists(filename_fullpath))
                {
                    StreamWriter sw = new StreamWriter(this.filename_fullpath, false, this.enc);
                    sw.WriteLine();
                    sw.Close();
                }
                Read();
            }

            private void Read()
            {
                string txt = "";
                try
                {
                    StreamReader sr = new StreamReader(this.filename_fullpath, this.enc);
                    txt = sr.ReadToEnd();
                    sr.Close();
                }
                catch
                {

                }
                string[] a = txt.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string b in a)
                {
                    string[] c = b.Split(']');
                    if (c.Length == 2)
                        this.data.Add(c[0].Replace("[", ""), c[1]);
                }
            }

            public string Data(string key)
            {
                return (this.data.ContainsKey(key)) ? this.data[key] : "";
            }

            public void Save()
            {
                StreamWriter sw = new StreamWriter(this.filename_fullpath, false, this.enc);
                foreach (var d in this.data)
                {
                    sw.WriteLine("[" + d.Key + "]" + d.Value);
                }
                sw.Close();
            }

        }

        public class Path
        {
            // アプリケーションのパスを返す
            public static string GetLocalPath()
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
            }
            // 末尾のディレクトリ名を返す
            public static string GetLastDir(string path)
            {
                string[] pathArr = path.Split('\\');
                string lastDir = pathArr[pathArr.Length - 2];
                return lastDir;
            }

        }
    }
}
