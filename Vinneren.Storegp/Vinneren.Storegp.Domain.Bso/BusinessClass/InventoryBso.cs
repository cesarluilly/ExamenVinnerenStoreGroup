using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Domain.Entity.ByTable;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Vinneren.Storegp.Domain.Bso.BusinessClass
{
	//==================================================================================================================
	//                                                      //Responsabilidad: Proporciona propiedades y comportamientos 
	//                                                      //   para el objeto.   
	public class InventoryBso :
		BsoBusinessObject,
		IInventory
	{
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.

        public int Pk { get { return this._inventoryEntity_Z.Pk; } set {this._inventoryEntity_Z.Pk = value;} }
        public DateTime Date { get { return this._inventoryEntity_Z.Date; } set {this._inventoryEntity_Z.Date = value;} }
        public string? Note { get { return this._inventoryEntity_Z.Note; } set { this._inventoryEntity_Z.Note = value;} }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //                                                  //Category
        private InventoryEntity _inventoryEntity_Z;
		public InventoryEntity InventoryEntity 
		{
			get
			{
				return _inventoryEntity_Z;
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
        public InventoryBso(
			InventoryEntity Category_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			) : base(Category_I, unitOfWork_I, boolAsTracking_I)
		{
			//                                              //Assig data related to Dto.
			this._inventoryEntity_Z = Category_I; 					

			//                                              //Inject dependences.

		}

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //TRANSFORMATION METHODS.

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //ACCESS METHODS.

		//--------------------------------------------------------------------------------------------------------------
		public static InventoryBso inventoryAddToDB(

            IInventory dto_I,
            IMapper mapper_I,
            IUnitOfWork unitOfWork_M,
			bool boolSaveChanges_I = true
			)
		{
			InventoryEntity entity =
			mapper_I.Map<InventoryEntity>(dto_I);

			unitOfWork_M.InventoryRepo.AddOne(entity, boolSaveChanges_I);

            return new InventoryBso(entity, unitOfWork_M, true);
		}

		//--------------------------------------------------------------------------------------------------------------
		public static InventoryBso inventoryFromDB(

			int intPk_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			InventoryBso bso = null;

			IQueryable<InventoryEntity> iqy = unitOfWork_I.InventoryRepo.GetOneByPk(intPk_I);
			InventoryEntity entity;

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
				bso = new InventoryBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static InventoryBso inventoryFromIQueryable(

			IQueryable<InventoryEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			InventoryBso bso = null;

			InventoryEntity entity;

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
				bso = new InventoryBso(entity, unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static List<InventoryBso> darrinventoryFromIQueryable(

			IQueryable<InventoryEntity> iqy_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			List<InventoryEntity> darrentity = new List<InventoryEntity>(); ;

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

			List<InventoryBso> darrbso = darrentity.Select(entity => new InventoryBso(entity,
					unitOfWork_I, boolAsTracking_I)).ToList();

			return darrbso;
		}
	}

	//==================================================================================================================
}
