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
    /// <summary>
    /// 
    /// </summary>
    public partial class Container
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TContainer, TBuilder> : AbstractContainer.Builder<TContainer, TBuilder>
            where TContainer : Container
            where TBuilder : Builder<TContainer, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TContainer component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ContainerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ContainerDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Container.Builder<Container, Container.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Container()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Container component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Container.Config config) : base(new Container(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Container component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Container.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Container(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Container.Builder Container()
        {
#if MVC
			return this.Container(new Container { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Container(new Container());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Container.Builder Container(Container component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Container.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Container.Builder Container(Container.Config config)
        {
#if MVC
			return new Container.Builder(new Container(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Container.Builder(new Container(config));
#endif			
        }
    }
}