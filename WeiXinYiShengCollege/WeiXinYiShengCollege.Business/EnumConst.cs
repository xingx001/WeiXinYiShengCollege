﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinYiShengCollege.Business
{
    class EnumConst
    {
    }

    /// <summary>
    /// 理事级别：0：未分配，1：理事 ，2：常务理事，3：荣誉理事 
    /// </summary>
    public enum UserLevel
    {
        /// <summary>
        /// 0：未分配
        /// </summary>
        未分配 = 0,
        /// <summary>
        /// 1：理事 
        /// </summary>
        理事 = 1,
        /// <summary>
        /// 2：常务理事
        /// </summary>
        常务理事 = 2,
        /// <summary>
        /// 3：荣誉理事
        /// </summary>
        荣誉理事 = 3
    }
    /// <summary>
    /// 用户类型：0：未分配，1：粉丝类型 ,2：理事类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 0：未分配
        /// </summary>
        未分配 = 0,
        /// <summary>
        /// 1：粉丝类型
        /// </summary>
        粉丝类型 = 1,
        /// <summary>
        /// 1：理事类型
        /// </summary>
        理事类型 = 2
    }
    /// <summary>
    /// 是否认证 0:未认证 1:已认证 2：提交认证申请 3：认证未通过  目前只针对理事
    /// </summary>
    public enum ApproveFlag
    {
        /// <summary>
        /// 0:未认证
        /// </summary>
        未认证 = 0,
        /// <summary>
        /// 1:已认证
        /// </summary>
        已认证 = 1,
        /// <summary>
        /// 2：提交认证申请
        /// </summary>
        已提交认证申请 = 2,
        /// <summary>
        /// 3：认证未通过 
        /// </summary>
        认证未通过 = 3
    }

    /// <summary>
    ///兑换积分状态 
    /// </summary>
    public enum PayStatus
    {
        //支付状态 0：未支付给理事 1：支付中  2：已支付
        /// <summary>
        /// 未支付
        /// </summary>
        NoPay = 0,
        /// <summary>
        /// 支付中
        /// </summary>
        Paying = 1,
        /// <summary>
        /// 已支付
        /// </summary>
        HavePayed = 2,
    }

    public enum ErrorCode : int
    {
        
        NotFindOpenId=10000,
        /// <summary>
        /// 二次获取code失败
        /// </summary>
        NotFindNewCode=10001,
        NotFindUser=10002,
        /// <summary>
        /// 插入地区表
        /// </summary>
        InsertArea=10003
    }

    /// <summary>
    /// 目录的类型
    /// </summary>
    public enum SysModuleLinkType:int
    {
        临证参考=1,
        经典方剂=2
    }
    /// <summary>
    /// 用户点击日志类型（UserOpLog表）
    /// </summary>
    public enum OptionType : int
    {
        /// <summary>
        /// 点赞
        /// </summary>
        zan=1,
        /// <summary>
        /// 查看
        /// </summary>
        see=2
    }

    /// <summary>
    /// 免责类型 表UserException
    /// </summary>

    public enum ExceptionsType : int
    {
        /// <summary>
        /// 临证参考免责类型
        /// </summary>
        临证参考=1,
        经典方剂 = 2
    }
}
