using Authentication.Provider;
using DataModel.Models;
using Interface;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    public class WrapperRepository : IWrapperRepository
    {
        private DataContext _context;

        private IActivitiesAssignedRepository _activitiesAssigned;

        private IActivityRepository _activity;

        private IActivityTypeRepository _activityType;

        private IAuditTrailRepository _auditTrail;

        private IAuditTrailTypeRepository _auditTrailType;

        private IAuthorRepository _author;

        private IBankRepository _bank;

        private IBookItemRepository _book;

        private ICategoryRepository _category;

        private ICustomerRepository _customer;

        private IDesignationRepository _designation;

        private IDocumentUploadRepository _documentUpload;

        private IEmployeeRepository _employee;

        private IEmployeeContactRepository _employeeContact;

        private ILoginActivityRepository _loginActivity;

        private IPublisherRepository _publisher;

        private IPurchaseOrderRepository _purchaseOrder;

        private IPurchaseOrderDetailRepository _purchaseOrderDetail;

        private IPurchaseReceiptRegisterRepository _purchaseReceiptRegister;

        private IPurchaseReceiptRegisterDetailRepository _purchaseReceiptRegisterDetail;

        private IPurchaseReturnRepository _purchaseReturn;

        private IPurchaseReturnDetailRepository _purchaseReturnDetail;

        private IRoleRepository _role;

        private ISaleInvoiceRepository _saleInvoice;

        private ISaleInvoiceDetailRepository _saleInvoiceDetail;

        private ISaleIssueRegisterRepository _saleIssueRegister;

        private ISaleReturnRepository _saleReturn;

        private ISaleReturnDetailRepository _saleReturnDetail;

        private IStatusRepository _status;

        private IStoreRepository _store;

        private ISupplierRepository _supplier;

        private ISupplyStatusRepository _supplyStatus;

        private ITaxRepository _tax;

        private ITenantRepository _tenant;

        private ITitleRepository _title;

        private ITokenRepository _token;

        private ISecurityManager _securityManager;


        public ISecurityManager SecurityManager {
            get
            {
                if (_securityManager == null)
                {
                    _securityManager = new SecurityManager(_context);
                }

                return _securityManager;
            }
        }

        public IActivitiesAssignedRepository ActivitiesAssigned
        {
            get
            {
                if (_activitiesAssigned == null)
                {
                    _activitiesAssigned = new ActivitiesAssignedRepository(_context);
                }

                return _activitiesAssigned;
            }
        }




        public IActivityRepository Activity
        {
            get
            {
                if (_activity == null)
                {
                    _activity = new ActivityRepository(_context);
                }

                return _activity;
            }
        }




        public IActivityTypeRepository ActivityType
        {
            get
            {
                if (_activityType == null)
                {
                    _activityType = new ActivityTypeRepository(_context);
                }

                return _activityType;
            }
        }




        public IAuditTrailRepository AuditTrail
        {
            get
            {
                if (_auditTrail == null)
                {
                    _auditTrail = new AuditTrailRepository(_context);
                }

                return _auditTrail;
            }
        }




        public IAuditTrailTypeRepository AuditTrailType
        {
            get
            {
                if (_auditTrailType == null)
                {
                    _auditTrailType = new AuditTrailTypeRepository(_context);
                }

                return _auditTrailType;
            }
        }




        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_context);
                }

                return _author;
            }
        }




        public IBankRepository Bank
        {
            get
            {
                if (_bank == null)
                {
                    _bank = new BankRepository(_context);
                }

                return _bank;
            }
        }




        public IBookItemRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookItemRepository(_context);
                }

                return _book;
            }
        }




        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }

                return _category;
            }
        }




        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_context);
                }

                return _customer;
            }
        }




        public IDesignationRepository Designation
        {
            get
            {
                if (_designation == null)
                {
                    _designation = new DesignationRepository(_context);
                }

                return _designation;
            }
        }




        public IDocumentUploadRepository DocumentUpload
        {
            get
            {
                if (_documentUpload == null)
                {
                    _documentUpload = new DocumentUploadRepository(_context);
                }

                return _documentUpload;
            }
        }




        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_context);
                }

                return _employee;
            }
        }




        public IEmployeeContactRepository EmployeeContact
        {
            get
            {
                if (_employeeContact == null)
                {
                    _employeeContact = new EmployeeContactRepository(_context);
                }

                return _employeeContact;
            }
        }




        public ILoginActivityRepository LoginActivity
        {
            get
            {
                if (_loginActivity == null)
                {
                    _loginActivity = new LoginActivityRepository(_context);
                }

                return _loginActivity;
            }
        }




        public IPublisherRepository Publisher
        {
            get
            {
                if (_publisher == null)
                {
                    _publisher = new PublisherRepository(_context);
                }

                return _publisher;
            }
        }




        public IPurchaseOrderRepository PurchaseOrder
        {
            get
            {
                if (_purchaseOrder == null)
                {
                    _purchaseOrder = new PurchaseOrderRepository(_context);
                }

                return _purchaseOrder;
            }
        }




        public IPurchaseOrderDetailRepository PurchaseOrderDetail
        {
            get
            {
                if (_purchaseOrderDetail == null)
                {
                    _purchaseOrderDetail = new PurchaseOrderDetailRepository(_context);
                }

                return _purchaseOrderDetail;
            }
        }




        public IPurchaseReceiptRegisterRepository PurchaseReceiptRegister
        {
            get
            {
                if (_purchaseReceiptRegister == null)
                {
                    _purchaseReceiptRegister = new PurchaseReceiptRegisterRepository(_context);
                }

                return _purchaseReceiptRegister;
            }
        }




        public IPurchaseReceiptRegisterDetailRepository PurchaseReceiptRegisterDetail
        {
            get
            {
                if (_purchaseReceiptRegisterDetail == null)
                {
                    _purchaseReceiptRegisterDetail = new PurchaseReceiptRegisterDetailRepository(_context);
                }

                return _purchaseReceiptRegisterDetail;
            }
        }




        public IPurchaseReturnRepository PurchaseReturn
        {
            get
            {
                if (_purchaseReturn == null)
                {
                    _purchaseReturn = new PurchaseReturnRepository(_context);
                }

                return _purchaseReturn;
            }
        }




        public IPurchaseReturnDetailRepository PurchaseReturnDetail
        {
            get
            {
                if (_purchaseReturnDetail == null)
                {
                    _purchaseReturnDetail = new PurchaseReturnDetailRepository(_context);
                }

                return _purchaseReturnDetail;
            }
        }




        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_context);
                }

                return _role;
            }
        }




        public ISaleInvoiceRepository SaleInvoice
        {
            get
            {
                if (_saleInvoice == null)
                {
                    _saleInvoice = new SaleInvoiceRepository(_context);
                }

                return _saleInvoice;
            }
        }




        public ISaleInvoiceDetailRepository SaleInvoiceDetail
        {
            get
            {
                if (_saleInvoiceDetail == null)
                {
                    _saleInvoiceDetail = new SaleInvoiceDetailRepository(_context);
                }

                return _saleInvoiceDetail;
            }
        }




        public ISaleIssueRegisterRepository SaleIssueRegister
        {
            get
            {
                if (_saleIssueRegister == null)
                {
                    _saleIssueRegister = new SaleIssueRegisterRepository(_context);
                }

                return _saleIssueRegister;
            }
        }




        public ISaleReturnRepository SaleReturn
        {
            get
            {
                if (_saleReturn == null)
                {
                    _saleReturn = new SaleReturnRepository(_context);
                }

                return _saleReturn;
            }
        }




        public ISaleReturnDetailRepository SaleReturnDetail
        {
            get
            {
                if (_saleReturnDetail == null)
                {
                    _saleReturnDetail = new SaleReturnDetailRepository(_context);
                }

                return _saleReturnDetail;
            }
        }




        public IStatusRepository Status
        {
            get
            {
                if (_status == null)
                {
                    _status = new StatusRepository(_context);
                }

                return _status;
            }
        }




        public IStoreRepository Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new StoreRepository(_context);
                }

                return _store;
            }
        }




        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierRepository(_context);
                }

                return _supplier;
            }
        }




        public ISupplyStatusRepository SupplyStatus
        {
            get
            {
                if (_supplyStatus == null)
                {
                    _supplyStatus = new SupplyStatusRepository(_context);
                }

                return _supplyStatus;
            }
        }




        public ITaxRepository Tax
        {
            get
            {
                if (_tax == null)
                {
                    _tax = new TaxRepository(_context);
                }

                return _tax;
            }
        }




        public ITenantRepository Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new TenantRepository(_context);
                }

                return _tenant;
            }
        }




        public ITitleRepository Title
        {
            get
            {
                if (_title == null)
                {
                    _title = new TitleRepository(_context);
                }

                return _title;
            }
        }




        public ITokenRepository Token
        {
            get
            {
                if (_token == null)
                {
                    _token = new TokenRepository(_context);
                }

                return _token;
            }
        }

       

        public WrapperRepository(DataContext repositoryContext)
        {
            _context = repositoryContext;
        }


    }
}
