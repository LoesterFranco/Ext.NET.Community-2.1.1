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
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class MenuCollectionBuilder<TParent, TParentBuilder>
         : AbstractComponentCollectionBuilder<TParent, TParentBuilder>
        where TParent : ButtonBase
        where TParentBuilder : ButtonBase.Builder<TParent, TParentBuilder>
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="builder"></param>
        public MenuCollectionBuilder(TParent owner, TParentBuilder builder) : base(owner, builder) { }


        /*  Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public virtual MenuCollectionBuilder<TParent, TParentBuilder> Add(MenuBase menu)
        {
            this.Owner.Menu.Add(menu);
            return this;
        }

		/// <summary>
		/// 
		/// </summary>
        public virtual MenuItem.Builder Add(Action<MenuItem, MenuItem.Builder> action)
        {
            MenuItem.Builder builder = new MenuItem.Builder(new MenuItem());
            action(builder.ToComponent(), builder);
            return builder;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    /// <typeparam name="TParentBuilder"></typeparam>
    public partial class MenuItemBaseMenuCollectionBuilder<TParent, TParentBuilder>
         : AbstractComponentCollectionBuilder<TParent, TParentBuilder>
        where TParent : MenuItemBase
        where TParentBuilder : MenuItemBase.Builder<TParent, TParentBuilder>
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="builder"></param>
        public MenuItemBaseMenuCollectionBuilder(TParent owner, TParentBuilder builder) : base(owner, builder) { }


        /*  Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public virtual MenuItemBaseMenuCollectionBuilder<TParent, TParentBuilder> Add(MenuBase menu)
        {
            this.Owner.Menu.Add(menu);
            return this;
        }

		/// <summary>
		/// 
		/// </summary>
        public virtual MenuItem.Builder Add(Action<MenuItem, MenuItem.Builder> action)
        {
            MenuItem.Builder builder = new MenuItem.Builder(new MenuItem());
            action(builder.ToComponent(), builder);
            return builder;
        }

        //public virtual TBuilder Items(Action<ItemsBuilder<TContainerBase, TBuilder>> action)
        //{
        //    action(new ItemsBuilder<TContainerBase, TBuilder>(this.ToControl(), this as TBuilder));
        //    return this as TBuilder;
        //}
    }
}