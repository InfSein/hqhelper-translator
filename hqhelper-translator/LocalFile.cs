using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hqhelper_translator;

internal class LocalFile
{
    /// <summary>
    /// 读取文件内容。如果文件不存在,将会新建此文件和上级目录,并返回空字符串。
    /// </summary>
    /// <param name="path">传入文件而非文件夹的完整路径</param>
    /// <returns>文件的内容</returns>
    public static string Read(string path)
    {
        CreateFileIfAbsent(path);
        return File.ReadAllText(path);
    }

    /// <summary>
    /// 写入文件内容。如果文件不存在,将会新建此文件和上级目录。
    /// </summary>
    /// <param name="path">传入文件而非文件夹的完整路径</param>
    /// <param name="value">将要写入的内容</param>
    public static void Write(string path, string value)
    {
        CreateFileIfAbsent(path);
        File.WriteAllText(path, value);
    }

    /// <summary>
    /// 新建指定文件及其上级目录,如果它们不存在。
    /// </summary>
    /// <param name="path">传入文件而非文件夹的完整路径</param>
    public static void CreateFileIfAbsent(string path)
    {
        if (!File.Exists(path))
        {
            var parentFolder = GetParentFolder(path);
            CreateFolderIfAbsent(parentFolder);
            File.Create(path).Close();
        }
    }

    /// <summary>
    /// 新建指定文件夹及其上级目录,如果它们不存在。
    /// </summary>
    /// <param name="path">传入文件夹而非文件的完整路径</param>
    public static void CreateFolderIfAbsent(string path)
    {
        if (!Directory.Exists(path))
        {
            var folderPath = GetParentFolder(path);
            CreateFolderIfAbsent(folderPath);
            Directory.CreateDirectory(path);
        }
    }

    /// <summary>
    /// 获取给定路径的上级目录路径
    /// </summary>
    /// <param name="path">传入文件或文件夹的完整路径</param>
    private static string GetParentFolder(string path)
    {
        var folder = path.Replace(path.Split(@"\").Last(), string.Empty);
        folder = folder.Trim('\\');
        return folder;
    }

    /// <summary>
    /// 删除给定目录下的所有文件
    /// </summary>
    public static void DeleteAllFilesUnderFolder(string folder)
    {
        DirectoryInfo inputRoot = new(folder);
        foreach (var f in inputRoot.GetFiles())
        {
            string fullpath = f.FullName;
            File.Delete(fullpath);
        }
    }
}
