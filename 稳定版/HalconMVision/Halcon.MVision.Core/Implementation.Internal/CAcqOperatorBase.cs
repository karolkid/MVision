﻿//Halcon.MVision.Implementation.Internal.CAcqOperatorBase
using System;
using System.Collections;
using HalconDotNet;


//**********************************************
//文件名：CAcqOperatorBase
//命名空间：Halcon.MVision.Core.Implementation.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：相机操作基类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/11/22 15:06:38
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace Halcon.MVision.Implementation.Internal
{
    public class CAcqOperatorBase : IAcqOperatorBase
    {

        #region 构造函数

        public CAcqOperatorBase()
        {

        }



        #endregion


        #region 属性



        #endregion

        #region 公共方法

        /// <summary>
        /// 获取设备参数
        /// </summary>
        /// <param name="deviceHanlde">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        public virtual HTuple GetParam(HTuple deviceHanlde, HTuple paramName)
        {
            if (deviceHanlde.TupleEqual(null)) throw new NullReferenceException("设备句柄为空");
            HTuple hv_HalconError;
            hv_HalconError = 2;
            HTuple param = new HTuple();
            try
            {
                HOperatorSet.GetFramegrabberParam(deviceHanlde, paramName, out param);
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
            }
            return param;
        }

        /// <summary>
        /// 获取相机参数范围
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名称</param>
        /// <returns></returns>
        public virtual HTuple GetParamRange(HTuple deviceHandle, HTuple paramName)
        {
            if (deviceHandle.TupleEqual(null)) throw new NullReferenceException("设备句柄为空！");
            HTuple hv_HalconError;
            hv_HalconError = 2;
            HTuple param = new HTuple();
            try
            {
                HOperatorSet.GetFramegrabberParam(deviceHandle, new HTuple(paramName.S + "_range"), out param);
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
            }
            return param;
        }

        /// <summary>
        /// 获取相机参数最大值
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        public virtual HTuple GetParamRangeMax(HTuple deviceHandle, HTuple paramName)
        {
            if (deviceHandle.TupleEqual(null)) throw new NullReferenceException("设备句柄为空");
            HTuple hv_HalconError;
            hv_HalconError = 2;
            HTuple param = new HTuple();
            try
            {
                HTuple tempParam;
                HOperatorSet.GetFramegrabberParam(deviceHandle, new HTuple(paramName.S + "_range"), out tempParam);
                switch (tempParam.Type)
                {
                    case HTupleType.INTEGER:
                        param = tempParam.IArr[1];
                        break;
                    case HTupleType.LONG:
                        param = tempParam.LArr[1];
                        break;
                    case HTupleType.DOUBLE:
                        param = tempParam.DArr[1];
                        break;
                    default:
                        break;
                }
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
            }
            return param;
        }

        /// <summary>
        /// 获取参数最小值
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        public virtual HTuple GetParamRangeMin(HTuple deviceHandle, HTuple paramName)
        {
            if (deviceHandle.TupleEqual(null)) throw new NullReferenceException("设备句柄为空");
            HTuple hv_HalconError;
            hv_HalconError = 2;
            HTuple param = new HTuple();
            try
            {
                HTuple tempParam;
                HOperatorSet.GetFramegrabberParam(deviceHandle, new HTuple(paramName.S + "_range"), out tempParam);
                switch (tempParam.Type)
                {
                    case HTupleType.INTEGER:
                        param = tempParam.IArr[0];
                        break;
                    case HTupleType.LONG:
                        param = tempParam.LArr[0];
                        break;
                    case HTupleType.DOUBLE:
                        param = tempParam.DArr[0];
                        break;
                    default:
                        break;
                }
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
            }
            return param;
        }

        /// <summary>
        /// 获取参数所有选项值
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        public virtual HTuple GetParamValues(HTuple deviceHandle, HTuple paramName)
        {
            if (deviceHandle.TupleEqual(null)) throw new NullReferenceException("设备句柄为空"); 
            HTuple hv_HalconError;
            hv_HalconError = 2;
            HTuple param = new HTuple();
            
            try
            {
                HOperatorSet.GetFramegrabberParam(deviceHandle, new HTuple(paramName.S + "_values"), out param);
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
            }
            return param;
        }

        /// <summary>
        /// 判断参数是否存在
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名称</param>
        /// <returns></returns>
        public bool JudgeParamExist(HTuple deviceHandle, HTuple paramName)
        {
            if (deviceHandle.TupleNotEqual(null)) throw new NullReferenceException("设备句柄为空");
            HTuple hv_halconError;
            try
            {
                HTuple names;
                HOperatorSet.GetFramegrabberParam(deviceHandle,new HTuple(""),out names);
                if (((IList)names.SArr).Contains(paramName.S))
                    return true;
                else
                    return false;
            }
            catch (HalconException e)
            {
                hv_halconError = e.GetErrorCode();
                if ((int)hv_halconError < 0)
                    throw e;                
            }
            return false;
        }

        /// <summary>
        /// 设置相机参数
        /// </summary>
        /// <param name="deviceHandle">设备句柄</param>
        /// <param name="paramName">参数名</param>
        /// <param name="param">参数值</param>
        /// <returns></returns>
        public virtual bool SetParam(HTuple deviceHandle, HTuple paramName, HTuple param)
        {
            if (deviceHandle.TupleEqual(null)) throw new NullReferenceException("设备句柄为空");
            HTuple hv_HalconError;
            hv_HalconError = 2;
            try
            {
                HOperatorSet.SetFramegrabberParam(deviceHandle, paramName, param);
                return true;
            }
            catch (HalconException e)
            {
                hv_HalconError = e.GetErrorCode();
                if ((int)hv_HalconError < 0)
                    throw e;
            }
            return false;
        }

        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
