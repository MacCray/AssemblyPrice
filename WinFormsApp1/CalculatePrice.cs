using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AssemblyPrice.Models;

namespace AssemblyPrice
{
    public partial class CalculatePrice : Form
    {
        public CalculatePrice()
        {
            InitializeComponent();
            DisplaySpecifications();
        }

        List<Specification> specificationList;
        public void DisplaySpecifications()
        {
            using (VKRContext dbContext = new())
            {
                specificationList = dbContext.Specifications.AsNoTracking()
                    .Include(spc => spc.SpcProducts)
                    .ThenInclude(spcProduct => spcProduct.ОбозначениеИзделияNavigation)
                    .ThenInclude(product => product.ProductCompanies)
                    .ThenInclude(productCompany => productCompany.НаименованиеКомпанииNavigation)
                    .ToList();
                foreach (var specification in specificationList)
                {
                    listBox1.Items.Add(specification.НаименованиеФайлаСпецификации);
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.ToString() == "") return;
            calcPrice.Enabled = true;
            listBox2.Items.Clear();
            foreach (SpcProduct product in specificationList[listBox1.SelectedIndex].SpcProducts)
            {
                listBox2.Items.Add(product.ОбозначениеИзделия);
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.ToString() == "") return;
            dataGridView1.Visible = true;
            label3.Visible = true;
            using (VKRContext dbContext = new())
            {
                var selectedSpcProduct = specificationList[listBox1.SelectedIndex].SpcProducts
                    .FirstOrDefault(p => p.ОбозначениеИзделия == listBox2.SelectedItem.ToString());
                dataGridView1.DataSource = new BindingSource(selectedSpcProduct.ОбозначениеИзделияNavigation, "");
                dataGridView1.Columns["ProductCount"].DisplayIndex = dataGridView1.Columns.Count - 1;
                dataGridView1.Columns["ProductCompanies"].Visible = dataGridView1.Columns["SpcProducts"].Visible = false;
                dataGridView1.Rows[0].Cells["ProductCount"].Value = selectedSpcProduct.КоличествоИзделий;
            }
        }
        private void calcPrice_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            while(richTextBox1.Controls.Count != 0)
            {
                richTextBox1.Controls.Remove(richTextBox1.Controls[0]);
            }

            Dictionary <StandartProduct, Dictionary<Company, decimal>> productsCompanyPrices = new();
            richTextBox1.Text += "Оптимальным вариантом покупки будет:\n";
            string productsWithoutPrice = "";
            foreach (SpcProduct spcProduct in specificationList[listBox1.SelectedIndex].SpcProducts)
            {
                if (spcProduct.ОбозначениеИзделияNavigation.ProductCompanies.Count == 0)
                {
                    productsWithoutPrice += $"{spcProduct.ОбозначениеИзделияNavigation.Обозначение}, ";
                    continue;
                }
                foreach (ProductCompany productCompany in spcProduct.ОбозначениеИзделияNavigation.ProductCompanies)
                {
                    if (!productsCompanyPrices.TryGetValue(spcProduct.ОбозначениеИзделияNavigation, out Dictionary<Company, decimal> companyPriceList))
                    {
                        productsCompanyPrices.Add(
                            spcProduct.ОбозначениеИзделияNavigation,
                            new Dictionary<Company, decimal>
                            {
                                [productCompany.НаименованиеКомпанииNavigation] = decimal.Round(productCompany.Стоимость * spcProduct.КоличествоИзделий * (1 - productCompany.Скидка), 2)
                            });
                    }
                    else
                    {
                        productsCompanyPrices[spcProduct.ОбозначениеИзделияNavigation].Add(
                            productCompany.НаименованиеКомпанииNavigation,
                            decimal.Round(productCompany.Стоимость * spcProduct.КоличествоИзделий * (1 - productCompany.Скидка), 4));
                    }
                }
            }

            richTextBox1.Text += productsWithoutPrice.Length == 0 ? "" : "Нет компаний, которые продают " + productsWithoutPrice.Remove(productsWithoutPrice.Length - 2, 2) + ".\n";
            decimal finalPrice = 0;
            foreach (KeyValuePair<StandartProduct, Dictionary<Company, decimal>> productCompanyPrices in productsCompanyPrices)
            {
                decimal minPrice = productCompanyPrices.Value.Values.Min();
                finalPrice += minPrice;
                var companyMinPrices = productCompanyPrices.Value.Where(el => el.Value == minPrice).Select(e => e.Key).ToList();   
                
                richTextBox1.Text += $"{productCompanyPrices.Key.Обозначение} за {minPrice} у ";
                LinkLabel link = new();
                link.LinkClicked += new LinkLabelLinkClickedEventHandler(link_LinkClicked);
                link.Text = companyMinPrices[0].Наименование;
                link.AutoSize = true;
                link.Location = richTextBox1.GetPositionFromCharIndex(richTextBox1.TextLength);
                richTextBox1.Controls.Add(link);
                richTextBox1.Text += link.Text + " ";
                if (companyMinPrices.Count > 1)
                {
                    foreach (Company company in companyMinPrices.Skip(1))
                    {
                        richTextBox1.Text += " или ";
                        link = new();
                        link.LinkClicked += new LinkLabelLinkClickedEventHandler(link_LinkClicked);
                        link.Text = company.Наименование;
                        link.AutoSize = true;
                        link.Location = richTextBox1.GetPositionFromCharIndex(richTextBox1.TextLength);
                        richTextBox1.Controls.Add(link);
                        richTextBox1.Text += link.Text + " ";
                    }
                }
                richTextBox1.Text += "\n";
            }
            richTextBox1.Text += $"Итоговая стоимость - {finalPrice}";
            richTextBox1.Visible = true;
        }
        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (VKRContext dbContext = new())
            {
                Company selectedCompany = dbContext.Companies.Find((sender as LinkLabel).Text);
                MessageBox.Show($"Имя компании: {selectedCompany.Наименование}\nАдрес: {selectedCompany.Адрес}\nТелефон: {selectedCompany.Телефон}" +
                    $"\nСайт: {selectedCompany.Сайт}\nEmail: {selectedCompany.Email}",
                    "Данные о компании", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
