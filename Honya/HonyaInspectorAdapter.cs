using MessagePack;
using System.Windows.Forms;

namespace Honya
{
    public class HonyaInspectorAdapter
    {
        public static readonly string InspectorName = "Honya";

        private RichTextBox textBox = new RichTextBox()
        {
            Multiline = true,
            Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
        };

        private byte[] body;
        public byte[] Body
        {
            get
            {
                return body;
            }
            set
            {
                if (body == value)
                {
                    return;
                }

                body = value;

                try
                {
                    var result = Crypto.Decrypt(body);
                    var str = MessagePackSerializer.ToJson(result);
                    this.textBox.Text = JsonHelper.FormatJson(str);
                }
                catch
                {
                    this.textBox.Text = string.Empty;
                }
            }
        }

        public void Clear()
        {
            this.textBox.Clear();
        }

        public void AddToTab(TabPage o)
        {
            this.textBox.Height = o.Height;
            this.textBox.Width = o.Width;
            o.Text = InspectorName;
            o.Controls.Add(this.textBox);
        }
    }
}
