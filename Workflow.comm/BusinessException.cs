/***********************************
 * 目的：同意构造接口返回的异常信息
 * 创建人：Author
 * 创建时间：208.04.22 13:26
 * 修改人;
 * 修改目的：
 * 修改时间
 * 修改结果：
 ***********************************/

using Microsoft.AspNetCore.Mvc.Filters;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Workflow.comm
{
    public class BusinessException : Exception
    {
        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
        }

        private string _message;
        public override string Message
        {
            get
            {
                return _message;
            }
        }
        private string _data;
        public  string data
        {
            get
            {
                return _data;
            }
        }

        public BusinessException(string message)
            : base(message)
        {
            _message = message;
        }

        public BusinessException(string code, string message)
            : base("[" + code + "]" + message)
        {
            _code = code;
            _message = message;
        }
        public BusinessException(string code, string message, string data)
            : base("[" + code + "]" + "[" + message + "]" + data)
        {
            _code = code;
            _message = message;
            _data = data;
        }

        public static readonly string NotMyTask = "当前单据状态已发生改变!";

        public static readonly string ApproverIsEmpty = "下一步审批人为空!";

        public static readonly string ForbidCallback = "任务已被处理, 不可撤回!";


        /// <summary>
        /// 任务已处理
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string TaskAlreadyHandled(string oper)
        {
            return string.Format("当前任务已被{0}处理!", oper);
        }

        /// <summary>
        /// 主数据没有找到
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string NotFound(object id)
        {
            if (id != null)
                return string.Format("未查询到数据<ID:{0}>!", id);

            return string.Format("未查询到数据!");
        }

        /// <summary>
        /// 步骤没有找到
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string StepNotFound(object id)
        {
            if (id != null)
                return string.Format("未查询到步骤数据<ID:{0}>!", id);

            return string.Format("未查询到步骤数据!");
        }

        /// <summary>
        /// 反序列化失败
        /// </summary>
        /// <param name="modalName"></param>
        /// <returns></returns>
        public static string DeserializeFail(string modalName = "")
        {
            return string.Format("反序列化模型<{0}>失败!", modalName);
        }

        /// <summary>
        /// 流程禁止提交
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string Forbid(string state)
        {
            return string.Format("当前流程状态<{0}>, 无法执行操作!", state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="acceptName"></param>
        /// <returns></returns>
        public static string CannotOperate(string nodeName, int accept)
        {
            return string.Format("当前流程<{0}>无法执行<{1}>操作!", nodeName, 0 == accept ? "拒绝" : (1 == accept ? "提交" : (2 == accept ? "撤回" : "")));
        }

        #region ##Actitviti

        /// <summary>
        /// Activiti多次启动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ActivitiStarted(int processInstanceId)
        {
            return string.Format("Activiti流程<processInstanceId:{0}>已启动!", processInstanceId);

        }

        /// <summary>
        /// Activiti未找到
        /// </summary>
        /// <param name="processInstanceId"></param>
        /// <returns></returns>
        public static string ActivitiNotFound(string processInstanceId)
        {
            return string.Format("Activiti流程<processInstanceId:{0}>不存在!", processInstanceId);
        }

        /// <summary>
        /// Activiti启动失败
        /// </summary>
        /// <param name="key">流程KEY</param>
        /// <returns></returns>
        public static string ActivitiStartFail(string processInstancekey)
        {
            return string.Format("Activiti流程<processInstancekey: {0}>启动失败!", processInstancekey);
        }

        /// <summary>
        /// 处理失败
        /// </summary>
        /// <param name="dataId">节点ID</param>
        /// <returns></returns>
        public static string ActivitiHandleFail(string taskId)
        {
            return string.Format("Activiti流程<taskId: {0}>任务处理失败!", taskId);
        }

        /// <summary>
        /// 撤回失败
        /// </summary>
        /// <param name="dataId">节点ID</param>
        /// <returns></returns>
        public static string ActivitiCallbackFail(string taskId)
        {
            return string.Format("Activiti流程<taskId: {0}>任务回滚失败!");
        }

        /// <summary>
        /// 确认用户失败
        /// </summary>
        /// <returns></returns>
        public static string ActivitiEnsureUserFail()
        {
            return string.Format("Activiti确认用户异常!");
        }

        #endregion

        #region ##流程配置

        public static string WorkflowInfoNotFound(string key)
        {
            return string.Format("未查询到流程<{0}>的相关信息!", key);
        }

        public static string NodeInfoNotFound(string key)
        {
            return string.Format("未查询到流程节点<{0}>的相关信息!", key);
        }

        public static string AcceptInfoNotFound(string nodeCode, int accept)
        {
            return string.Format("未查询到流程节点<{0}>的操作<{1}>相关信息!", nodeCode, accept);
        }

        #endregion

        #region ##待办, 待阅

        public static string PendingNotFound(string actor)
        {
            //return string.Format("未查询到此用户<{0}>的待办事项或已被处理!", actor);
            return string.Format("该事项已被处理或撤回!", actor);
        }

        public static string PendingMuti(string actor)
        {
            return string.Format("此用户<{0}>存在多条待办!", actor);
        }

        #endregion

        #region 增/删/改/查
        /// <summary>
        /// 查
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string QueryException(string key)
        {
            return string.Format("未查询到当前{0}的信息!", key);
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string UpdateException(string key = null)
        {
            if (key == null)
                return string.Format("修改当前数据失败!");
            else
                return string.Format("修改当前{0}的数据失败!", key);
        }
        /// <summary>
        ///增
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string InsertException(string key)
        {
            return string.Format("新增{0}数据失败!", key);
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DeleteException(string key = null)
        {
            if (key == null)
                return string.Format("删除当前数据失败!可能已被删除!");
            else
                return string.Format("删除当前{0}的数据失败!可能已被删除!", key);
        }
        #endregion

        #region ##附件

        public static string AttachmentGetFailure(string msg = "")
        {
            return string.Format("获取附件失败{0}{1}!", "" == msg ? "" : ",", msg);
        }

        public static string AttachmentSaveFailure(string msg = "")
        {
            return string.Format("保存附件数据失败{0}{1}!", "" == msg ? "" : ",", msg);
        }

        public static string AttachmentUploadFailure(string msg = "")
        {
            return string.Format("上传附件失败{0}{1}!", "" == msg ? "" : ",", msg);
        }

        public static string AttachmentReuploadFailure(string msg = "")
        {
            return string.Format("重新上传附件失败{0}{1}!", "" == msg ? "" : ",", msg);
        }

        #endregion
    }
}
