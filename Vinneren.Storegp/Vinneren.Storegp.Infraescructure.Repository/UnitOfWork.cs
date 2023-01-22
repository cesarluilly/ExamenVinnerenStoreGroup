using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 22, 2023. 
namespace Vinneren.Storegp.Infraescructure.Repository
{
    //==================================================================================================================
    public class UnitOfWork : IUnitOfWork
    {
        private VinnContext _context;
        private Object _dbContextTransaction;

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTOR.
        public UnitOfWork(VinnContext context)
        {
            _context = context;
        }
    }
}
