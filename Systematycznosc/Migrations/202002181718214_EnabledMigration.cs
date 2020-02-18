namespace Systematycznosc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnabledMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MSreplication_options",
                c => new
                    {
                        optname = c.String(nullable: false, maxLength: 128),
                        value = c.Boolean(nullable: false),
                        major_version = c.Int(nullable: false),
                        minor_version = c.Int(nullable: false),
                        revision = c.Int(nullable: false),
                        install_failures = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.optname, t.value, t.major_version, t.minor_version, t.revision, t.install_failures });
            
            CreateTable(
                "dbo.spt_fallback_db",
                c => new
                    {
                        xserver_name = c.String(nullable: false, maxLength: 30, unicode: false),
                        xdttm_ins = c.DateTime(nullable: false),
                        xdttm_last_ins_upd = c.DateTime(nullable: false),
                        name = c.String(nullable: false, maxLength: 30, unicode: false),
                        dbid = c.Short(nullable: false),
                        status = c.Short(nullable: false),
                        version = c.Short(nullable: false),
                        xfallback_dbid = c.Short(),
                    })
                .PrimaryKey(t => new { t.xserver_name, t.xdttm_ins, t.xdttm_last_ins_upd, t.name, t.dbid, t.status, t.version });
            
            CreateTable(
                "dbo.spt_fallback_dev",
                c => new
                    {
                        xserver_name = c.String(nullable: false, maxLength: 30, unicode: false),
                        xdttm_ins = c.DateTime(nullable: false),
                        xdttm_last_ins_upd = c.DateTime(nullable: false),
                        low = c.Int(nullable: false),
                        high = c.Int(nullable: false),
                        status = c.Short(nullable: false),
                        name = c.String(nullable: false, maxLength: 30, unicode: false),
                        phyname = c.String(nullable: false, maxLength: 127, unicode: false),
                        xfallback_low = c.Int(),
                        xfallback_drive = c.String(maxLength: 2, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => new { t.xserver_name, t.xdttm_ins, t.xdttm_last_ins_upd, t.low, t.high, t.status, t.name, t.phyname });
            
            CreateTable(
                "dbo.spt_fallback_usg",
                c => new
                    {
                        xserver_name = c.String(nullable: false, maxLength: 30, unicode: false),
                        xdttm_ins = c.DateTime(nullable: false),
                        xdttm_last_ins_upd = c.DateTime(nullable: false),
                        dbid = c.Short(nullable: false),
                        segmap = c.Int(nullable: false),
                        lstart = c.Int(nullable: false),
                        sizepg = c.Int(nullable: false),
                        vstart = c.Int(nullable: false),
                        xfallback_vstart = c.Int(),
                    })
                .PrimaryKey(t => new { t.xserver_name, t.xdttm_ins, t.xdttm_last_ins_upd, t.dbid, t.segmap, t.lstart, t.sizepg, t.vstart });
            
            CreateTable(
                "dbo.spt_monitor",
                c => new
                    {
                        lastrun = c.DateTime(nullable: false),
                        cpu_busy = c.Int(nullable: false),
                        io_busy = c.Int(nullable: false),
                        idle = c.Int(nullable: false),
                        pack_received = c.Int(nullable: false),
                        pack_sent = c.Int(nullable: false),
                        connections = c.Int(nullable: false),
                        pack_errors = c.Int(nullable: false),
                        total_read = c.Int(nullable: false),
                        total_write = c.Int(nullable: false),
                        total_errors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.lastrun, t.cpu_busy, t.io_busy, t.idle, t.pack_received, t.pack_sent, t.connections, t.pack_errors, t.total_read, t.total_write, t.total_errors });
            
            CreateTable(
                "dbo.spt_values",
                c => new
                    {
                        number = c.Int(nullable: false),
                        type = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        name = c.String(maxLength: 35),
                        low = c.Int(),
                        high = c.Int(),
                        status = c.Int(),
                    })
                .PrimaryKey(t => new { t.number, t.type });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.spt_values");
            DropTable("dbo.spt_monitor");
            DropTable("dbo.spt_fallback_usg");
            DropTable("dbo.spt_fallback_dev");
            DropTable("dbo.spt_fallback_db");
            DropTable("dbo.MSreplication_options");
        }
    }
}
