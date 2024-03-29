#region License, Terms and Conditions
//
// Jayrock - JSON and JSON-RPC for Microsoft .NET Framework and Mono
// Written by Atif Aziz (atif.aziz@skybow.com)
// Copyright (c) 2005 Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 2.1 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Jayrock.Json.Conversion.Converters
{
    #region Imports

    using System;
    using System.Diagnostics;
    using Jayrock.Diagnostics;
    using Jayrock.Json.Conversion;

    #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public sealed class EnumImporter : ImporterBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public EnumImporter(Type type) :
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            base(type)
        {
            if (!type.IsEnum)
                throw new ArgumentException(string.Format("{0} does not inherit from System.Enum.", type));
            
            if (type.IsDefined(typeof(FlagsAttribute), true))
                throw new ArgumentException(string.Format("{0} is a bit field, which are not currently supported.", type));
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override object ImportFromString(ImportContext context, JsonReader reader)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            Debug.Assert(context != null);
            Debug.Assert(reader != null);

            string s = reader.Text.Trim();
        
            if (s.Length > 0)
            {
                char ch = s[0];
            
                if (Char.IsDigit(ch) || ch == '+' || ch == '-')
                    throw Error(s, null);
            }

            try
            {
                return ReadReturning(reader, Enum.Parse(OutputType, s, true));
            }
            catch (ArgumentException e)
            {
                //
                // Value is either an empty string ("") or only contains 
                // white space. Value is a name, but not one of the named
                // constants defined for the enumeration.
                //
            
                throw Error(s, e);
            }
        }

        private JsonException Error(string s, Exception e)
        {
            return new JsonException(string.Format("The value '{0}' cannot be imported as {1}.", DebugString.Format(s), OutputType.FullName), e);
        }
    }
}