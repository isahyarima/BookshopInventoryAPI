using Authentication.Provider;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    public interface IWrapperRepository
    {
        IActivitiesAssignedRepository ActivitiesAssigned { get; }

        IActivityRepository Activity { get; }

        IActivityTypeRepository ActivityType { get; }

        IAuditTrailRepository AuditTrail { get; }

        IAuditTrailTypeRepository AuditTrailType { get; }

        IAuthorRepository Author { get; }

        IBankRepository Bank { get; }

        IBookItemRepository Book { get; }

        ICategoryRepository Category { get; }

        ICustomerRepository Customer { get; }

        IDesignationRepository Designation { get; }

        IDocumentUploadRepository DocumentUpload { get; }

        IEmployeeRepository Employee { get; }

        IEmployeeContactRepository EmployeeContact { get; }

        ILoginActivityRepository LoginActivity { get; }

        IPublisherRepository Publisher { get; }

        IPurchaseOrderRepository PurchaseOrder { get; }

        IPurchaseOrderDetailRepository PurchaseOrderDetail { get; }

        IPurchaseReceiptRegisterRepository PurchaseReceiptRegister { get; }

        IPurchaseReceiptRegisterDetailRepository PurchaseReceiptRegisterDetail { get; }

        IPurchaseReturnRepository PurchaseReturn { get; }

        IPurchaseReturnDetailRepository PurchaseReturnDetail { get; }

        IRoleRepository Role { get; }

        ISaleInvoiceRepository SaleInvoice { get; }

        ISaleInvoiceDetailRepository SaleInvoiceDetail { get; }

        ISaleIssueRegisterRepository SaleIssueRegister { get; }

        ISaleReturnRepository SaleReturn { get; }

        ISaleReturnDetailRepository SaleReturnDetail { get; }

        IStatusRepository Status { get; }

        IStoreRepository Store { get; }

        ISupplierRepository Supplier { get; }

        ISupplyStatusRepository SupplyStatus { get; }

        ITaxRepository Tax { get; }

        ITenantRepository Tenant { get; }

        ITitleRepository Title { get; }

        ITokenRepository Token { get; }

        ISecurityManager SecurityManager { get; }
    }
}
