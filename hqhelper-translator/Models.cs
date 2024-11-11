using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hqhelper_translator
{
    internal class Models
    {
        public struct ItemUnpacked
        {
            //{
            //  "rids":["6128"],
            //  "id":43273,
            //  "lang":["クラロウォルナット・フィッシングロッド","Claro Walnut Fishing Rod","克拉洛胡桃木钓竿"],
            //  "icon":38511,
            //  "ilv":690,
            //  "uc":32,
            //  "sc":29,
            //  "hq":true,
            //  "dye":2,
            //  "act":0,
            //  "bon":9210,
            //  "reduce":false,
            //  "elv":100,
            //  "jobs":19,
            //  "ms":1,
            //  "jd":true,
            //  "p":"7.0",
            //  "desc":["","",""],
            //  "bpm":[[12,3200,3213],[14,3.2,0.003],[18,72,144]],
            //  "spm":[[72,1303,174],[73,745,99],[3,202,22]],
            //  "actParm":[]
            //}
            public List<string> rids;
            public int id;
            public List<string> lang;
            public int icon;
            public int ilv;
            public int uc;
            public int sc;
            public bool hq;
            public int dye;
            public int act;
            public int bon;
            public bool reduce;
            public int elv;
            public int jobs;
            public int ms;
            public bool jd;
            public string p;
            public List<string> desc;
            public List<List<int>> bpm;
            public List<List<int>> spm;
            public List<dynamic> actParm;
        }
        public struct GatheringUnpacked
        {
            // {
            //  "type":3,
            //  "pointType":1,
            //  "territory":140,
            //  "place":264,
            //  "popType":"normal",
            //  "popTime":false,
            //  "coords":{"x":"23.36","y":"23.40"}
            // }
            public int territory;
            //public int place;
        }
        public struct ItemTranslated
        {
            public string name_zh;
            public string name_ja;
            public string name_en;
            public string desc_zh;
            public string desc_ja;
            public string desc_en;

            public ItemTranslated(string name_zh, string name_ja, string name_en, string desc_zh, string desc_ja, string desc_en)
            {
                this.name_zh = name_zh;
                this.name_ja = name_ja;
                this.name_en = name_en;
                this.desc_zh = desc_zh;
                this.desc_ja = desc_ja;
                this.desc_en = desc_en;
            }
        }
        public struct PlaceTranslated
        {
            public int place_id;
            public string name_zh;
            public string name_ja;
            public string name_en;
            public PlaceTranslated(int place_id, string name_zh, string name_ja, string name_en)
            {
                this.place_id = place_id;
                this.name_zh = name_zh;
                this.name_ja = name_ja;
                this.name_en = name_en;
            }
        }
    }
}
