#region LICENSE

// Unless explicitly acquired and licensed from Licensor under another
// license, the contents of this file are subject to the Reciprocal Public
// License ("RPL") Version 1.5, or subsequent versions as allowed by the RPL,
// and You may not copy or use this file in either source code or executable
// form, except in compliance with the terms and conditions of the RPL.
// 
// All software distributed under the RPL is provided strictly on an "AS
// IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, AND
// LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
// LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RPL for specific
// language governing rights and limitations under the RPL.

#endregion

using System.Collections.Generic;
using System.Text;
using HQ.Lingo.Descriptor;

namespace HQ.Lingo.Dialects
{
    public interface ISqlDialect
    {
        char? StartIdentifier { get; }
        char? EndIdentifier { get; }
        char? Separator { get; }
        char? Parameter { get; }
        char? Quote { get; }

        string SetSuffix { get; }
        bool SelectStar { get; }

        bool TryFetchInsertedKey(FetchInsertedKeyLocation location, out string sql);
        void Page(string sql, StringBuilder sb);

        string ResolveTableName(IDataDescriptor descriptor);
        string ResolveColumnName(IDataDescriptor descriptor, string columnName);
        IEnumerable<string> ResolveKeyNames(IDataDescriptor descriptor);
        IEnumerable<string> ResolveColumnNames(IDataDescriptor descriptor, ColumnScope scope = ColumnScope.All);
    }
}
