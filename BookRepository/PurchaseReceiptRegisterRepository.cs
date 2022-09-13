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
    public class PurchaseReceiptRegisterRepository : IPurchaseReceiptRegisterRepository
    {
        private readonly DataContext context;
        public PurchaseReceiptRegisterRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<PurchaseReceiptRegister> CreatePurchaseReceiptRegisterAsync(PurchaseReceiptRegisterVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new PurchaseReceiptRegister
            {
                PurchaseReceiptRegisterId = model.purchaseReceiptRegisterId,
                SupplierId = model.supplierId,
                PurchaseOrderId = model.purchaseOrderId,
                GoodReceiptNoteNumber = model.goodReceiptNoteNumber,
                ReceiptDate = model.receiptDate,
                ReceiptTime = model.receiptTime,
                TransportCompany = model.transportCompany,
                VehicleNumber = model.vehicleNumber,
                DriverName = model.driverName,
                ReceiptStatusId = model.receiptStatusId,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.PurchaseReceiptRegister.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new PurchaseReceiptRegister();
        }

        public async Task<bool> DeletePurchaseReceiptRegister(int purchaseReceiptRegisterId)
        {
            var exist = await context.PurchaseReceiptRegister.FindAsync(purchaseReceiptRegisterId);

            if (exist == null) throw new Exception("No Record Found!");

            context.PurchaseReceiptRegister.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<PurchaseReceiptRegisterVM> GetPurchaseReceiptRegister(int purchaseReceiptRegisterId, int tenantId)
        {
            return await (from x in context.PurchaseReceiptRegister
                          where x.PurchaseReceiptRegisterId == purchaseReceiptRegisterId
                                && x.TenantId == tenantId
                          select new PurchaseReceiptRegisterVM
                          {
                              purchaseReceiptRegisterId = x.PurchaseReceiptRegisterId,
                              supplierId = x.SupplierId,
                              purchaseOrderId = x.PurchaseOrderId,
                              goodReceiptNoteNumber = x.GoodReceiptNoteNumber,
                              receiptDate = x.ReceiptDate,
                              receiptTime = x.ReceiptTime,
                              transportCompany = x.TransportCompany,
                              vehicleNumber = x.VehicleNumber,
                              driverName = x.DriverName,
                              receiptStatusId = x.ReceiptStatusId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PurchaseReceiptRegisterVM>> GetPurchaseReceiptRegister(int tenantId)
        {
            return await (from x in context.PurchaseReceiptRegister
                          where x.TenantId == tenantId
                      //    && x.PurchaseReceiptRegisterId == purchaseReceiptRegisterId
                          select new PurchaseReceiptRegisterVM
                          {
                              purchaseReceiptRegisterId = x.PurchaseReceiptRegisterId,
                              supplierId = x.SupplierId,
                              purchaseOrderId = x.PurchaseOrderId,
                              goodReceiptNoteNumber = x.GoodReceiptNoteNumber,
                              receiptDate = x.ReceiptDate,
                              receiptTime = x.ReceiptTime,
                              transportCompany = x.TransportCompany,
                              vehicleNumber = x.VehicleNumber,
                              driverName = x.DriverName,
                              receiptStatusId = x.ReceiptStatusId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseReceiptRegisterId).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReceiptRegisterVM>> GetPurchaseReceiptRegisterById(int purchaseReceiptRegisterId, int tenantId)
        {
            return await (from x in context.PurchaseReceiptRegister
                          where x.TenantId == tenantId
                          select new PurchaseReceiptRegisterVM
                          {
                              purchaseReceiptRegisterId = x.PurchaseReceiptRegisterId,
                              supplierId = x.SupplierId,
                              purchaseOrderId = x.PurchaseOrderId,
                              goodReceiptNoteNumber = x.GoodReceiptNoteNumber,
                              receiptDate = x.ReceiptDate,
                              receiptTime = x.ReceiptTime,
                              transportCompany = x.TransportCompany,
                              vehicleNumber = x.VehicleNumber,
                              driverName = x.DriverName,
                              receiptStatusId = x.ReceiptStatusId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseReceiptRegisterId).ToListAsync();
        }

        public async Task<bool> UpdatePurchaseReceiptRegister(int purchaseReceiptRegisterId, PurchaseReceiptRegisterVM model)
        {
            var record = await context.PurchaseReceiptRegister.FindAsync(purchaseReceiptRegisterId);

            if (record == null) throw new Exception("No Record Found!");

           
            record.SupplierId = model.supplierId;
            record.PurchaseOrderId = model.purchaseOrderId;
            record.GoodReceiptNoteNumber = model.goodReceiptNoteNumber;
            record.ReceiptDate = model.receiptDate;
            record.ReceiptTime = model.receiptTime;
            record.TransportCompany = model.transportCompany;
            record.VehicleNumber = model.vehicleNumber;
            record.DriverName = model.driverName;
            record.ReceiptStatusId = model.receiptStatusId;
            record.DateRegistered = DateTime.Now;
                     record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






