using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Helper
{
    public class UtilDB
    {
        public static Realm GetInstanceRealm()
        {
            var config = new RealmConfiguration()
            {
                SchemaVersion = 1,
                MigrationCallback = (migration, oldSchemaVersion) =>
                {

                }
            };

            var _realm = Realm.GetInstance(config);

            return _realm;
        }
    }
}