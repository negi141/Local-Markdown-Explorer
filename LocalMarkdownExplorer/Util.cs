using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace negi
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

            public static string GetFileReadToEnd(string filename)
            {
                var filename_fullpath = Util.Path.GetLocalPath() + filename;
                var enc = Encoding.GetEncoding("UTF-8");
                if (!File.Exists(filename_fullpath))
                {
                    StreamWriter sw = new StreamWriter(filename_fullpath, false, enc);
                    sw.Close();
                }
                return GetFileReadToEnd(filename, enc);
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

            public static void SaveFile(string filePath, string content)
            {
                var filename_fullpath = Util.Path.GetLocalPath() + filePath;
                SaveFile(filename_fullpath, content, Encoding.GetEncoding("UTF-8"));
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

        public class Validate
        {
            public static bool TextBox(System.Windows.Forms.TextBox control, string label)
            {
                if (control.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show(label + "を入力してください");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public static bool DirectoryExists(string path, string label)
            {
                if (!Directory.Exists(path))
                {
                    System.Windows.Forms.MessageBox.Show("パス：" + path + "が存在しません");
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }
}
