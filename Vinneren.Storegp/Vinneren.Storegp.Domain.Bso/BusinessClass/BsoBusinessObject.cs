using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Infraescructure.Interface;

namespace Vinneren.Storegp.Domain.Bso.BusinessClass
{
    //==================================================================================================================
    //                                                      //Responsabilidad: Proveer metodos comunes de clases de  
    //                                                      //   negocio.
    //                                                      //It provide properties and behaviors to class BSO
    public abstract class BsoBusinessObject
    {
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.

        //                                                  //Context
        protected IUnitOfWork _unitOfWork_Z;

        //                                                  //DBSet to contain the entity.
        public object entity { get { return this.entity_Z; } }
        protected object entity_Z;

        //                                                  //AsTracking
        public bool boolAsTracking { get { return boolAsTracking_Z; } }
        protected bool boolAsTracking_Z;

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //SUPPORT METHODS TO DYNAMIC VARIABLES.

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.

        //--------------------------------------------------------------------------------------------------------------
        public BsoBusinessObject(
            object entity_I,
            IUnitOfWork _unitOfWork_Z,
            bool boolAsTracking_I
            )
        {
            this._unitOfWork_Z = _unitOfWork_Z;
            this.boolAsTracking_Z = boolAsTracking_I;
            this.entity_Z = entity_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //TRANSFORMATION METHODS.

        //--------------------------------------------------------------------------------------------------------------
        public void subUpdateAtDB(

            bool boolSaveChanges_I = true
            )
        {
            _unitOfWork_Z.context.Update(this.entity_Z);

            if (boolSaveChanges_I)
                _unitOfWork_Z.context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //ACCESS METHODS.

        //--------------------------------------------------------------------------------------------------------------
        public void subDeleteAtDB(

            bool boolSaveChanges_I = true
            )
        {
            _unitOfWork_Z.context.Remove(this.entity_Z);

            if (boolSaveChanges_I)
                _unitOfWork_Z.context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSaveChanges(

            )
        {
            _unitOfWork_Z.context.SaveChanges();
        }
    }

    //==================================================================================================================
}
