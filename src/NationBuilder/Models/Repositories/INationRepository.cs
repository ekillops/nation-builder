using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Models
{
    public interface INationRepository
    {
        IQueryable<Event> Events { get; }
        IQueryable<Structure> Structures { get; }
        IQueryable<Nation> NationsIncludeRelated { get; }
        IQueryable<Nation> Nations { get; }
        IQueryable<Government> Governments { get; }
        IQueryable<ApplicationUser> Users { get; }

        //Nation Methods
        Nation Save(Nation nation);
        Nation Edit(Nation nation);
        void Remove(Nation nation);
        void DeleteAllNations();

        //Government Methods
        Government Save(Government nation);
        Government Edit(Government nation);
        void Remove(Government nation);
        void DeleteAllGovernments();

        //Structure Methods
        Structure Save(Structure nation);
        Structure Edit(Structure nation);
        void Remove(Structure nation);
        void DeleteAllStructures();

        //Event Methods
        Event Save(Event nation);
        Event Edit(Event nation);
        void Remove(Event nation);
        void DeleteAllEvents();
    }
}
