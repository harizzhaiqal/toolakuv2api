using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;


namespace Toolaku.Models.Reference
{
    public class DayType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DayTypes : ResponseBase
    {
        public List<DayType> result { get; set; }
    }

    public class Edition
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Editions : ResponseBase
    {
        public List<Edition> result { get; set; }
    }

    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DocumentTypes : ResponseBase
    {
        public List<DocumentType> result { get; set; }
    }

    public class Frequency
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Frequencies : ResponseBase
    {
        public List<Frequency> result { get; set; }
    }

    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Genders : ResponseBase
    {
        public List<Gender> result { get; set; }
    }

    public class LeaveDurationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class LeaveDurationTypes : ResponseBase
    {
        public List<LeaveDurationType> result { get; set; }
    }

    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class LeaveTypes : ResponseBase
    {
        public List<LeaveType> result { get; set; }
    }

    public class MaritalStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MaritalStatuses : ResponseBase
    {
        public List<MaritalStatus> result { get; set; }
    }

    public class EmploymentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmploymentStatuses : ResponseBase
    {
        public List<EmploymentStatus> result { get; set; }
    }


}
