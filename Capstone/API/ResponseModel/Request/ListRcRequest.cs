using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.ResponseModel.Request
{
    public class ListRcRequest
    {
        public int id { get; set; }

        public string code { get; set; }
        public string name { get; set; }
        public string requestLevel { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public int? quantity { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? Deadline { get; set; }
        public string Office { get; set; }
        public string Status { get; set; }
        public int? parentId { get; set; }
        public int? rank { get; set; }
        public string note { get; set; }
        public string comment { get; set; }
        public string HrInchange { get; set; }
        public List<ListRcRequest> Children { get; set; }

    }
    public class GetChildRcRequest
    {
        public List<ListRcRequest> GetChildren(List<RcRequest> comments, int parentId)
        {
            var list = comments.Where(x => x.ParentId == parentId).Select(x => new ListRcRequest()
            {
                id = x.Id,
                code = x.Code,
                name = x.Name,
                requestLevel = x.RequestLevelNavigation?.Name,
                department = x.Orgnization?.Name,
                position = x.Position?.Name,
                quantity = x.Number,
                createdOn = x.EffectDate,
                Deadline = x.ExpireDate,
                Office = x.Sign?.FullName,
                Status = x.Status == -1 ? "Accept" : x.Status == 0 ? "Reject" : "pending",
                parentId = x.ParentId,
                rank = x.Rank,
                note = x.Note,
                comment = x.Comment,
                HrInchange = x.HrInchangeNavigation?.FullName,
                Children = GetChildren(comments, x.Id),

            }).ToList();

            return list;

        }

    }
}