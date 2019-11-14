using CEDTeam.CES.Tool.Constants;
using CEDTeam.CES.Tool.Helpers;
using CEDTeam.CES.Tool.Models.Shopee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEDTeam.CES.Tool
{
    public partial class Form1 : Form
    {
        public IEnumerable<Control> GetAllControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControl(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public Form1()
        {
            InitializeComponent();
            foreach(var item in GetAllControl(this, typeof(CheckedListBox)))
            {
                var checkListBox = (CheckedListBox)item;
                checkListBox.ItemCheck += CheckListBox_ItemCheck;
            }
        }

        private void CheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var checkListBox = (CheckedListBox)sender;
            if (0.Equals(e.Index))
            {
                for (int i = 1; i < checkListBox.Items.Count; i++)
                    checkListBox.SetItemCheckState(i, e.NewValue);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApiHelper apiHelper = new ApiHelper(ApiConstant.Shopee.SHOPEE_BASE);
            var a = apiHelper.Get<ShopeeCategory>(ApiConstant.Shopee.SHOPEE_BASE + ApiConstant.Shopee.CATEGORIES);
            if (a != null)
            {
                shopeeCategory.Items.Clear();
                shopeeCategory.Items.Add("Select All");
                a.data?.category_list?.ForEach(item => shopeeCategory.Items.Add(item.display_name));
            }
        }
    }
}
