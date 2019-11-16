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
using CEDTeam.CES.Tool.Business;
using CEDTeam.CES.Tool.Repositories;

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
            CheckForIllegalCrossThreadCalls = false;
            LoadCategory(cateShopee, Enums.SiteType.Shopee);
            LoadCategory(cateLazada, Enums.SiteType.Lazada);
            LoadCategory(cateTiki, Enums.SiteType.Tiki);
            LoadCategory(cateSendo, Enums.SiteType.Sendo);
            //foreach(var item in GetAllControl(this, typeof(CheckedListBox)))
            //{
            //    var checkListBox = (CheckedListBox)item;
            //    checkListBox.ItemCheck += CheckListBox_ItemCheck;
            //}
        }

        private void LoadCategory(TreeView treeView, Enums.SiteType type)
        {
            var readCategory = new ReadCategory();
            var category = readCategory.GetAllCategory(type);
            treeView.Nodes.Clear();
            category["category"].ForEach(item =>
            {
                if(!(Enums.SiteType.Sendo.Equals(type) && item.Url.Contains("tien-ich")) && !string.IsNullOrWhiteSpace(item.Name))
                {
                    var treenode = treeView.Nodes.Add(item.Url, item.Name);
                    category["subcategory"].Where(it => it.Parent.Equals(item.Id)).ToList().ForEach(i => {
                        if (!(Enums.SiteType.Sendo.Equals(type) && i.Url.Contains("tien-ich")) && !string.IsNullOrWhiteSpace(i.Name))
                            treenode.Nodes.Add(i.Url, i.Name);
                    });
                }
            });
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
            var readCategory = new ReadCategory();
            readCategory.GetAllCategory(Enums.SiteType.Shopee);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ApiHelper apiHelper = new ApiHelper(ApiConstant.Shopee.SHOPEE_BASE);
            //var a = apiHelper.Get<ShopeeCategory>(ApiConstant.Shopee.SHOPEE_BASE + ApiConstant.Shopee.CATEGORIES);
            //if (a != null)
            //{
            //    shopeeCategory.Items.Clear();
            //    shopeeCategory.Items.Add("Select All");
            //    a.data?.category_list?.ForEach(item => shopeeCategory.Items.Add(item.display_name));
            //}
        }

        private void cateShopee_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Parent == null)
            {
                foreach(var item in e.Node.Nodes)
                {
                    var treenode = (TreeNode)item;
                    treenode.Checked = e.Node.Checked;
                }
            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            //tableLayoutPanel1.Enabled = false;
            //var a = new BaseRepository();
            //var b=  a.GetConnection();
            //return;
            Task shopeeTask = new Task(() =>
            {
                var listKey = new List<string>();
                var apiHelper = new ApiHelper(ApiConstant.Shopee.SHOPEE_BASE);
                foreach (var item in cateShopee.Nodes)
                {
                    var treenode = (TreeNode)item;
                    if(treenode.Checked && treenode.Nodes.Count == 0)
                    {
                        if (treenode.Nodes.Count == 0)
                        {
                            listKey.Add(treenode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1]);
                            txtLog.AppendText(treenode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1] + ",");
                        } 
                    } 
                    else
                    {
                        foreach (var it in treenode.Nodes)
                        {
                            var subnode = (TreeNode)it;
                            if (subnode.Checked)
                            {
                                listKey.Add(subnode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1]);
                                var key = subnode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1];
                                txtLog.AppendText(key.Split('.')[1] + ",");
                            }
                        }
                    }
                    
                }
                listKey.ForEach(item =>
                {
                    var apiTask = new Task(() =>
                    {
                        var result = new ShopeeSearchItem();
                        var newest = 0;
                        do
                        {
                            string uri = string.Format(ApiConstant.Shopee.SEARCH_ITEMS, 9824, newest);
                            result = apiHelper.Get<ShopeeSearchItem>(uri);
                            newest += 50;
                            result.items?.ForEach(prod =>
                            {
                                var prodDetail = apiHelper.Get<ShopeeDetailItem>(string.Format(ApiConstant.Shopee.PROD_DETAIL, prod.itemid, prod.shopid));
                                txtLog.AppendText(prodDetail.item.name + "\r\n");
                            });
                        } while (result.items != null);
                    });
                    apiTask.Start();
                });
                
            });
            shopeeTask.Start();
            //var a = cateSh;

            //Console.WriteLine(a.Count+"");
        }
    }
}
