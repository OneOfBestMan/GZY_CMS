using GZY_CMS.Core.Repository;
using GZY_CMS.IService;
using GZY_CMS.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZY_CMS.Service
{
     public class WorknodeService : IWorknodeService
    {
        public IRepository<GZY_Worknode, SystemContext> SysContext { get; set; }

        public List<GZY_Worknode> Select(string Node_abbre,string Node_href,int? Node_type,string NodeValid, int index, int rows, out int total)
        {
            var worknodecontext = SysContext.GetList();
            if (!string.IsNullOrEmpty(Node_abbre))
            {
                worknodecontext = worknodecontext.Where(a => a.Node_abbre.Contains(Node_abbre));
            }
            if (!string.IsNullOrEmpty(Node_href))
            {
                worknodecontext = worknodecontext.Where(a => a.Node_href.Contains(Node_href));
            }
            if (!string.IsNullOrEmpty(NodeValid))
            {
                worknodecontext = worknodecontext.Where(a => a.NodeValid == NodeValid);
            }
            if (Node_type != null)
            {
                worknodecontext = worknodecontext.Where(a => a.Node_type == Node_type);
            }
            var count = worknodecontext.Count();
            total = count;
            return worknodecontext.Skip(rows * (index - 1)).Take(rows).ToList();
        }


        public bool Add(GZY_Worknode model)
        {
            return SysContext.Add(model);
        }

        public int DeleteWorknode(int[] ids)
        {
            List<GZY_Worknode> list = new List<GZY_Worknode>();
            foreach (var item in ids)
            {
                var date = SysContext.Get(a => a.ID == item);
                if (date != null)
                {
                    list.Add(date);
                }

            }
            return SysContext.RemoveRange(list);
        }

        public GZY_Worknode SelectWorknodeModel(int id)
        {
            return SysContext.Get(a => a.ID == id);
        }


        public bool UpdataWorknodeModel(GZY_Worknode model)
        {
            return SysContext.Update(model);
        }

        public List<dynamic> SelectWorks(string name)
        {
            var date = from a in SysContext.GetList(a => a.Node_abbre.Contains(name)&&a.Node_type!=3)
                       select new
                       {
                           text= a.Node_abbre,
                           id =  a.ID
                       };

            return date.ToList<dynamic>();
        }

    }
}
