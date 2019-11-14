using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEDTeam.CES.Tool.Models.Common;

namespace CEDTeam.CES.Tool.UserControls
{
    public partial class MultiSelectDropdownList : UserControl
    {
        public List<DropdownItem> Items 
        { 
            set 
            {
                checkedListBox1.Items.Clear();
                value.ForEach(item => checkedListBox1.Items.Add(item.Text, false));
            } 
            get 
            { 
                return Items; 
            } 
        }
        public MultiSelectDropdownList()
        {
            InitializeComponent();
        }
    }
}
