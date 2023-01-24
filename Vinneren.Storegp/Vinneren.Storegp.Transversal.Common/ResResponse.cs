using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Vinneren.Storegp.Transversal.Common
{
    //=================================================================================================================  
    public class ResResponse<T>
    {
        //-------------------------------------------------------------------------------------------------------------
        //                                                  //INSTANCE VARIABLES.

        private Status Status { get; }

        public int intStatus { get { return this.Status.intStatus; } 
            set { this.Status.intStatus = value; } }
        public String strUserMessage { get { return this.Status.strUserMessage; }
            set { this.Status.strUserMessage = value; } }
        public String strDevMessage { get { return this.Status.strDevMessage; } 
            set { this.strDevMessage = value; } }
        public T Data { get; set; }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //DYNAMIC VARIABLES.

        //                                                  //boolIsSuccess
        private bool boolIsSuccess_Z;
        public bool boolIsSuccess
        {
            get
            {
                this.subGetboolIsSuccess(
                    out boolIsSuccess_Z);
                return boolIsSuccess_Z;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //SUPPORT METHODS TO DYNAMIC VARIABLES.
        
        //--------------------------------------------------------------------------------------------------------------
        private void subGetboolIsSuccess(
            //                                              //Get boolIsSuccess.

            out bool boolIsSuccess_O
            )
        {
            boolIsSuccess_O = this.intStatus == 200 ? true : false;
        }

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.

        //-------------------------------------------------------------------------------------------------------------
        public ResResponse(
            Status st_I,
            T data_I
            )
        {
            this.Status = st_I;
            this.Data = data_I;
        }

        //-------------------------------------------------------------------------------------------------------------
        public ResResponse(
            Status st_I
            )
        {
            this.Status = st_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //ACCESS METHODS.
        public void setException(
            String strException_I
            )
        {
            this.Status.subSetExceptionError(strException_I);
        }

        //-------------------------------------------------------------------------------------------------------------
    }
}
