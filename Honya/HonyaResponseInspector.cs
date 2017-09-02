using Fiddler;
using System.Windows.Forms;

namespace Honya
{
    public class HonyaResponseInspector : Inspector2, IResponseInspector2
    {
        private HonyaInspectorAdapter adapter = new HonyaInspectorAdapter();

        public HTTPResponseHeaders headers { get; set; }

        public byte[] body { get => adapter.Body; set => adapter.Body = value; }
        public bool bDirty { get; set; }
        public bool bReadOnly { get; set; }

        public void Clear()
        {
            this.adapter.Clear();
        }

        public override int GetOrder()
        {
            return 0;
        }

        public override void AddToTab(TabPage o)
        {
            this.adapter.AddToTab(o);
        }
    }
}
