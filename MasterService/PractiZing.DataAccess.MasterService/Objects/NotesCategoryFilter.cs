using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class NotesCategoryFilter : INotesCategoryFilter
    {
        [SearchField(Name = NotesCategoryFilterModel.CategoryName)]
        public string CategoryName { get; set; }

        [SearchField(Name = NotesCategoryFilterModel.ParentID)]
        public int? ParentID { get; set; }

        [SearchField(Name = NotesCategoryFilterModel.DefaultNote)]
        public string DefaultNote { get; set; }

        [SearchField(Name = NotesCategoryFilterModel.HasFollowUp)]
        public bool? HasFollowUp { get; set; }

        [SearchField(Name = NotesCategoryFilterModel.FollowUpPeriod)]
        public string FollowUpPeriod { get; set; }
    }

    public class NotesCategoryFilterModel
    {
        public const string TableName = "NotesCategory";
        public const string CategoryName = TableName + "." + "CategoryName";
        public const string ParentID = TableName + "." + "ParentID";
        public const string DefaultNote = TableName + "." + "DefaultNote";
        public const string HasFollowUp = TableName + "." + "HasFollowUp";
        public const string FollowUpPeriod = TableName + "." + "FollowUpPeriod";
    }
}
