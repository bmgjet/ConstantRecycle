using System.Collections.Generic;
namespace Oxide.Plugins
{
    [Info("ConstantRecycle", "bmgjet", "1.0.0")]
    class ConstantRecycle : RustPlugin
    {
        List<Recycler> Running = new List<Recycler>();
        private void OnRecyclerToggle(Recycler recycler,BasePlayer player)
        {
            if(recycler.IsOn())
            {
                recycler.CancelInvoke(recycler.StartRecycling);
                Running.Remove(recycler);
                return;
            }
            recycler.InvokeRepeating(recycler.StartRecycling,1,1);
            if(!Running.Contains(recycler)){Running.Add(recycler);}
        }
        void Unload() { foreach(var recycler in Running) { recycler.CancelInvoke(recycler.StartRecycling); } }
    }
}