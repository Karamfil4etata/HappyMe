﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GlobalCommon {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GlobalCommon() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HappyMe.Web.App_GlobalResources.GlobalCommon", typeof(GlobalCommon).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Невалиден имейл.
        /// </summary>
        public static string Invalid_email_address_error_generic {
            get {
                return ResourceManager.GetString("Invalid_email_address_error_generic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} трябва да е поне {2} символа..
        /// </summary>
        public static string Length_error_generic {
            get {
                return ResourceManager.GetString("Length_error_generic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Невалиден телефонен номер.
        /// </summary>
        public static string Phone_number_invalid_error_generic {
            get {
                return ResourceManager.GetString("Phone_number_invalid_error_generic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Моля въведете стойност.
        /// </summary>
        public static string Required_field_error_generic {
            get {
                return ResourceManager.GetString("Required_field_error_generic", resourceCulture);
            }
        }
    }
}
