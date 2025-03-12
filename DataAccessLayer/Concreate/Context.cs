using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class Context: DbContext
    {
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MemberTitle> MemberTitles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
