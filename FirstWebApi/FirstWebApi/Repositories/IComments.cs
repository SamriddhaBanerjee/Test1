using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebApi.Repositories
{
    interface IComments
    {
        void InsertComment(Models.InformationView Comment); //Inserting

        IEnumerable<Models.InformationView> ListofComment(); //List 
    }
}
