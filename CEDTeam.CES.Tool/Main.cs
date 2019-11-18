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

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategory(cateShopee, Enums.SiteType.Shopee);
            LoadCategory(cateLazada, Enums.SiteType.Lazada);
            LoadCategory(cateTiki, Enums.SiteType.Tiki);
            LoadCategory(cateSendo, Enums.SiteType.Sendo);
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            //RunShopee();
            //RunLazada();
            RunTiki();
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
                        var listProduct = new List<Product>();
                        do
                        {
                            string uri = string.Format(ApiConstant.Shopee.SEARCH_ITEMS, item.ProductId, newest);
                            result = apiHelper.Get<ShopeeSearchItem>(uri);
                            newest += 50;
                            listProduct.Clear();
                            result.items?.ForEach(prod =>
                            {
                                var prodDetail = apiHelper.Get<ShopeeDetailItem>(string.Format(ApiConstant.Shopee.PROD_DETAIL, prod.itemid, prod.shopid));
                                txtLog.AppendText(prodDetail.item.name + "\r\n");
                                listProduct.Add(new Product
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
                            });
                            productRepository.InsertProduct(listProduct);
                            Thread.Sleep((int)sleepTime.Value * 1000);
                        } while (result.items != null);
                        txtLog.AppendText("---Done get Category" + item.Url);
                    });
                    Thread.Sleep((int)sleepTime.Value * 1000);
                    apiTask.Start();
                });
            });
            shopeeTask.Start();
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
                                CategoryId = treenode.Tag.ToString()
                            });
                            //txtLog.AppendText(treenode.Name.Split(new string[] { "cat." }, StringSplitOptions.None)[1] + ",");
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
                                    CategoryId = subnode.Tag.ToString()
                                });
                            }
                        }
                    }

                }
                listKey.ForEach(item =>
                {
                    var apiTask = new Task(() =>
                    {
                        var result = new LazadaSearchItem();
                        var page = 1;
                        var listProduct = new List<Product>();
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
                            listProduct.Clear();
                            result.mods?.listItems?.ForEach(prod =>
                            {
                                //var prodDetail = apiHelper.Get<ShopeeDetailItem>(string.Format(ApiConstant.Shopee.PROD_DETAIL, prod.itemid, prod.shopid));
                                txtLog.AppendText("--LAZADA: " + prod.name + "\r\n");
                                try
                                {
                                    var product = new Product();
                                    product.Name = prod.name;
                                    product.CommentCount = prod.review;
                                    product.Url = prod.productUrl;
                                    product.CategoryId = item.CategoryId;
                                    product.CreatedDate = null;
                                    product.Discount = prod.discount;
                                    product.Quantity = 0;
                                    product.QuantitySold = 0;
                                    product.VariableJson = null;
                                    listProduct.Add(product);
                                }
                                catch (Exception e)
                                {

                                }
                                
                            //listProduct.Add(new Product
                            //{
                            //    Name = prod.name,
                            //        CommentCount = prod.review,
                            //        Url = prod.productUrl,
                            //        CategoryId = item.CategoryId,
                            //        CreatedDate = null,
                            //        Discount = (long)(prod.originalPrice - prod.price),
                            //        Quantity = 0,
                            //        QuantitySold = 0,
                            //        VariableJson = null
                            //    });
                        });
                            //productRepository.InsertProduct(listProduct);
                            Thread.Sleep((int)sleepTime.Value * 1000);
                        } while (result.mods?.listItems != null);
                        txtLog.AppendText("---Done get Category" + item.Url);
                    });
                    apiTask.Start();
                    Thread.Sleep((int)sleepTime.Value * 1000);
                });
            });
            lazadaTask.Start();
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
                                CategoryId = treenode.Tag.ToString()
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
                                    CategoryId = subnode.Tag.ToString()
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
                        var listProduct = new List<Product>();
                        do
                        {
                            string uri = string.Format(item.Url + "&page={0}", page);
                            var doc = apiHelper.Get(uri);
                            page++;
                            els= doc.DocumentNode.SelectNodes("//div[@data-seller-product-id]");
                            els?.ToList()?.ForEach(element =>
                            {
                                var mCommentCount = Regex.Match(element.InnerHtml, @"\((\d+).nh");
                                var sCommentCount = long.Parse(!mCommentCount.Success ? "0" : mCommentCount.Groups[1].Value);
                                var sUrl = Regex.Match(element.InnerHtml, "href=\"(.+?)\"").Groups[1].Value;
                                var sDiscount = Regex.Match(element.InnerHtml, "sale-tag-square\">(.+?)<").Groups[1].Value;
                                txtLog.AppendText(element.GetAttributeValue("data-title", "") + page + "\r\n");
                                listProduct.Add(new Product
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
                            });
                            //productRepository.InsertProduct(listProduct);
                            Thread.Sleep((int)sleepTime.Value * 1000);
                        } while (els?.Count > 0);
                        txtLog.AppendText("---Done get Category" + item.Url);
                    });
                    apiTask.Start();
                    Thread.Sleep((int)sleepTime.Value * 1000);
                });
            });
            tikiTask.Start();
            return tikiTask;
        }
    }
}
