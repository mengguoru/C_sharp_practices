using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public class Operation
    {
        private double _num1;
        private double _num2;

       public double num1
        {
            get { return _num1; }
            set { _num1 = value; }
        }
        public double num2
        {
            get { return _num2; }
            set { _num2 = value; }
        }
        public virtual double getResult()
        {
            double result = 0;
            return result;
        }
    }
    public class OperationAdd : Operation
    {
        public override double getResult()
        {
            return (double)(num1 + num2);
        }
    }
    public class OperationSub : Operation
    {
        public override double getResult()
        {
            return (double)(num1 - num2);
        }
    }
    public class OperationMul : Operation
    {
        public override double getResult()
        {
            return (double)(num1*num2);
        }
    }
    public class OperationDiv : Operation
    {
        public override double getResult()
        {
            if (0 == num2)
                throw new Exception("divisor can't be 0");
            return (double)(num1/num2);
        }
    }
    // factory method pattern
    public class OperationFactory
    {
        public static Operation createOperation(string item)
        {
            Operation temp = null;
            switch(item)
            {
                case "+":
                    temp = new OperationAdd();
                    break;
                case "-":
                    temp = new OperationSub();
                    break;
                case "*":
                    temp = new OperationMul();
                    break;
                case "/":
                    temp = new OperationDiv();
                    break;
            }
            return temp;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
            //set default item
            comboBox1.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.label1.Text = this.textBox1.Text + comboBox1.SelectedItem + this.textBox2.Text;
            String str = comboBox1.GetItemText(comboBox1.SelectedItem);
            Operation oper = OperationFactory.createOperation(str);
            try
            {
                oper.num1 = Convert.ToDouble(this.textBox1.Text);
                oper.num2 = Convert.ToDouble(this.textBox2.Text);
            }catch(Exception)
            {
                throw ;
            }
            double result = oper.getResult();
            this.label1.Text = Convert.ToString("result ="+result);
        }
    }
}
