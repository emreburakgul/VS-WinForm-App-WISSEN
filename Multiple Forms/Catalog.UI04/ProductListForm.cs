using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog.UI04
{
    public partial class ProductListForm : Form
    {
        private List<Product> _productRepository;
        private List<Category> _categoriRepository;

        public ProductListForm(List<Category> categoriesRepository,List<Product> productsRepository)
        {
            InitializeComponent();
            _categoriRepository = categoriesRepository;
            _productRepository = productsRepository;
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {

            grdProductList.DataSource = _productRepository;
        }

        private void grdProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show(grdProductList.CurrentCell.Value.ToString());

            //            MessageBox.Show(@$"Id:{grdProductList.CurrentRow.Cells[2].Value.ToString()}
            //Price: {grdProductList.CurrentRow.Cells[0].Value.ToString()}
            //Name:{grdProductList.CurrentRow.Cells[3].Value.ToString()}
            //Kategori:{grdProductList.CurrentRow.Cells[1].Value.ToString()}");

            var showData = (Product)grdProductList.CurrentRow.DataBoundItem;
            MessageBox.Show(@$"ID: {showData.Id}
Price: {showData.Price}
Name: {showData.Name}
Category: {showData.Category}" );
        }

     
    }
}
