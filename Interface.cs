using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Animation;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DESQT
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }
        public Chart chart_energy => chart1;
        public Interface Form => Form;


        private void Interface_Load(object sender, EventArgs e)
        {
            mewtest2.Hide();
            ktest2.Hide();
            ntest2.Hide();
            panel4.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible=false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ntest1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                mewtest2.Hide();
                ktest2.Show();
                ktest2.BringToFront();
                ntest2.Hide();
                eCidletest1.Hide();
            }
            else if (radioButton2.Checked)
            {
                mewtest2.Hide();
                ktest2.Hide();
                ntest2.Show();
                ntest2.BringToFront();
                eCidletest1.Hide();

            }
            else if( radioButton1.Checked)
            {
                mewtest2.Show();
                mewtest2.BringToFront();
                ktest2.Hide();
                ntest2.Hide();
                eCidletest1.Hide();


            }
            else
            {
                mewtest2.Hide();
                eCidletest1.BringToFront();
                ktest2.Hide();
                ntest2.Hide();
                eCidletest1.Show();
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Simulation.clear_stat_charts_var();
            SimulationNP.clear_stat_charts_var();
            clear_charts();
            Boolean preemp = false;
            if (radioButton11.Checked)
            {
                preemp = false;
            } //no preempt
            else if (radioButton10.Checked)
            {
                preemp = true;
            }//preempt
            //PRIORITY////////////////////////////////////////////////////////////////////////////////////////////////
            if (radioButton8.Checked)//priority
            {
                label17.Text = "Priority Model";
               
                if (radioButton1.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        
                        Simulation.Simulation_mew_test(preemp,Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text),
                        Convert.ToSingle(mewtest2.textBox9.Text), Convert.ToSingle(mewtest2.textBox12.Text), Convert.ToSingle(mewtest2.textBox13.Text)
                        , Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text), Convert.ToInt32(mewtest2.textBox3.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text), Convert.ToSingle(mewtest2.textBox8.Text),
                        Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        label18.Text = "Buffer Size =" + mewtest2.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                        Simulation.Simulation_mew_test(preemp, Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text),
                        Convert.ToSingle(mewtest2.textBox9.Text), Convert.ToSingle(mewtest2.textBox12.Text), Convert.ToSingle(mewtest2.textBox13.Text)
                        , Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text), Convert.ToInt32(mewtest2.textBox3.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text), Convert.ToSingle(mewtest2.textBox8.Text),
                        Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        label18.Text = "Buffer Infinite ";

                    }

                    lambda_low.Text = "λ low =" + mewtest2.textBox9.Text;
                    lambda_med.Text = "λ med =" + mewtest2.textBox12.Text;
                    lambda_med.Visible = true;
                    lambda_high.Text = "λ high =" + mewtest2.textBox13.Text;
                    lambda_high.Visible = true;
                    

                    label19.Text = "Threshold =" + mewtest2.textBox4.Text;

                    label20.Text = "EC initial =" + mewtest2.textBox7.Text;
                    label21.Text = "EC busy =" + mewtest2.textBox6.Text;
                    label22.Text = "EC packet =" + mewtest2.textBox8.Text;
                    label23.Text = "EC switching =" + mewtest2.textBox2.Text;
                    label13.Text = "Arr dist =" + mewtest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + mewtest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + mewtest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "µ";
                    }
                    label6.Text = "Miu variation :";
                    update_charts(Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox10.Text));

                }  //mew test
                else if (radioButton2.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        Simulation.Simulation_n_test(preemp, Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text),
                       Convert.ToSingle(ntest2.textBox9.Text), Convert.ToSingle(ntest2.textBox12.Text), Convert.ToSingle(ntest2.textBox13.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text), Convert.ToInt32(ntest2.textBox3.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        label18.Text = "Buffer Size =" + ntest2.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                        Simulation.Simulation_n_test(preemp, Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text),
                       Convert.ToSingle(ntest2.textBox9.Text), Convert.ToSingle(ntest2.textBox12.Text), Convert.ToSingle(ntest2.textBox13.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text), Convert.ToInt32(ntest2.textBox3.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        label18.Text = "Buffer Infinite";
                    }
                    lambda_low.Text = "λ low =" + ntest2.textBox9.Text;
                    lambda_med.Text = "λ med =" + ntest2.textBox12.Text;
                    lambda_high.Text = "λ high =" + ntest2.textBox13.Text;


                    label19.Text = "Mew =" + ntest2.textBox4.Text;

                    label20.Text = "EC initial =" + ntest2.textBox7.Text;
                    label21.Text = "EC busy =" + ntest2.textBox6.Text;
                    label22.Text = "EC packet =" + ntest2.textBox8.Text;
                    label23.Text = "EC switching =" + ntest2.textBox2.Text;
                    label13.Text = "Arr dist =" + ntest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + ntest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + ntest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "N";
                    }
                    label6.Text = "N variation :";
                    update_charts(Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox10.Text));

                } //n test
                else if (radioButton9.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        Simulation.Simulation_ENIDLE_test(preemp, Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                        true, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                       Convert.ToSingle(eCidletest1.textBox10.Text),
                       Convert.ToSingle(eCidletest1.textBox9.Text), Convert.ToSingle(eCidletest1.textBox12.Text), Convert.ToSingle(eCidletest1.textBox13.Text)
                       , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text), Convert.ToInt32(eCidletest1.textBox5.Text),
                       Convert.ToInt32(eCidletest1.textBox3.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                       Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        label18.Text = "Buffer Size =" + eCidletest1.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                        Simulation.Simulation_ENIDLE_test(preemp, Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                        false, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                       Convert.ToSingle(eCidletest1.textBox10.Text),
                       Convert.ToSingle(eCidletest1.textBox9.Text), Convert.ToSingle(eCidletest1.textBox12.Text), Convert.ToSingle(eCidletest1.textBox13.Text)
                       , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text), Convert.ToInt32(eCidletest1.textBox5.Text),
                       Convert.ToInt32(eCidletest1.textBox3.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                       Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        label18.Text = "Buffer Infinite";
                    }
                    lambda_low.Text = "λ low =" + eCidletest1.textBox9.Text;
                    lambda_med.Text = "λ med =" + eCidletest1.textBox12.Text;
                    lambda_high.Text = "λ high =" + eCidletest1.textBox13.Text;


                    label19.Text = "Mew =" + eCidletest1.textBox16.Text;

                    label20.Text = "N =" + eCidletest1.textBox4.Text;
                    label21.Text = "EC busy =" + eCidletest1.textBox6.Text;
                    label22.Text = "EC packet =" + eCidletest1.textBox8.Text;
                    label23.Text = "EC switching =" + eCidletest1.textBox2.Text;
                    label13.Text = "Arr dist =" + eCidletest1.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + eCidletest1.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + eCidletest1.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "ECi";
                    }
                    label6.Text = "EC idle variation :";
                    update_charts(Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox10.Text));


                }//EC idle
                else
                {
                    if (radioButton4.Checked)
                    {
                        Simulation.Simulation_k_test(preemp, Convert.ToString(ktest2.comboBox1.SelectedItem), Convert.ToString(ktest2.comboBox2.SelectedItem),
                            Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox11.Text),
                            Convert.ToSingle(ktest2.textBox10.Text),
                            Convert.ToSingle(ktest2.textBox9.Text), Convert.ToSingle(ktest2.textBox12.Text), Convert.ToSingle(ktest2.textBox13.Text)
                            , Convert.ToSingle(ktest2.textBox5.Text), Convert.ToInt32(ktest2.textBox4.Text), Convert.ToInt32(ktest2.textBox3.Text),
                            Convert.ToSingle(ktest2.textBox7.Text), Convert.ToSingle(ktest2.textBox6.Text), Convert.ToSingle(ktest2.textBox8.Text),
                            Convert.ToSingle(ktest2.textBox2.Text), Convert.ToSingle(ktest2.textBox14.Text));
                    }
                    lambda_low.Text = "λ low =" + ktest2.textBox9.Text;
                    lambda_med.Text = "λ med =" + ktest2.textBox12.Text;
                    lambda_high.Text = "λ high =" + ktest2.textBox13.Text;


                    label18.Text = "Threshold =" + ktest2.textBox5.Text;
                    label19.Text = "Mew =" + ktest2.textBox4.Text;

                    label20.Text = "EC initial =" + ktest2.textBox7.Text;
                    label21.Text = "EC busy =" + ktest2.textBox6.Text;
                    label22.Text = "EC packet =" + ktest2.textBox8.Text;
                    label23.Text = "EC switching =" + ktest2.textBox2.Text;
                    label13.Text = "Arr dist =" + ktest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + ktest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + ktest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "K";
                    }
                    label6.Text = "K variation :";
                    update_charts(Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox10.Text));

                } //k test
            }
            //SANS PRIORITY////////////////////////////////////////////////////////////////////////////////////////////////
            else if(radioButton6.Checked)//sans priority
            {
                label17.Text = "Without Priority Model";
                if (radioButton1.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        // float lambda = Convert.ToSingle(mewtest2.textBox9.Text)+ Convert.ToSingle(mewtest2.textBox12.Text)+ Convert.ToSingle(mewtest2.textBox13.Text);
                       // float lambda = Convert.ToSingle(mewtest2.textBox9.Text);
                        SimulationNP.Simulation_mew_test(Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text), Convert.ToSingle(mewtest2.textBox15.Text), Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text), 
                        Convert.ToSingle(mewtest2.textBox8.Text), Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        label18.Text = "Buffer Size =" + mewtest2.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                        //float lambda = Convert.ToSingle(mewtest2.textBox9.Text) + Convert.ToSingle(mewtest2.textBox12.Text) + Convert.ToSingle(mewtest2.textBox13.Text);
                       // float lambda = Convert.ToSingle(mewtest2.textBox9.Text);
                        SimulationNP.Simulation_mew_test(Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text), Convert.ToSingle(mewtest2.textBox15.Text), Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text),
                        Convert.ToSingle(mewtest2.textBox8.Text), Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        label18.Text = "Buffer Infinite ";
                    }
                    // float lambd = Convert.ToSingle(mewtest2.textBox9.Text) + Convert.ToSingle(mewtest2.textBox12.Text) + Convert.ToSingle(mewtest2.textBox13.Text);
                    float lambd = Convert.ToSingle(mewtest2.textBox15.Text);
                    lambda_low.Text = "λ =" + Convert.ToString(lambd);
                    lambda_med.Visible = false;
                    lambda_high.Visible = false;

                    label19.Text = "Threshold =" + mewtest2.textBox4.Text;

                    label20.Text = "EC initial =" + mewtest2.textBox7.Text;
                    label21.Text = "EC busy =" + mewtest2.textBox6.Text;
                    label22.Text = "EC packet =" + mewtest2.textBox8.Text;
                    label23.Text = "EC switching =" + mewtest2.textBox2.Text;
                    label13.Text = "Arr dist =" + mewtest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + mewtest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + mewtest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "µ";
                    }
                    label6.Text = "Miu variation :";
                    update_charts(Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox10.Text));

                }  //mew test
                else if (radioButton2.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text);
                        SimulationNP.Simulation_n_test(Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text), Convert.ToSingle(ntest2.textBox15.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        label18.Text = "Buffer Size =" + ntest2.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text);
                        SimulationNP.Simulation_n_test(Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text), Convert.ToSingle(ntest2.textBox15.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        label18.Text = "Buffer Infinite";
                    }

                    //float lambd = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                    float lambd = Convert.ToSingle(ntest2.textBox15.Text);
                    lambda_low.Text = "λ =" + Convert.ToString(lambd);
                    lambda_med.Visible = false;
                    lambda_high.Visible = false; 


                    label19.Text = "Mew =" + ntest2.textBox4.Text;

                    label20.Text = "EC initial =" + ntest2.textBox7.Text;
                    label21.Text = "EC busy =" + ntest2.textBox6.Text;
                    label22.Text = "EC packet =" + ntest2.textBox8.Text;
                    label23.Text = "EC switching =" + ntest2.textBox2.Text;
                    label13.Text = "Arr dist =" + ntest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + ntest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + ntest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "N";
                    }
                    label6.Text = "N variation :";
                    update_charts(Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox10.Text));

                } //n test
                else if (radioButton9.Checked)
                {
                    if (radioButton4.Checked)
                    {
                       
                        SimulationNP.Simulation_ENIDLE_test(Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                        true, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                       Convert.ToSingle(eCidletest1.textBox10.Text), Convert.ToSingle(eCidletest1.textBox15.Text)
                       , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text),
                       Convert.ToInt32(eCidletest1.textBox5.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                       Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        label18.Text = "Buffer Size =" + eCidletest1.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {

                        SimulationNP.Simulation_ENIDLE_test(Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                       false, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                      Convert.ToSingle(eCidletest1.textBox10.Text), Convert.ToSingle(eCidletest1.textBox15.Text)
                      , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text),
                      Convert.ToInt32(eCidletest1.textBox5.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                      Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        label18.Text = "Buffer Infinite";
                    }

                    //float lambd = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                    float lambd = Convert.ToSingle(eCidletest1.textBox15.Text);
                    lambda_low.Text = "λ =" + Convert.ToString(lambd);
                    lambda_med.Visible = false;
                    lambda_high.Visible = false;


                    label19.Text = "Mew =" + eCidletest1.textBox16.Text;

                    label20.Text = "N ="+eCidletest1.textBox4.Text;
                    label21.Text = "EC busy =" + eCidletest1.textBox6.Text;
                    label22.Text = "EC packet =" + eCidletest1.textBox8.Text;
                    label23.Text = "EC switching =" + eCidletest1.textBox2.Text;
                    label13.Text = "Arr dist =" + eCidletest1.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + eCidletest1.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + eCidletest1.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "ECi";
                    }
                    label6.Text = "EC idle variation :";
                    update_charts(Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox10.Text));


                }//EC idle
                else
                {
                    if (radioButton4.Checked)
                    {
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text);
                        SimulationNP.Simulation_k_test(Convert.ToString(ktest2.comboBox1.SelectedItem), Convert.ToString(ktest2.comboBox2.SelectedItem),
                            Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox11.Text),
                            Convert.ToSingle(ktest2.textBox10.Text), Convert.ToSingle(ktest2.textBox15.Text)
                            , Convert.ToSingle(ktest2.textBox5.Text), Convert.ToInt32(ktest2.textBox4.Text),
                            Convert.ToSingle(ktest2.textBox7.Text), Convert.ToSingle(ktest2.textBox6.Text), Convert.ToSingle(ktest2.textBox8.Text),
                            Convert.ToSingle(ktest2.textBox2.Text), Convert.ToSingle(ktest2.textBox14.Text));
                    }
                    // float lambd = Convert.ToSingle(ktest2.textBox9.Text) + Convert.ToSingle(ktest2.textBox12.Text) + Convert.ToSingle(ktest2.textBox13.Text);
                    float lambd = Convert.ToSingle(ktest2.textBox15.Text);
                    lambda_low.Text = "λ =" + lambd;
                    lambda_med.Visible = false;
                    lambda_high.Visible = false;


                    label18.Text = "Threshold =" + ktest2.textBox5.Text;
                    label19.Text = "Mew =" + ktest2.textBox4.Text;

                    label20.Text = "EC initial =" + ktest2.textBox7.Text;
                    label21.Text = "EC busy =" + ktest2.textBox6.Text;
                    label22.Text = "EC packet =" + ktest2.textBox8.Text;
                    label23.Text = "EC switching =" + ktest2.textBox2.Text;
                    label13.Text = "Arr dist =" + ktest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + ktest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + ktest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "K";
                    }
                    label6.Text = "K variation :";
                    update_charts(Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox10.Text));

                } //k test
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            else //both
            {
                label17.Text = "Both Models";
                if (radioButton1.Checked)
                {
                    if (radioButton4.Checked)
                    {
                      Simulation.Simulation_mew_test(preemp,Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text),
                        Convert.ToSingle(mewtest2.textBox9.Text), Convert.ToSingle(mewtest2.textBox12.Text), Convert.ToSingle(mewtest2.textBox13.Text)
                        , Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text), Convert.ToInt32(mewtest2.textBox3.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text), Convert.ToSingle(mewtest2.textBox8.Text),
                        Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        //float lambda = Convert.ToSingle(mewtest2.textBox9.Text) + Convert.ToSingle(mewtest2.textBox12.Text) + Convert.ToSingle(mewtest2.textBox13.Text);
                       // float lambda = Convert.ToSingle(mewtest2.textBox9.Text);
                        SimulationNP.Simulation_mew_test(Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text), Convert.ToSingle(mewtest2.textBox15.Text), Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text),
                        Convert.ToSingle(mewtest2.textBox8.Text), Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        label25.Text = "λ Total =" + mewtest2.textBox15.Text;

                        label18.Text = "Buffer Size =" + mewtest2.textBox5.Text;
                    }
                    else if (radioButton5.Checked)
                    {
                      Simulation.Simulation_mew_test(preemp,Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text),
                        Convert.ToSingle(mewtest2.textBox9.Text), Convert.ToSingle(mewtest2.textBox12.Text), Convert.ToSingle(mewtest2.textBox13.Text)
                        , Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text), Convert.ToInt32(mewtest2.textBox3.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text), Convert.ToSingle(mewtest2.textBox8.Text),
                        Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        // float lambda = Convert.ToSingle(mewtest2.textBox9.Text) + Convert.ToSingle(mewtest2.textBox12.Text) + Convert.ToSingle(mewtest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(mewtest2.textBox9.Text);
                        SimulationNP.Simulation_mew_test(Convert.ToString(mewtest2.comboBox1.SelectedItem), Convert.ToString(mewtest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox11.Text),
                        Convert.ToSingle(mewtest2.textBox10.Text), Convert.ToSingle(mewtest2.textBox15.Text), Convert.ToInt32(mewtest2.textBox5.Text), Convert.ToInt32(mewtest2.textBox4.Text),
                        Convert.ToSingle(mewtest2.textBox7.Text), Convert.ToSingle(mewtest2.textBox6.Text),
                        Convert.ToSingle(mewtest2.textBox8.Text), Convert.ToSingle(mewtest2.textBox2.Text), Convert.ToSingle(mewtest2.textBox14.Text));
                        label25.Text = "λ Total =" + mewtest2.textBox15.Text;

                        label18.Text = "Buffer Infinite ";

                    }

                    lambda_low.Text = "λ low =" + mewtest2.textBox9.Text;
                    lambda_med.Text = "λ med =" + mewtest2.textBox12.Text;
                    lambda_high.Text = "λ high =" + mewtest2.textBox13.Text;


                    label19.Text = "Threshold =" + mewtest2.textBox4.Text;

                    label20.Text = "EC initial =" + mewtest2.textBox7.Text;
                    label21.Text = "EC busy =" + mewtest2.textBox6.Text;
                    label22.Text = "EC packet =" + mewtest2.textBox8.Text;
                    label23.Text = "EC switching =" + mewtest2.textBox2.Text;
                    label13.Text = "Arr dist =" + mewtest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + mewtest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + mewtest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "µ";
                    }
                    label6.Text = "Miu variation :";
                    update_charts(Convert.ToSingle(mewtest2.textBox1.Text), Convert.ToSingle(mewtest2.textBox10.Text));

                }  //mew test
                else if (radioButton2.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        Simulation.Simulation_n_test(preemp,Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text),
                       Convert.ToSingle(ntest2.textBox9.Text), Convert.ToSingle(ntest2.textBox12.Text), Convert.ToSingle(ntest2.textBox13.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text), Convert.ToInt32(ntest2.textBox3.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text);
                        SimulationNP.Simulation_n_test(Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        true, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text), Convert.ToSingle(ntest2.textBox15.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        label25.Text = "λ Total =" + ntest2.textBox15.Text;
                        label18.Text = "Buffer Size =" + ntest2.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                      Simulation.Simulation_n_test(preemp,Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text),
                       Convert.ToSingle(ntest2.textBox9.Text), Convert.ToSingle(ntest2.textBox12.Text), Convert.ToSingle(ntest2.textBox13.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text), Convert.ToInt32(ntest2.textBox3.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        // float lambda = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text);
                        SimulationNP.Simulation_n_test(Convert.ToString(ntest2.comboBox1.SelectedItem), Convert.ToString(ntest2.comboBox2.SelectedItem),
                        false, Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox11.Text),
                       Convert.ToSingle(ntest2.textBox10.Text), Convert.ToSingle(ntest2.textBox15.Text)
                       , Convert.ToSingle(ntest2.textBox4.Text), Convert.ToInt32(ntest2.textBox5.Text),
                       Convert.ToSingle(ntest2.textBox7.Text), Convert.ToSingle(ntest2.textBox6.Text), Convert.ToSingle(ntest2.textBox8.Text),
                       Convert.ToSingle(ntest2.textBox2.Text), Convert.ToSingle(ntest2.textBox14.Text));
                        label25.Text = "λ Total =" + ntest2.textBox15.Text;
                        label18.Text = "Buffer Infinite";
                    }
                    lambda_low.Text = "λ low =" + ntest2.textBox9.Text;
                    lambda_med.Text = "λ med =" + ntest2.textBox12.Text;
                    lambda_high.Text = "λ high =" + ntest2.textBox13.Text;


                    label19.Text = "Mew =" + ntest2.textBox4.Text;

                    label20.Text = "EC initial =" + ntest2.textBox7.Text;
                    label21.Text = "EC busy =" + ntest2.textBox6.Text;
                    label22.Text = "EC packet =" + ntest2.textBox8.Text;
                    label23.Text = "EC switching =" + ntest2.textBox2.Text;
                    label13.Text = "Arr dist =" + ntest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + ntest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + ntest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "N";
                    }
                    label6.Text = "N variation :";
                    update_charts(Convert.ToSingle(ntest2.textBox1.Text), Convert.ToSingle(ntest2.textBox10.Text));

                } //n test
                else if (radioButton9.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        Simulation.Simulation_ENIDLE_test(preemp,Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                        true, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                       Convert.ToSingle(eCidletest1.textBox10.Text),
                       Convert.ToSingle(eCidletest1.textBox9.Text), Convert.ToSingle(eCidletest1.textBox12.Text), Convert.ToSingle(eCidletest1.textBox13.Text)
                       , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text), Convert.ToInt32(eCidletest1.textBox5.Text),
                       Convert.ToInt32(eCidletest1.textBox3.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                       Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        SimulationNP.Simulation_ENIDLE_test(Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                       true, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                      Convert.ToSingle(eCidletest1.textBox10.Text), Convert.ToSingle(eCidletest1.textBox15.Text)
                      , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text),
                      Convert.ToInt32(eCidletest1.textBox5.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                      Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        label18.Text = "Buffer Size =" + eCidletest1.textBox5.Text;

                    }
                    else if (radioButton5.Checked)
                    {
                        Simulation.Simulation_ENIDLE_test(preemp,Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                        false, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                       Convert.ToSingle(eCidletest1.textBox10.Text),
                       Convert.ToSingle(eCidletest1.textBox9.Text), Convert.ToSingle(eCidletest1.textBox12.Text), Convert.ToSingle(eCidletest1.textBox13.Text)
                       , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text), Convert.ToInt32(eCidletest1.textBox5.Text),
                       Convert.ToInt32(eCidletest1.textBox3.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                       Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        SimulationNP.Simulation_ENIDLE_test(Convert.ToString(eCidletest1.comboBox1.SelectedItem), Convert.ToString(eCidletest1.comboBox2.SelectedItem),
                      false, Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox11.Text),
                     Convert.ToSingle(eCidletest1.textBox10.Text), Convert.ToSingle(eCidletest1.textBox15.Text)
                     , Convert.ToSingle(eCidletest1.textBox16.Text), Convert.ToInt32(eCidletest1.textBox4.Text),
                     Convert.ToInt32(eCidletest1.textBox5.Text), Convert.ToSingle(eCidletest1.textBox6.Text), Convert.ToSingle(eCidletest1.textBox8.Text),
                     Convert.ToSingle(eCidletest1.textBox2.Text), Convert.ToSingle(eCidletest1.textBox14.Text));
                        label18.Text = "Buffer Infinite";
                    }
                    lambda_low.Text = "λ low =" + eCidletest1.textBox9.Text;
                    lambda_med.Text = "λ med =" + eCidletest1.textBox12.Text;
                    lambda_high.Text = "λ high =" + eCidletest1.textBox13.Text;
                    label16.Text= "λ no prio = " + eCidletest1.textBox15.Text;

                    label19.Text = "Mew =" + eCidletest1.textBox16.Text;

                    label20.Text = "N =" + eCidletest1.textBox4.Text;
                    label21.Text = "EC busy =" + eCidletest1.textBox6.Text;
                    label22.Text = "EC packet =" + eCidletest1.textBox8.Text;
                    label23.Text = "EC switching =" + eCidletest1.textBox2.Text;
                    label13.Text = "Arr dist =" + eCidletest1.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + eCidletest1.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + eCidletest1.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "ECi";
                    }
                    label6.Text = "EC idle variation :";
                    update_charts(Convert.ToSingle(eCidletest1.textBox1.Text), Convert.ToSingle(eCidletest1.textBox10.Text));


                }//EC idle
                else
                {
                    if (radioButton4.Checked)
                    {
                        Simulation.Simulation_k_test(preemp,Convert.ToString(ktest2.comboBox1.SelectedItem), Convert.ToString(ktest2.comboBox2.SelectedItem),
                                               Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox11.Text),
                                               Convert.ToSingle(ktest2.textBox10.Text),
                                               Convert.ToSingle(ktest2.textBox9.Text), Convert.ToSingle(ktest2.textBox12.Text), Convert.ToSingle(ktest2.textBox13.Text)
                                               , Convert.ToSingle(ktest2.textBox5.Text), Convert.ToInt32(ktest2.textBox4.Text), Convert.ToInt32(ktest2.textBox3.Text),
                                               Convert.ToSingle(ktest2.textBox7.Text), Convert.ToSingle(ktest2.textBox6.Text), Convert.ToSingle(ktest2.textBox8.Text),
                                               Convert.ToSingle(ktest2.textBox2.Text), Convert.ToSingle(ktest2.textBox14.Text));
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                        //float lambda = Convert.ToSingle(ntest2.textBox9.Text);
                        SimulationNP.Simulation_k_test(Convert.ToString(ktest2.comboBox1.SelectedItem), Convert.ToString(ktest2.comboBox2.SelectedItem),
                            Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox11.Text),
                            Convert.ToSingle(ktest2.textBox10.Text), Convert.ToSingle(ktest2.textBox15.Text)
                            , Convert.ToSingle(ktest2.textBox5.Text), Convert.ToInt32(ktest2.textBox4.Text),
                            Convert.ToSingle(ktest2.textBox7.Text), Convert.ToSingle(ktest2.textBox6.Text), Convert.ToSingle(ktest2.textBox8.Text),
                            Convert.ToSingle(ktest2.textBox2.Text), Convert.ToSingle(ktest2.textBox14.Text));

                    }

                    //   float lambda2 = Convert.ToSingle(ntest2.textBox9.Text) + Convert.ToSingle(ntest2.textBox12.Text) + Convert.ToSingle(ntest2.textBox13.Text);
                    //float lambda2 = Convert.ToSingle(ntest2.textBox9.Text);
                    lambda_low.Text = "λ low =" + ktest2.textBox9.Text;
                    lambda_med.Text = "λ med =" + ktest2.textBox12.Text;
                    lambda_high.Text = "λ high =" + ktest2.textBox13.Text;
                    label25.Text = "λ Total =" + ktest2.textBox15.Text;


                    label18.Text = "Threshold =" + ktest2.textBox5.Text;
                    label19.Text = "Mew =" + ktest2.textBox4.Text;

                    label20.Text = "EC initial =" + ktest2.textBox7.Text;
                    label21.Text = "EC busy =" + ktest2.textBox6.Text;
                    label22.Text = "EC packet =" + ktest2.textBox8.Text;
                    label23.Text = "EC switching =" + ktest2.textBox2.Text;
                    label13.Text = "Arr dist =" + ktest2.comboBox1.SelectedItem;
                    label12.Text = "Serv dist =" + ktest2.comboBox2.SelectedItem;
                    label11.Text = "Standard dev =" + ktest2.textBox14.Text;
                    //---------------------------------

                    foreach (Chart x in panel4.Controls.OfType<Chart>())
                    {
                        x.ChartAreas[0].AxisX.Title = "K";
                    }
                    label6.Text = "K variation :";
                    update_charts(Convert.ToSingle(ktest2.textBox1.Text), Convert.ToSingle(ktest2.textBox10.Text));

                } //k test

            }
            //BOTH////////////////////////////////////////////////////////////////////////////////////////////////       
            panel4.Visible = true;
            panel3.Visible = false;
            
        }
        void update_charts(float begin, float step)
        {
            label10.BackColor = Color.FromArgb(20, 40, 80);
            label10.ForeColor = Color.White;
            chart_energy.Visible = true;

            chart_energy_update(begin, step);
            chart_Waiting_Time_update(begin, step);
            chart_debit_update(begin, step);
            chart_prob_blocking_update(begin, step);
            chart_prob_vacancy_update(begin, step);
            chart_Response_Time_update(begin, step);

        }
        void chart_energy_update(float begin,float step)
        {


            begin = (float)Math.Round((float)begin, 3);
            step = (float)Math.Round((Double)step, 3);
            float b = begin;
            float b2 = begin;
            float end1,end2;
            if (radioButton8.Checked)
            {
                end1 = (Simulation.EC_array).Count;
                chart1.Series.Add("With Priorite");
                chart1.Series[0].ChartType = SeriesChartType.Line;
                chart1.Series[0].BorderWidth = 4;
                chart1.Series[0].IsXValueIndexed = true;
                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[0].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart1.Series[0].MarkerSize = 10;
                chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
                chart1.ApplyPaletteColors();
                chart1.Series[0].LabelForeColor = chart1.Series[0].Color;
                chart1.Series[0].LabelBackColor = Color.FromArgb(233, 235, 238);

                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart1.Series[0].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.EC_array[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
            }
            else if (radioButton6.Checked)
            {
                end2 = (SimulationNP.EC_array).Count;
                chart1.Series.Add("Without PRIORITY");
                chart1.Series[0].ChartType = SeriesChartType.Line;
                chart1.Series[0].BorderWidth = 4;
                chart1.Series[0].IsXValueIndexed = true;
                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[0].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart1.Series[0].MarkerSize = 10;
                chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
                chart1.ApplyPaletteColors();
                chart1.Series[0].LabelForeColor = chart1.Series[0].Color;
                chart1.Series[0].LabelBackColor = Color.FromArgb(233, 235, 238);

                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart1.Series[0].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.EC_array[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
            }
            else 
            {
                end1 = (Simulation.EC_array).Count;
                chart1.Series.Add("With Priorite");
                chart1.Series["With Priorite"].ChartType = SeriesChartType.Line;
                chart1.Series["With Priorite"].BorderWidth = 4;
                chart1.Series["With Priorite"].IsXValueIndexed = true;
                chart1.Series["With Priorite"].IsValueShownAsLabel = true;
                chart1.Series["With Priorite"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart1.Series["With Priorite"].MarkerSize = 10;
                chart1.Series["With Priorite"].MarkerStyle = MarkerStyle.Circle;
                chart1.ApplyPaletteColors();
                chart1.Series["With Priorite"].LabelForeColor = chart1.Series[0].Color;
                chart1.Series["With Priorite"].LabelBackColor = Color.FromArgb(233, 235, 238);

                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart1.Series["With Priorite"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.EC_array[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                end2 = (SimulationNP.EC_array).Count;
                chart1.Series.Add("Without PRIORITY");
                chart1.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart1.Series["Without PRIORITY"].BorderWidth = 4;
                chart1.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart1.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart1.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart1.Series["Without PRIORITY"].MarkerSize = 10;
                chart1.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart1.ApplyPaletteColors();
                chart1.Series["Without PRIORITY"].LabelForeColor = chart1.Series[1].Color;
                chart1.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);

                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart1.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b2, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.EC_array[i]), 1, MidpointRounding.AwayFromZero));
                    b2 += step;
                }
            }
            
                       
        }
        void chart_Waiting_Time_update(float begin, float step)
        {

            float b = begin;
            float end1,end2;
            float b2 = begin;

            if (radioButton8.Checked)
            {
                end1 = (Simulation.Mean_waiting_timeLow).Count;

                chart6.Series.Add("LOW");
                chart6.Series["LOW"].ChartType = SeriesChartType.Line;
                chart6.Series["LOW"].BorderWidth = 4;
                chart6.Series["LOW"].IsXValueIndexed = true;
                chart6.Series["LOW"].IsValueShownAsLabel = true;
                chart6.Series["LOW"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["LOW"].MarkerSize = 10;
                chart6.Series["LOW"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["LOW"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart6.Series["LOW"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart6.Series["LOW"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_waiting_timeLow[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                //****************************************************************
                b = begin;


                chart6.Series.Add("MEDIUM");
                chart6.Series["MEDIUM"].ChartType = SeriesChartType.Line;
                chart6.Series["MEDIUM"].BorderWidth = 4;
                chart6.Series["MEDIUM"].IsXValueIndexed = true;
                chart6.Series["MEDIUM"].IsValueShownAsLabel = true;
                chart6.Series["MEDIUM"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["MEDIUM"].MarkerSize = 10;
                chart6.Series["MEDIUM"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["MEDIUM"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart6.Series["MEDIUM"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_waiting_timeMed).Count; i++)
                {
                    chart6.Series["MEDIUM"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_waiting_timeMed[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                //****************************************************************
                b = begin;


                chart6.Series.Add("HIGH");
                chart6.Series["HIGH"].ChartType = SeriesChartType.Line;
                chart6.Series["HIGH"].BorderWidth = 4;
                chart6.Series["HIGH"].IsXValueIndexed = true;
                chart6.Series["HIGH"].IsValueShownAsLabel = true;
                chart6.Series["HIGH"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["HIGH"].MarkerSize = 10;
                chart6.Series["HIGH"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["HIGH"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart6.Series["HIGH"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_waiting_timeHigh).Count; i++)
                {
                    chart6.Series["HIGH"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_waiting_timeHigh[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

            }
            else if (radioButton6.Checked)
            {
                end2 = (SimulationNP.Mean_waiting_time).Count;

                chart6.Series.Add("Without Priority");
                chart6.Series["Without Priority"].ChartType = SeriesChartType.Line;
                chart6.Series["Without Priority"].BorderWidth = 4;
                chart6.Series["Without Priority"].IsXValueIndexed = true;
                chart6.Series["Without Priority"].IsValueShownAsLabel = true;
                chart6.Series["Without Priority"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["Without Priority"].MarkerSize = 10;
                chart6.Series["Without Priority"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["Without Priority"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart6.Series["Without Priority"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart6.Series["Without Priority"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Mean_waiting_time[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }


            }
            else
            {
                end1 = (Simulation.Mean_waiting_timeLow).Count;

                chart6.Series.Add("LOW");
                chart6.Series["LOW"].ChartType = SeriesChartType.Line;
                chart6.Series["LOW"].BorderWidth = 4;
                chart6.Series["LOW"].IsXValueIndexed = true;
                chart6.Series["LOW"].IsValueShownAsLabel = true;
                chart6.Series["LOW"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["LOW"].MarkerSize = 10;
                chart6.Series["LOW"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["LOW"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart6.Series["LOW"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart6.Series["LOW"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_waiting_timeLow[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                //****************************************************************
                b = begin;


                chart6.Series.Add("MEDIUM");
                chart6.Series["MEDIUM"].ChartType = SeriesChartType.Line;
                chart6.Series["MEDIUM"].BorderWidth = 4;
                chart6.Series["MEDIUM"].IsXValueIndexed = true;
                chart6.Series["MEDIUM"].IsValueShownAsLabel = true;
                chart6.Series["MEDIUM"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["MEDIUM"].MarkerSize = 10;
                chart6.Series["MEDIUM"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["MEDIUM"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart6.Series["MEDIUM"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_waiting_timeMed).Count; i++)
                {
                    chart6.Series["MEDIUM"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_waiting_timeMed[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                //****************************************************************
                b = begin;


                chart6.Series.Add("HIGH");
                chart6.Series["HIGH"].ChartType = SeriesChartType.Line;
                chart6.Series["HIGH"].BorderWidth = 4;
                chart6.Series["HIGH"].IsXValueIndexed = true;
                chart6.Series["HIGH"].IsValueShownAsLabel = true;
                chart6.Series["HIGH"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["HIGH"].MarkerSize = 10;
                chart6.Series["HIGH"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["HIGH"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart6.Series["HIGH"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_waiting_timeHigh).Count; i++)
                {
                    chart6.Series["HIGH"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_waiting_timeHigh[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                end2 = (SimulationNP.Mean_waiting_time).Count;

                chart6.Series.Add("Without Priority");
                chart6.Series["Without Priority"].ChartType = SeriesChartType.Line;
                chart6.Series["Without Priority"].BorderWidth = 4;
                chart6.Series["Without Priority"].IsXValueIndexed = true;
                chart6.Series["Without Priority"].IsValueShownAsLabel = true;
                chart6.Series["Without Priority"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart6.Series["Without Priority"].MarkerSize = 10;
                chart6.Series["Without Priority"].MarkerStyle = MarkerStyle.Circle;
                chart6.ApplyPaletteColors();
                chart6.Series["Without Priority"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart6.Series["Without Priority"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart6.Series["Without Priority"].Points.AddXY(Math.Round((float)b2, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Mean_waiting_time[i]), 1, MidpointRounding.AwayFromZero));
                    b2 += step;
                }

            }
         
           
        }
        void chart_debit_update(float begin, float step)
        {
            float b = begin;
            float end1,end2;
            float b2 = begin;

            if (radioButton8.Checked)
            {
                end1 = (Simulation.DebitLow).Count;

                chart10.Series.Add("LOW");
                chart10.Series["LOW"].ChartType = SeriesChartType.Line;
                chart10.Series["LOW"].BorderWidth = 4;
                chart10.Series["LOW"].IsXValueIndexed = true;
                chart10.Series["LOW"].IsValueShownAsLabel = true;
                chart10.Series["LOW"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["LOW"].MarkerSize = 10;
                chart10.Series["LOW"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["LOW"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart10.Series["LOW"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart10.Series["LOW"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.DebitLow[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                //****************************************************************
                b = begin;


                chart10.Series.Add("MEDIUM");
                chart10.Series["MEDIUM"].ChartType = SeriesChartType.Line;
                chart10.Series["MEDIUM"].BorderWidth = 4;
                chart10.Series["MEDIUM"].IsXValueIndexed = true;
                chart10.Series["MEDIUM"].IsValueShownAsLabel = true;
                chart10.Series["MEDIUM"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["MEDIUM"].MarkerSize = 10;
                chart10.Series["MEDIUM"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["MEDIUM"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart10.Series["MEDIUM"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.DebitMed).Count; i++)
                {
                    chart10.Series["MEDIUM"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.DebitMed[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                //****************************************************************
                b = begin;


                chart10.Series.Add("HIGH");
                chart10.Series["HIGH"].ChartType = SeriesChartType.Line;
                chart10.Series["HIGH"].BorderWidth = 4;
                chart10.Series["HIGH"].IsXValueIndexed = true;
                chart10.Series["HIGH"].IsValueShownAsLabel = true;
                chart10.Series["HIGH"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["HIGH"].MarkerSize = 10;
                chart10.Series["HIGH"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["HIGH"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart10.Series["HIGH"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.DebitHigh).Count; i++)
                {
                    chart10.Series["HIGH"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.DebitHigh[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }


            }
            else if (radioButton6.Checked)
            {
                end2 = (SimulationNP.Debit).Count;

                chart10.Series.Add("Without PRiority");
                chart10.Series["Without PRiority"].ChartType = SeriesChartType.Line;
                chart10.Series["Without PRiority"].BorderWidth = 4;
                chart10.Series["Without PRiority"].IsXValueIndexed = true;
                chart10.Series["Without PRiority"].IsValueShownAsLabel = true;
                chart10.Series["Without PRiority"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["Without PRiority"].MarkerSize = 10;
                chart10.Series["Without PRiority"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["Without PRiority"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart10.Series["Without PRiority"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart10.Series["Without PRiority"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Debit[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
            }
            else
            {
                end1 = (Simulation.DebitLow).Count;

                chart10.Series.Add("LOW");
                chart10.Series["LOW"].ChartType = SeriesChartType.Line;
                chart10.Series["LOW"].BorderWidth = 4;
                chart10.Series["LOW"].IsXValueIndexed = true;
                chart10.Series["LOW"].IsValueShownAsLabel = true;
                chart10.Series["LOW"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["LOW"].MarkerSize = 10;
                chart10.Series["LOW"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["LOW"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart10.Series["LOW"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart10.Series["LOW"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.DebitLow[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                //****************************************************************
                b = begin;


                chart10.Series.Add("MEDIUM");
                chart10.Series["MEDIUM"].ChartType = SeriesChartType.Line;
                chart10.Series["MEDIUM"].BorderWidth = 4;
                chart10.Series["MEDIUM"].IsXValueIndexed = true;
                chart10.Series["MEDIUM"].IsValueShownAsLabel = true;
                chart10.Series["MEDIUM"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["MEDIUM"].MarkerSize = 10;
                chart10.Series["MEDIUM"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["MEDIUM"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart10.Series["MEDIUM"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.DebitMed).Count; i++)
                {
                    chart10.Series["MEDIUM"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.DebitMed[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                //****************************************************************
                b = begin;


                chart10.Series.Add("HIGH");
                chart10.Series["HIGH"].ChartType = SeriesChartType.Line;
                chart10.Series["HIGH"].BorderWidth = 4;
                chart10.Series["HIGH"].IsXValueIndexed = true;
                chart10.Series["HIGH"].IsValueShownAsLabel = true;
                chart10.Series["HIGH"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["HIGH"].MarkerSize = 10;
                chart10.Series["HIGH"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["HIGH"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart10.Series["HIGH"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.DebitHigh).Count; i++)
                {
                    chart10.Series["HIGH"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.DebitHigh[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                end2 = (SimulationNP.Debit).Count;

                chart10.Series.Add("Without PRiority");
                chart10.Series["Without PRiority"].ChartType = SeriesChartType.Line;
                chart10.Series["Without PRiority"].BorderWidth = 4;
                chart10.Series["Without PRiority"].IsXValueIndexed = true;
                chart10.Series["Without PRiority"].IsValueShownAsLabel = true;
                chart10.Series["Without PRiority"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart10.Series["Without PRiority"].MarkerSize = 10;
                chart10.Series["Without PRiority"].MarkerStyle = MarkerStyle.Circle;
                chart10.ApplyPaletteColors();
                chart10.Series["Without PRiority"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart10.Series["Without PRiority"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart10.Series["Without PRiority"].Points.AddXY(Math.Round((float)b2, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Debit[i]), 1, MidpointRounding.AwayFromZero));
                    b2 += step;
                }

            }
            
        }
        void chart_prob_blocking_update(float begin, float step)
        {
            float b = begin;
            float b2 = begin;
            float end1,end2;
            if (radioButton8.Checked)
            {
                end1 = (Simulation.Blocking_prob).Count;

                chart8.Series.Add("WITH PRIORITY");
                chart8.Series["WITH PRIORITY"].ChartType = SeriesChartType.Line;
                chart8.Series["WITH PRIORITY"].BorderWidth = 4;
                chart8.Series["WITH PRIORITY"].IsXValueIndexed = true;
                chart8.Series["WITH PRIORITY"].IsValueShownAsLabel = true;
                chart8.Series["WITH PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart8.Series["WITH PRIORITY"].MarkerSize = 10;
                chart8.Series["WITH PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart8.ApplyPaletteColors();
                chart8.Series["WITH PRIORITY"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart8.Series["WITH PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart8.Series["WITH PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Blocking_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

            }
            else if (radioButton6.Checked)
            {
                end2 = (SimulationNP.Blocking_prob).Count;

                chart8.Series.Add("Without PRIORITY");
                chart8.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart8.Series["Without PRIORITY"].BorderWidth = 4;
                chart8.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart8.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart8.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart8.Series["Without PRIORITY"].MarkerSize = 10;
                chart8.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart8.ApplyPaletteColors();
                chart8.Series["Without PRIORITY"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart8.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart8.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Blocking_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

            }
            else
            {
                end1 = (Simulation.Blocking_prob).Count;

                chart8.Series.Add("WITH PRIORITY");
                chart8.Series["WITH PRIORITY"].ChartType = SeriesChartType.Line;
                chart8.Series["WITH PRIORITY"].BorderWidth = 4;
                chart8.Series["WITH PRIORITY"].IsXValueIndexed = true;
                chart8.Series["WITH PRIORITY"].IsValueShownAsLabel = true;
                chart8.Series["WITH PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart8.Series["WITH PRIORITY"].MarkerSize = 10;
                chart8.Series["WITH PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart8.ApplyPaletteColors();
                chart8.Series["WITH PRIORITY"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart8.Series["WITH PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart8.Series["WITH PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Blocking_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                end2 = (SimulationNP.Blocking_prob).Count;

                chart8.Series.Add("Without PRIORITY");
                chart8.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart8.Series["Without PRIORITY"].BorderWidth = 4;
                chart8.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart8.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart8.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart8.Series["Without PRIORITY"].MarkerSize = 10;
                chart8.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart8.ApplyPaletteColors();
                chart8.Series["Without PRIORITY"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart8.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart8.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b2, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Blocking_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b2 += step;
                }

            }

        }
        void chart_prob_vacancy_update(float begin, float step)
        {
            float b = begin;
            float b2 = begin;

            float end1,end2;
            if (radioButton8.Checked)
            {
                end1 = (Simulation.Vacancy_prob).Count;

                chart7.Series.Add("WITH PRIORITY");
                chart7.Series["WITH PRIORITY"].ChartType = SeriesChartType.Line;
                chart7.Series["WITH PRIORITY"].BorderWidth = 4;
                chart7.Series["WITH PRIORITY"].IsXValueIndexed = true;
                chart7.Series["WITH PRIORITY"].IsValueShownAsLabel = true;
                chart7.Series["WITH PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart7.Series["WITH PRIORITY"].MarkerSize = 10;
                chart7.Series["WITH PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart7.ApplyPaletteColors();
                chart7.Series["WITH PRIORITY"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart7.Series["WITH PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart7.Series["WITH PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Vacancy_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
            }
            else if (radioButton6.Checked)
            {

                end2 = (SimulationNP.Vacancy_prob).Count;

                chart7.Series.Add("Without PRIORITY");
                chart7.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart7.Series["Without PRIORITY"].BorderWidth = 4;
                chart7.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart7.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart7.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart7.Series["Without PRIORITY"].MarkerSize = 10;
                chart7.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart7.ApplyPaletteColors();
                chart7.Series["Without PRIORITY"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart7.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart7.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Vacancy_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

            }
            else
            {
                end1 = (Simulation.Vacancy_prob).Count;

                chart7.Series.Add("WITH PRIORITY");
                chart7.Series["WITH PRIORITY"].ChartType = SeriesChartType.Line;
                chart7.Series["WITH PRIORITY"].BorderWidth = 4;
                chart7.Series["WITH PRIORITY"].IsXValueIndexed = true;
                chart7.Series["WITH PRIORITY"].IsValueShownAsLabel = true;
                chart7.Series["WITH PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart7.Series["WITH PRIORITY"].MarkerSize = 10;
                chart7.Series["WITH PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart7.ApplyPaletteColors();
                chart7.Series["WITH PRIORITY"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart7.Series["WITH PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart7.Series["WITH PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Vacancy_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                end2 = (SimulationNP.Vacancy_prob).Count;

                chart7.Series.Add("Without PRIORITY");
                chart7.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart7.Series["Without PRIORITY"].BorderWidth = 4;
                chart7.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart7.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart7.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart7.Series["Without PRIORITY"].MarkerSize = 10;
                chart7.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart7.ApplyPaletteColors();
                chart7.Series["Without PRIORITY"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart7.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart7.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b2, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Vacancy_prob[i]), 1, MidpointRounding.AwayFromZero));
                    b2 += step;
                }
            }

           
        }
        void chart_Response_Time_update(float begin, float step)
        {

            float b = begin;
            float b2 = begin;
            float end1,end2;
            if (radioButton8.Checked)
            {
                end1 = (Simulation.Mean_response_timeLow).Count;

                chart9.Series.Add("LOW");
                chart9.Series["LOW"].ChartType = SeriesChartType.Line;
                chart9.Series["LOW"].BorderWidth = 4;
                chart9.Series["LOW"].IsXValueIndexed = true;
                chart9.Series["LOW"].IsValueShownAsLabel = true;
                chart9.Series["LOW"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["LOW"].MarkerSize = 10;
                chart9.Series["LOW"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["LOW"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart9.Series["LOW"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart9.Series["LOW"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_response_timeLow[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                //****************************************************************
                b = begin;


                chart9.Series.Add("MEDIUM");
                chart9.Series["MEDIUM"].ChartType = SeriesChartType.Line;
                chart9.Series["MEDIUM"].BorderWidth = 4;
                chart9.Series["MEDIUM"].IsXValueIndexed = true;
                chart9.Series["MEDIUM"].IsValueShownAsLabel = true;
                chart9.Series["MEDIUM"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["MEDIUM"].MarkerSize = 10;
                chart9.Series["MEDIUM"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["MEDIUM"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart9.Series["MEDIUM"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_response_timeMed).Count; i++)
                {
                    chart9.Series["MEDIUM"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_response_timeMed[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                //****************************************************************
                b = begin;


                chart9.Series.Add("HIGH");
                chart9.Series["HIGH"].ChartType = SeriesChartType.Line;
                chart9.Series["HIGH"].BorderWidth = 4;
                chart9.Series["HIGH"].IsXValueIndexed = true;
                chart9.Series["HIGH"].IsValueShownAsLabel = true;
                chart9.Series["HIGH"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["HIGH"].MarkerSize = 10;
                chart9.Series["HIGH"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["HIGH"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart9.Series["HIGH"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_waiting_timeHigh).Count; i++)
                {
                    chart9.Series["HIGH"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_response_timeHigh[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

            }
            else if (radioButton6.Checked)
            {
                end2 = (SimulationNP.Mean_response_time).Count;

                chart9.Series.Add("Without PRIORITY");
                chart9.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart9.Series["Without PRIORITY"].BorderWidth = 4;
                chart9.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart9.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart9.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["Without PRIORITY"].MarkerSize = 10;
                chart9.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["Without PRIORITY"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart9.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart9.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Mean_response_time[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

            }
            else
            {
                end1 = (Simulation.Mean_response_timeLow).Count;

                chart9.Series.Add("LOW");
                chart9.Series["LOW"].ChartType = SeriesChartType.Line;
                chart9.Series["LOW"].BorderWidth = 4;
                chart9.Series["LOW"].IsXValueIndexed = true;
                chart9.Series["LOW"].IsValueShownAsLabel = true;
                chart9.Series["LOW"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["LOW"].MarkerSize = 10;
                chart9.Series["LOW"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["LOW"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart9.Series["LOW"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end1; i++)
                {
                    chart9.Series["LOW"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_response_timeLow[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                //****************************************************************
                b = begin;


                chart9.Series.Add("MEDIUM");
                chart9.Series["MEDIUM"].ChartType = SeriesChartType.Line;
                chart9.Series["MEDIUM"].BorderWidth = 4;
                chart9.Series["MEDIUM"].IsXValueIndexed = true;
                chart9.Series["MEDIUM"].IsValueShownAsLabel = true;
                chart9.Series["MEDIUM"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["MEDIUM"].MarkerSize = 10;
                chart9.Series["MEDIUM"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["MEDIUM"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart9.Series["MEDIUM"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_response_timeMed).Count; i++)
                {
                    chart9.Series["MEDIUM"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_response_timeMed[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }
                //****************************************************************
                b = begin;


                chart9.Series.Add("HIGH");
                chart9.Series["HIGH"].ChartType = SeriesChartType.Line;
                chart9.Series["HIGH"].BorderWidth = 4;
                chart9.Series["HIGH"].IsXValueIndexed = true;
                chart9.Series["HIGH"].IsValueShownAsLabel = true;
                chart9.Series["HIGH"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["HIGH"].MarkerSize = 10;
                chart9.Series["HIGH"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["HIGH"].LabelForeColor = chart1.Series["With Priorite"].Color;
                chart9.Series["HIGH"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < (Simulation.Mean_waiting_timeHigh).Count; i++)
                {
                    chart9.Series["HIGH"].Points.AddXY(Math.Round((float)b, 1, MidpointRounding.AwayFromZero), Math.Round((float)(Simulation.Mean_response_timeHigh[i]), 1, MidpointRounding.AwayFromZero));
                    b += step;
                }

                end2 = (SimulationNP.Mean_response_time).Count;

                chart9.Series.Add("Without PRIORITY");
                chart9.Series["Without PRIORITY"].ChartType = SeriesChartType.Line;
                chart9.Series["Without PRIORITY"].BorderWidth = 4;
                chart9.Series["Without PRIORITY"].IsXValueIndexed = true;
                chart9.Series["Without PRIORITY"].IsValueShownAsLabel = true;
                chart9.Series["Without PRIORITY"].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                chart9.Series["Without PRIORITY"].MarkerSize = 10;
                chart9.Series["Without PRIORITY"].MarkerStyle = MarkerStyle.Circle;
                chart9.ApplyPaletteColors();
                chart9.Series["Without PRIORITY"].LabelForeColor = chart1.Series["Without PRIORITY"].Color;
                chart9.Series["Without PRIORITY"].LabelBackColor = Color.FromArgb(233, 235, 238);
                // Add point.

                for (int i = 0; i < end2; i++)
                {
                    chart9.Series["Without PRIORITY"].Points.AddXY(Math.Round((float)b2, 1, MidpointRounding.AwayFromZero), Math.Round((float)(SimulationNP.Mean_response_time[i]), 1, MidpointRounding.AwayFromZero));
                    b2 += step;
                }

            }
        }


        void clear_charts()
        {
            chart1.Series.Clear();
            chart10.Series.Clear();
            chart7.Series.Clear();
            chart8.Series.Clear();
            chart9.Series.Clear();
            chart6.Series.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;


            foreach (System.Windows.Forms.Label x in panel6.Controls.OfType<System.Windows.Forms.Label>())
            {

                x.BackColor = Color.White;
                x.ForeColor = Color.Black;


            }
            foreach (Chart x in panel4.Controls.OfType<Chart>())
            {
                x.Visible = false;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Label clickedLabel = sender as System.Windows.Forms.Label;

            foreach (System.Windows.Forms.Label x in panel6.Controls.OfType<System.Windows.Forms.Label>())
            {
                if (x != clickedLabel)
                {
                    x.BackColor = Color.White;
                    x.ForeColor = Color.Black;
                }
                else
                {
                    clickedLabel.BackColor = Color.FromArgb(20, 40, 80);
                    clickedLabel.ForeColor = Color.White;


                }
            }


            switch (clickedLabel.Name)
            {
                case "label10":

                    chart1.Visible = true;

                    chart10.Visible = false;
                    chart9.Visible = false;
                    chart8.Visible = false;
                    chart7.Visible = false;
                    chart6.Visible = false;
                    break;

                case "label7":

                    chart10.Visible = true;

                    chart1.Visible = false;
                    chart6.Visible = false;
                    chart7.Visible = false;
                    chart8.Visible = false;
                    chart9.Visible = false;
                    break;

                case "label9":

                    chart9.Visible = true;

                    chart1.Visible = false;
                    chart6.Visible = false;
                    chart7.Visible = false;
                    chart8.Visible = false;
                    chart10.Visible = false;
                    break;

                case "label8":

                    chart6.Visible = true;

                    chart1.Visible = false;
                    chart7.Visible = false;
                    chart8.Visible = false;
                    chart9.Visible = false;
                    chart10.Visible = false;
                    break;


                case "label4":

                    chart7.Visible = true;

                    chart1.Visible = false;
                    chart6.Visible = false;
                    chart8.Visible = false;
                    chart9.Visible = false;
                    chart10.Visible = false;
                    break;


                case "label5":

                    chart8.Visible = true;

                    chart1.Visible = false;
                    chart6.Visible = false;
                    chart7.Visible = false;
                    chart9.Visible = false;
                    chart10.Visible = false;
                    break;





            }
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
    
}
