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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ControlConverter : StringConverter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ControlConverter() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if ((context == null) || (context.Container == null))
            {
                return null;
            }

            object[] controls = this.GetControls(context.Container);

            if (controls != null)
            {
                return new TypeConverter.StandardValuesCollection(controls);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected virtual object[] GetControls(IContainer container)
        {
            ComponentCollection components = container.Components;
            ArrayList controls = new ArrayList();

            foreach (IComponent component in components)
            {
                if (component is System.Web.UI.Control)
                {
                    Control c = (Control)component;

                    if (c.ID.IsNotEmpty() && this.CheckType(c))
                    {
                        controls.Add(string.Copy(c.ID));
                    }
                }
            }

            controls.Sort(Comparer.Default);

            return controls.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual bool CheckType(Control c)
        {
            return (!this.Types.Contains(c.GetType()));
        }

        private List<Type> types;
        private List<Type> Types
        {
            get
            {
                if (this.types == null)
                {
                    this.types = new List<Type>();
                    this.types.Add(typeof(HtmlForm));
                    this.types.Add(typeof(ResourceManager));
                    this.types.Add(typeof(HtmlInputHidden));
                    this.types.Add(typeof(Hidden));
                    this.types.Add(typeof(Page));
                }

                return this.types;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}