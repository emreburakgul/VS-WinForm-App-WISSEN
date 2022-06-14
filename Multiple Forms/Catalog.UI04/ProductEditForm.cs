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
    public partial class ProductEditForm : Form
    {
        private List<Product>_productRepository;
        private List<Category> _categoriRepository;

        public ProductEditForm(List<Category> categoriesRepository,List<Product> productsRepository)
        {
            InitializeComponent();
            _categoriRepository = categoriesRepository;
            _productRepository = productsRepository;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Price = decimal.Parse(mtxtPrice.Text),
                Name = txtProductName.Text.Trim(),
                Category = (Category)cmbProductCatalog.SelectedItem,             
                
            };

            _productRepository.Add(product);
            txtProductName.Clear();
            mtxtPrice.Clear();
            cmbProductCatalog.SelectedIndex = -1;

            var dialogResult = MessageBox.Show(
                "Kayıt başarıyla gerçekleştirildi, yeni kayıt yapmak istiyor musunuz?",
                "Kayıt başarılı",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                Close();
            }

        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            cmbProductCatalog.DisplayMember = "Name";
            cmbProductCatalog.DataSource = _categoriRepository;
        }
    }
}
