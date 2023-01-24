using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Domain.Entity.ByTable;
using Vinneren.Storegp.Infraescructure.Interface;

namespace Vinneren.Storegp.Domain.Bso.BusinessClass
{
	//==================================================================================================================
	//                                                      //Responsabilidad: Proporciona propiedades y comportamientos 
	//                                                      //   para el objeto.   
	public class CategoryBso :
		BsoBusinessObject,
		ICategory
	{
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.
        public int Pk { get {return this.CategoryEntity_Z.Pk; } set {this.CategoryEntity_Z.Pk = value; } }
        public string? Name { get {return this.CategoryEntity_Z.Name; } set {this.CategoryEntity_Z.Name = value; } }
        public int Id { get { return this.CategoryEntity_Z.Id; } set { this.CategoryEntity_Z.Id = value; } }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //                                                  //Category
        private CategoryEntity CategoryEntity_Z;
		public CategoryEntity CategoryEntity 
		{
			get
			{
				return CategoryEntity_Z;
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
        public CategoryBso(
			CategoryEntity Category_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			) : base(Category_I, unitOfWork_I, boolAsTracking_I)
		{
			//                                              //Assig data related to Dto.
			this.CategoryEntity_Z = Category_I; 					

			//                                              //Inject dependences.

		}

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //TRANSFORMATION METHODS.

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //ACCESS METHODS.

		//--------------------------------------------------------------------------------------------------------------
		public static CategoryBso categoryAddToDB(

            ICategory dto_I,
            IMapper mapper_I,
            IUnitOfWork unitOfWork_M,
			bool boolSaveChanges_I = true
			)
		{
			CategoryEntity entity =
            mapper_I.Map<CategoryEntity>(dto_I);

			unitOfWork_M.CategoryRepo.AddOne(entity, boolSaveChanges_I);

            return new CategoryBso(entity, unitOfWork_M, true);
		}

		//--------------------------------------------------------------------------------------------------------------
		public static CategoryBso categoryFromDB(

			int intPk_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			CategoryBso bso = null;

			IQueryable<CategoryEntity> iqy = unitOfWork_I.CategoryRepo.GetOneByPk(intPk_I);
			CategoryEntity entity;

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
				bso = new CategoryBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static CategoryBso categoryFromIQueryable(

			IQueryable<CategoryEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			CategoryBso bso = null;

			CategoryEntity entity;

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
				bso = new CategoryBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static List<CategoryBso> darrcategoryFromIQueryable(

			IQueryable<CategoryEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			List<CategoryEntity> darrentity = new List<CategoryEntity>(); ;

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

			List<CategoryBso> darrbso = darrentity.Select(entity => new CategoryBso(entity,
					unitOfWork_I, boolAsTracking_I)).ToList();

			return darrbso;
		}
	}

	//==================================================================================================================
}
