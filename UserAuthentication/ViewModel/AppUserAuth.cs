using System.Collections.Generic;

namespace Authentication.ViewModel
{
    public class AppUserAuth
    {
        public string ErrorMessage;
        public int? DepartmentUnitId;
        public int? DegreeType;

        public AppUserAuth() : base()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;
            IsAuthenticated = false;
        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Email { get; set; }
        public int? userId { get; set; }
        public int? TenantId { get;  set; }
        public List<string> Activities { get; set; }
        public byte[] Passport { get; set; }
        public int? RoleId { get;  set; }
        public int? RoleLevelAccressId { get;  set; }
        public int? Ts { get;  set; }
        public int? Tc { get;  set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public int? EmployeeTypeId { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public int? DepartmentId { get; set; }
        public int? FacultyId { get; set; }
        public int? ProgrammeId { get; set; }
        public string ApplicationNumber { get; set; }
        public string CurrencyName { get; set; }
        public string currencySymbol { get; set; }
        public bool IsCompleted { get; set; }
    }
}
