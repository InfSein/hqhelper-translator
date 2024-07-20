using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hqhelper_translator
{
    internal class CommonTool
    {
        #region MessageBox Show
        public static void ShowMsg(string content, string title = "")
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowWarn(string content, string title = "")
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowError(string content, string title = "")
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool ShowConfirm(string content, string title = "", MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(content, title,
                MessageBoxButtons.YesNo,
                icon,
                MessageBoxDefaultButton.Button2
            ) == DialogResult.Yes;
        }
        #endregion

        #region Process Excel

        public static bool ExportExcel(
            Dictionary<string, DataTable> dts,
            string path,
            bool force_rewrite = false
        )
        {
            if (!path.EndsWith(".xlsx"))
                path += ".xlsx";
            if (!force_rewrite && File.Exists(path))
            {
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("检测到已有同名文件。\n要覆盖它吗?", "警告",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2
                );
                if (MsgBoxResult == DialogResult.No)
                {
                    return false;
                }
            }
            var workBook = new XLWorkbook();
            foreach (var dt in dts)
            {
                workBook.Worksheets.Add(dt.Value, dt.Key);
            }
            foreach (var ws in workBook.Worksheets)
            {
                ws.Columns().AdjustToContents();
            }
            workBook.SaveAs(path);
            return true;
        }

        #endregion

        #region Other

        /// <summary>
        /// 调用默认浏览器打开给定的URL
        /// </summary>
        public static void OpenUrl(string url)
        {
            dynamic? kstr;
            string s;
            try
            {
                // 从注册表中读取默认浏览器可执行文件路径
                RegistryKey? key2 = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice\");
                if (key != null)
                {
                    kstr = key.GetValue("ProgId");
                    if (kstr != null)
                    {
                        s = kstr.ToString();
                        // "ChromeHTML","MSEdgeHTM" etc.
                        if (Registry.GetValue(@"HKEY_CLASSES_ROOT\" + s + @"\shell\open\command", null, null) is string path)
                        {
                            var split = path.Split('"');
                            path = split.Length >= 2 ? split[1] : "";
                            if (path != "")
                            {
                                Process.Start(path, url);
                                return;
                            }
                        }
                    }
                }
                if (key2 != null)
                {
                    kstr = key2.GetValue("");
                    if (kstr != null)
                    {
                        s = kstr.ToString();
                        var lastIndex = s.IndexOf(".exe", StringComparison.Ordinal);
                        if (lastIndex == -1)
                        {
                            lastIndex = s.IndexOf(".EXE", StringComparison.Ordinal);
                        }
                        var path = s.Substring(1, lastIndex + 3);
                        var result1 = Process.Start(path, url);
                        if (result1 == null)
                        {
                            var result2 = Process.Start("explorer.exe", url);
                            if (result2 == null)
                            {
                                Process.Start(url);
                            }
                        }
                    }
                }
                else
                {
                    var result2 = Process.Start("explorer.exe", url);
                    if (result2 == null)
                    {
                        Process.Start(url);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"调用浏览器失败,因为{ex.Message}。\n链接已经被复制到您的剪贴板，请手动操作。");
                TryCopy(url);
            }
        }

        /// <summary>
        /// 尝试将给定文本复制到剪贴板
        /// </summary>
        /// <returns>是否成功复制</returns>
        public static bool TryCopy(string text)
        {
            try
            {
                Clipboard.SetText(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
