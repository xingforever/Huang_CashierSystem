using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class Seeting
    {
        public static int GoodsInfoPageCount = 3;
        public static int ToadyOrderPageCount = 3;
        public static int GoodsManagerPageCount = 3;
        public static int AllOrderPageCount = 3;
        public  static int ProfitPageCount = 30;


        public  void SetGoodsInfoPageCount(int data)
        {
            GoodsInfoPageCount = data;
        }
        public  Seeting()
        {
            GoodsInfoPageCount = 3;
            ToadyOrderPageCount = 3;
            GoodsManagerPageCount = 3;
            AllOrderPageCount = 3;
            ProfitPageCount = 10;

        }
    }
}
