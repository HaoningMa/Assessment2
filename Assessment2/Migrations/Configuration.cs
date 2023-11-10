namespace Assessment2.Migrations
{
    using Assessment2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assessment2.Data.Assessment2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Assessment2.Data.Assessment2Context";
        }

        protected override void Seed(Assessment2.Data.Assessment2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            var area = new List<Area>
            {
                new Area {Name = "Xian"},
                new Area {Name = "Sichuan"},
                new Area {Name = "Guizhou"},        
                new Area {Name = "Tianjin"}
            };
            area.ForEach(c => context.Areas.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var customer = new List<Custom>
            {
                new Custom{Name = "Andy",Address="Chengting",PlaceID=area.Single(c=>c.Name=="Xian").ID},
                new Custom{Name = "Annie",Address="Kinghsien",PlaceID=area.Single(c=>c.Name=="Tianjin").ID},
                new Custom{Name = "Ashbur",Address="Yenan",PlaceID=area.Single(c=>c.Name=="Sichuan").ID},
                new Custom{Name = "Acker",Address="Shensi",PlaceID=area.Single(c=>c.Name=="Sichuan").ID},
                new Custom{Name = "Alma",Address="Tainan",PlaceID=area.Single(c=>c.Name=="Guizhou").ID},
                new Custom{Name = "Abbott",Address="Kweilin",PlaceID=area.Single(c=>c.Name=="Tianjin").ID},
            };
            customer.ForEach(c => context.Customs.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}
