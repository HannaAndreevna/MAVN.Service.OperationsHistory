﻿using System.Collections;
using System.Collections.Generic;

namespace MAVN.Service.OperationsHistory.Domain.Models
{
    public class PaginatedSmartVoucherPaymentsHistory : BasePagedModel
    {
        public IEnumerable<ISmartVoucherPayment> SmartVoucherPaymentsHistory { get; set; }
    }
}
