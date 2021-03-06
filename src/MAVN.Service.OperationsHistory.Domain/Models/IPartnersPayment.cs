using System;
using MAVN.Numerics;

namespace MAVN.Service.OperationsHistory.Domain.Models
{
    public interface IPartnersPayment
    {
        string PaymentRequestId { get; }

        string CustomerId { get; }

        string PartnerId { get; }

        string PartnerName { get; }

        string LocationId { get; }

        Money18 Amount { get; }

        string AssetSymbol { get; }

        DateTime Timestamp { get; }
    }
}
