using System.Collections.Generic;
using GZY_CMS.Infrastructure;
using GZY_CMS.SystemModel;

namespace GZY_CMS.IService
{
    public interface IWorknodeService: IDependency
    {
        bool Add(GZY_Worknode model);
        int DeleteWorknode(int[] ids);
        List<GZY_Worknode> Select(string Node_abbre, string Node_href, int? Node_type, string NodeValid, int index, int rows, out int total);
        GZY_Worknode SelectWorknodeModel(int id);
        bool UpdataWorknodeModel(GZY_Worknode model);

        List<dynamic> SelectWorks(string name);
    }
}