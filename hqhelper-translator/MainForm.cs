using ClosedXML.Excel;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using static hqhelper_translator.Models;

namespace hqhelper_translator;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private ConfigHelper.ConfigModel config;

    private static string ExcelPath
    {
        get {
            var path = Environment.CurrentDirectory + @"\Excels";
            LocalFile.CreateFolderIfAbsent(path);
            return path;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        config = ConfigHelper.Value;
        if (config.HqhelperPath.IsValid())
            TbxPosiRepo.Text = config.HqhelperPath;
        版本信息ToolStripMenuItem.Text = "版本:v." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString();
    }

    #region 顶部菜单
    private void hqHelper仓库目录ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CommonTool.OpenUrl("https://github.com/InfSein/hqhelper-dawntrail");
    }
    private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CommonTool.OpenUrl("https://github.com/InfSein/hqhelper-dawntrail/wiki/HqHelper-中文本地化指南");
    }
    #endregion

    #region 超链接文本
    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        CommonTool.OpenUrl("https://github.com/InfSein/hqhelper-dawntrail");
    }
    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("explorer.exe", ExcelPath);
    }
    private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        CommonTool.OpenUrl("https://github.com/InfSein/hqhelper-dawntrail/wiki/HqHelper-中文本地化指南");
    }
    #endregion

    #region 按钮
    private void BtnPosiRepo_Click(object sender, EventArgs e)
    {
        if (OpenFileDialogPosiRepo.ShowDialog() == DialogResult.OK)
        {
            var filename = OpenFileDialogPosiRepo.FileName;
            var pathname = Path.GetDirectoryName(filename);
            if (string.IsNullOrEmpty(pathname))
            {
                CommonTool.ShowError($"选取的文件路径似乎不合法：\n{filename}");
                return;
            }
            //foreach (var o in filename.Split(''))
            TbxPosiRepo.Text = pathname;
            config.HqhelperPath = pathname;
            ConfigHelper.Value = config;
        }
    }
    private void BtnResolveToExcel_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(config.HqhelperPath))
        {
            CommonTool.ShowError("请先定位HqHelper目录");
            return;
        }

        #region 主要i18n
        var json_path = config.HqhelperPath;
        if (!json_path.EndsWith('\\')) json_path += "\\";
        json_path += @"src\languages\translates\default.json";
        var xlsx_path = ExcelPath + @"\主要i18n.xlsx";

        var json_content = LocalFile.Read(json_path);

        var json = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, dynamic>>>(json_content);
        json ??= new();

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("中文", typeof(string)));
        dt.Columns.Add(new DataColumn("日文", typeof(string)));
        dt.Columns.Add(new DataColumn("英文", typeof(string)));

        foreach (var i18n in json)
        {
            string cn = i18n.Key;
            string ja = i18n.Value["ja"];
            string en = i18n.Value["en"];
            DataRow dr = dt.NewRow();
            dr["中文"] = cn;
            dr["日文"] = ja;
            dr["英文"] = en;
            dt.Rows.Add(dr);
        }

        var dts = new Dictionary<string, DataTable>() {
            { "HqHelper-i18n", dt }
        };
        CommonTool.ExportExcel(dts, xlsx_path, true);
        #endregion

        #region 道具暂译
        json_path = config.HqhelperPath;
        if (!json_path.EndsWith('\\')) json_path += "\\";
        var name_json_path = json_path + @"src\assets\data\translations\xiv-item-names.json";
        var desc_json_path = json_path + @"src\assets\data\translations\xiv-item-descriptions.json";
        var item_json_path = json_path + @"src\assets\data\unpacks\item.json";
        xlsx_path = ExcelPath + @"\道具暂译表.xlsx";

        var name_json_content = LocalFile.Read(name_json_path);
        var desc_json_content = LocalFile.Read(desc_json_path);
        var item_json_content = LocalFile.Read(item_json_path);

        var name_json = JsonConvert.DeserializeObject<Dictionary<int, string>>(name_json_content);
        var desc_json = JsonConvert.DeserializeObject<Dictionary<int, string>>(desc_json_content);
        var item_json = JsonConvert.DeserializeObject<Dictionary<int, ItemUnpacked>>(item_json_content);
        name_json ??= []; desc_json ??= []; item_json ??= [];

        dt = new DataTable();
        dt.Columns.Add(new DataColumn("道具ID", typeof(int)));
        dt.Columns.Add(new DataColumn("道具名-中文", typeof(string)));
        dt.Columns.Add(new DataColumn("道具名-日文", typeof(string)));
        dt.Columns.Add(new DataColumn("道具名-英文", typeof(string)));
        dt.Columns.Add(new DataColumn("道具描述-中文", typeof(string)));
        dt.Columns.Add(new DataColumn("道具描述-日文", typeof(string)));
        dt.Columns.Add(new DataColumn("道具描述-英文", typeof(string)));

        var items_to_translate = new Dictionary<int, ItemTranslated>();

        // 不移除已有的翻译
        foreach (var existed_name in name_json)
        {
            var itemID = existed_name.Key;
            ExtractDataFromItemJson(item_json, itemID,
                out string name_zh, out string name_ja, out string name_en,
                out string desc_zh, out string desc_ja, out string desc_en
            );
            name_zh = existed_name.Value;
            items_to_translate.TryAdd(itemID, new(
                name_zh, name_ja, name_en,
                desc_zh, desc_ja, desc_en
            ));
        }
        foreach (var existed_desc in desc_json)
        {
            var itemID = existed_desc.Key;
            ExtractDataFromItemJson(item_json, itemID,
                out string name_zh, out string name_ja, out string name_en,
                out string desc_zh, out string desc_ja, out string desc_en
            );
            desc_zh = existed_desc.Value;
            if (items_to_translate.TryGetValue(itemID, out var item))
            {
                item.desc_zh = desc_zh;
                items_to_translate[itemID] = item;
            }
            else
                items_to_translate.TryAdd(itemID, new(
                    name_zh, name_ja, name_en,
                    desc_zh, desc_ja, desc_en
                ));
        }
        // 筛选出没有中文名的待翻译道具
        foreach (var item in item_json)
        {
            var itemID = item.Key;
            var names = item.Value.lang;
            if (
                !string.IsNullOrEmpty(names[0])
                && string.IsNullOrEmpty(names[2])
            )
            {
                ExtractDataFromItemJson(item_json, itemID,
                    out string name_zh, out string name_ja, out string name_en,
                    out string desc_zh, out string desc_ja, out string desc_en
                );
                items_to_translate.TryAdd(itemID, new(
                    name_zh, name_ja, name_en,
                    desc_zh, desc_ja, desc_en
                ));
            }
        }

        void ExtractDataFromItemJson(Dictionary<int, ItemUnpacked> item_json, int itemID,
            out string name_zh, out string name_ja, out string name_en,
            out string desc_zh, out string desc_ja, out string desc_en)
        {
            name_zh = ""; name_ja = ""; name_en = "";
            desc_zh = ""; desc_ja = ""; desc_en = "";
            if (item_json.TryGetValue(itemID, out var item))
            {
                name_ja = item.lang[0];
                name_en = item.lang[1];
                name_zh = item.lang[2];
                desc_ja = item.desc[0];
                desc_en = item.desc[1];
                desc_zh = item.desc[2];
            }
        }

        // 将待翻译的道具按道具ID递增排序
        items_to_translate = items_to_translate.SortByKey();

        // 导出为Excel
        foreach (var item in items_to_translate)
        {
            int itemID = item.Key;
            string name_zh = item.Value.name_zh;
            string name_ja = item.Value.name_ja;
            string name_en = item.Value.name_en;
            string desc_zh = item.Value.desc_zh;
            string desc_ja = item.Value.desc_ja;
            string desc_en = item.Value.desc_en;
            DataRow dr = dt.NewRow();
            dr["道具ID"] = itemID;
            dr["道具名-中文"] = name_zh;
            dr["道具名-日文"] = name_ja;
            dr["道具名-英文"] = name_en;
            dr["道具描述-中文"] = desc_zh;
            dr["道具描述-日文"] = desc_ja;
            dr["道具描述-英文"] = desc_en;
            dt.Rows.Add(dr);
        }
        dts = new Dictionary<string, DataTable>() {
            { "HqHelper-道具暂译表", dt }
        };
        CommonTool.ExportExcel(dts, xlsx_path, true);
        #endregion

        CommonTool.ShowMsg("成功地将Json处理成了Excel。\n即将打开Excel所在的文件夹……");
        var xlsx_folder = xlsx_path.Replace(xlsx_path.Split("\\").Last(), "");
        Process.Start("explorer.exe", ExcelPath);
    }
    private void BtnRegroupToJson_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(config.HqhelperPath))
        {
            CommonTool.ShowError("请先定位HqHelper目录");
            return;
        }

        #region 主要i18n
        var json_path = config.HqhelperPath;
        if (!json_path.EndsWith('\\')) json_path += "\\";
        json_path += @"src\languages\translates\default.json";
        var xlsx_path = ExcelPath + @"\主要i18n.xlsx";
        var json_content = LocalFile.Read(json_path);

        var json = JsonConvert.DeserializeObject<Dictionary<string, ExpandoObject>>(json_content);
        json ??= [];
        var invalid_cns = new List<string>();

        var workBook = new XLWorkbook(xlsx_path);
        var workSheet = workBook.Worksheet(1);
        var rowCount = workSheet.RowCount();

        for (int i = 1; i < rowCount; i++) // 跳过标题栏
        {
            var rowIndex = i + 1;
            var row = workSheet.Row(rowIndex);
            var cn = row.Cell(1).GetString() ?? "";
            var ja = row.Cell(2).GetString() ?? "";
            var en = row.Cell(3).GetString() ?? "";

            if (cn.Length == 0)
                continue;
            if (!json.TryGetValue(cn, out ExpandoObject? value))
                invalid_cns.Add(cn);
            else
            {
                dynamic obj = value;
                obj.ja = ja;
                obj.en = en;
                json[cn] = obj;
            }
        }

        LocalFile.Write(json_path, JsonConvert.SerializeObject(json, Formatting.Indented));
        #endregion

        #region 道具暂译表
        json_path = config.HqhelperPath;
        if (!json_path.EndsWith('\\')) json_path += "\\";
        var name_json_path = json_path + @"src\assets\data\translations\xiv-item-names.json";
        var desc_json_path = json_path + @"src\assets\data\translations\xiv-item-descriptions.json";
        xlsx_path = ExcelPath + @"\道具暂译表.xlsx";

        workBook = new XLWorkbook(xlsx_path);
        workSheet = workBook.Worksheet(1);
        rowCount = workSheet.RowCount();

        var names = new Dictionary<int, string>();
        var descs = new Dictionary<int, string>();

        for (int i = 1; i < rowCount; i++) // 跳过标题栏
        {
            var rowIndex = i + 1;
            var row = workSheet.Row(rowIndex);

            var firstCell = row.Cell(1).GetString() ?? "";
            if (string.IsNullOrEmpty(firstCell))
                continue;

            var itemID = int.Parse(firstCell);
            var name_cn = row.Cell(2).GetString() ?? "";
            var name_ja = row.Cell(3).GetString() ?? "";
            var name_en = row.Cell(4).GetString() ?? "";
            var desc_cn = row.Cell(5).GetString() ?? "";
            var desc_ja = row.Cell(6).GetString() ?? "";
            var desc_en = row.Cell(7).GetString() ?? "";

            if (!string.IsNullOrEmpty(name_cn))
                names.TryAdd(itemID, name_cn);
            if (!string.IsNullOrEmpty(desc_cn))
                descs.TryAdd(itemID, desc_cn);
        }

        names = names.SortByKey();
        descs = descs.SortByKey();

        LocalFile.Write(name_json_path, JsonConvert.SerializeObject(names, Formatting.Indented));
        LocalFile.Write(desc_json_path, JsonConvert.SerializeObject(descs, Formatting.Indented));
        #endregion

        CommonTool.ShowMsg("已完成重组。请到本地仓库中检查更改……");
    }
    #endregion
}
