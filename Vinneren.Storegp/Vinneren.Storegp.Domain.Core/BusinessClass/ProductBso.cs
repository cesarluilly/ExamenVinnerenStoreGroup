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
	public class ProductBso :
		BsoBusinessObject,
		IProduct
	{
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.
        public int Pk { get { return this.ProductEntity.Pk ;} 
			set { this.ProductEntity.Pk = value;}}
        public string? Name { get { return this.ProductEntity.Name ;} 
			set { this.ProductEntity.Name = value;}}
        public string? NumMaterial { get { return this.ProductEntity.NumMaterial ;} 
			set { this.ProductEntity.NumMaterial = value;} }


        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //                                                  //Category
        private ProductEntity ProductEntity_Z;
		public ProductEntity ProductEntity 
		{
			get
			{
				return ProductEntity_Z;
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
        public ProductBso(
			ProductEntity Category_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			) : base(Category_I, unitOfWork_I, boolAsTracking_I)
		{
			//                                              //Assig data related to Dto.
			this.ProductEntity_Z = Category_I; 					

			//                                              //Inject dependences.

		}

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //TRANSFORMATION METHODS.

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //ACCESS METHODS.

		//--------------------------------------------------------------------------------------------------------------
		public static ProductBso categoryAddToDB(

            IProduct dto_I,
			IUnitOfWork unitOfWork_M,
			bool boolSaveChanges_I = true
			)
		{
			ProductEntity entity =
			AutoMapperConfig.mapper.Map<ProductEntity>(dto_I);

			unitOfWork_M.ProductRepo.AddOne(entity, boolSaveChanges_I);

            return new ProductBso(entity, unitOfWork_M, true);
		}

		//--------------------------------------------------------------------------------------------------------------
		public static ProductBso categoryFromDB(

			int intPk_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			ProductBso bso = null;

			IQueryable<ProductEntity> iqy = unitOfWork_I.ProductRepo.GetOneByPk(intPk_I);
			ProductEntity entity;

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
				bso = new ProductBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static ProductBso categoryFromIQueryable(

			IQueryable<ProductEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			ProductBso bso = null;

			ProductEntity entity;

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
				bso = new ProductBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static List<ProductBso> darrcategoryFromIQueryable(

			IQueryable<ProductEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			List<ProductEntity> darrentity = new List<ProductEntity>(); ;

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

			List<ProductBso> darrbso = darrentity.Select(entity => new ProductBso(entity,
					unitOfWork_I, boolAsTracking_I)).ToList();

			return darrbso;
		}
	}

	//==================================================================================================================
}
