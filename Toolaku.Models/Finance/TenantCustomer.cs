using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Finance
{
    public class TenantCustomer
    {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string PIC { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string Poscode { get; set; }
            public int CountryId { get; set; }
            public int StateId { get; set; }
    }

    public class TenantCustomerDetail : ResponseBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PIC { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Poscode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }

    public class TenantCustomerUpdateRequest
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PIC { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Poscode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }

    public class TenantCustomerList
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PIC { get; set; }
    }

    public class TenantCustomerLists : ResponseBase
    {
        public List<TenantCustomerList> result { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class TenantCustomerResponse : ResponseBase
    {
        public TenantCustomerResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public int CustomerId { get; set; }
    }

    public class CustomerToRemove
    {
        public int CustomerId { get; set; }
    }
}
