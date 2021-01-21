using System.Collections.Generic;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Profile
{
    public class TenantCertificate : ResponseBase
    {
        public int TenantCertificateId { get; set; }
        public string LogoURL { get; set; }
        public string CertificateName { get; set; }
        public string CertNo { get; set; }
        public string IssuedBy { get; set; }
        public string DateIssued { get; set; }
    }

    public class TenantCertificates : ResponseBase
    {
        public List<TenantCertificate> Result { get; set; }
    }

    public class TenantCertificateNew
    {
        public string LogoURL { get; set; }
        public string CertificateName { get; set; }
        public string CertNo { get; set; }
        public string IssuedBy { get; set; }
        public string DateIssued { get; set; }
    }

    public class TenantCertificateUpdate
    {
        public int TenantCertificateId { get; set; }
        public string LogoURL { get; set; }
        public string CertificateName { get; set; }
        public string CertNo { get; set; }
        public string IssuedBy { get; set; }
        public string DateIssued { get; set; }
    }

}
