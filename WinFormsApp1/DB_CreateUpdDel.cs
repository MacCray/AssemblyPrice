using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using AssemblyPrice.Models;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace AssemblyPrice
{
    public partial class DB_CreateUpdDel : Form
    {
        public DB_CreateUpdDel()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            var checkedRb = tableLayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
            if (checkedRb is null) return;
            string helpString = "";
            switch (checkedRb.Name)
            {
                case "rbCompany":
                    helpString = "Данная таблица отображает данные по компаниям.\n" +
                        "При работе с данной таблицей доступны 5 полей для ввода и возможность добавления логотипа компании через диалоговое окно.\n" +
                        "Поля \"Наименование компании\", \"Email\", \"Сайт\" ограниченны длиной в 50 символов, \"Телефон\" - 12 символов и \"Адрес\" - 100 символов.\n" +
                        "Также при вводе Email следует учитывать, что воспринимается только email соответствующий протоколу RFC 5322\"\"." +
                        "При вводе телефона допускается шаблон вида +7/7/8XXXXXXXXX, где X это цифра из диапазона от 0 до 9. При вводе сайта допускается URL сформированный в соответствии с RFC 3986 и RFC 3987. " +
                        "В качестве логотипа принимаются изображения формата PNG, JPG и JPEG.\n" +
                        "При выделении всей строки таблицы, поля для ввода будут автоматически заполнены соответствующими данными выделенной строки.\n" +
                        "Поле \"Наименование компании\" при редактировании и удалении записи должно оставаться неизменным, иначе возникнет ошибка." +
                        "Если требуется изменить имя компании, следует создать новую запись." +
                        "Для удаления надо выделить нужную строку таблицы или вручную ввести данные в поле \"Наименование компании\" и нажать кнопку \"Удаление записи\".";
                    break;
                case "rbProduct":
                    helpString = "Данная таблица отображает данные по стандартным изделиям, которые были извлечены из спецификации.\n" +
                        "При работе с этой таблицей доступно только просмотр данных из таблицы, так как все изделия считываются из файла спецификации. Для удаления изделий надо удалить соответствующую спецификацию.";
                    break;
                case "rbSpc":
                    helpString = "Данная таблица отображает данные по спецификациям.\n" +
                        "При работе с этой таблицей для добавления спецификации и извлечения из нее данных о стандартных изделиях необходимо нажать кнопку открытия файла.\n" +
                        "Для удаления надо выделить нужную строку таблицы и нажать кнопку \"Удаление записи\".";
                    break;
                case "rbProductCompany":
                    helpString = "Данная таблица отображает какие компании продают стандартные изделия и по какой цене и скидке.\n" +
                        "При работе с этой таблицей доступны 2 выпадающих списка со всеми существующими компаниями и изделиями в базе данных, " +
                        "и два поля \"Стоимость\" и \"Скидка\". При вводе десятичных чисел в качестве знака разделителя допускается только \",\"." +
                        "Максимальная длина поля \"Стоимость\" - 17 символов, поля \"Скидка\" - 5 символов." +
                        "Для удаления надо выделить нужную строку таблицы или вручную выбрать компанию и изделие из списков и нажать кнопку \"Удаление записи\".";
                    break;
                case "rbSpcProduct":
                    helpString = "Данная таблица отображает количество стандартных изделий в спецификациях.\n" +
                         "При работе с этой таблицей доступно только просмотр данных из таблицы. Для удаления записей надо удалить соответствующую спецификацию.";
                    break;
            }
            MessageBox.Show(this, helpString, "Помощь по таблице " + $"\"{checkedRb.Text}\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string error = null;
            if (rbCompany.Checked)
            {
                if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || imgBox.Image == null)
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка добавления компании", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    Company company = new();
                    MemoryStream stream = new();
                    try
                    {
                        company.Наименование = textBox1.Text;
                        company.Адрес = textBox2.Text;
                        company.Телефон = textBox3.Text;
                        company.Сайт = textBox4.Text;
                        company.Email = textBox5.Text;
                        imgBox.Image?.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        company.Логотип = stream.Capacity == 0 ? null : stream.ToArray();
                        dbContext.Companies.Add(company);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.InnerException.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Create", error);
                        DisplayEntity("rbCompany");
                    }
                }
            }
            else if (rbProductCompany.Checked)
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка добавления компании", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    ProductCompany prodCompany = new();
                    try
                    {
                        prodCompany.ОбозначениеИзделия = StdProdDrowDownList.SelectedValue.ToString();
                        prodCompany.НаименованиеКомпании = CompanyDrowDownList.SelectedValue.ToString();
                        prodCompany.Стоимость = decimal.Parse(textBox3.Text);
                        prodCompany.Скидка = decimal.Parse(textBox4.Text);
                        dbContext.ProductCompanies.Add(prodCompany);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.InnerException.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Create", error);
                        DisplayEntity("rbProductCompany");
                    }
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string error = null;
            if (rbCompany.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните поле \"Наименование компании\"!", "Ошибка редактирования компании", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || imgBox.Image == null)
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка редактирования компании", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    Company company = new();
                    MemoryStream stream = new();
                    try
                    {
                        company.Наименование = textBox1.Text;
                        company.Адрес = textBox2.Text;
                        company.Телефон = textBox3.Text;
                        company.Сайт = textBox4.Text;
                        company.Email = textBox5.Text;
                        imgBox.Image?.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        company.Логотип = stream.Capacity == 0 ? null : stream.ToArray();
                        dbContext.Companies.Update(company);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Update", error);
                        DisplayEntity("rbCompany");
                    }
                }
            }
            else if (rbProductCompany.Checked)
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    ProductCompany prodCompany = new();
                    try
                    {
                        prodCompany.ОбозначениеИзделия = StdProdDrowDownList.SelectedValue.ToString();
                        prodCompany.НаименованиеКомпании = CompanyDrowDownList.SelectedValue.ToString();
                        prodCompany.Стоимость = decimal.Parse(textBox3.Text);
                        prodCompany.Скидка = decimal.Parse(textBox4.Text);
                        dbContext.ProductCompanies.Update(prodCompany);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Update", error);
                        DisplayEntity("rbProductCompany");
                    }
                }
            }
            else if (rbSpc.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните поле \"Имя файла спецификации\"!", "Ошибка редактирования спецификации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    Specification specification = new();
                    MemoryStream stream = new();
                    try
                    {
                        imgBox.Image?.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        dbContext.Specifications.Update(new Specification()
                        {
                            НаименованиеФайлаСпецификации = textBox1.Text,
                            НаименованиеСборкиЧертежа = textBox2.Text,
                            Изображение = stream.Capacity == 0 ? null : stream.ToArray()
                        });
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Update", error);
                        DisplayEntity("rbSpc");
                    }
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error = null;
            if (rbCompany.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните поле \"Наименование компании\"!", "Ошибка удаления компании", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    Company company = new();
                    try
                    {
                        company.Наименование = textBox1.Text;
                        dbContext.Companies.Remove(company);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Remove", error);
                        DisplayEntity("rbCompany");
                    }
                }
            }
            else if (rbSpc.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните поле \"Имя файла спецификации\"!", "Ошибка удаления спецификации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (VKRContext dbContext = new())
                {
                    try
                    {
                        var specificationList = dbContext.Specifications.Where(spc => spc.НаименованиеФайлаСпецификации == textBox1.Text).Include(spc => spc.SpcProducts)
                            .ThenInclude(spcProduct => spcProduct.ОбозначениеИзделияNavigation)
                            .ToList();
                        foreach (var spcProduct in specificationList[0].SpcProducts)
                        {
                            if (dbContext.SpcProducts.Where(spcPr => spcPr.ОбозначениеИзделияNavigation == spcProduct.ОбозначениеИзделияNavigation).ToList().Count() > 1) continue;
                            dbContext.StandartProducts.Remove(spcProduct.ОбозначениеИзделияNavigation);
                        }
                        dbContext.Specifications.Remove(specificationList[0]);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        DisplayEntity("rbSpc");
                        ShowStatus("Remove", error);
                    }
                }
            }
            else if (rbProductCompany.Checked)
            {
                using (VKRContext dbContext = new())
                {
                    ProductCompany prodCompany = new();
                    try
                    {
                        prodCompany.ОбозначениеИзделия = StdProdDrowDownList.SelectedValue.ToString();
                        prodCompany.НаименованиеКомпании = CompanyDrowDownList.SelectedValue.ToString();
                        dbContext.ProductCompanies.Remove(prodCompany);
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        error = ex.Message;
                    }
                    catch (FormatException ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        ShowStatus("Remove", error);
                        DisplayEntity("rbProductCompany");
                    }
                }

            }
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (rbSpc.Checked)
            {
                openFileDialog.Filter = "Файл Excel (*.xls, *.xlsx)|*.xls;*.xlsx|Файл изображения (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Path.GetExtension(openFileDialog.FileName) == ".xls" || Path.GetExtension(openFileDialog.FileName) == ".xlsx")
                    {
                        LoadSpcFromExcelFile(openFileDialog.FileName);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    else if (Path.GetExtension(openFileDialog.FileName) == ".png" || Path.GetExtension(openFileDialog.FileName) == ".jpg" || Path.GetExtension(openFileDialog.FileName) == ".jpeg")
                    {
                        imgBox.Image = Image.FromFile(openFileDialog.FileName);
                    }
                }
                return;
            }
            else if (rbCompany.Checked)
            {
                openFileDialog.Filter = "Файл изображения (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imgBox.Image = Image.FromFile(openFileDialog.FileName);
                }
                return;
            }
        }
        private void rbCompany_CheckedChanged(object sender, EventArgs e)
        {
            DisplayEntity("rbCompany");
        }
        private void rbProduct_CheckedChanged(object sender, EventArgs e)
        {
            DisplayEntity("rbProduct");
        }
        private void rbSpc_CheckedChanged(object sender, EventArgs e)
        {
            DisplayEntity("rbSpc");
        }
        private void rbProductCompany_CheckedChanged(object sender, EventArgs e)
        {
            DisplayEntity("rbProductCompany");
        }
        private void rbSpcProduct_CheckedChanged(object sender, EventArgs e)
        {
            DisplayEntity("rbSpcProduct");
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                if (rbCompany.Checked)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        textBox1.Text = row.Cells[0].Value.ToString();
                        textBox2.Text = row.Cells[1].Value.ToString();
                        textBox3.Text = row.Cells[2].Value.ToString();
                        textBox4.Text = row.Cells[3].Value.ToString();
                        textBox5.Text = row.Cells[4].Value.ToString();
                        imgBox.Image = Image.FromStream(new MemoryStream(row.Cells[5].Value as byte[]));
                    }
                }
                else if (rbProduct.Checked)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        textBox1.Text = row.Cells[0].Value.ToString();
                        textBox2.Text = row.Cells[1].Value?.ToString();
                        textBox3.Text = row.Cells[2].Value?.ToString();
                    }
                }
                else if (rbSpc.Checked)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        textBox1.Text = row.Cells[0].Value.ToString();
                        textBox2.Text = row.Cells[1].Value.ToString();
                        imgBox.Image = row.Cells[2].Value != null ? Image.FromStream(new MemoryStream(row.Cells[2].Value as byte[])) : null;
                    }
                }
                else if (rbProductCompany.Checked)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        StdProdDrowDownList.SelectedValue = row.Cells[0].Value.ToString();
                        CompanyDrowDownList.SelectedValue = row.Cells[1].Value.ToString();
                        textBox3.Text = row.Cells[2].Value.ToString();
                        textBox4.Text = row.Cells[3].Value.ToString();
                    }
                }
                else if (rbSpcProduct.Checked)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        textBox1.Text = row.Cells[0].Value.ToString();
                        textBox2.Text = row.Cells[1].Value.ToString();
                        textBox3.Text = row.Cells[2].Value.ToString();
                    }
                }
            }
        }
        private void DisplayEntity(string sender)
        {
            using (VKRContext dbContext = new())
            {
                switch (sender)
                {
                    case "rbCompany":
                        label1.Text = "Наименовние компании:";
                        label2.Text = "Адрес:";
                        label3.Text = "Телефон:";
                        label4.Text = "Сайт:";
                        label5.Text = "Email:";
                        label6.Text = "Логотип:";
                        btnOpenFile.Text = "Открыть изображение логотипа компании";

                        textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = false;
                        textBox1.MaxLength = 50;
                        textBox2.MaxLength = 100;
                        textBox3.MaxLength = 12;

                        textBox4.MaxLength = 50;
                        textBox5.MaxLength = 50;

                        tableLayoutPanel.SetRowSpan(btnDelete, 1);
                        tableLayoutPanel.SetRowSpan(btnCreate, 2);
                        tableLayoutPanel.SetRowSpan(btnUpdate, 2);

                        StdProdDrowDownList.Visible = CompanyDrowDownList.Visible = false;
                        label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible =
                            textBox1.Visible = textBox2.Visible = textBox3.Visible = textBox4.Visible = textBox5.Visible = imgBox.Visible =
                            btnOpenFile.Visible = btnCreate.Visible = btnUpdate.Visible = btnDelete.Visible = true;

                        List<Company> _companyList = dbContext.Companies.ToList();
                        dataGridView.DataSource = _companyList;
                        ((DataGridViewImageColumn)dataGridView.Columns["Логотип"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        dataGridView.Columns["ProductCompanies"].Visible = false;
                        dataGridView.Columns["Адрес"].MinimumWidth = 256;
                        break;
                    case "rbProduct":
                        label1.Text = "Обозначение изделия:";
                        label2.Text = "Масса:";
                        label3.Text = "Наименование материала:";

                        textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = true;

                        label4.Visible = label5.Visible = label6.Visible = textBox4.Visible = textBox5.Visible = 
                            btnOpenFile.Visible = btnCreate.Visible = btnUpdate.Visible = btnDelete.Visible = imgBox.Visible = StdProdDrowDownList.Visible = CompanyDrowDownList.Visible = false;
                        label1.Visible = label2.Visible = label3.Visible = 
                            textBox1.Visible = textBox2.Visible = textBox3.Visible = true;

                        List <StandartProduct> _productList = dbContext.StandartProducts.ToList();
                        dataGridView.DataSource = _productList;
                        dataGridView.Columns["ProductCompanies"].Visible = dataGridView.Columns["SpcProducts"].Visible = false;
                        break;
                    case "rbSpc":
                        label1.Text = "Имя файла спецификации:";
                        label2.Text = "Имя cборки:";
                        label6.Text = "Изображение сборки: ";
                        btnOpenFile.Text = "Открыть файл";

                        textBox1.ReadOnly = textBox2.ReadOnly = true;

                        tableLayoutPanel.SetRowSpan(btnDelete, 1);
                        tableLayoutPanel.SetRowSpan(btnUpdate, 1);

                        label3.Visible = label4.Visible = label5.Visible = 
                            textBox3.Visible = textBox4.Visible = textBox5.Visible = btnCreate.Visible = 
                            StdProdDrowDownList.Visible = CompanyDrowDownList.Visible = false;
                        label1.Visible = label2.Visible = label6.Visible = textBox1.Visible = textBox2.Visible = imgBox.Visible = btnOpenFile.Visible = btnUpdate.Visible = btnDelete.Visible = true;

                        List<Specification> _spcList = dbContext.Specifications.ToList();
                        dataGridView.DataSource = _spcList;
                        ((DataGridViewImageColumn)dataGridView.Columns["Изображение"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        dataGridView.Columns["SpcProducts"].Visible = false;
                        dataGridView.Columns["Изображение"].MinimumWidth = 600;
                        break;
                    case "rbProductCompany":
                        label1.Text = "Обозначение изделия:";
                        label2.Text = "Наименование компании:";
                        label3.Text = "Стоимость:";
                        label4.Text = "Скидка:";

                        textBox3.ReadOnly = false;
                        textBox3.MaxLength = 17;
                        textBox4.MaxLength = 5;

                        tableLayoutPanel.SetRowSpan(btnDelete, 1);
                        tableLayoutPanel.SetRowSpan(btnCreate, 2);
                        tableLayoutPanel.SetRowSpan(btnUpdate, 2);

                        label5.Visible = label6.Visible = textBox1.Visible = textBox2.Visible = textBox5.Visible 
                            = btnOpenFile.Visible = imgBox.Visible = false;
                        label1.Visible = label2.Visible = label3.Visible = label4.Visible =
                            textBox3.Visible = textBox4.Visible = btnCreate.Visible = btnUpdate.Visible = btnDelete.Visible = StdProdDrowDownList.Visible = CompanyDrowDownList.Visible = true;

                        List<ProductCompany> _prodCompList = dbContext.ProductCompanies.ToList();

                        StdProdDrowDownList.DataSource = dbContext.StandartProducts.ToList();
                        StdProdDrowDownList.DisplayMember = "Обозначение";
                        StdProdDrowDownList.ValueMember = "Обозначение";
                        CompanyDrowDownList.DataSource = dbContext.Companies.ToList();
                        CompanyDrowDownList.DisplayMember = "Наименование";
                        CompanyDrowDownList.ValueMember = "Наименование";

                        dataGridView.DataSource = _prodCompList;
                        dataGridView.Columns["НаименованиеКомпанииNavigation"].Visible = dataGridView.Columns["ОбозначениеИзделияNavigation"].Visible = false;
                        break;
                    case "rbSpcProduct":
                        label1.Text = "Наименование спецификации:";
                        label2.Text = "Обозначение изделия:";
                        label3.Text = "Количество:";

                        textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = true;

                        StdProdDrowDownList.Visible = CompanyDrowDownList.Visible = label4.Visible = label5.Visible = label6.Visible = textBox4.Visible = textBox5.Visible =
                            btnOpenFile.Visible = btnCreate.Visible = btnUpdate.Visible = btnDelete.Visible = imgBox.Visible = false;
                        textBox1.Visible = textBox2.Visible = textBox3.Visible = label1.Visible = label2.Visible = label3.Visible  = true;

                        List<SpcProduct> _prodSborkaList = dbContext.SpcProducts.ToList();
                        dataGridView.DataSource = _prodSborkaList;
                        dataGridView.Columns["НаименованиеСпецификацииNavigation"].Visible = dataGridView.Columns["ОбозначениеИзделияNavigation"].Visible = false;
                        break;
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dataGridView1_SizeChanged(null, null);
            }
        }
        private void ShowStatus(string Action, string ex)
        {
            if (ex == null)
            {
                if (Action == "Create")
                {
                    MessageBox.Show("Добавление успешно!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Action == "Update")
                {
                    MessageBox.Show("Обновление успешно!", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Удаление успешно!", "Удаление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Возникла ошибка!\n" + ex, "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadSpcFromExcelFile(string excelFilePath)
        {
            Excel.Application oXL = null;
            Excel.Workbook oWB = null;
            Excel.Worksheet oSheet = null;
            string error = null;
            try
            {
                oXL = new();
                oWB = oXL.Workbooks.Open(excelFilePath, ReadOnly: true);
                oSheet = oWB.ActiveSheet;
                using (VKRContext dbContext = new())
                {
                    Excel.Range usedRange = oSheet.UsedRange.Cells;
                    Specification spc = new() 
                    {
                        НаименованиеФайлаСпецификации = oWB.Name.Split(".xls")[0],
                        НаименованиеСборкиЧертежа = usedRange.Find(What: "Документация", LookIn: Excel.XlFindLookIn.xlValues).Offset[2, 0].Value2
                    };
                    dbContext.Specifications.Add(spc);
                    dbContext.SaveChanges();

                    List<StandartProduct> products = new();
                    List<SpcProduct> spcProducts = new();
                    Excel.Range standartProductsRange = usedRange.Find(What: "Стандартные изделия", LookIn: Excel.XlFindLookIn.xlValues).Offset[2, 0].CurrentRegion;
                    object[,] standartProductsInfo = standartProductsRange.Value2 as object[,];
                    for (int i = 1; i <= standartProductsInfo.GetLength(0); i++)
                    {
                        if (standartProductsInfo[i, 5].ToString() == "") continue;
                        products.Add(new StandartProduct()
                        {
                            Обозначение = Convert.ToString(standartProductsInfo[i, 5]),
                            Масса = standartProductsInfo[i, 8] != null ? Convert.ToDouble(standartProductsInfo[i, 8]) : null,
                            НаименованиеМатериала = Convert.ToString(standartProductsInfo[i, 16]) == "" ? null : Convert.ToString(standartProductsInfo[i, 16])
                        });
                        spcProducts.Add(new SpcProduct
                        {
                            НаименованиеСпецификации = spc.НаименованиеФайлаСпецификации,
                            ОбозначениеИзделия = products.Last().Обозначение,
                            КоличествоИзделий = Convert.ToInt32(standartProductsInfo[i, 6])
                        });
                    }
                    foreach (StandartProduct product in products)
                    {
                        if (dbContext.StandartProducts.Find(product.Обозначение) != null) continue;
                        dbContext.StandartProducts.Add(product);
                        dbContext.SaveChanges();
                    }
                    foreach (SpcProduct productSpc in spcProducts)
                    {
                        dbContext.SpcProducts.Add(productSpc);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                error = ex.InnerException.Message;
            }
            finally
            {
                oXL.Quit();
                ShowStatus("Create", error);
                DisplayEntity("rbSpc");
            }
        }
        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                row.MinimumHeight = 64;
                row.Height = (dataGridView.Height - dataGridView.ColumnHeadersHeight) / dataGridView.RowCount - 5;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e) //Проверка телефона
        {
            if (rbCompany.Checked)
            {
                if (textBox3.Text == "") return;
                string phonePattern = @"^((\+7|7|8)+([0-9]){10})$";
                Regex regex = new(phonePattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(textBox3.Text))
                {
                    MessageBox.Show(this, "Неверный формат телефона", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBox4_Leave(object sender, EventArgs e) //Проверка сайта
        {
            if (rbCompany.Checked)
            {
                if (textBox4.Text == "") return;
                if (!Uri.IsWellFormedUriString(textBox5.Text, UriKind.RelativeOrAbsolute))
                {
                    MessageBox.Show(this, "Неверный формат URL", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void textBox5_Leave(object sender, EventArgs e) //Проверка email
        {
            if (rbCompany.Checked)
            {
                if (textBox5.Text == "") return;
                string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                Regex regex = new (emailPattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(textBox5.Text))
                {
                    MessageBox.Show(this, "Неверный формат email", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void decimalInput(object sender, KeyPressEventArgs e) //Ограничение на ввод чисел
        {
            if (rbProductCompany.Checked)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 44)
                {
                    e.Handled = true;
                }
            }
        }
    }
}