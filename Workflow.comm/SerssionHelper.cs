using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Text;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;

  namespace Workflow.comm
{
    public class SerssionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session { get; set; }

        public SerssionHelper()
        {
            _httpContextAccessor = new HttpContextAccessor();
            _session = _httpContextAccessor.HttpContext.Session;
        }

        /// <summary>
        /// 将Mapper 写入到session
        /// </summary>
        /// <param name="mapper"></param>
        public void WriteMapper(IMapper mapper)
        {
            _session.SetString("Mapper", JsonSerializer.SerializeToString<IMapper>(mapper));
        }

        /// <summary>
        /// 获取Mapper
        /// </summary>
        /// <returns></returns>
        public IMapper GetMapper()
        {
            return JsonSerializer.DeserializeFromString<IMapper>(_session.GetString("Mapper"));
        }
    }
}
