using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay2
{
    public class BusinessLayer
    {
        databaselayer db = new databaselayer();
        public DataTable GetAll()
        {
            return db.select("select * from Course");
        }
        public DataTable GetByID(int id)
        {
            return db.select("select * from Course where Crs_Id="+id+"");
        }

        public int Add(string name,int duration,int topicid)
        {
           return db.execute("insert into Course([Crs_Name],[Crs_Duration],[Top_Id]) VALUES('" + name + "', " + duration + ", " + topicid + ")");

        }
        public int Update(int id,string name, int duration, int topicid)
        {
            return db.execute("UPDATE [dbo].[Course] SET [Crs_Name] ='" +name + "' ,[Crs_Duration] =" + duration + " ,[Top_Id] =" + topicid + " WHERE Crs_Id=" + id + "");

        }
        public int Delete(int id)
        {
            return db.execute("delete from Course where Crs_Id=" + id + "");

        }
    }
}
