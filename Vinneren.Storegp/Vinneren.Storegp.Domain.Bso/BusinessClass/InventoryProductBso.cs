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
	public class InventoryProductBso :
		BsoBusinessObject,
		IInventoryProduct
	{
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.

        public int Pk { get {return this._InventoryProductEntity_Z.Pk; } 
			set {this._InventoryProductEntity_Z.Pk = value;} }
        public int Units { get {return this._InventoryProductEntity_Z.Units; } 
			set {this._InventoryProductEntity_Z.Units = value;} }
        public string? Note { get {return this._InventoryProductEntity_Z.Note; } 
			set {this._InventoryProductEntity_Z.Note = value;} }
        public int PkInventory { get {return this._InventoryProductEntity_Z.PkInventory; } 
			set {this._InventoryProductEntity_Z.PkInventory = value;} }
        public int PkProduct { get { return this._InventoryProductEntity_Z.PkProduct; }
			set {this._InventoryProductEntity_Z.PkProduct = value;} }


        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //                                                  //Category
        private InventoryProductEntity _InventoryProductEntity_Z;
		public InventoryProductEntity InventoryProductEntity 
		{
			get
			{
				return _InventoryProductEntity_Z;
			}
		}

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //DYNAMIC VARIABLES **RelationTo**.

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //DYNAMIC VARIABLES **Foreign**.
		//                                                  //ProductForeign
		private bool boolWasProductForeignCalculatedAux_Z;
		private ProductBso ProductForeign_Z;
		public ProductBso ProductForeign
		{
			get
			{
				this.subGetProductForeign(
					out ProductForeign_Z);
				return ProductForeign_Z;
			}
		}

		//                                                  //Inventory
		private bool boolWasInventoryForeignCalculatedAux_Z;
		private InventoryBso InventoryForeign_Z;
		public InventoryBso InventoryForeign
		{
			get
			{
				this.subGetInventoryForeign(
					out InventoryForeign_Z);
				return InventoryForeign_Z;
			}
		}

		//--------------------------------------------------------------------------------------------------------------
		private void subGetInventoryForeign(
			//                                              //Get dynamicVarNameForeign.

			out InventoryBso InventoryForeign_O
			)
		{
			InventoryForeign_O = this.InventoryForeign_Z;
			if (
				//                                          //Verify that it is false.
				this.boolWasInventoryForeignCalculatedAux_Z == false
				)
			{
				this.boolWasInventoryForeignCalculatedAux_Z = true;
				if (
					//                                      //Verify if already was inject.
					InventoryForeign_O != null
					)
				{
					if (
						//                                  //Verify if it is not the same Pk.
						InventoryForeign_O.Pk != this._InventoryProductEntity_Z.PkInventory
						)
					{
						InventoryForeign_O = null;
					}
				}

				if (
					//                                      //It has not value
					InventoryForeign_O == null &&
					//                                      //Verify if PkForeing has a value
					this._InventoryProductEntity_Z.PkInventory > 0
					)
				{
					//										//Build the instance.
					InventoryForeign_O = InventoryBso.inventoryFromDB(this._InventoryProductEntity_Z.PkInventory, 
						this._unitOfWork_Z, this.boolAsTracking);
				}
			}
		}

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //SUPPORT METHODS TO DYNAMIC VARIABLES.
        //--------------------------------------------------------------------------------------------------------------
        private void subGetProductForeign(
            //                                              //Get ProductForeign.

            out ProductBso ProductForeign_O
            )
        {
            ProductForeign_O = this.ProductForeign_Z;
            if (
                //                                          //Verify that it is false.
                this.boolWasProductForeignCalculatedAux_Z == false
                )
            {
                this.boolWasProductForeignCalculatedAux_Z = true;
                if (
                    //                                      //Verify if already was inject.
                    ProductForeign_O != null
                    )
                {
                    if (
                        //                                  //Verify if it is not the same Pk.
                        ProductForeign_O.Pk != this._InventoryProductEntity_Z.PkProduct
                        )
                    {
                        ProductForeign_O = null;
                    }
                }

                if (
                    //                                      //It has not value
                    ProductForeign_O == null &&
                    //                                      //Verify if PkForeing has a value
                    this._InventoryProductEntity_Z.PkProduct > 0
                    )
                {
                    //										//Build the instance.
                    ProductForeign_O = ProductBso.productFromDB(this._InventoryProductEntity_Z.PkProduct,
                        this._unitOfWork_Z, this.boolAsTracking_Z);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.

        //--------------------------------------------------------------------------------------------------------------
        public InventoryProductBso(
			InventoryProductEntity Category_I,
			ProductBso productForeign_I,
			InventoryBso inventoryForeign_I,
			IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			) : base(Category_I, unitOfWork_I, boolAsTracking_I)
		{
			//                                              //Assig data related to Dto.
			this._InventoryProductEntity_Z = Category_I;

			//                                              //Inject dependences.
			this.ProductForeign_Z = productForeign_I;
			this.InventoryForeign_Z = inventoryForeign_I;
        }

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //TRANSFORMATION METHODS.

		//--------------------------------------------------------------------------------------------------------------
		//                                                  //ACCESS METHODS.

		//--------------------------------------------------------------------------------------------------------------
		public static InventoryProductBso categoryAddToDB(

            IProduct dto_I,
            ProductBso productForeign_I,
            InventoryBso inventoryForeign_I,
            IMapper mapper_I,
            IUnitOfWork unitOfWork_M,
			bool boolSaveChanges_I = true
			)
		{
            InventoryProductEntity entity =
			mapper_I.Map<InventoryProductEntity>(dto_I);

			unitOfWork_M.InventoryProductRepo.AddOne(entity, boolSaveChanges_I);

            return new InventoryProductBso(entity, productForeign_I, inventoryForeign_I,
				unitOfWork_M, true);
		}

		//--------------------------------------------------------------------------------------------------------------
		public static InventoryProductBso categoryFromDB(

			int intPk_I,
            ProductBso productForeign_I,
            InventoryBso inventoryForeign_I,
            IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			InventoryProductBso bso = null;

			IQueryable<InventoryProductEntity> iqy = unitOfWork_I.InventoryProductRepo.GetOneByPk(intPk_I);
			InventoryProductEntity entity;

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
				bso = new InventoryProductBso(entity, productForeign_I, inventoryForeign_I,
					unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static InventoryProductBso categoryFromIQueryable(

			IQueryable<InventoryProductEntity> iqy_I,
            ProductBso productForeign_I,
            InventoryBso inventoryForeign_I,
            IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			InventoryProductBso bso = null;

			InventoryProductEntity entity;

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
				bso = new InventoryProductBso(entity, productForeign_I, inventoryForeign_I, 
					unitOfWork_I, boolAsTracking_I);
			return bso;
		}

		//--------------------------------------------------------------------------------------------------------------
		public static List<InventoryProductBso> darrcategoryFromIQueryable(

			IQueryable<InventoryProductEntity> iqy_I,
            ProductBso productForeign_I,
            InventoryBso inventoryForeign_I,
            IUnitOfWork unitOfWork_I,
			bool boolAsTracking_I
			)
		{
			List<InventoryProductEntity> darrentity = new List<InventoryProductEntity>(); ;

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

			List<InventoryProductBso> darrbso = darrentity.Select(entity => new InventoryProductBso(entity,
                    productForeign_I, inventoryForeign_I, unitOfWork_I, boolAsTracking_I)).ToList();

			return darrbso;
		}
	}

	//==================================================================================================================
}
