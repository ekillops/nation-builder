using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Models
{
    public class EFNationRepository : INationRepository
    {
        public NationBuilderDbContext db = new NationBuilderDbContext();

        public EFNationRepository(NationBuilderDbContext connection = null)
        {
            if (connection == null)
            {
                db = new NationBuilderDbContext();
            }
            else
            {
                db = connection;
            }
        }

        public IQueryable<Event> Events { get {return db.Events; } }
        public IQueryable<Structure> Structures { get {return db.Structures; } }
        public IQueryable<Nation> NationsIncludeRelated { get {
                return db.Nations
                    .Include(n => n.Structures)
                    .Include(n => n.Government);
            } }
        public IQueryable<Nation> Nations { get { return db.Nations; } }
        public IQueryable<Government> Governments { get {return db.Governments; } }
        public IQueryable<ApplicationUser> Users { get {return db.Users; } }


        //Nation Methods
        public Nation Save(Nation nation)
        {
            db.Nations.Add(nation);
            db.SaveChanges();
            return nation;
        }

        public Nation Edit(Nation nation)
        {
            db.Entry(nation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return nation;
        }

        public void Remove(Nation nation)
        {
            db.Nations.Remove(nation);
            db.SaveChanges();
        }

        public void DeleteAllNations()
        {
            //List<Nation> allNations = db.Nations.ToList();
            db.RemoveRange(db.Nations);
            db.SaveChanges();
        }

        //Event Methods
        public Event Save(Event nation)
        {
            db.Events.Add(nation);
            db.SaveChanges();
            return nation;
        }

        public Event Edit(Event nation)
        {
            db.Entry(nation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return nation;
        }

        public void Remove(Event nation)
        {
            db.Events.Remove(nation);
            db.SaveChanges();
        }

        public void DeleteAllEvents()
        {
            //List<Event> allEvents = db.Events.ToList();
            db.RemoveRange(db.Events);
            db.SaveChanges();
        }

        //Government Methods
        public Government Save(Government nation)
        {
            db.Governments.Add(nation);
            db.SaveChanges();
            return nation;
        }

        public Government Edit(Government nation)
        {
            db.Entry(nation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return nation;
        }

        public void Remove(Government nation)
        {
            db.Governments.Remove(nation);
            db.SaveChanges();
        }

        public void DeleteAllGovernments()
        {
            //List<Government> allGovernments = db.Governments.ToList();
            db.RemoveRange(db.Governments);
            db.SaveChanges();
        }

        //Structure Methods
        public Structure Save(Structure nation)
        {
            db.Structures.Add(nation);
            db.SaveChanges();
            return nation;
        }

        public Structure Edit(Structure nation)
        {
            db.Entry(nation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return nation;
        }

        public void Remove(Structure nation)
        {
            db.Structures.Remove(nation);
            db.SaveChanges();
        }

        public void DeleteAllStructures()
        {
            //List<Structure> allStructures = db.Structures.ToList();
            db.RemoveRange(db.Structures);
            db.SaveChanges();
        }
    }
}
