using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace nhibernate_glimpse_real_time_sql.Models
{
    public class Client
    {
        public virtual Guid Guid { get; set; }
        public virtual string Uri { get; set; }
    }

    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(x => x.Guid, "CliendGuid");
            Map(x => x.Uri, "ClientUri");
            Table("Clients");
        }
    }
}