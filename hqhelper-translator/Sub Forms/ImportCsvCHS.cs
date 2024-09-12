using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static hqhelper_translator.Models;

namespace hqhelper_translator.Sub_Forms
{
    public partial class ImportCsvCHS : Form
    {
        private string RepoPath;
        private ConfigHelper.ConfigModel config;
        public ImportCsvCHS(ConfigHelper.ConfigModel config, string repoPath)
        {
            RepoPath = repoPath;
            this.config = config;
            InitializeComponent();
        }

        private static string LogPath
        {
            get
            {
                var path = Environment.CurrentDirectory + @"\Logs";
                LocalFile.CreateFolderIfAbsent(path);
                return path;
            }
        }

        private void ImportCsvCHS_Load(object sender, EventArgs e)
        {
            TbxPosiCSV.Text = config.CHS_CSVPath ?? "";
            CbOperateMode.SelectedIndex = 0;
        }

        private void BtnPosiCSV_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogPosiCSV.ShowDialog() == DialogResult.OK)
            {
                var filename = OpenFileDialogPosiCSV.FileName;
                if (string.IsNullOrEmpty(filename))
                {
                    CommonTool.ShowError($"选取的文件路径似乎不合法：\n{filename}");
                    return;
                }
                TbxPosiCSV.Text = filename;
                config.CHS_CSVPath = filename;
                ConfigHelper.Value = config;
            }
        }

        private void CbOperateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbOperateMode.SelectedIndex == 0)
                LabelOperateModeDesc.Text = "预先检查暂译与国服文本的区别，不实行更改。";
            else if (CbOperateMode.SelectedIndex == 1)
                LabelOperateModeDesc.Text = "直接使用国服文本替换暂译。";
            else
                LabelOperateModeDesc.Text = "未预料到的选择，请检查BUG。";
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            var path_repository = RepoPath;
            var path_chscsv = TbxPosiCSV.Text;

            if (string.IsNullOrEmpty(path_repository))
            {
                CommonTool.ShowError("未选定HqHelper仓库的路径。请关闭本窗口返回主界面选择路径。");
                return;
            }
            if (string.IsNullOrEmpty(path_chscsv))
            {
                CommonTool.ShowError("未选定拆包文件的路径。");
                return;
            }

            // Key: itemID, value: (itemName, itemDesc)
            var items = new Dictionary<int, (string, string)>();

            var chsContent = CsvReader.ReadCsv(path_chscsv, Encoding.GetEncoding("GB2312"));
            foreach (var lineCells in chsContent)
            {
                if (lineCells is null) continue;
                var cells = lineCells;
                if (cells.Length < 10) continue;
                if (!int.TryParse(cells[0], out int itemID)) continue;
                var itemName = cells[1];
                var itemDesc = cells[9];
                items.TryAdd(itemID, (itemName, itemDesc));
            }

            if (!path_repository.EndsWith('\\')) path_repository += "\\";
            var name_json_path = path_repository + @"src\assets\data\translations\xiv-item-names.json";
            var desc_json_path = path_repository + @"src\assets\data\translations\xiv-item-descriptions.json";

            var name_json_content = LocalFile.Read(name_json_path);
            var desc_json_content = LocalFile.Read(desc_json_path);

            var name_json = JsonConvert.DeserializeObject<Dictionary<int, string>>(name_json_content);
            var desc_json = JsonConvert.DeserializeObject<Dictionary<int, string>>(desc_json_content);
            name_json ??= []; desc_json ??= [];

            // Key: itemID, value: (oldVal, newVal)
            var changed_item_names = new Dictionary<int, (string, string)>();
            var changed_item_descs = new Dictionary<int, (string, string)>();
            var not_exist_items = new List<int>();

            foreach (var itemKvp in name_json)
            {
                var itemID = itemKvp.Key;
                var itemNameTranslated = itemKvp.Value;
                if (itemID < 0) continue; // ID为负的是注释，不管它
                if (items.TryGetValue(itemID, out var val) && !string.IsNullOrEmpty(val.Item1))
                {
                    var nameCHS = val.Item1;
                    if (nameCHS != itemNameTranslated)
                    {
                        name_json[itemID] = nameCHS;
                        changed_item_names.TryAdd(itemID, (itemNameTranslated, nameCHS));
                    }
                }
                else
                {
                    not_exist_items.Add(itemID);
                }
            }
            foreach (var itemKvp in desc_json)
            {
                var itemID = itemKvp.Key;
                var itemDescTranslated = itemKvp.Value;
                if (itemID < 0) continue; // ID为负的是注释，不管它
                if (items.TryGetValue(itemID, out var val))
                {
                    var descCHS = val.Item2;
                    if (string.IsNullOrEmpty(descCHS)) continue;
                    descCHS = descCHS.Replace("\n", "<br>");
                    if (!string.IsNullOrEmpty(descCHS) && descCHS != itemDescTranslated)
                    {
                        desc_json[itemID] = descCHS;
                        changed_item_descs.TryAdd(itemID, (itemDescTranslated, descCHS));
                    }
                }
            }

            var msg = "处理完成。\n共发现：\n";
            msg += $"\t{changed_item_names.Count}个物品的名称需要更正；\n";
            msg += $"\t{changed_item_descs.Count}个物品的描述需要更正；\n";
            msg += $"\t{not_exist_items.Count}个物品国服尚未实装。\n";

            if (CbOperateMode.SelectedIndex == 1)
            {
                LocalFile.Write(name_json_path, JsonConvert.SerializeObject(name_json, Formatting.Indented));
                LocalFile.Write(desc_json_path, JsonConvert.SerializeObject(desc_json, Formatting.Indented));
                msg += "暂译表已经更新，请到仓库中检查变更。\n";
            }

            if (CbxOutputCompares.Checked)
            {
                var logmsg = "";
                logmsg += "===道具名更正===\n";
                foreach (var changed_item in changed_item_names)
                    logmsg += $"{changed_item.Value.Item1} -> {changed_item.Value.Item2}\n";
                logmsg += "\n===道具描述更正===\n";
                foreach (var changed_desc in changed_item_descs)
                    logmsg += $"{changed_desc.Value.Item1} -> {changed_desc.Value.Item2}\n";
                logmsg += "\n===国服拆包不存在的物品(可能未实装)===\n";
                logmsg += string.Join(',', not_exist_items);
                LocalFile.Write(LogPath + $@"\log_importcsv_chs ({DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}).txt", logmsg);
                msg += "日志已经输出，请到程序目录下检查。\n";
            }

            msg = msg.Trim();
            CommonTool.ShowMsg(msg);
        }
    }
}
