using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DeleteNoReceiveMoney();
            Console.WriteLine();
            Console.ReadKey();


        }

        #region UserInfo Test
        static void AddUser()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = "hl4545x";
            userInfo.PassWord = "123";
            userInfo.Remark = "  ";
            userInfo.DelFlag = false;

            UserInfoDal userInfoDal = new UserInfoDal();

            bool d = userInfoDal.Add(userInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditUser()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = "545x";
            userInfo.PassWord = "1xiugaui 23";
            userInfo.Remark = "修改lhil   ";
            userInfo.DelFlag = false;
            userInfo.Id = 3;

            UserInfoDal userInfoDal = new UserInfoDal();

            bool d = userInfoDal.Edit(userInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }


        static void getUserInfo()
        {

            int id = 3;
            UserInfoDal userInfoDal = new UserInfoDal();
            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "UserInfo";
            var d = userInfoDal.GetDataTable(searchModel);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteUser()
        {
            int id = 3;
            UserInfoDal userInfoDal = new UserInfoDal();
            var d = userInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }
        #endregion

        #region unitInfo Test
        static void AddUnit()
        {
            UnitInfo userInfo = new UnitInfo();
            userInfo.UnitName = "张";

            userInfo.Remark = "  ";
            userInfo.DelFlag = false;

            UnitInfoDal unitInfoDal = new UnitInfoDal();

            bool d = unitInfoDal.Add(userInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditUnit()
        {
            UnitInfo userInfo = new UnitInfo();
            userInfo.UnitName = "liu ";

            userInfo.Remark = " fd  ";
            userInfo.DelFlag = false;
            userInfo.Id = 1;

            UnitInfoDal unitInfoDal = new UnitInfoDal();

            bool d = unitInfoDal.Edit(userInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void getUnitInfo()
        {

            int id = 1;

            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "UnitInfo";
            UnitInfoDal unitInfoDal = new UnitInfoDal();
            var d = unitInfoDal.GetDataTable(searchModel);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteUnit()
        {
            int id = 1;
            UnitInfoDal unitInfoDal = new UnitInfoDal();
            var d = unitInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }
        #endregion

        #region sortInfo Test
        static void AddSort()
        {
            SortInfo sortInfo = new SortInfo();
            sortInfo.SortName = "水管";

            sortInfo.Remark = "  ";
            sortInfo.DelFlag = false;

            SortInfoDal unitInfoDal = new SortInfoDal();

            bool d = unitInfoDal.Add(sortInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditSort()
        {
            SortInfo sortInfo = new SortInfo();
            sortInfo.SortName = "水34管";
            sortInfo.Remark = "  ";
            sortInfo.DelFlag = false;
            sortInfo.Id = 1;
            SortInfoDal sortInfoDal = new SortInfoDal();         

            bool d = sortInfoDal.Edit(sortInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void getsortInfo()
        {

            int id = 1;

            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "SortInfo";
            SortInfoDal sortInfoDal = new SortInfoDal();           
            var d = sortInfoDal.GetDataTable(searchModel);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteSort()
        {
            int id = 1;
            SortInfoDal sortInfoDal = new SortInfoDal();
            var d = sortInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }
        #endregion

        #region WholeSalerInfo Test
        static void AddWholeSalerInfo()
        {
            WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
            wholeSalerInfo.Management = "hlx";
            wholeSalerInfo.SupName = "fdf";
            wholeSalerInfo.TelePhone = "fdffdf411";
            wholeSalerInfo.AddressInfo = "fds";
         
            wholeSalerInfo.Remark = "  ";
            wholeSalerInfo.DelFlag = false;

            WholeSalerInfoDal wholeSalerInfoDal = new WholeSalerInfoDal();

            bool d = wholeSalerInfoDal.Add(wholeSalerInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditWholeSalerInfo()
        {
            WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
            wholeSalerInfo.Management = "hdfdlx";
            wholeSalerInfo.SupName = "f";
            wholeSalerInfo.TelePhone = "fd";
            wholeSalerInfo.AddressInfo = "f";
            wholeSalerInfo.Id = 1;
            wholeSalerInfo.Remark = "  ";
            wholeSalerInfo.DelFlag = false;
            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            bool d = sortInfoDal.Edit(wholeSalerInfo); 
        
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void getWholeSalerInfo()
        {

            int id = 1;

            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "WholeSalerInfo";
            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            var d = sortInfoDal.GetDataTable(searchModel);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteWholeSalerInfo()
        {
            int id = 1;
            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            var d = sortInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }
        #endregion


        #region GoodsInfo
        static void AddGoodsInfo()
        {
            GoodsInfo goodsInfo = new GoodsInfo();
            goodsInfo.UnitId = 1;
            goodsInfo.SortId = 1;
            goodsInfo.WholeSalerId = 1;
            goodsInfo.GoodsName = "食品";
            goodsInfo.PurPrice = (decimal)455.343;
            goodsInfo.PayPrice = (decimal)455.343;
            goodsInfo.Total = 50;
            goodsInfo.SalesCount = 0;
            goodsInfo.SurplusCount = 50;
            goodsInfo.GoodsType = "测试";
            goodsInfo.CreateTime = DateTime.Now;
            goodsInfo.LastTime = DateTime.Now + new TimeSpan(50, 5, 5, 1);
            GoodsInfoDal GoodsInfoDal = new GoodsInfoDal();

            bool d = GoodsInfoDal.Add(goodsInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditGoodsInfo()
        {
            GoodsInfo goodsInfo = new GoodsInfo();
            goodsInfo.UnitId = 1;
            goodsInfo.SortId = 1;
            goodsInfo.WholeSalerId = 1;
            goodsInfo.GoodsName = "品";
            goodsInfo.PurPrice = (decimal)455.343;
            goodsInfo.PayPrice = (decimal)455.343;
            goodsInfo.Total = 500;
            goodsInfo.SalesCount = 0;
            goodsInfo.SurplusCount = 500;
            goodsInfo.GoodsType = " gfg ";
            goodsInfo.CreateTime = DateTime.Now;
            goodsInfo.LastTime = DateTime.Now + new TimeSpan(50, 5, 5, 1);
            goodsInfo.Id = 2;
            GoodsInfoDal GoodsInfoDal = new GoodsInfoDal();

            bool d = GoodsInfoDal.Edit(goodsInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void GetGoodsInfo()
        {

            int id = 1;

            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "GoodsInfo";
            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            var d = sortInfoDal.GetDataTable(searchModel);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteGoodsInfo()
        {
            int id = 1;
            GoodsInfoDal sortInfoDal = new GoodsInfoDal();
            var d = sortInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }
        #endregion


        #region SalesInfo Test
        static void AddSalesInfo()
        {

            GoodsInfoDal GoodsInfoDal = new GoodsInfoDal();
            ProfitsInfo salesInfo = new ProfitsInfo();
            //salesInfo.GoodsId = 2;
            //salesInfo.Count = 3;
            //salesInfo.DisCount = 50;
            //salesInfo.GoodsInfo = GoodsInfoDal.GetEntityById(salesInfo.GoodsId);
            //salesInfo.Prices = salesInfo.GoodsInfo.PayPrice * (decimal)salesInfo.Count - salesInfo.DisCount;
            //salesInfo.CreateTime = DateTime.Now;
            //salesInfo.IsPay = true;


            ProfitsInfoDal salesInfoDal = new ProfitsInfoDal();

            bool d = salesInfoDal.Add(salesInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditSalesInfo()
        {
            GoodsInfoDal GoodsInfoDal = new GoodsInfoDal();


            ProfitsInfoDal salesInfoDal = new ProfitsInfoDal();
            ProfitsInfo salesInfo = salesInfoDal.GetEntityById(2);
            salesInfo.Remark = "测试修改";
            salesInfo.IsPay = false;

            var d = salesInfoDal.Edit(salesInfo);//仅能修改 备注和是否支付
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void GetSalesInfo()
        {

            int id = 2;


            ProfitsInfoDal salesInfoDal = new ProfitsInfoDal();
            var d = salesInfoDal.GetEntityById(id);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteSalesInfo()
        {
            int id = 2;
            ProfitsInfoDal salesInfoDal = new ProfitsInfoDal();
            var d = salesInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        } 
        #endregion



        static void AddNoReceiveMoney()
        {
            NoReceiveMoneyDal noReceiveMoneyDal = new NoReceiveMoneyDal();
            ProfitsInfoDal salesInfoDal = new ProfitsInfoDal();
            NoReceiveMoney noReceiveMoney = new NoReceiveMoney();
            noReceiveMoney.SalesInfoId = 2;
            noReceiveMoney.SalesInfo = salesInfoDal.GetEntityById(2);
            noReceiveMoney.CustomerName = "hhh";
            noReceiveMoney.CreateTime = DateTime.Now;
            noReceiveMoney.Phone = "15779708285";        
            bool d = noReceiveMoneyDal.Add(noReceiveMoney);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void EditNoReceiveMoney()
        {
            NoReceiveMoneyDal noReceiveMoneyDal = new NoReceiveMoneyDal();

            NoReceiveMoney noReceiveMoney = new NoReceiveMoney();
            noReceiveMoney.Id = 1;
            noReceiveMoney.CustomerName = "fdf";
            bool d = noReceiveMoneyDal.Edit(noReceiveMoney);

            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void GetNoReceiveMoney()
        {

            int id = 1;

            NoReceiveMoneyDal noReceiveMoneyDal = new NoReceiveMoneyDal();
            var d = noReceiveMoneyDal.GetEntityById(id);

            if (d != null)
            {
                Console.WriteLine(d.CustomerName);
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void DeleteNoReceiveMoney()
        {
            int id = 1;
            NoReceiveMoneyDal noReceiveMoneyDal = new NoReceiveMoneyDal();
            var d = noReceiveMoneyDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }


        static void Add()
        {
            WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();


            WholeSalerInfoDal wholeSalerInfoDal = new WholeSalerInfoDal();

            bool d = wholeSalerInfoDal.Add(wholeSalerInfo);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void Edit()
        {
            WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();

            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            bool d = sortInfoDal.Edit(wholeSalerInfo);

            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void Get()
        {

            int id = 1;

            SearchModel searchModel = new SearchModel();
            searchModel.ModelName = "WholeSalerInfo";
            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            var d = sortInfoDal.GetDataTable(searchModel);
            if (d != null)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        static void Delete()
        {
            int id = 1;
            WholeSalerInfoDal sortInfoDal = new WholeSalerInfoDal();
            var d = sortInfoDal.Delete(id);
            if (d)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }



    }
}
