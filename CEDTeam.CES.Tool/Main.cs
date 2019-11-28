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
using CEDTeam.CES.Tool.Models;
using CEDTeam.CES.Tool.Models.Lazada;
using System.Threading;
using Newtonsoft.Json;
using CEDTeam.CES.Tool.Extensions;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using CEDTeam.CES.Tool.Models.Sendo;
using static System.Windows.Forms.ListViewItem;
using CEDTeam.CES.Tool.Models.Common;

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

        private readonly ProductRepository productRepository = new ProductRepository();
        private long Count = 0;
        List<Task> listTask = new List<Task>();
        private Dictionary<string, List<Models.Category>> listSubcategory = new Dictionary<string, List<Models.Category>>();
        private SynchronizedCollection<Product> Products = new SynchronizedCollection<Product>();

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                new BaseRepository().GetConnection().Open();
            } 
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            foreach (var item in GetAllControl(this, typeof(TreeView)))
            {
                var treeView = (TreeView)item;
                treeView.AfterCheck += TreeView_AfterCheck; ;
            }
        }

        private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                foreach (var item in e.Node.Nodes)
                {
                    var treenode = (TreeNode)item;
                    treenode.Checked = e.Node.Checked;
                }
            }
        }

        private void LoadCategory(TreeView treeView, Enums.SiteType type)
        {
            var readCategory = new ReadCategory();
            var category = readCategory.GetAllCategory(type);
            string key = "shopee";
            switch (type)
            {
                case Enums.SiteType.Lazada: key = "lazada"; break;
                case Enums.SiteType.Tiki: key = "tiki"; break;
                case Enums.SiteType.Sendo: key = "sendo"; break;
            }
            listSubcategory.Add(key, category["subcategory"]);
            treeView.Nodes.Clear();
            category["category"].ForEach(item =>
            {
                if (!(Enums.SiteType.Sendo.Equals(type) && item.Url.Contains("tien-ich")) && !string.IsNullOrWhiteSpace(item.Name))
                {
                    var treenode = treeView.Nodes.Add(item.Url, item.Name);
                    treenode.Tag = item.Id;
                    category["subcategory"].Where(it => it.Parent.Equals(item.Id)).ToList().ForEach(i => {
                        if (!(Enums.SiteType.Sendo.Equals(type) && i.Url.Contains("tien-ich")) && !string.IsNullOrWhiteSpace(i.Name))
                            treenode.Nodes.Add(i.Url, i.Name).Tag = i.Parent;
                    });
                }
            });
        }
        private bool kt = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategory(cateShopee, Enums.SiteType.Shopee);
            LoadCategory(cateLazada, Enums.SiteType.Lazada);
            LoadCategory(cateTiki, Enums.SiteType.Tiki);
            LoadCategory(cateSendo, Enums.SiteType.Sendo);
        }
       
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            RunSync();
        }

        private void RunSync()
        {
            listTask.Clear();
            if (!kt)
            {
                btnStart.Text = "Running";
                groupBox1.Enabled = false;
                var task1 = RunShopee();
                var task2 = RunLazada();
                var task3 = RunTiki();
                var task4 = RunSendo();
                int time = 0;
                Task t = new Task(() =>
                {
                    groupBox6.Text = "Log";
                    while (true)
                    {
                        if (Products.Count > recordPerInsertTime.Value)
                        {
                            var t1 = new Task(() =>
                            {
                                try
                                {
                                    var result = new ProductRepository().InsertProduct(Products.Take(1000).ToList());
                                    txtlogInsert.AppendText("Inserted " + result + " product(s) into Database!\r\n");
                                    txtlogInsert.AppendText("---" + (Products.Count - 1000) + " in queue!\r\n");
                                    for (int i = 0; i < 1000; i++)
                                    {
                                        Products.RemoveAt(i);
                                    }
                                }
                                catch (Exception e)
                                {
                                    txtlogInsert.AppendText(e.Message + "\r\n");
                                }
                            });
                            t1.Start();
                        }
                        if (listTask.All(i => i.IsCompleted))
                        {
                            if(Products.Count > 0)
                            {
                                var t1 = new Task(() =>
                                {
                                    try
                                    {
                                        var result = new ProductRepository().InsertProduct(Products.Take(1000).ToList());
                                        txtlogInsert.AppendText("Inserted " + result + " product(s) into Database!\r\n");
                                        txtlogInsert.AppendText("---" + Products.Count + " in queue!\r\n");
                                        Products.Clear();
                                    }
                                    catch (Exception e)
                                    {
                                        txtlogInsert.AppendText(e.Message + "\r\n");
                                    }
                                });
                                t1.Start();
                            }
                            break;
                        }
                        groupBox6.Text = "Log -- Synced: " + Count + " product/"+ time + " seconds";
                        time++;
                        Thread.Sleep(1000);
                    }
                    groupBox1.Enabled = true;
                    btnStart.Text = "Start";
                    kt = false;
                });
                t.Start();
            }
            else
            {
                btnStart.Text = "Start";
            }
            kt = !kt;
        }

        private Task RunShopee()
        {
            Task shopeeTask = new Task(() =>
            {
                var listKey = new List<Product>();
                var apiHelper = new ApiHelper(ApiConstant.Shopee.SHOPEE_BASE);
                foreach (var item in cateShopee.Nodes)
                {
                    var treenode = (TreeNode)item;
                    if (treenode.Checked && treenode.Nodes.Count == 0)
                    {
                        if (treenode.Nodes.Count == 0)
                        {
                            listKey.Add(new Product
                            {
                                ProductId = treenode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1],
                                CategoryId = treenode.Tag.ToString(),
                                CategoryUrl = treenode.Name
                            });
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

                                var key = subnode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1];
                                listKey.Add(new Product
                                {
                                    ProductId = key.Split('.')[1],
                                    CategoryId = subnode.Tag.ToString(),
                                    CategoryUrl = subnode.Name
                                });
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
                            string uri = string.Format(ApiConstant.Shopee.SEARCH_ITEMS, item.ProductId, newest);
                            result = apiHelper.Get<ShopeeSearchItem>(uri);
                            newest += 50;
                            result?.items?.ForEach(prod =>
                            {
                                var prodDetail = apiHelper.Get<ShopeeDetailItem>(string.Format(ApiConstant.Shopee.PROD_DETAIL, prod.itemid, prod.shopid));
                                txtLog.AppendText(prodDetail.item.name + "\r\n");
                                Products.Add(new Product
                                {
                                    Name = prodDetail.item.name,
                                    CommentCount = prodDetail.item.cmt_count,
                                    Url = string.Format("https://shopee.vn/product-i.{0}.{1}", prodDetail.item.shopid, prodDetail.item.itemid),
                                    CategoryId = item.CategoryId,
                                    CreatedDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(prodDetail.item.ctime.Value)).ToLocalTime(),
                                    Discount = prodDetail.item.discount,
                                    Quantity = prodDetail.item.stock,
                                    QuantitySold = prodDetail.item.historical_sold,
                                    VariableJson = JsonConvert.SerializeObject(prodDetail.item.models),
                                    Price = ((long)prodDetail.item.price_max) / 100000, 
                                    ProductId = prodDetail.item.itemid.ToString(),
                                    CategoryUrl = item.CategoryUrl
                                });
                                Count++;
                            });
                            //productRepository.InsertProduct(listProduct);
                            Thread.Sleep((int)sleepTime.Value * 1000);
                        } while (result != null || result.items != null);
                        txtLog.AppendText("---Done get Shopee Category" + item.Url);
                    });
                    Thread.Sleep((int)sleepTime.Value * 1000);
                    apiTask.Start();
                    listTask.Add(apiTask);
                });
            });
            shopeeTask.Start();
            listTask.Add(shopeeTask);
            return shopeeTask;
        }

        private Task RunLazada()
        {
            Task lazadaTask = new Task(() =>
            {
                var listKey = new List<Product>();
                var apiHelper = new ApiHelper(ApiConstant.Lazada.LAZADA_BASE);
                foreach (var item in cateLazada.Nodes)
                {
                    var treenode = (TreeNode)item;
                    if (treenode.Checked && treenode.Nodes.Count == 0)
                    {
                        if (treenode.Nodes.Count == 0)
                        {
                            listKey.Add(new Product
                            {
                                Url = treenode.Name,
                                CategoryId = treenode.Tag.ToString(),
                                CategoryUrl = treenode.Name
                            });
                        }
                    }
                    else
                    {
                        foreach (var it in treenode.Nodes)
                        {
                            var subnode = (TreeNode)it;
                            if (subnode.Checked)
                            {
                                listKey.Add(new Product
                                {
                                    Url = subnode.Name,
                                    CategoryId = subnode.Tag.ToString(),
                                    CategoryUrl = subnode.Name
                                });
                            }
                        }
                    }

                }
                listKey.ForEach(item =>
                {
                    var result = new LazadaSearchItem();
                    var page = 1;
                    try
                    {

                    } catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    do
                    {
                        string uri = string.Format(item.Url + ApiConstant.Lazada.GET_PROD_AJAX, page);
                        result = apiHelper.Get<LazadaSearchItem>(uri);
                        page++;
                        result?.mods?.listItems?.ForEach(prod =>
                        {
                            //var prodDetail = apiHelper.Get<ShopeeDetailItem>(string.Format(ApiConstant.Shopee.PROD_DETAIL, prod.itemid, prod.shopid));
                            txtLog.AppendText("--LAZADA: " + prod.name + "\r\n");
                            try
                            {
                                var product = new Product();
                                product.Price = (long)prod.price;
                                product.Name = prod.name;
                                product.ProductId = prod.itemId;
                                product.CommentCount = prod.review;
                                product.Url = prod.productUrl;
                                product.CategoryId = item.CategoryId;
                                product.CreatedDate = null;
                                product.Discount = prod.discount;
                                product.Quantity = 0;
                                product.QuantitySold = 0;
                                product.VariableJson = null;
                                product.CategoryUrl = item.CategoryUrl;
                                Products.Add(product);
                                Count++;
                            }
                            catch (Exception e)
                            {

                            }
                    });
                        // productRepository.InsertProduct(listProduct);
                        Thread.Sleep(60 * 1000);
                    } while (result != null || result.mods?.listItems != null);
                    txtLog.AppendText("---Done get Lazada Category" + item.Url);
                    //Thread.Sleep((int)sleepTime.Value * 1000);
                });
            });
            lazadaTask.Start();
            listTask.Add(lazadaTask);
            return lazadaTask;
        }
        private Task RunTiki()
        {
            Task tikiTask = new Task(() =>
            {
                var listKey = new List<Product>();
                var apiHelper = new ApiHelper(ApiConstant.Tiki.TIKI_BASE);
                foreach (var item in cateTiki.Nodes)
                {
                    var treenode = (TreeNode)item;
                    if (treenode.Checked && treenode.Nodes.Count == 0)
                    {
                        if (treenode.Nodes.Count == 0)
                        {
                            listKey.Add(new Product
                            {
                                Url = treenode.Name,
                                CategoryId = treenode.Tag.ToString(),
                                CategoryUrl = treenode.Name
                            });
                        }
                    }
                    else
                    {
                        foreach (var it in treenode.Nodes)
                        {
                            var subnode = (TreeNode)it;
                            if (subnode.Checked)
                            {
                                listKey.Add(new Product
                                {
                                    Url = subnode.Name,
                                    CategoryId = subnode.Tag.ToString(),
                                    CategoryUrl = subnode.Name
                                });
                            }
                        }
                    }

                }
                listKey.ForEach(item =>
                {
                    var apiTask = new Task(() =>
                    {
                        var els = new HtmlNodeCollection(null);
                        var page = 1;
                        do
                        {
                            string uri = string.Format(item.Url + "&page={0}", page);
                            var doc = apiHelper.Get(uri, false);
                            page++;
                            els= doc.DocumentNode.SelectNodes("//div[@data-seller-product-id]");
                            els?.ToList()?.ForEach(element =>
                            {
                                var mCommentCount = Regex.Match(element.InnerHtml, @"\((\d+).nh");
                                var sCommentCount = long.Parse(!mCommentCount.Success ? "0" : mCommentCount.Groups[1].Value);
                                var sUrl = Regex.Match(element.InnerHtml, "href=\"(.+?)\"").Groups[1].Value;
                                var sDiscount = Regex.Match(element.InnerHtml, "sale-tag-square\">(.+?)<").Groups[1].Value;
                                txtLog.AppendText(element.GetAttributeValue("data-title", "") + "\r\n");
                                Products.Add(new Product
                                {
                                    ProductId = element.GetAttributeValue("data-id", ""),
                                    Name = element.GetAttributeValue("data-title", ""),
                                    CategoryId = item.CategoryId,
                                    Quantity = 0,
                                    QuantitySold = 0,
                                    CommentCount = sCommentCount,
                                    Url = sUrl,
                                    Discount = sDiscount,
                                    Price = long.Parse(element.GetAttributeValue("data-price","")),
                                    CategoryUrl = item.Url
                                });
                                Count++;
                            });
                            Thread.Sleep((int)sleepTime.Value * 1000);
                        } while (els?.Count > 0);
                        txtLog.AppendText("---Done get Tiki Category" + item.Url);
                    });
                    apiTask.Start();
                    listTask.Add(apiTask);
                    Thread.Sleep((int)sleepTime.Value * 1000);
                });
            });
            tikiTask.Start();
            listTask.Add(tikiTask);
            return tikiTask;
        }

        private Task RunSendo()
        {
            Task sendoTask = new Task(() =>
            {
                var listKey = new List<Product>();
                var apiHelper = new ApiHelper(ApiConstant.Sendo.SENDO_BASE);
                foreach (var item in cateSendo.Nodes)
                {
                    var treenode = (TreeNode)item;
                    if (treenode.Checked && treenode.Nodes.Count == 0)
                    {
                        if (treenode.Nodes.Count == 0)
                        {
                            string result = apiHelper.GetString(treenode.Name, true);
                            Match m = Regex.Match(result, @"categoryId"":(\d +)");
                            if(m.Success)
                            {
                                listKey.Add(new Product
                                {
                                    ProductId = m.Groups[1].Value,
                                    CategoryId = treenode.Tag.ToString(),
                                    CategoryUrl = treenode.Name
                                });
                            }
                        }
                    }
                    else
                    {
                        foreach (var it in treenode.Nodes)
                        {
                            var subnode = (TreeNode)it;
                            if (subnode.Checked)
                            {
                                string result = apiHelper.GetString(treenode.Name,true);
                                Match m = Regex.Match(result, @"categoryId"":(\d+)");
                                if (m.Success)
                                {
                                    listKey.Add(new Product
                                    {
                                        ProductId = m.Groups[1].Value,
                                        CategoryId = subnode.Tag.ToString(),
                                        CategoryUrl = subnode.Name
                                    });
                                }
                            }
                        }
                    }

                }
                listKey.ForEach(item =>
                {
                    var apiTask = new Task(() =>
                    {
                        var result = new SendoProductItem();
                        var page = 1;
                        do
                        {
                            string uri = string.Format(ApiConstant.Sendo.GET_PROD_AJAX, item.ProductId, page);
                            result = apiHelper.Get<SendoProductItem>(uri);
                            page++;
                            result?.Result?.Data?.ForEach(prod =>
                            {
                                txtLog.AppendText(prod.Name + "\r\n");
                                Products.Add(new Product
                                {
                                    Name = prod.Name,
                                    CommentCount = prod.TotalRated,
                                    Url = string.Format("https://www.sendo.vn/product-n-{0}.html", prod.ProductId.Value),
                                    CategoryId = item.CategoryId,
                                    CreatedDate = null,
                                    Discount = prod.FinalPromotionPercent.Value.ToString() + "%",
                                    Quantity = null,
                                    QuantitySold = prod.OrderCount,
                                    VariableJson = null,
                                    Price = prod.FinalPriceMax,
                                    ProductId = prod.ProductId.Value.ToString(),
                                    CategoryUrl = item.CategoryUrl
                                });
                                Count++;
                            });
                            Thread.Sleep((int)sleepTime.Value * 1000);
                        } while (result?.Result.Data?.Count > 0);
                        txtLog.AppendText("---Done get Sendo Category" + item.Url);
                    });
                    Thread.Sleep((int)sleepTime.Value * 1000);
                    apiTask.Start();
                    listTask.Add(apiTask);
                });
            });
            sendoTask.Start();
            listTask.Add(sendoTask);
            return sendoTask;
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            if (txtLog.TextLength > 10000)
                txtLog.Clear();
        }

        private void btnStartDailySync_Click(object sender, EventArgs e)
        {
            btnStartDailySync.Enabled = false;
            Task task = new Task(() =>
            {
                while(true)
                {
                    var now = DateTime.Now;
                    var dailyTime = dateTimePicker1.Value;
                    if (now.Hour == dailyTime.Hour && now.Minute == dailyTime.Minute && listTask.Count == 0)
                        RunSync();
                    Thread.Sleep(1000);
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var apiHelper = new ApiHelper(ApiConstant.Shopee.SHOPEE_BASE);
            var keywordRepository = new KeywordRepository();
            var task = new Task(() =>
            {
                List<KeywordByCategory> keywordByCategories = new List<KeywordByCategory>();
                listSubcategory["shopee"].ForEach(item =>
                {
                    ListViewItem listViewItem = new ListViewItem("Shopee");
                    var strArr = item.Url?.Split('.');
                    string id = strArr[strArr.Length - 1];
                    var result = apiHelper.Get<ShopeeKeywordByCategory>(string.Format(ApiConstant.Shopee.KEYWORD_BY_CATEGORY, id));
                    var keywords = result?.items?.Select(keywordItem => keywordItem.display_name).ToArray();
                    listViewItem.SubItems.Add(item.Name);
                    listViewItem.SubItems.Add(string.Join(",", keywords));
                    listView1.Items.Add(listViewItem);
                    if(keywords.Count() > 0)
                    {
                        keywordByCategories.Add(new KeywordByCategory
                        {
                            CategoryUrl = item.Url,
                            Keywords = keywords.ToList()
                        });
                    }
                });
                try
                {
                    txtSyncKeywordLog.AppendText("Inserted " + keywordRepository.InsertKeywords(keywordByCategories) + " shopee keyword into database.");
                } 
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            task.Start();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            TreeView treeView = (TreeView)((ContextMenuStrip)toolStripMenuItem.Owner).SourceControl;
            foreach(TreeNode treeNode in treeView.Nodes)
            {
                treeNode.Checked = true;
            }
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            TreeView treeView = (TreeView)((ContextMenuStrip)toolStripMenuItem.Owner).SourceControl;
            foreach (TreeNode treeNode in treeView.Nodes)
            {
                treeNode.Checked = false;
            }
        }
    }
}
