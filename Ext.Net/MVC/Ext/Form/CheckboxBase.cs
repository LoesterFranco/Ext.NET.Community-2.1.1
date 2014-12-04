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
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ext.Net.Utilities;
using Ext.Net.MVC;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class CheckboxBase
    {
        protected override void OnMetadataProcess(ModelMetadata meta, string name, ViewDataDictionary viewData, ControllerContext context)
        {
            base.OnMetadataProcess(meta, name, viewData, context);

            if (meta.AdditionalValues.ContainsKey(AbstractValidationAttribute.KEY))
            {
                ValidationCollection validations = (ValidationCollection)meta.AdditionalValues[AbstractValidationAttribute.KEY];

                AbstractValidation required = validations.FirstOrDefault(v => v is PresenceValidation);
                
                if (required != null)
                {
                    this.UncheckedValue = "false";
                }
            }
        }

        protected override void SetModelValue(object value)
        {            
            if (value != null)
            {
                this.InputValue = "true";                

                if (value is bool)
                {
                    this.Checked = (bool)Convert.ChangeType(value, typeof(bool));
                }
                else
                {
                    this.Checked = String.Equals(this.Name, value.ToString(), StringComparison.Ordinal);
                }
            }
        }

        protected override void SetModelValidationRule(ModelClientValidationRule rule)
        {
            base.SetModelValidationRule(rule);

            switch (rule.ValidationType)
            {
                case "required":
                    //this.GetErrors.Handler = "return this.getValue() ? [] : [" + JSON.Serialize(rule.ErrorMessage) + "];";
                    this.UncheckedValue = "false";
                    break;
            }
        }
    }
}