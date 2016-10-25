using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Dal;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Services;

namespace Ioc
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mongo = new MongoClient();
            var db = "kulepool";
            var cp = new ConventionPack();
            cp.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camel case", cp, x => true);

            builder.Register(x => new StudentsRepository(mongo, db)).As<IStudentsRepository>();
            builder.RegisterType<StudentsService>().As<IStudentsService>();
        }
    }
}
