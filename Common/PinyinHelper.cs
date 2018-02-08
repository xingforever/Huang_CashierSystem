using Microsoft.International.Converters.PinYinConverter;

namespace Common
{
    public partial class PinyinHelper
    {

        public static string GetPinyin(string s1)
        {
            string s2 = "";
            foreach (char c in s1)
            {
                ChineseChar cc = new ChineseChar(c);
                s2 += cc.Pinyins[0][0];

            }

            return s2;


        }
    }
}
