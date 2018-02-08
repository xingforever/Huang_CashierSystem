﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll;
using Model;
using System.Data;

namespace CashierSystem
{
   public  class DataManager
    {
        /// <summary>
        /// 商品信息表
        /// </summary>
        public static GoodsInfoBll GoodsInfoBLL { get; set; }
        /// <summary>
        /// 未收账信息表
        /// </summary>
        public static NoReceiveMoneyBll NoReceiveMoneyBLL { get; set; }
        /// <summary>
        /// 售货单表
        /// </summary>

        public static SalesInfoBll SalesInfoBLL { get; set;  }
        /// <summary>
        /// 商品类型表
        /// </summary>

        public  static  UnitInfoBll UnitInfoBLL { get; set; }
        /// <summary>
        /// 管理员信息表
        /// </summary>

        public static  UserInfoBll UserInfoBLL { get; set; }
        /// <summary>
        /// 供货商信息表
        /// </summary>

        public  static WholeSalerInfoBll WholeSalerInfoBLL { get; set; }
        /// <summary>
        /// 商品类型表
        /// </summary>
        public static SortInfoBll SortInfoBLL { get; set; }

        public DataManager()
        {
            GoodsInfoBLL = new GoodsInfoBll();
            NoReceiveMoneyBLL = new NoReceiveMoneyBll();
            SalesInfoBLL = new SalesInfoBll();
            SortInfoBLL = new SortInfoBll();
            UserInfoBLL = new UserInfoBll();
            WholeSalerInfoBLL = new WholeSalerInfoBll();
            UnitInfoBLL = new UnitInfoBll();
        }
        /// <summary>
        /// 数据表刷新
        /// </summary>
        /// <param name="baseBll"></param>
        /// <returns></returns>
        public  DataTable  LoadData(BaseBll<BaseModel> baseBll)
        {
           return  baseBll.GetDataTable();
        }
        /// <summary>
        /// 加载表的默认数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable LoadBySelectId(int id)
        {
           
            switch (id)
            {
                case 0:
                  return   GoodsInfoBLL.GetDataTable();                    
                case 1:
                    return SalesInfoBLL.GetTodayDataTable();
                case 2:
                   return GoodsInfoBLL.GetDataTable();
                case 3:
                    return SalesInfoBLL.GetDataTable();
                case 4:
                    return UnitInfoBLL.GetDataTable();
                case 5:
                    return SortInfoBLL.GetDataTable();
                case 6:
                    return  WholeSalerInfoBLL.GetDataTable();
                case 7:
                    return UserInfoBLL.GetDataTable();
                default:
                    break;
            }
            return null;
        }

        public static void GetHandTxtAndHideIndex(int id, ref List<string> handText,  ref List<int> hideIndex)
        {
            switch (id)
            {
                case 0:
                    handText = new GoodsInfo().GetHanderTxt();
                    hideIndex= new GoodsInfo().GetHideIndex();
                    break;
                case 1:
                    handText = new SalesInfo().GetHanderTxt();
                    hideIndex = new SalesInfo().GetHideIndex();
                    break;
                case 2:
                    handText = new GoodsInfo().GetHanderTxt();
                    hideIndex = new GoodsInfo().GetHideIndex();
                    break;
                case 3:
                    handText = new SalesInfo().GetHanderTxt();
                    hideIndex = new SalesInfo().GetHideIndex();
                    break;
                case 4:
                    handText = new UnitInfo().GetHanderTxt();
                    hideIndex = new UnitInfo().GetHideIndex();
                    break;
                case 5:
                    handText = new SortInfo().GetHanderTxt();
                    hideIndex = new SortInfo().GetHideIndex();
                    break;
                case 6:
                    handText = new WholeSalerInfo().GetHanderTxt();
                    hideIndex = new WholeSalerInfo().GetHideIndex();
                    break;
                case 7:
                    handText = new UserInfo().GetHanderTxt();
                    hideIndex = new UserInfo().GetHideIndex();
                    break;
                default:
                    break;
            }
           
        }



    }
}