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
            // {
            //  "rids":[],
            //  "id":1,
            //  "lang":["ギル","Gil","金币"],
            //  "icon":65002,
            //  "ilv":1,"uc":63,"sc":0,"hq":false,"dye":0,"act":0,"bon":0,
            //  "reduce":false,"elv":1,"jobs":0,"ms":0,"jd":false,
            //  "p":"1.0",
            //  "desc":["","Standard Eorzean currency.","艾欧泽亚流通最为广泛的圆形国际都市通用货币。"],
            //  "bpm":[],"actParm":[]
            // }
            public List<string> lang;
            public List<string> desc;
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
