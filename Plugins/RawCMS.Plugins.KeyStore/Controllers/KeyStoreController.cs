﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using RawCMS.Library.Core.Attributes;
using RawCMS.Plugins.KeyStore.Model;

namespace RawCMS.Plugins.KeyStore.Controllers
{
    [AllowAnonymous]
    [RawAuthentication]
    [ApiController]
    [Route("api/[controller]")]
    public class KeyStoreController : ControllerBase
    {
        private KeyStoreService service;

        public KeyStoreController(KeyStoreService service)
        {
            this.service = service;
        }

        [HttpHead("{key}")]
        public void Get(string key)
        {
            // var content = new OkResult();
            StringValues result = new StringValues(new string[] { service.Get(key) as string });
            Response.Headers.Add("r", result);
            //return content;
        }

        [HttpPost()]
        public void Set([FromBody]KeyStoreInsertModel insert)
        {
            service.Set(insert);
        }
    }
}