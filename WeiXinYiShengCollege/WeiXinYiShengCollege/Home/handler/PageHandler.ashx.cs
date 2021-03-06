﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalBook.Module;
using Module.Models;
using Module.Utils;
using WeiXinYiShengCollege.Business;

namespace HospitalBookWebSite.Home.handler
{
    /// <summary>
    /// PageHandler 的摘要说明
    /// </summary>
    public class PageHandler : BaseHandler
    {
        public PageHandler()
        {
            dictAction.Add("GetUserList", GetUserList);
            dictAction.Add("GetReplyContentList", GetReplyContentList);
            
        }
        /// <summary>
        /// code值为:
        ///-105: 用户未登录.
        /// </summary>
        /// <returns></returns>
        private bool IsReady()
        {
            if (LoginAdminUser.GetCurrentUser() == null)
            {
                Response.Write(BaseCommon.ObjectToJson(new { code = ExceptionType.NotLogin, m = "请先登录" }));
                return false;
            }
            return true;
        }


        private void GetReplyContentList()
        {
            if (!IsReady())
                return;


            string upkey = RequestKeeper.GetFormString(Request["upkey"]);
           

            int pageIndex = RequestKeeper.GetFormInt(Request["PageIndex"]);
            int pageSize = 1000;// RequestKeeper.GetFormInt(Request["PageSize"]);

            List<AutoReplyContent> list = MsgAutoReplyBusiness.GetReplyContentList(upkey);

            PageList<List<AutoReplyContent>> pList = new PageList<List<AutoReplyContent>>(1, pageSize, list.Count);
            pList.Source = list;

            Response.Write(BaseCommon.ObjectToJson(new ReturnJsonType<PageList<List<AutoReplyContent>>>() { code = 1, m = pList }));

        }

        private void GetUserList()
        {
            if (!IsReady())
                return;


            long mobile = RequestKeeper.GetFormLong(Request["mobile"]);
            int userType = RequestKeeper.GetFormInt(Request["UserType"]);
            int userLevel = RequestKeeper.GetFormInt(Request["UserLevel"]);
            int cmId = RequestKeeper.GetFormInt(Request["CustomerManagerId"]);
            int province = RequestKeeper.GetFormInt(Request["province"]);
            int city = RequestKeeper.GetFormInt(Request["city"]);
            int approveflag = RequestKeeper.GetFormInt(Request["approveflag"]);


            int pageIndex = RequestKeeper.GetFormInt(Request["PageIndex"]);
            int pageSize = 20;// RequestKeeper.GetFormInt(Request["PageSize"]);

            PageList<List<dynamic>> pList = UserBusiness.GetUserList(mobile, userType, userLevel, cmId, province, city, approveflag, pageIndex, pageSize);
            if (pList != null && pList.Source != null && pList.Source.Count > 0)
            {
                List<CustomerManager> clist = UserBusiness.GetCustomerManagerList();
                foreach (dynamic u in pList.Source)
                {
                    IDictionary<string, object> dic = u;
                    if (clist != null)
                    {
                        CustomerManager cm = clist.Find(m => m.Id == (int)dic["CustomerManagerId"]);
                        if (cm != null)
                        {
                            dic["CustomerManagerMobile"] = cm.Mobile.ToString();
                            dic["CustomerManagerName"] = cm.Name.ToString();
                        }
                    }
                    dic["UserLevelStr"] = Enum.GetName(typeof(UserLevel), dic["UserLevel"]);
                    dic["UserTypeStr"] = Enum.GetName(typeof(UserType), dic["UserType"]);
                    dic["ApproveFlagStr"] = Enum.GetName(typeof(ApproveFlag), dic["ApproveFlag"]);
                    dic["Score"] = Convert.ToDecimal(dic["Score"]) / 100; //分换算成元
                    dic["LastScore"] = Convert.ToDecimal(dic["LastScore"]) / 100; //分换算成元

                }
            }

            Response.Write(BaseCommon.ObjectToJson(new ReturnJsonType<PageList<List<dynamic>>>() { code = 1, m = pList }));

        }
        
    }
}