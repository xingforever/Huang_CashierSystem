using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public partial class Md5Helper
    {
        public static string EncryptString(string str)
        {
            //utf8 x2
            //创建对象的方法,构造方法,静态方法
            MD5 md5 = MD5.Create();
            //调用MD5加密方法
            //将字符串转换为字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            byte[] byteNew = md5.ComputeHash(byteOld);
            //将加密结果进行 转换字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                //将字符转换成16进制表示的字符串,而是占用从两头来
                sb.Append(b.ToString("x2"));
            }
            //返回加密字符串
            return sb.ToString();


        }
    }
}
