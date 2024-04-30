using LiteDB;
using RPGWriter.Repositories;
using System;

namespace RPGWriter.Services
{
    public class Service
    {
        private LiteDatabase db = new LiteDatabase(AppContext.BaseDirectory);

        public SubjectRepository SubjectRepo { get; private set; }

        public Service()
        {
            SubjectRepo = new SubjectRepository(db);
        }
    }
}
