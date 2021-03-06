﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MAVN.Common.MsSql;
using MAVN.Service.OperationsHistory.Domain.Models;
using MAVN.Service.OperationsHistory.Domain.Repositories;
using MAVN.Service.OperationsHistory.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.OperationsHistory.MsSqlRepositories.Repositories
{
    public class SmartVoucherPaymentsRepository : ISmartVoucherPaymentsRepository
    {
        private readonly MsSqlContextFactory<OperationsHistoryContext> _contextFactory;

        public SmartVoucherPaymentsRepository(MsSqlContextFactory<OperationsHistoryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddAsync(ISmartVoucherPayment payment)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = SmartVoucherPaymentEntity.Create(payment);
                var historyEntity = TransactionHistoryEntity.CreateForSmartVoucherPayment(payment);
                
                context.SmartVoucherPayments.Add(entity);
                context.TransactionHistories.Add(historyEntity);

                await context.SaveChangesAsync();
            }
        }

        public async Task<PaginatedSmartVoucherPaymentsHistory> GetByDatesPaginatedAsync(
            DateTime dateFrom,
            DateTime dateTo,
            int skip,
            int take)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var payments = context.SmartVoucherPayments.Where(p =>
                    p.Timestamp >= dateFrom && p.Timestamp < dateTo);

                var totalCount = await payments.CountAsync();

                var result = await payments
                    .OrderBy(t => t.Timestamp)
                    .Skip(skip)
                    .Take(take)
                    .ToArrayAsync();

                return new PaginatedSmartVoucherPaymentsHistory
                {
                    SmartVoucherPaymentsHistory = result,
                    TotalCount = totalCount
                };
            }
        }
    }
}
