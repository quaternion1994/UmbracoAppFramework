using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace testumbracocontactform.DataAccess.Entities
{
    [TableName("messagesCustomTable")]
    [PrimaryKey("Id", autoIncrement = true)]
    [ExplicitColumns]
    public class MessageDto
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("Name")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Length(1000)]
        public string Name { get; set; }

        [Column("Email")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Length(1000)]
        public string Email { get; set; }

        [Column("Phone")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Length(1000)]
        public string Phone { get; set; }

        [Column("Message")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Length(1000)]
        public string Message { get; set; }


        [Column("Subject")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string Subject { get; set; }

        [Column("Date")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public DateTime Date { get; set; }


        [Column("MessageStatus")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        public int MessageStatus { get; set; }
    }
}
