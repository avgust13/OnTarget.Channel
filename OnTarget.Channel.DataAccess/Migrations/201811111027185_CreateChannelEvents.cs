namespace OnTarget.Channel.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateChannelEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChannelEvents",
                c => new
                    {
                        ChannelEventId = c.Int(nullable: false, identity: true),
                        ChannelEventDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Thumbnail = c.String(),
                        EmbedUrl = c.String(),
                        DirectUrl = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ChannelEventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChannelEvents");
        }
    }
}
