using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* File filter
 * All Supported Types|*.txt;*.waypoints;*.shp;*.plan
 */

namespace MissionPlanner.GCSViews.FileSelecteds
{
    public partial class FileSelect : Form
    {
        private EOpenFileItem _eOpenFileItem;

        public string SelectedFile { get; set; }
        

        public FileSelect ( EOpenFileItem eOpenFileItem )
        {
            InitializeComponent( );
            _eOpenFileItem = eOpenFileItem;
        }

        private void TableStyle ( )
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle( );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle( );

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 204 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 21F );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 204 ) ) );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        }

        private bool IsFindRow ( DataGridViewRow dgr, int index )
        {
            return dgr.Cells[ index ].Value.ToString( ).IndexOf( tbFilter.Text ) > 0;
        }

        public void ShowFiles ( string directory, string extension = null )
        {
            if ( ( directory?.Length ?? -1 ) < 1 )
            {
                return;
            }

            var files = Directory.GetFiles( directory );

            foreach ( var file in files )
            {
                if ( extension != null )
                {
                    if ( !file.EndsWith( extension ) )
                    {
                        continue;
                    }
                }

                var fileName = Path.GetFileNameWithoutExtension( file );
                var time = File.GetLastWriteTime( file );
                var row = new object[]
                {
                    fileName,
                    time,
                    file
                };
                
                dataGridView.Rows.Add( row );
            }

            if ( files.Length > 0 )
            {
                btnOK.Enabled = true;
            }
        }

        private void BtnClear_Click ( object sender, EventArgs e )
        {
            if ( dataGridView.RowCount > 0 )
            {
                tbFilter.Clear( );
            }
        }

        private void TbFilter_TextChanged ( object sender, EventArgs e )
        {   
            btnOK.Enabled = false;
            
            foreach ( DataGridViewRow dgr in dataGridView.Rows )
            {
                if ( !dgr.IsNewRow && tbFilter.Text != string.Empty )
                {
                    var isFindedRow = IsFindRow( dgr, 0 ) || IsFindRow( dgr, 1 );

                    if ( isFindedRow )
                    {
                        dgr.Visible = true;
                        btnOK.Enabled = true;
                    }
                    else
                    {
                        dgr.Visible = false;
                    }
                }
            }
        }

        private void BtnOK_Click ( object sender, EventArgs e )
        {
            if ( ( dataGridView.CurrentCell?.RowIndex ?? -1 ) < 0 || ( dataGridView.CurrentCell?.ColumnIndex ?? -1 ) < 0 )
            {
                return;
            }

            SelectedFile = dataGridView.CurrentRow.Cells[ colPath.Index ].Value.ToString( );
            Close( );
        }

        private void BtnCancel_Click ( object sender, EventArgs e )
        {
            Close( );
        }

        private void BtnDelete_Click ( object sender, EventArgs e )
        {
            var resourceManager = new ResourceManager( GetType( ).FullName, Assembly.GetExecutingAssembly( ) );
            var question = resourceManager.GetString( "questionMissionText", CultureInfo.CurrentUICulture );
            var caption = resourceManager.GetString( "captionMissionText", CultureInfo.CurrentUICulture );

            switch ( _eOpenFileItem )
            {
                case EOpenFileItem.Mission:
                    if ( MessageBox.Show( question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.OK )
                    {
                        foreach ( DataGridViewRow row in dataGridView.SelectedRows )
                        {
                            var filename = dataGridView.SelectedRows[ 0 ].Cells[ "colPath" ].Value.ToString( );

                            dataGridView.Rows.Remove( row );
                            File.Delete( filename );
                            dataGridView.Update( );
                        }
                    }
                    break;
                case EOpenFileItem.BlackBox:
                    if ( MessageBox.Show( question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.OK )
                    {
                        foreach ( DataGridViewRow row in dataGridView.SelectedRows )
                        {
                            var filename = dataGridView.SelectedRows[ 0 ].Cells[ "colPath" ].Value.ToString( );

                            dataGridView.Rows.Remove( row );

                            try
                            {
                                File.Delete( filename );
                                File.Delete( filename + ".log" );
                                File.Delete( filename + ".log.gpx" );
                                File.Delete( filename + ".log.kml" );
                                File.Delete( filename + ".log.param" );
                                File.Delete( filename + ".logOwp.txt" );
                            }
                            catch (Exception)
                            { }

                            dataGridView.Update( );
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }
    }
}
