using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApi.Repositories
{
    public class Comments
    {
        public void InsertInfo(Models.InformationView Comment)

        {

            using (DbconnectionContext context = new DbconnectionContext())

            {

                context.Comment.Add(Comment);

                context.SaveChanges();

            }

        }

        public IEnumerable<Models.InformationView> ListInfo()

        {

            using (DbconnectionContext context = new DbconnectionContext())

            {
                var listofcomments = from Comments in context.Comment
                                     select Comments;

                return listofcomments;
            }
        }
    }
}