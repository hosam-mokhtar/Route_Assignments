using EF_Core.Data;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace EF_Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region   1.make a mapping for this schema(code first).
            //Notes:-
            //1.Don’t make relations between tables(create tables only).
            //2.Use all ways of mapping(create a table using convention and another using fluent APIS and so on... ).

            #region Option 01
            //ItiDbContext itiDb = new ItiDbContext();
            //try
            //{
            //Some Code
            //}
            //finally
            //{
            //itiDb.Dispose();
            //}
            #endregion

            #region Option 02
            //using (ItiDbContext itiDb = new ItiDbContext())
            //{

            //}
            #endregion

            #region Option 03
            using ItiDbContext itiDb = new ItiDbContext();
            #endregion

            #endregion

        }
    }
}
