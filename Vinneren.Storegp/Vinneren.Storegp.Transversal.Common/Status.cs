using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 23, 2022. 
namespace Vinneren.Storegp.Transversal.Common
{
    //==================================================================================================================
    public class Status
    {
        public const String strGenericMessage = "Something is wrong.";
        public const String strInvalidDataMessage = "Invalid data.";

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES

        private int intStatus_Z { get; set; }
        public int intStatus
        {
            get
            {
                return this.intStatus_Z;
            }
            set { this.intStatus_Z = value;}
        }

        private String strUserMessage_Z { get; set; }
        public String strUserMessage
        {
            get
            {
                return this.strUserMessage_Z;
            }
            set
            {
                this.strUserMessage_Z = value;
            }
        }

        private String strDevMessage_Z { get; set; }
        public String strDevMessage
        {
            get
            {
                return this.strDevMessage_Z;
            }
            set
            {
                this.strDevMessage_Z = value;
            }
        }

        public bool boolStatusOk
        {
            get
            {
                return this.intStatus_Z == 200;
            }
        }
        private bool boolErrorWasSeted_Z { get; set; }
        public bool boolErrorWasSeted
        {
            get
            {
                return this.boolErrorWasSeted_Z;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //TRANSFROMATION METHODS.

        //--------------------------------------------------------------------------------------------------------------
        public void subSetUserError(
            //                                              //Dev message will be the same 

            String strUserMessage_I
            )
        {
            this.intStatus_Z = 401;
            this.strDevMessage_Z = strUserMessage_I;
            this.strUserMessage_Z = strUserMessage_I;
            this.boolErrorWasSeted_Z = true;
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSetDevError(
            //                                              //User message will be the generic "Something is wrong."

            String strDevMessage_I
            )
        {
            this.intStatus_Z = 400;
            this.strUserMessage_Z = Status.strGenericMessage;
            this.strDevMessage_Z = strDevMessage_I;
            this.boolErrorWasSeted_Z = true;
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSetDevError(
            //                                              //User message will be the generic "Something is wrong."

            String strDevMessage_I,
            int intStatus_I
            )
        {
            this.intStatus_Z = intStatus_I;
            this.strUserMessage_Z = Status.strGenericMessage;
            this.strDevMessage_Z = strDevMessage_I;
            this.boolErrorWasSeted_Z = true;
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSetStatus(
            //                                              //User message will be the generic "Something is wrong."

            String strDevMessage_I,
            String strUserMessage_I,
            int intStatus_I
            )
        {
            this.intStatus_Z = intStatus_I;
            this.strUserMessage_Z = strUserMessage_I;
            this.strDevMessage_Z = strDevMessage_I;
            this.boolErrorWasSeted_Z = (intStatus_I != 200) || (intStatus_I != 300);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSetExceptionError(
            //                                              //User message will be the generic "Something is wrong."

            String strDevMessage_I
            )
        {
            this.intStatus_Z = 499;
            this.strUserMessage_Z = Status.strGenericMessage;
            this.strDevMessage_Z = strDevMessage_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSetOk(
            //                                              //User message will be the generic "Something is wrong."

            )
        {
            this.intStatus_Z = 200;
            this.strUserMessage_Z = "";
            this.strDevMessage_Z = "";
        }

        //--------------------------------------------------------------------------------------------------------------
        public void subSetOk(
            //                                              //User message will be the generic "Something is wrong."

            String strUserMessage_I
            )
        {
            this.intStatus_Z = 200;
            this.strUserMessage_Z = strUserMessage_I;
            this.strDevMessage_Z = strUserMessage_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTOR
        private Status(
            //                                              //
            int intStatus_I,
            String strUserMessage_I,
            String strDevMessage_I
            )
        {
            this.intStatus_Z = intStatus_I;
            this.strUserMessage_Z = strUserMessage_I;
            this.strDevMessage_Z = strDevMessage_I;
            this.boolErrorWasSeted_Z = false;
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //SINGLETON

        //--------------------------------------------------------------------------------------------------------------
        public static Status stGetInitialInvalid(

            )
        {
            return new Status(400, Status.strGenericMessage, Status.strInvalidDataMessage);
        }

        //--------------------------------------------------------------------------------------------------------------
        public static Status stGetInitialOk(

            )
        {
            return new Status(200, "", "");
        }

        //--------------------------------------------------------------------------------------------------------------
        public static Status stGetForException(
            String strException_I
            )
        {
            return new Status(499, Status.strGenericMessage, strException_I);
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}
