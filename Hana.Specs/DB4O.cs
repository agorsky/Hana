using Db4objects.Db4o;
using System.Web;
using System.IO;
using System.Reflection;
using Db4objects.Db4o.CS;

public class DB4O {
    IObjectContainer container;
    static IObjectServer server;
    static IObjectContainer GetContainer(string fileName) {
        if (server == null)
            server = Db4oClientServer
                .OpenServer(Db4oClientServer.NewServerConfiguration(), fileName, 0);
        return server.OpenClient();
    }



    public DB4O(string connectionStringName) {
        SetPath(connectionStringName);
        container = DB4O.GetContainer(_dbPath);
    }
    public DB4O() : this("ObjectStore") { }


    string _dbPath;
    void SetPath(string csName) {
        _dbPath = System.Configuration.ConfigurationManager.ConnectionStrings[csName].ConnectionString;

        //check to see if this is pointing to data directory
        //change as you need btw
        if (_dbPath.Contains("|DataDirectory|")) {

            //we know, then, that this is a web project
            //and HttpContext is hopefully not null...
            _dbPath = _dbPath.Replace("|DataDirectory|", "");
            string appDir = "";
            if (HttpContext.Current != null) {

                appDir = HttpContext.Current.Server.MapPath("~/App_Data/");
            } else {

                //this should be the "/bin" directory
                appDir = Directory.GetCurrentDirectory();

                //set to the root of the app
                appDir = appDir.Replace("\\bin\\Debug", "\\App_Data\\");
                appDir = appDir.Replace("\\bin\\Release", "\\App_Data\\");

            }
            _dbPath = Path.Combine(appDir, _dbPath);
        }

    }


    public IObjectContainer Container {
        get {
            return container;
        }
    }


}