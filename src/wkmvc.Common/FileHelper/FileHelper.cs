using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace wkmvc.Common
{
    /// <summary>
    /// Describe：文件帮助类
    /// Author：YuanGang
    /// Date：2016/08/05
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 目录分隔符
        /// windows "\" Mac OS and Linux  "/"
        /// </summary>
        private static string DirectorySeparatorChar = Path.DirectorySeparatorChar.ToString();
        /// <summary>
        /// 包含应用程序的目录的绝对路径
        /// </summary>
        private static string _ContentRootPath = DI.ServiceProvider.GetRequiredService<IHostingEnvironment>().ContentRootPath;

        #region 检测指定路径是否存在

        /// <summary>
        /// 检测指定路径是否存在
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsExist(string path)
        {
            return IsDirectory(MapPath(path)) ? Directory.Exists(MapPath(path)) : File.Exists(MapPath(path));
        }
        /// <summary>
        /// 检测指定路径是否存在（异步方式）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static async Task<bool> IsExistAsync(string path)
        {
            return await Task.Run(() => IsDirectory(MapPath(path)) ? Directory.Exists(MapPath(path)) : File.Exists(MapPath(path)));
        }

        #endregion

        #region 检测目录是否为空

        /// <summary>
        /// 检测目录是否为空
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsEmptyDirectory(string path)
        {
            return Directory.GetFiles(MapPath(path)).Length <= 0 && Directory.GetDirectories(MapPath(path)).Length <= 0;
        }
        /// <summary>
        /// 检测目录是否为空
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static async Task<bool> IsEmptyDirectoryAsync(string path)
        {
            return await Task.Run(() => Directory.GetFiles(MapPath(path)).Length <= 0 && Directory.GetDirectories(MapPath(path)).Length <= 0);
        }

        #endregion

        #region 创建文件或目录

        /// <summary>
        /// 创建目录或文件
        /// </summary>
        /// <param name="path">路径</param>
        public static void CreateFiles(string path)
        {
            try {
                if (IsExist(path))
                {
                    if (IsDirectory(MapPath(path)))
                        Directory.CreateDirectory(MapPath(path));
                    else
                    {
                        FileInfo file = new FileInfo(MapPath(path));
                        FileStream fs = file.Create();
                        fs.Dispose();
                    }
                }                   
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 删除文件或目录

        /// <summary>
        /// 删除目录或文件
        /// </summary>
        /// <param name="path">路径</param>
        public static void DeleteFiles(string path)
        {
            try
            {
                if (IsExist(path))
                {
                    if (IsDirectory(MapPath(path)))
                        Directory.Delete(MapPath(path));
                    else
                        File.Delete(MapPath(path));                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 清空目录下所有文件及子目录，依然保留该目录
        /// </summary>
        /// <param name="path"></param>
        public static void ClearDirectory(string path)
        {
            if(IsExist(path))
            {
                //目录下所有文件
                string[] files = Directory.GetFiles(MapPath(path));
                foreach(var file in files)
                {
                    DeleteFiles(file);
                }
                //目录下所有子目录
                string[] directorys = Directory.GetDirectories(MapPath(path));
                foreach(var dir in directorys)
                {
                    DeleteFiles(dir);
                }
            }
        }

        #endregion

        #region 判断文件是否为隐藏文件（系统独占文件）

        /// <summary>
        /// 检测文件或文件夹是否为隐藏文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsHiddenFile(string path)
        {
            return IsDirectory(MapPath(path)) ? InspectHiddenFile(new DirectoryInfo(MapPath(path))) : InspectHiddenFile(new FileInfo(MapPath(path)));
        }
        /// <summary>
        /// 检测文件或文件夹是否为隐藏文件（异步方式）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static async Task<bool> IsHiddenFileAsync(string path)
        {
            return await Task.Run(() => IsDirectory(MapPath(path)) ? InspectHiddenFile(new DirectoryInfo(MapPath(path))) : InspectHiddenFile(new FileInfo(MapPath(path))));
        }
        /// <summary>
        /// 私有方法 文件是否为隐藏文件（系统独占文件）
        /// </summary>
        /// <param name="fileSystemInfo"></param>
        /// <returns></returns>
        private static bool InspectHiddenFile(FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo.Name.StartsWith("."))
            {
                return true;
            }
            else if (fileSystemInfo.Exists &&
                ((fileSystemInfo.Attributes & FileAttributes.Hidden) != 0 ||
                 (fileSystemInfo.Attributes & FileAttributes.System) != 0))
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 文件操作

        #region 复制文件

        /// <summary>
        /// 复制文件内容到目标文件夹
        /// </summary>
        /// <param name="sourcePath">源文件</param>
        /// <param name="targetPath">目标文件夹</param>
        /// <param name="isOverWrite">是否可以覆盖</param>
        public static void Copy(string sourcePath,string targetPath,bool isOverWrite=true)
        {
            File.Copy(MapPath(sourcePath), MapPath(targetPath)+ GetFileName(sourcePath), isOverWrite);
        }
        /// <summary>
        /// 复制文件内容到目标文件夹
        /// </summary>
        /// <param name="sourcePath">源文件</param>
        /// <param name="targetPath">目标文件夹</param>
        /// <param name="newName">新文件名称</param>
        /// <param name="isOverWrite">是否可以覆盖</param>
        public static void Copy(string sourcePath, string targetPath,string newName, bool isOverWrite = true)
        {
            File.Copy(MapPath(sourcePath), MapPath(targetPath) + newName, isOverWrite);
        }

        #endregion

        #region 移动文件

        /// <summary>
        /// 移动文件到目标目录
        /// </summary>
        /// <param name="sourcePath">源文件</param>
        /// <param name="targetPath">目标目录</param>
        public static void Move(string sourcePath, string targetPath)
        {
            string sourceFileName = GetFileName(sourcePath);
            //如果目标目录不存在则创建
            if(IsExist(targetPath))
            {
                CreateFiles(targetPath);
            }
            else
            {
                //如果目标目录存在同名文件则删除
                if (IsExist(Path.Combine(MapPath(targetPath), sourceFileName)))
                {
                    DeleteFiles(Path.Combine(MapPath(targetPath), sourceFileName));
                }
            }

            File.Move(MapPath(sourcePath), Path.Combine(MapPath(targetPath), sourceFileName));


        }

        #endregion

        /// <summary>
        /// 获取文件名和扩展名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            return Path.GetFileName(MapPath(path));
        }

        /// <summary>
        /// 获取文件名不带扩展名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileNameWithOutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(MapPath(path));
        }
        
        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileExtension(string path)
        {
            return Path.GetExtension(MapPath(path));
        }

        #endregion

        #region 获取文件绝对路径

        /// <summary>
        /// 获取文件绝对路径
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string MapPath(string path)
        {            
            return  Path.Combine(_ContentRootPath , path.TrimStart('~','/').Replace("/", DirectorySeparatorChar));
        }
        /// <summary>
        /// 获取文件绝对路径（异步方式）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static async Task<string> MapPathAsync(string path)
        {
            return await Task.Run(() =>  Path.Combine(_ContentRootPath, path.TrimStart('~', '/').Replace("/", DirectorySeparatorChar)));
        }


        /// <summary>
        /// 是否为目录或文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsDirectory(string path)
        {
            return path.IndexOf(".") <= 0;
        }

        #endregion

    }
}
