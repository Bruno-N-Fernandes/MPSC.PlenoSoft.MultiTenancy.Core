using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.MultiTenancy.Core.DataScripts
{
    public static class ScriptExtension
	{
        public static IEnumerable<String> SplitInGO(this String source) => source.Split("\r\nGO\r\n", StringSplitOptions.RemoveEmptyEntries).Select(cmd => cmd.Trim());

        public static String ObterCreateDatabase(String databaseName) => ObterCreateDatabase(@"D:\MsSqlServer", databaseName);

        public static String ObterCreateDatabase(String fullPath, String databaseName) => $@"
Create Database [{databaseName}] Containment = None On Primary
    (Name = N'{databaseName}'    , FileName = N'{fullPath}\{databaseName}.mdf', Size = 8192KB, FileGrowth = 65536KB)
Log On
    (Name = N'{databaseName}_log', FileName = N'{fullPath}\{databaseName}.ldf', Size = 8192KB, FileGrowth = 65536KB);
GO
USE [{databaseName}];
GO
Alter Database [{databaseName}] Set Compatibility_Level = 140 ;
GO
Alter Database [{databaseName}] Set Ansi_Null_Default Off ;
GO
Alter Database [{databaseName}] Set Ansi_Nulls Off ;
GO
Alter Database [{databaseName}] Set Ansi_Padding Off ;
GO
Alter Database [{databaseName}] Set Ansi_Warnings Off ;
GO
Alter Database [{databaseName}] Set Arithabort Off ;
GO
Alter Database [{databaseName}] Set Auto_Close Off ;
GO
Alter Database [{databaseName}] Set Auto_Shrink Off ;
GO
Alter Database [{databaseName}] Set Auto_Create_Statistics On (Incremental = Off) ;
GO
Alter Database [{databaseName}] Set Auto_Update_Statistics On ;
GO
Alter Database [{databaseName}] Set Cursor_Close_On_Commit Off ;
GO
Alter Database [{databaseName}] Set Cursor_Default Global ;
GO
Alter Database [{databaseName}] Set Concat_Null_Yields_Null Off ;
GO
Alter Database [{databaseName}] Set Numeric_Roundabort Off ;
GO
Alter Database [{databaseName}] Set Quoted_Identifier Off ;
GO
Alter Database [{databaseName}] Set Recursive_Triggers Off ;
GO
Alter Database [{databaseName}] Set Disable_Broker ;
GO
Alter Database [{databaseName}] Set Auto_Update_Statistics_Async Off ;
GO
Alter Database [{databaseName}] Set Date_Correlation_Optimization Off ;
GO
Alter Database [{databaseName}] Set Parameterization Simple ;
GO
Alter Database [{databaseName}] Set Read_Committed_Snapshot Off ;
GO
Alter Database [{databaseName}] Set Read_Write ;
GO
Alter Database [{databaseName}] Set Recovery Full ;
GO
Alter Database [{databaseName}] Set Multi_user ;
GO
Alter Database [{databaseName}] Set Page_Verify CheckSum  ;
GO
Alter Database [{databaseName}] Set Target_Recovery_Time = 60 Seconds ;
GO
Alter Database [{databaseName}] Set Delayed_Durability = Disabled ;
GO
Alter Database Scoped Configuration Set Legacy_Cardinality_Estimation = Off ;
GO
Alter Database Scoped Configuration For Secondary Set Legacy_Cardinality_Estimation = Primary ;
GO
Alter Database Scoped Configuration Set MaxDop = 0 ;
GO
Alter Database Scoped Configuration For Secondary Set MaxDop = Primary ;
GO
Alter Database Scoped Configuration Set Parameter_Sniffing = On ;
GO
Alter Database Scoped Configuration For Secondary Set Parameter_Sniffing = Primary ;
GO
Alter Database Scoped Configuration Set Query_Optimizer_Hotfixes = Off ;
GO
Alter Database Scoped Configuration For Secondary Set Query_Optimizer_Hotfixes = Primary ;
GO
If (Not Exists (Select Name From Sys.FileGroups Where (Is_Default = 1) And (Name = N'Primary')) )
	Alter Database [{databaseName}] Modify FileGroup [Primary] Default ;
GO
";
    }
}
