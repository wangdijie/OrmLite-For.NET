// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

using System;
using ServiceStack.DataAnnotations;
namespace YW.Model.Entitys.YW2016
{

    /// <summary>
    /// 
    /// </summary>
    [Remark("")]
	[Alias("class_info")]
	[FromT4]
    [Serializable]
    public partial class ClassInfo : YW.Model.HasId    {

		/// <summary>  </summary>
        [Alias("id")]
        [AutoIncrement]
        public override long Id { get; set;}

		/// <summary>  </summary>
        [Alias("class_name")]
        public string ClassName { get; set;}

		/// <summary>  </summary>
        [Alias("create_time")]
        public DateTime? CreateTime { get; set;}
    }

}
#pragma warning restore 1591