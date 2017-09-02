using Fiddler;
using System.Windows.Forms;

namespace Honya
{
    public class HonyaRequestInspector : Inspector2, IRequestInspector2
    {
        private HonyaInspectorAdapter adapter = new HonyaInspectorAdapter();

        public HTTPRequestHeaders headers { get; set; }

        public byte[] body { get => adapter.Body; set => adapter.Body = value; }
        public bool bDirty { get; set; }
        public bool bReadOnly { get; set; }

        public void Clear()
        {
            adapter.Clear();
        }

        public override int GetOrder()
        {
            return 0;
        }

        public override void AddToTab(TabPage o)
        {
            adapter.AddToTab(o);
        }
    }
}
