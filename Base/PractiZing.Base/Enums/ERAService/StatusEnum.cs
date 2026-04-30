using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.ERAService
{
    public enum StatusEnum
    {
        FileInserted = 0,
        SendingData = 1,
        Processed = 2,
        Failed = 3
    }

    public class ClaimFolderName
    {
        public const string lucid = "Lucid-Edi";
        public const string access = "Access_Edi";
        public const string apollo = "Apollo-Edi";
        public const string unilab = "Unilab-Edi";
        public const string bt = "Beachtree-Edi";
    }

    public class ERAFolderName
    {
        public const string lucid = "PI_LUCID";
        public const string access = "PI_ACCESS";
        public const string apollo = "PI_APOLLO";
        public const string unilab = "PI_UNILAB";
        public const string bt = "PI_BEACHTREE";
    }

    public static class SettingCDConstant
    {
        public const string FolderName = "FolderName";
        public const string UserName = "ERAServiceUserName";
        public const string Password = "ERAServicePassword";
    }
}
