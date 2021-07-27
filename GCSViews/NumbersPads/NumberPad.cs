using MissionPlanner.GCSViews.NumbersPads.Controllers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.NumbersPads
{
    public partial class NumberPad<T> : Form
    {
        private T _editControl;

        private NumberClickController<T> numberClickController;

        #region CONSTRUCTORS

        public NumberPad ( )
        {
            InitializeComponent( );
        }

        public NumberPad ( T editControl ) : this()
        {
            _editControl = editControl;
            numberClickController = new NumberClickController<T>( editControl );
        }

        #endregion

        #region METHODS

        

        #endregion

        #region EVENTS_HANDLERS

        private void Btn0_Click ( object sender, EventArgs e )
        {
            
        }

        private void Btn1_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn2_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn3_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn4_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn5_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn6_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn7_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn8_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void Btn9_Click ( object sender, EventArgs e )
        {
            numberClickController.NumberButtonClick( sender );
        }

        private void BtnLeft_Click ( object sender, EventArgs e )
        {

        }

        private void BtnRight_Click ( object sender, EventArgs e )
        {

        }

        private void BtnBsp_Click ( object sender, EventArgs e )
        {

        }

        private void BtnMove_Click ( object sender, EventArgs e )
        {

        }

        private void Close_Click ( object sender, EventArgs e )
        {
            Close( );
        }

        private void BtnDel_Click ( object sender, EventArgs e )
        {

        }

        #endregion
    }
}
