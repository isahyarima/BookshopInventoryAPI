using Common.TableEnum;
using Data.TransferObject.ViewModel;
using DataModel.Models;
using Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly DataContext context;
        public PurchaseOrderRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<PurchaseOrder> CreatePurchaseOrderAsync(PurchaseOrderVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new PurchaseOrder
            {
                PurchaseOrderId = model.purchaseOrderId,
                OrderDate = model.orderDate,
                SupplierId = model.supplierId,
                OrderNumber = model.orderNumber,
                OrderValidDate = model.orderValidDate,
                TaxId = model.taxId,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.PurchaseOrder.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new PurchaseOrder();
        }


        public async Task<IEnumerable<PurchaseOrderVM>> SearchPurchaseOrderAsync(PurchaseOrderVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            model.orderDate = model.orderDate.Value.AddDays(1);

            return await (from x in context.PurchaseOrder
                          where DbFunctions.TruncateTime(x.OrderDate) == DbFunctions.TruncateTime(model.orderDate)
                          select new PurchaseOrderVM
                          {
                              purchaseOrderId = x.PurchaseOrderId,
                              orderDate = x.OrderDate,
                              supplierName = context.Supplier.Where(o => o.SupplierId == x.SupplierId).Select(o => o.SupplierName).FirstOrDefault(),
                              orderNumber = x.OrderNumber,
                              orderValidDate = x.OrderValidDate,
                              tax = context.Tax.Where(o => o.TaxId == x.TaxId).Select(o => o.TaxName).FirstOrDefault(),
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),

                          }).OrderBy(o => o.purchaseOrderId).ToListAsync();
        }

        public async Task<bool> DeletePurchaseOrder(int purchaseOrderId)
        {
            var exist = await context.PurchaseOrder.FindAsync(purchaseOrderId);

            if (exist == null) throw new Exception("No Record Found!");

            context.PurchaseOrder.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<PurchaseOrderVM> GetPurchaseOrder(int purchaseOrderId, int tenantId)
        {
            return await (from x in context.PurchaseOrder
                          where x.PurchaseOrderId == purchaseOrderId
                                && x.TenantId == tenantId
                          select new PurchaseOrderVM
                          {
                              purchaseOrderId = x.PurchaseOrderId,
                              orderDate = x.OrderDate,
                              supplierName = context.Supplier.Where(o=>o.SupplierId == x.SupplierId).Select(o=>o.SupplierName).FirstOrDefault(),
                              orderNumber = x.OrderNumber,
                              orderValidDate = x.OrderValidDate,
                              tax = context.Tax.Where(o=>o.TaxId == x.TaxId).Select(o=>o.TaxName).FirstOrDefault(),
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrder(int tenantId)
        {
            return await (from x in context.PurchaseOrder
                          where x.TenantId == tenantId
                        // && x.PurchaseOrderId == purchaseOrderId
                          select new PurchaseOrderVM
                          {
                              purchaseOrderId = x.PurchaseOrderId,
                              orderDate = x.OrderDate,
                              supplierName = context.Supplier.Where(o => o.SupplierId == x.SupplierId).Select(o => o.SupplierName).FirstOrDefault(),
                              orderNumber = x.OrderNumber,
                              orderValidDate = x.OrderValidDate,
                              tax = context.Tax.Where(o => o.TaxId == x.TaxId).Select(o => o.TaxName).FirstOrDefault(),
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseOrderId).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrderById(int purchaseOrderId, int tenantId)
        {
            return await (from x in context.PurchaseOrder
                          where x.TenantId == tenantId
                          select new PurchaseOrderVM
                          {
                              purchaseOrderId = x.PurchaseOrderId,
                              orderDate = x.OrderDate,
                              supplierName = context.Supplier.Where(o => o.SupplierId == x.SupplierId).Select(o => o.SupplierName).FirstOrDefault(),
                              orderNumber = x.OrderNumber,
                              orderValidDate = x.OrderValidDate,
                              tax = context.Tax.Where(o => o.TaxId == x.TaxId).Select(o => o.TaxName).FirstOrDefault(),
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseOrderId).ToListAsync();
        }

        public async Task<bool> UpdatePurchaseOrder(int purchaseOrderId, PurchaseOrderVM model)
        {
            var record = await context.PurchaseOrder.FindAsync(purchaseOrderId);

            if (record == null) throw new Exception("No Record Found!");

       
            record.OrderDate = model.orderDate;
            record.SupplierId = model.supplierId;
            record.OrderNumber = model.orderNumber;
            record.OrderValidDate = model.orderValidDate;
            record.TaxId = model.taxId;
            record.DateRegistered = DateTime.Now;
           
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






