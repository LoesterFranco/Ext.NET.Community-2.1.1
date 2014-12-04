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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class RowBody
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TRowBody, TBuilder> : GridFeature.Builder<TRowBody, TBuilder>
            where TRowBody : RowBody
            where TBuilder : Builder<TRowBody, TBuilder>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action">The action delegate</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetAdditionalData(string handler)
            {
                if(JFunction.IsFunctionName(handler))
                {
                    this.ToComponent().GetAdditionalData.Fn = handler;
                }
                else
                {
                    this.ToComponent().GetAdditionalData.Handler = handler;
                }
                
                return this as TBuilder;
            }
        }
    }
}