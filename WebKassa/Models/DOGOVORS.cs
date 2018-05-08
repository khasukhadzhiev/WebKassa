//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebKassa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOGOVORS
    {
        public int ID { get; set; }
        public int ABONENT_ID { get; set; }
        public int SERVICE_ID { get; set; }
        public Nullable<int> SUPPLIER_ID { get; set; }
        public Nullable<int> SUPPLIER_DEPT { get; set; }
        public Nullable<int> MANAG_ID { get; set; }
        public string DOC_NUM { get; set; }
        public Nullable<System.DateTime> DOC_DATE { get; set; }
        public System.DateTime BDATE { get; set; }
        public Nullable<System.DateTime> EDATE { get; set; }
        public short GEN_TARIFF { get; set; }
        public short GEN_NORM { get; set; }
        public Nullable<decimal> LASTPAY { get; set; }
        public Nullable<System.DateTime> LASTPAYDATE { get; set; }
        public Nullable<decimal> LASTCHARGE { get; set; }
        public Nullable<System.DateTime> LASTCHARGEDATE { get; set; }
        public Nullable<decimal> LASTCHARGE_NORM { get; set; }
        public Nullable<decimal> LASTCHARGE_BASE { get; set; }
        public Nullable<decimal> LASTCHARGE_EXEMPTS { get; set; }
        public Nullable<decimal> LAST_SUBSIDY { get; set; }
        public Nullable<System.DateTime> LAST_SUBSIDY_DATE { get; set; }
        public Nullable<decimal> NEW_CHARGE { get; set; }
        public Nullable<decimal> NEW_CHARGE_NORM { get; set; }
        public Nullable<decimal> NEW_CHARGE_BASE { get; set; }
        public Nullable<decimal> NEW_CHARGE_EXEMPT { get; set; }
        public Nullable<decimal> NEW_CHARGE_OUT { get; set; }
        public Nullable<decimal> NEW_CHARGE_IN { get; set; }
        public Nullable<System.DateTime> NEW_CHARGE_DATE { get; set; }
        public string RESPONSIBLE { get; set; }
        public Nullable<decimal> GOROD_SALDO { get; set; }
        public Nullable<System.DateTime> GOROD_SALDO_DATE { get; set; }
        public string NOTE { get; set; }
        public decimal BALANCE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> MODIFYDATE { get; set; }
        public short IS_ACTIVE { get; set; }
        public Nullable<int> CREATEUSERID { get; set; }
        public Nullable<int> MODIFYUSERID { get; set; }
        public Nullable<decimal> PENI { get; set; }
        public decimal QUANT_SALDO { get; set; }
        public Nullable<short> EXPORT_SALDO { get; set; }
        public Nullable<decimal> AVG_POTR { get; set; }
        public string RETLG { get; set; }
        public string UDSTN { get; set; }
        public short IMPORT { get; set; }
        public short ADD_DESS { get; set; }
        public Nullable<System.DateTime> DEPOSIT_DATE { get; set; }
        public int CONTROLER_ID { get; set; }
        public Nullable<decimal> SINC_KOEF { get; set; }
        public decimal NOTUSED_SUBSIDY { get; set; }
        public Nullable<decimal> CENTS { get; set; }
        public Nullable<int> MOD_NU { get; set; }
        public Nullable<int> STOP_A { get; set; }
        public Nullable<int> TYPE_DOG { get; set; }
        public Nullable<int> COM_USHET { get; set; }
        public Nullable<int> PL_OBEM { get; set; }
        public Nullable<int> POK_CACHESTVA { get; set; }
        public Nullable<int> CONTRACTUALBASIS { get; set; }
        public string GIS_CODE { get; set; }
        public string GIS_STATUS { get; set; }
        public Nullable<int> GIS_EXPORT { get; set; }
        public Nullable<int> GIS_POK_K { get; set; }
    }
}