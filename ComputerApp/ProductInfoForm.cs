/// <summary>
/// APP NAME : Dollar Computers
/// AUTHOR : Preetinder Singh Brar
/// STUDENT NUMBER : 200334111
/// CREATE DATE : 02 April 2017
/// DESCRIPTION : The program that simulates a computer purchase.
/// </summary>
using DollarComputers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarComputers
{
    public partial class ProductInfoForm : Form
    {
        //PUBLIC VARIABLES*******************************
        public Form previousForm;

        //PRIVATE VARIABLES*******************************
        private StreamWriter _writer;
        private StreamReader _reader;

        /// <summary>
        /// Method to be called if form is being loaded by startform
        /// </summary>
        public void OpenProduct()
        {
            openToolStripMenuItem.PerformClick();
        }

        public ProductInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event Handler to close all previous forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Close();
        }

        /// <summary>
        /// Event handler to handle click on every button on this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductInfoFormButton_Click(object sender, EventArgs e)
        {
            Button productInfoFormButton = sender as Button;
            switch (productInfoFormButton.Name)
            {
                case "SelectAnotherProductButton":
                    this.Hide();
                    this.previousForm.Show();
                    break;
                case "CancelButton":
                    this.Close();
                    break;
                case "NextButton":
                    OrderForm myOrderForm = new OrderForm();
                    myOrderForm.previousForm = this;
                    myOrderForm.Show();
                    this.Hide();
                    break;
            }
        }

        /// <summary>
        /// Event handler to fill data in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductInfoForm_Load(object sender, EventArgs e)
        {
            ProductIdTextBox.Text = ServiceClass.selectedId.ToString();
            ConditionTextBox.Text = ServiceClass.condition;
            CostTextBox.Text = ServiceClass.cost.ToString();
            PlatformTextBox.Text = ServiceClass.platform;
            OSTextBox.Text = ServiceClass.os;
            ManufacturerTextBox.Text = ServiceClass.manufacturer;
            ModelTextBox.Text = ServiceClass.model;
            MemoryTextBox.Text = ServiceClass.ram;
            LCDSizeTextBox.Text = ServiceClass.lcdSize;
            HDDTextBox.Text = ServiceClass.hdd;
            CPUBrandTextBox.Text = ServiceClass.cpuBrand;
            CPUNumberTextBox.Text = ServiceClass.cpuNumber;
            GPUTypeTextBox.Text = ServiceClass.gpuType;
            CPUTypeTextBox.Text = ServiceClass.cpuType;
            CPUSpeedTextBox.Text = ServiceClass.cpuSpeed;
            WebCamTextBox.Text = ServiceClass.webCam;
        }

        /// <summary>
        /// Event handler to handle click on the tool strip menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Name)
            {
                case "selectAnotherProductToolStripMenuItem":
                    this.Hide();
                    this.previousForm.Show();
                    break;
                case "openToolStripMenuItem":
                    OpenProductFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    OpenProductFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                    OpenProductFileDialog.FileName = "Product.txt";
                    if (OpenProductFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filename = OpenProductFileDialog.FileName;
                        try
                        {
                            this._reader = new StreamReader(filename);

                            if (this._reader.Peek() != -1)
                            {
                                ProductIdTextBox.Text = this._reader.ReadLine();
                                ConditionTextBox.Text = this._reader.ReadLine();
                                CostTextBox.Text = this._reader.ReadLine();
                                PlatformTextBox.Text = this._reader.ReadLine();
                                OSTextBox.Text = this._reader.ReadLine();
                                ManufacturerTextBox.Text = this._reader.ReadLine();
                                ModelTextBox.Text = this._reader.ReadLine();
                                MemoryTextBox.Text = this._reader.ReadLine();
                                LCDSizeTextBox.Text = this._reader.ReadLine();
                                HDDTextBox.Text = this._reader.ReadLine();
                                CPUBrandTextBox.Text = this._reader.ReadLine();
                                CPUNumberTextBox.Text = this._reader.ReadLine();
                                GPUTypeTextBox.Text = this._reader.ReadLine();
                                CPUTypeTextBox.Text = this._reader.ReadLine();
                                CPUSpeedTextBox.Text = this._reader.ReadLine();
                                WebCamTextBox.Text = this._reader.ReadLine();
                                ServiceClass.selectedId = Convert.ToInt32(ProductIdTextBox.Text);
                                ServiceClass.condition = ConditionTextBox.Text;
                                ServiceClass.cost = Convert.ToDecimal(CostTextBox.Text);
                                ServiceClass.platform = PlatformTextBox.Text;
                                ServiceClass.os = OSTextBox.Text;
                                ServiceClass.manufacturer = ManufacturerTextBox.Text;
                                ServiceClass.model = ModelTextBox.Text;
                                ServiceClass.ram = MemoryTextBox.Text;
                                ServiceClass.lcdSize = LCDSizeTextBox.Text;
                                ServiceClass.hdd = HDDTextBox.Text;
                                ServiceClass.cpuBrand = CPUBrandTextBox.Text;
                                ServiceClass.cpuNumber = CPUNumberTextBox.Text;
                                ServiceClass.gpuType = GPUTypeTextBox.Text;
                                ServiceClass.cpuType = CPUTypeTextBox.Text;
                                ServiceClass.cpuSpeed = CPUSpeedTextBox.Text;
                                ServiceClass.webCam = WebCamTextBox.Text;
                            }
                            else
                            {
                                MessageBox.Show("File Empty - No data to Read", "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            this._reader.Close();
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception.Message);
                            MessageBox.Show("Error Reading File", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (ProductIdTextBox.Text == "0")
                    {
                        MessageBox.Show("No Data Found!!Please select product from previous form!!", "No Product Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.previousForm.Show();
                        this.Hide();
                    }
                    break;
                case "saveToolStripMenuItem":
                    SaveProductFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    SaveProductFileDialog.FileName = "Product.txt";
                    SaveProductFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                    if (SaveProductFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filename = SaveProductFileDialog.FileName;
                        try
                        {
                            this._writer = new StreamWriter(filename);
                            this._writer.WriteLine(ProductIdTextBox.Text);
                            this._writer.WriteLine(ConditionTextBox.Text);
                            this._writer.WriteLine(CostTextBox.Text);
                            this._writer.WriteLine(PlatformTextBox.Text);
                            this._writer.WriteLine(OSTextBox.Text);
                            this._writer.WriteLine(ManufacturerTextBox.Text);
                            this._writer.WriteLine(ModelTextBox.Text);
                            this._writer.WriteLine(MemoryTextBox.Text);
                            this._writer.WriteLine(LCDSizeTextBox.Text);
                            this._writer.WriteLine(HDDTextBox.Text);
                            this._writer.WriteLine(CPUBrandTextBox.Text);
                            this._writer.WriteLine(CPUNumberTextBox.Text);
                            this._writer.WriteLine(GPUTypeTextBox.Text);
                            this._writer.WriteLine(CPUTypeTextBox.Text);
                            this._writer.WriteLine(CPUSpeedTextBox.Text);
                            this._writer.WriteLine(WebCamTextBox.Text);
                            this._writer.Close();
                            MessageBox.Show("File Written Successfully", "File Status",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception.Message);
                            MessageBox.Show("Error  Writing File", "File Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "exitToolStripMenuItem":
                    this.Close();
                    break;
            }
        }
    }
}
