using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelAuto.Models;

namespace API.ResponseModel.Orgnization
{
    public class OrgResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
        public int? Level { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EfectDate { get; set; }
        public DateTime DissolutionDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NumberBussines { get; set; }
        public string Address { get; set; }
        public int? NationID { get; set; }
        public int? ProvinceID { get; set; }
        public int? DistrictID { get; set; }
        public int? WardID { get; set; }
        public int? ManagerID { get; set; }
        public List<OrgResponse> Children { get; set; }
    }
    public class GetChildOrgnization 
    {
       public List<OrgResponse> GetChildOrg (List<ModelAuto.Models.Orgnization> list, int parent)
        {
            var list1 = list.Where(x => x.ParentId == parent).Select(x => new OrgResponse()
            {
                Name = x.Name,
                Id = x.Id,
                Code=x.Code,
                Level=x.Level,
                ParentID= x.ParentId,
                Children= GetChildOrg(list,x.Id),
            }).ToList();
            return list1;
        }

    }

    public class OrgResponse1
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
        public int? Level { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EfectDate { get; set; }
        public DateTime DissolutionDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NumberBussines { get; set; }
        public string Address { get; set; }
        public int? NationID { get; set; }
        public int? ProvinceID { get; set; }
        public int? DistrictID { get; set; }
        public int? WardID { get; set; }
        public int? ManagerID { get; set; }
    }

}
