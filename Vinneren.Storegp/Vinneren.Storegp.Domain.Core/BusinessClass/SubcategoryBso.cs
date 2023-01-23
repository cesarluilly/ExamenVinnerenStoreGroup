using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Domain.Interface.ByTable;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;
using Vinneren.Storegp.Transversal.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Vinneren.Storegp.Domain.Core.BusinessClass
{
	//==================================================================================================================
	//                                                      //Responsabilidad: Proporciona propiedades y comportamientos 
	//                                                      //   para el objeto.   
	public class SubcategoryBso :
		BsoBusinessObject,
		ISubcategory
	{
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.
        public int Pk { get {return this.SubcategoryEntity_Z.Pk; } set {this.SubcategoryEntity_Z.Pk = value; } }
        public string? Name { get {return this.SubcategoryEntity_Z.Name; } set {this.SubcategoryEntity_Z.Name = value; } }
        public int Id { get { return this.SubcategoryEntity_Z.Id; } set { this.SubcategoryEntity_Z.Id = value; } }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //                                                  //Category
        private SubcategoryEntity SubcategoryEntity_Z;
		public SubcategoryEntity SubcategoryEntity 
		{
			get
			{
				return SubcategoryEntity_Z;
			}
		}

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES **RelationTo**.

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES **Foreign**.

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //SUPPORT METHODS TO DYNAMIC VARIABLES.

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.

        //--------------------------------------------------------------------------------------------------------------
        public SubcategoryBso(
			SubcategoryEntity Subcategory_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			) : base(Subcategory_I, unitOfWork_I, boolAsTracking_I)
		{
			//                                              //Assig data related to Dto.
			this.SubcategoryEntity_Z = Subcategory_I; 					

			//                                              //Inject dependences.

		}

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //TRANSFORMATION METHODS.

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //ACCESS METHODS.

		//--------------------------------------------------------------------------------------------------------------
		public static SubcategoryBso subcategoryAddToDB(

            ISubcategory dto_I,
			IUnitOfWork unitOfWork_M,
			bool boolSaveChanges_I = true
			)
		{
			SubcategoryEntity entity =
			AutoMapperConfig.mapper.Map<SubcategoryEntity>(dto_I);

			unitOfWork_M.SubcategoryRepo.AddOne(entity, boolSaveChanges_I);

            return new SubcategoryBso(entity, unitOfWork_M, true);
		}

		//--------------------------------------------------------------------------------------------------------------
		public static SubcategoryBso subcategoryFromDB(

			int intPk_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
            SubcategoryBso bso = null;

			IQueryable<SubcategoryEntity> iqy = unitOfWork_I.SubcategoryRepo.GetOneByPk(intPk_I);
			SubcategoryEntity entity;

			if (
				boolAsTracking_I
				)
			{
				entity = iqy.FirstOrDefault();
			}
			else
			{
				entity = iqy.AsNoTracking().FirstOrDefault();
			}

			if (
				entity != null
				)
				bso = new SubcategoryBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static SubcategoryBso subcategoryFromIQueryable(

			IQueryable<SubcategoryEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			SubcategoryBso bso = null;

			SubcategoryEntity entity;

			if (
				boolAsTracking_I
				)
			{
				entity = iqy_I.FirstOrDefault();
			}
			else
			{
				entity = iqy_I.AsNoTracking().FirstOrDefault();
			}

			if (
				entity != null
				)
				bso = new SubcategoryBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static List<SubcategoryBso> darrcategoryFromIQueryable(

			IQueryable<SubcategoryEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			List<SubcategoryEntity> darrentity = new List<SubcategoryEntity>(); ;

			if (
				boolAsTracking_I
				)
			{
				darrentity = iqy_I.ToList();
			}
			else
			{
				darrentity = iqy_I.AsNoTracking().ToList();
			}

			List<SubcategoryBso> darrbso = darrentity.Select(entity => new SubcategoryBso(entity,
					unitOfWork_I, boolAsTracking_I)).ToList();

			return darrbso;
		}
	}

	//==================================================================================================================
}
