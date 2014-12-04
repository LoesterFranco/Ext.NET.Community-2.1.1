/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.1.1 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.Web.Mvc;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class RestResult : ActionResult
    {
        private bool success;
        private string msg;
        private object data;

        /// <summary>
        /// 
        /// </summary>
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Data
        {
            get { return data; }
            set { data = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            Response response = new Response(true);
            response.Success = this.Success;
            response.Message = this.Message;
            response.Data = JSON.Serialize(this.Data);

            response.Return();
        }
    }
}
