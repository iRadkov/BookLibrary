namespace BookLibDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "GenreDescription", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "GenreDescription");
        }
    }
}
