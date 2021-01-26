namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssignCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignCourses",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignCourses");
        }
    }
}
