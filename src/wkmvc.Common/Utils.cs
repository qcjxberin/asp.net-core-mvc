using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace wkmvc.Common
{
    public class Utils
    {

        /// <summary>
        /// 读取指定文件中的内容,文件名为空或找不到文件返回空串
        /// </summary>
        /// <param name="FileName">文件全路径</param>
        /// <param name="isLineWay">是否按行读取返回字符串 true为是</param>
        public static string GetFileContent(string FileName, bool isLineWay)
        {
            string result = string.Empty;
            using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    StreamReader sr = new StreamReader(fs);
                    if (isLineWay)
                    {
                        while (!sr.EndOfStream)
                        {
                            result += sr.ReadLine() + "\n";
                        }
                    }
                    else
                    {
                        result = sr.ReadToEnd();
                    }
                    sr.Dispose();
                    fs.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

    }
}
