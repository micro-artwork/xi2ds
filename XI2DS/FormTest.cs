using System;
using System.Windows.Forms;
using SharpDX.XInput;
using Newtonsoft.Json;
using System.Drawing;

namespace XI2DS
{
    public partial class FormTest : Form
    {
        private State[] oldStates;
        private bool formLoaded = false;        

        public FormTest()
        {
            InitializeComponent();
            
            oldStates = new[]
            {
                new State(), new State(), new State(), new State()
            };
            
            //dataGridViewXInput.Rows.Add(4);
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                dataGridViewState.Rows.Add();
                dataGridViewState.Rows[rowIndex].Cells[0].Value = string.Format("{0}", rowIndex + 1);                
            }

            //dataGridViewState.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            formLoaded = true;
        }
        
        public void ShowState(int userIndex, State state)
        {   
            if (formLoaded)
            {
                var oldState = oldStates[userIndex];
                var oldJson = JsonConvert.SerializeObject(oldState);
                state.PacketNumber = 0;
                var newJson = JsonConvert.SerializeObject(state);

                if (oldJson != newJson)
                {                        
                    this.Invoke((MethodInvoker)delegate
                    {
                    var stateStr = Utils.XInputStateToText(state);
                        if (stateStr != "")
                        {
                            var log = string.Format("Controller {0} - {1}" + Environment.NewLine, userIndex + 1, stateStr);
                            this.uiTextLog.AppendText(log);
                        }

                        var data = Utils.XInputStateToGridViewData(state);
                        UpdateGridViewData(userIndex, data);
                    });
                    oldStates[userIndex] = state;
                }
            }
        }


        private void UpdateGridViewData(int rowIndex, float[] data)
        {

            for (int columnIndex = 0; columnIndex < data.Length; columnIndex++)
            {
                dataGridViewState.Rows[rowIndex].Cells[columnIndex + 1].Value = data[columnIndex];
                if (data[columnIndex] != 0f)
                {
                    dataGridViewState.Rows[rowIndex].Cells[columnIndex + 1].Style.BackColor = Color.LawnGreen;
                } else {
                    dataGridViewState.Rows[rowIndex].Cells[columnIndex + 1].Style.BackColor = Color.White;
                }

            }
            
        }


        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();            
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();            
        }
    }
}
