namespace MissionPlanner.GCSViews.Setups.Views
{
    partial class SettingView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingView));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.gbGpsFailtureActions = new System.Windows.Forms.GroupBox();
            this.rbAutoManeuvering = new System.Windows.Forms.RadioButton();
            this.rbLanding = new System.Windows.Forms.RadioButton();
            this.bgAlternateAerodromesPresence = new System.Windows.Forms.GroupBox();
            this.cbCheckAlternateAirfields = new System.Windows.Forms.CheckBox();
            this.gbCrossHairType = new System.Windows.Forms.GroupBox();
            this.rbBallistic = new System.Windows.Forms.RadioButton();
            this.rbRegular = new System.Windows.Forms.RadioButton();
            this.gbIkrlFailureActions = new System.Windows.Forms.GroupBox();
            this.rbIkrlAutoLanding = new System.Windows.Forms.RadioButton();
            this.rbIkrlTakeoffPoint = new System.Windows.Forms.RadioButton();
            this.gbAutoMode = new System.Windows.Forms.GroupBox();
            this.tlpAutoMode = new System.Windows.Forms.TableLayoutPanel();
            this.tbHomeReturnAltitude = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.lblHomeReturnAltitude = new System.Windows.Forms.Label();
            this.tbHomeReturnSpeed = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.lblHomeReturnSpeed = new System.Windows.Forms.Label();
            this.cbUseAlternateAirfieldStartPlace = new System.Windows.Forms.CheckBox();
            this.lblIterationCount = new System.Windows.Forms.Label();
            this.lblIdUav = new System.Windows.Forms.Label();
            this.tbIterationInstructionCount = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.tbIdUav = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.tbHeight = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.tbHangTime = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.tbSpeed = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.lblHangTime = new System.Windows.Forms.Label();
            this.tbPatrolRadius = new MissionPlanner.Controls.TextBoxes.IntTextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblPatrolRadius = new System.Windows.Forms.Label();
            this.gbLowBatteryActions = new System.Windows.Forms.GroupBox();
            this.cmbCrtBatteryActions = new System.Windows.Forms.ComboBox();
            this.cmbLowBatteryActions = new System.Windows.Forms.ComboBox();
            this.lblCrtBatteryAction = new System.Windows.Forms.Label();
            this.lblLowBatteryAction = new System.Windows.Forms.Label();
            this.gbGps = new System.Windows.Forms.GroupBox();
            this.btnGpsOff = new System.Windows.Forms.Button();
            this.btnGpsOn = new System.Windows.Forms.Button();
            this.tpInterface = new System.Windows.Forms.TabPage();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.rbKm_h = new System.Windows.Forms.RadioButton();
            this.rbM_S = new System.Windows.Forms.RadioButton();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.gbCoordinateSystem = new System.Windows.Forms.GroupBox();
            this.rbWgs84Deg = new System.Windows.Forms.RadioButton();
            this.rbSC_42 = new System.Windows.Forms.RadioButton();
            this.rbWGS_84 = new System.Windows.Forms.RadioButton();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.tpUpScreen = new System.Windows.Forms.TabPage();
            this.tlpHud = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHudParts = new System.Windows.Forms.TableLayoutPanel();
            this.tlpIndicators = new System.Windows.Forms.TableLayoutPanel();
            this.cbIndicators = new System.Windows.Forms.CheckBox();
            this.btnIndicators = new System.Windows.Forms.Button();
            this.tblUav = new System.Windows.Forms.TableLayoutPanel();
            this.cbUavParam = new System.Windows.Forms.CheckBox();
            this.btnUavParams = new System.Windows.Forms.Button();
            this.tblBattery = new System.Windows.Forms.TableLayoutPanel();
            this.cbBattery = new System.Windows.Forms.CheckBox();
            this.btnBattery = new System.Windows.Forms.Button();
            this.tblTarget = new System.Windows.Forms.TableLayoutPanel();
            this.cbTargetParam = new System.Windows.Forms.CheckBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.tblOther = new System.Windows.Forms.TableLayoutPanel();
            this.cbOtherParam = new System.Windows.Forms.CheckBox();
            this.btnOther = new System.Windows.Forms.Button();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.IndicatorBox = new System.Windows.Forms.GroupBox();
            this.cbGroundLevel = new System.Windows.Forms.CheckBox();
            this.cbCompass = new System.Windows.Forms.CheckBox();
            this.cbRollScale = new System.Windows.Forms.CheckBox();
            this.cbPitchScale = new System.Windows.Forms.CheckBox();
            this.cbCrossMark = new System.Windows.Forms.CheckBox();
            this.UavParamBox = new System.Windows.Forms.GroupBox();
            this.cbLatitude = new System.Windows.Forms.CheckBox();
            this.cbFlightTime = new System.Windows.Forms.CheckBox();
            this.cbFlightPath = new System.Windows.Forms.CheckBox();
            this.cbFlightMode = new System.Windows.Forms.CheckBox();
            this.cbLongitude = new System.Windows.Forms.CheckBox();
            this.cbInclination = new System.Windows.Forms.CheckBox();
            this.cbAzimuth = new System.Windows.Forms.CheckBox();
            this.cbHomeDistance = new System.Windows.Forms.CheckBox();
            this.cbRollAngle = new System.Windows.Forms.CheckBox();
            this.cbPitchAngle = new System.Windows.Forms.CheckBox();
            this.BatteryBox = new System.Windows.Forms.GroupBox();
            this.cbBatteryVoltage = new System.Windows.Forms.CheckBox();
            this.cbBatteryLevel = new System.Windows.Forms.CheckBox();
            this.cbBatteryCapacity = new System.Windows.Forms.CheckBox();
            this.cbBatteryTimeLeft = new System.Windows.Forms.CheckBox();
            this.TargetBox = new System.Windows.Forms.GroupBox();
            this.cbTarLon = new System.Windows.Forms.CheckBox();
            this.cbTarLat = new System.Windows.Forms.CheckBox();
            this.cbTargetHeight = new System.Windows.Forms.CheckBox();
            this.cbTargetWidth = new System.Windows.Forms.CheckBox();
            this.OtherParamBox = new System.Windows.Forms.GroupBox();
            this.cbWeaponStatus = new System.Windows.Forms.CheckBox();
            this.cbWindSpeed = new System.Windows.Forms.CheckBox();
            this.cbWindAngle = new System.Windows.Forms.CheckBox();
            this.cbSatellites = new System.Windows.Forms.CheckBox();
            this.cbSignalLevel = new System.Windows.Forms.CheckBox();
            this.cbAltitudeWrtHome = new System.Windows.Forms.CheckBox();
            this.cbRange1 = new System.Windows.Forms.CheckBox();
            this.cbRange2 = new System.Windows.Forms.CheckBox();
            this.cbCameraVAngle = new System.Windows.Forms.CheckBox();
            this.cbCameraHAngle = new System.Windows.Forms.CheckBox();
            this.cbVerticalSpeed = new System.Windows.Forms.CheckBox();
            this.cbAltitudeWrtGround = new System.Windows.Forms.CheckBox();
            this.cbHorizontalSpeed = new System.Windows.Forms.CheckBox();
            this.rbHomeReturn = new System.Windows.Forms.RadioButton();
            this.rbTakeoffPoint = new System.Windows.Forms.RadioButton();
            this.rbAutoLanding = new System.Windows.Forms.RadioButton();
            this.lblIterationInstructionCount = new System.Windows.Forms.Label();
            this.lblLbaAutoReturn = new System.Windows.Forms.Label();
            this.lblLbaAutoLanding = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tlpGeneral.SuspendLayout();
            this.gbGpsFailtureActions.SuspendLayout();
            this.bgAlternateAerodromesPresence.SuspendLayout();
            this.gbCrossHairType.SuspendLayout();
            this.gbIkrlFailureActions.SuspendLayout();
            this.gbAutoMode.SuspendLayout();
            this.tlpAutoMode.SuspendLayout();
            this.gbLowBatteryActions.SuspendLayout();
            this.gbGps.SuspendLayout();
            this.tpInterface.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.gbCoordinateSystem.SuspendLayout();
            this.tpUpScreen.SuspendLayout();
            this.tlpHud.SuspendLayout();
            this.tlpHudParts.SuspendLayout();
            this.tlpIndicators.SuspendLayout();
            this.tblUav.SuspendLayout();
            this.tblBattery.SuspendLayout();
            this.tblTarget.SuspendLayout();
            this.tblOther.SuspendLayout();
            this.tlpDetails.SuspendLayout();
            this.IndicatorBox.SuspendLayout();
            this.UavParamBox.SuspendLayout();
            this.BatteryBox.SuspendLayout();
            this.TargetBox.SuspendLayout();
            this.OtherParamBox.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tpGeneral);
            this.tabControl.Controls.Add(this.tpInterface);
            this.tabControl.Controls.Add(this.tpUpScreen);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Controls.Add(this.tlpGeneral);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tlpGeneral
            // 
            resources.ApplyResources(this.tlpGeneral, "tlpGeneral");
            this.tlpGeneral.Controls.Add(this.gbGpsFailtureActions, 0, 6);
            this.tlpGeneral.Controls.Add(this.bgAlternateAerodromesPresence, 0, 1);
            this.tlpGeneral.Controls.Add(this.gbCrossHairType, 0, 3);
            this.tlpGeneral.Controls.Add(this.gbIkrlFailureActions, 0, 5);
            this.tlpGeneral.Controls.Add(this.gbAutoMode, 0, 0);
            this.tlpGeneral.Controls.Add(this.gbLowBatteryActions, 0, 4);
            this.tlpGeneral.Controls.Add(this.gbGps, 0, 2);
            this.tlpGeneral.Name = "tlpGeneral";
            // 
            // gbGpsFailtureActions
            // 
            resources.ApplyResources(this.gbGpsFailtureActions, "gbGpsFailtureActions");
            this.gbGpsFailtureActions.Controls.Add(this.rbAutoManeuvering);
            this.gbGpsFailtureActions.Controls.Add(this.rbLanding);
            this.gbGpsFailtureActions.Name = "gbGpsFailtureActions";
            this.gbGpsFailtureActions.TabStop = false;
            // 
            // rbAutoManeuvering
            // 
            resources.ApplyResources(this.rbAutoManeuvering, "rbAutoManeuvering");
            this.rbAutoManeuvering.Name = "rbAutoManeuvering";
            this.rbAutoManeuvering.UseVisualStyleBackColor = true;
            // 
            // rbLanding
            // 
            resources.ApplyResources(this.rbLanding, "rbLanding");
            this.rbLanding.Checked = true;
            this.rbLanding.Name = "rbLanding";
            this.rbLanding.TabStop = true;
            this.rbLanding.UseVisualStyleBackColor = true;
            // 
            // bgAlternateAerodromesPresence
            // 
            resources.ApplyResources(this.bgAlternateAerodromesPresence, "bgAlternateAerodromesPresence");
            this.bgAlternateAerodromesPresence.Controls.Add(this.cbCheckAlternateAirfields);
            this.bgAlternateAerodromesPresence.Name = "bgAlternateAerodromesPresence";
            this.bgAlternateAerodromesPresence.TabStop = false;
            // 
            // cbCheckAlternateAirfields
            // 
            resources.ApplyResources(this.cbCheckAlternateAirfields, "cbCheckAlternateAirfields");
            this.cbCheckAlternateAirfields.Name = "cbCheckAlternateAirfields";
            this.cbCheckAlternateAirfields.UseVisualStyleBackColor = true;
            // 
            // gbCrossHairType
            // 
            resources.ApplyResources(this.gbCrossHairType, "gbCrossHairType");
            this.gbCrossHairType.Controls.Add(this.rbBallistic);
            this.gbCrossHairType.Controls.Add(this.rbRegular);
            this.gbCrossHairType.Name = "gbCrossHairType";
            this.gbCrossHairType.TabStop = false;
            // 
            // rbBallistic
            // 
            resources.ApplyResources(this.rbBallistic, "rbBallistic");
            this.rbBallistic.Name = "rbBallistic";
            this.rbBallistic.UseVisualStyleBackColor = true;
            // 
            // rbRegular
            // 
            resources.ApplyResources(this.rbRegular, "rbRegular");
            this.rbRegular.Checked = true;
            this.rbRegular.Name = "rbRegular";
            this.rbRegular.TabStop = true;
            this.rbRegular.UseVisualStyleBackColor = true;
            // 
            // gbIkrlFailureActions
            // 
            resources.ApplyResources(this.gbIkrlFailureActions, "gbIkrlFailureActions");
            this.gbIkrlFailureActions.Controls.Add(this.rbIkrlAutoLanding);
            this.gbIkrlFailureActions.Controls.Add(this.rbIkrlTakeoffPoint);
            this.gbIkrlFailureActions.Name = "gbIkrlFailureActions";
            this.gbIkrlFailureActions.TabStop = false;
            // 
            // rbIkrlAutoLanding
            // 
            resources.ApplyResources(this.rbIkrlAutoLanding, "rbIkrlAutoLanding");
            this.rbIkrlAutoLanding.Name = "rbIkrlAutoLanding";
            this.rbIkrlAutoLanding.UseVisualStyleBackColor = true;
            // 
            // rbIkrlTakeoffPoint
            // 
            resources.ApplyResources(this.rbIkrlTakeoffPoint, "rbIkrlTakeoffPoint");
            this.rbIkrlTakeoffPoint.Checked = true;
            this.rbIkrlTakeoffPoint.Name = "rbIkrlTakeoffPoint";
            this.rbIkrlTakeoffPoint.TabStop = true;
            this.rbIkrlTakeoffPoint.UseVisualStyleBackColor = true;
            // 
            // gbAutoMode
            // 
            resources.ApplyResources(this.gbAutoMode, "gbAutoMode");
            this.gbAutoMode.Controls.Add(this.tlpAutoMode);
            this.gbAutoMode.Name = "gbAutoMode";
            this.gbAutoMode.TabStop = false;
            // 
            // tlpAutoMode
            // 
            resources.ApplyResources(this.tlpAutoMode, "tlpAutoMode");
            this.tlpAutoMode.Controls.Add(this.tbHomeReturnAltitude, 1, 7);
            this.tlpAutoMode.Controls.Add(this.lblHomeReturnAltitude, 0, 7);
            this.tlpAutoMode.Controls.Add(this.tbHomeReturnSpeed, 1, 6);
            this.tlpAutoMode.Controls.Add(this.lblHomeReturnSpeed, 0, 6);
            this.tlpAutoMode.Controls.Add(this.cbUseAlternateAirfieldStartPlace, 0, 8);
            this.tlpAutoMode.Controls.Add(this.lblIterationCount, 0, 5);
            this.tlpAutoMode.Controls.Add(this.lblIdUav, 0, 0);
            this.tlpAutoMode.Controls.Add(this.tbIterationInstructionCount, 1, 5);
            this.tlpAutoMode.Controls.Add(this.tbIdUav, 1, 0);
            this.tlpAutoMode.Controls.Add(this.tbHeight, 1, 1);
            this.tlpAutoMode.Controls.Add(this.tbHangTime, 1, 3);
            this.tlpAutoMode.Controls.Add(this.tbSpeed, 1, 2);
            this.tlpAutoMode.Controls.Add(this.lblHangTime, 0, 3);
            this.tlpAutoMode.Controls.Add(this.tbPatrolRadius, 1, 4);
            this.tlpAutoMode.Controls.Add(this.lblHeight, 0, 1);
            this.tlpAutoMode.Controls.Add(this.lblSpeed, 0, 2);
            this.tlpAutoMode.Controls.Add(this.lblPatrolRadius, 0, 4);
            this.tlpAutoMode.Name = "tlpAutoMode";
            // 
            // tbHomeReturnAltitude
            // 
            resources.ApplyResources(this.tbHomeReturnAltitude, "tbHomeReturnAltitude");
            this.tbHomeReturnAltitude.Max = 100;
            this.tbHomeReturnAltitude.Min = 0;
            this.tbHomeReturnAltitude.Name = "tbHomeReturnAltitude";
            this.tbHomeReturnAltitude.Value = 0;
            // 
            // lblHomeReturnAltitude
            // 
            resources.ApplyResources(this.lblHomeReturnAltitude, "lblHomeReturnAltitude");
            this.lblHomeReturnAltitude.Name = "lblHomeReturnAltitude";
            // 
            // tbHomeReturnSpeed
            // 
            resources.ApplyResources(this.tbHomeReturnSpeed, "tbHomeReturnSpeed");
            this.tbHomeReturnSpeed.Max = 100;
            this.tbHomeReturnSpeed.Min = 0;
            this.tbHomeReturnSpeed.Name = "tbHomeReturnSpeed";
            this.tbHomeReturnSpeed.Value = 0;
            // 
            // lblHomeReturnSpeed
            // 
            resources.ApplyResources(this.lblHomeReturnSpeed, "lblHomeReturnSpeed");
            this.lblHomeReturnSpeed.Name = "lblHomeReturnSpeed";
            // 
            // cbUseAlternateAirfieldStartPlace
            // 
            resources.ApplyResources(this.cbUseAlternateAirfieldStartPlace, "cbUseAlternateAirfieldStartPlace");
            this.tlpAutoMode.SetColumnSpan(this.cbUseAlternateAirfieldStartPlace, 2);
            this.cbUseAlternateAirfieldStartPlace.Name = "cbUseAlternateAirfieldStartPlace";
            this.cbUseAlternateAirfieldStartPlace.UseVisualStyleBackColor = true;
            // 
            // lblIterationCount
            // 
            resources.ApplyResources(this.lblIterationCount, "lblIterationCount");
            this.lblIterationCount.Name = "lblIterationCount";
            // 
            // lblIdUav
            // 
            resources.ApplyResources(this.lblIdUav, "lblIdUav");
            this.lblIdUav.Name = "lblIdUav";
            // 
            // tbIterationInstructionCount
            // 
            resources.ApplyResources(this.tbIterationInstructionCount, "tbIterationInstructionCount");
            this.tbIterationInstructionCount.Max = 100;
            this.tbIterationInstructionCount.Min = 0;
            this.tbIterationInstructionCount.Name = "tbIterationInstructionCount";
            this.tbIterationInstructionCount.Value = 0;
            // 
            // tbIdUav
            // 
            resources.ApplyResources(this.tbIdUav, "tbIdUav");
            this.tbIdUav.Max = 99999999;
            this.tbIdUav.Min = 0;
            this.tbIdUav.Name = "tbIdUav";
            this.tbIdUav.Value = 0;
            // 
            // tbHeight
            // 
            resources.ApplyResources(this.tbHeight, "tbHeight");
            this.tbHeight.Max = 100;
            this.tbHeight.Min = 0;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Value = 0;
            // 
            // tbHangTime
            // 
            resources.ApplyResources(this.tbHangTime, "tbHangTime");
            this.tbHangTime.Max = 100;
            this.tbHangTime.Min = 0;
            this.tbHangTime.Name = "tbHangTime";
            this.tbHangTime.Value = 0;
            // 
            // tbSpeed
            // 
            resources.ApplyResources(this.tbSpeed, "tbSpeed");
            this.tbSpeed.Max = 100;
            this.tbSpeed.Min = 0;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Value = 0;
            // 
            // lblHangTime
            // 
            resources.ApplyResources(this.lblHangTime, "lblHangTime");
            this.lblHangTime.Name = "lblHangTime";
            // 
            // tbPatrolRadius
            // 
            resources.ApplyResources(this.tbPatrolRadius, "tbPatrolRadius");
            this.tbPatrolRadius.Max = 100;
            this.tbPatrolRadius.Min = 0;
            this.tbPatrolRadius.Name = "tbPatrolRadius";
            this.tbPatrolRadius.Value = 0;
            // 
            // lblHeight
            // 
            resources.ApplyResources(this.lblHeight, "lblHeight");
            this.lblHeight.Name = "lblHeight";
            // 
            // lblSpeed
            // 
            resources.ApplyResources(this.lblSpeed, "lblSpeed");
            this.lblSpeed.Name = "lblSpeed";
            // 
            // lblPatrolRadius
            // 
            resources.ApplyResources(this.lblPatrolRadius, "lblPatrolRadius");
            this.lblPatrolRadius.Name = "lblPatrolRadius";
            // 
            // gbLowBatteryActions
            // 
            resources.ApplyResources(this.gbLowBatteryActions, "gbLowBatteryActions");
            this.gbLowBatteryActions.Controls.Add(this.cmbCrtBatteryActions);
            this.gbLowBatteryActions.Controls.Add(this.cmbLowBatteryActions);
            this.gbLowBatteryActions.Controls.Add(this.lblCrtBatteryAction);
            this.gbLowBatteryActions.Controls.Add(this.lblLowBatteryAction);
            this.gbLowBatteryActions.Name = "gbLowBatteryActions";
            this.gbLowBatteryActions.TabStop = false;
            // 
            // cmbCrtBatteryActions
            // 
            resources.ApplyResources(this.cmbCrtBatteryActions, "cmbCrtBatteryActions");
            this.cmbCrtBatteryActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrtBatteryActions.FormattingEnabled = true;
            this.cmbCrtBatteryActions.Items.AddRange(new object[] {
            resources.GetString("cmbCrtBatteryActions.Items"),
            resources.GetString("cmbCrtBatteryActions.Items1")});
            this.cmbCrtBatteryActions.Name = "cmbCrtBatteryActions";
            // 
            // cmbLowBatteryActions
            // 
            resources.ApplyResources(this.cmbLowBatteryActions, "cmbLowBatteryActions");
            this.cmbLowBatteryActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLowBatteryActions.FormattingEnabled = true;
            this.cmbLowBatteryActions.Items.AddRange(new object[] {
            resources.GetString("cmbLowBatteryActions.Items"),
            resources.GetString("cmbLowBatteryActions.Items1"),
            resources.GetString("cmbLowBatteryActions.Items2")});
            this.cmbLowBatteryActions.Name = "cmbLowBatteryActions";
            // 
            // lblCrtBatteryAction
            // 
            resources.ApplyResources(this.lblCrtBatteryAction, "lblCrtBatteryAction");
            this.lblCrtBatteryAction.Name = "lblCrtBatteryAction";
            // 
            // lblLowBatteryAction
            // 
            resources.ApplyResources(this.lblLowBatteryAction, "lblLowBatteryAction");
            this.lblLowBatteryAction.Name = "lblLowBatteryAction";
            // 
            // gbGps
            // 
            resources.ApplyResources(this.gbGps, "gbGps");
            this.gbGps.Controls.Add(this.btnGpsOff);
            this.gbGps.Controls.Add(this.btnGpsOn);
            this.gbGps.Name = "gbGps";
            this.gbGps.TabStop = false;
            // 
            // btnGpsOff
            // 
            resources.ApplyResources(this.btnGpsOff, "btnGpsOff");
            this.btnGpsOff.Name = "btnGpsOff";
            this.btnGpsOff.UseVisualStyleBackColor = true;
            this.btnGpsOff.Click += new System.EventHandler(this.BtnGpsOff_Click);
            // 
            // btnGpsOn
            // 
            resources.ApplyResources(this.btnGpsOn, "btnGpsOn");
            this.btnGpsOn.Name = "btnGpsOn";
            this.btnGpsOn.UseVisualStyleBackColor = true;
            this.btnGpsOn.Click += new System.EventHandler(this.BtnGpsOn_Click);
            // 
            // tpInterface
            // 
            resources.ApplyResources(this.tpInterface, "tpInterface");
            this.tpInterface.Controls.Add(this.gbSpeed);
            this.tpInterface.Controls.Add(this.cmbLanguage);
            this.tpInterface.Controls.Add(this.gbCoordinateSystem);
            this.tpInterface.Controls.Add(this.lblLanguage);
            this.tpInterface.Name = "tpInterface";
            this.tpInterface.UseVisualStyleBackColor = true;
            // 
            // gbSpeed
            // 
            resources.ApplyResources(this.gbSpeed, "gbSpeed");
            this.gbSpeed.Controls.Add(this.rbKm_h);
            this.gbSpeed.Controls.Add(this.rbM_S);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.TabStop = false;
            // 
            // rbKm_h
            // 
            resources.ApplyResources(this.rbKm_h, "rbKm_h");
            this.rbKm_h.Name = "rbKm_h";
            this.rbKm_h.UseVisualStyleBackColor = true;
            // 
            // rbM_S
            // 
            resources.ApplyResources(this.rbM_S, "rbM_S");
            this.rbM_S.Checked = true;
            this.rbM_S.Name = "rbM_S";
            this.rbM_S.TabStop = true;
            this.rbM_S.UseVisualStyleBackColor = true;
            // 
            // cmbLanguage
            // 
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Name = "cmbLanguage";
            // 
            // gbCoordinateSystem
            // 
            resources.ApplyResources(this.gbCoordinateSystem, "gbCoordinateSystem");
            this.gbCoordinateSystem.Controls.Add(this.rbWgs84Deg);
            this.gbCoordinateSystem.Controls.Add(this.rbSC_42);
            this.gbCoordinateSystem.Controls.Add(this.rbWGS_84);
            this.gbCoordinateSystem.Name = "gbCoordinateSystem";
            this.gbCoordinateSystem.TabStop = false;
            // 
            // rbWgs84Deg
            // 
            resources.ApplyResources(this.rbWgs84Deg, "rbWgs84Deg");
            this.rbWgs84Deg.Name = "rbWgs84Deg";
            this.rbWgs84Deg.UseVisualStyleBackColor = true;
            // 
            // rbSC_42
            // 
            resources.ApplyResources(this.rbSC_42, "rbSC_42");
            this.rbSC_42.Name = "rbSC_42";
            this.rbSC_42.UseVisualStyleBackColor = true;
            // 
            // rbWGS_84
            // 
            resources.ApplyResources(this.rbWGS_84, "rbWGS_84");
            this.rbWGS_84.Checked = true;
            this.rbWGS_84.Name = "rbWGS_84";
            this.rbWGS_84.TabStop = true;
            this.rbWGS_84.UseVisualStyleBackColor = true;
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // tpUpScreen
            // 
            resources.ApplyResources(this.tpUpScreen, "tpUpScreen");
            this.tpUpScreen.Controls.Add(this.tlpHud);
            this.tpUpScreen.Name = "tpUpScreen";
            this.tpUpScreen.UseVisualStyleBackColor = true;
            // 
            // tlpHud
            // 
            resources.ApplyResources(this.tlpHud, "tlpHud");
            this.tlpHud.Controls.Add(this.tlpHudParts, 0, 0);
            this.tlpHud.Controls.Add(this.tlpDetails, 1, 0);
            this.tlpHud.Name = "tlpHud";
            // 
            // tlpHudParts
            // 
            resources.ApplyResources(this.tlpHudParts, "tlpHudParts");
            this.tlpHudParts.Controls.Add(this.tlpIndicators, 0, 0);
            this.tlpHudParts.Controls.Add(this.tblUav, 0, 1);
            this.tlpHudParts.Controls.Add(this.tblBattery, 0, 2);
            this.tlpHudParts.Controls.Add(this.tblTarget, 0, 3);
            this.tlpHudParts.Controls.Add(this.tblOther, 0, 4);
            this.tlpHudParts.Name = "tlpHudParts";
            // 
            // tlpIndicators
            // 
            resources.ApplyResources(this.tlpIndicators, "tlpIndicators");
            this.tlpIndicators.Controls.Add(this.cbIndicators, 0, 1);
            this.tlpIndicators.Controls.Add(this.btnIndicators, 0, 0);
            this.tlpIndicators.Name = "tlpIndicators";
            // 
            // cbIndicators
            // 
            resources.ApplyResources(this.cbIndicators, "cbIndicators");
            this.cbIndicators.Name = "cbIndicators";
            this.cbIndicators.UseVisualStyleBackColor = true;
            this.cbIndicators.CheckedChanged += new System.EventHandler(this.cbIndicators_CheckedChanged);
            // 
            // btnIndicators
            // 
            resources.ApplyResources(this.btnIndicators, "btnIndicators");
            this.btnIndicators.Name = "btnIndicators";
            this.btnIndicators.UseVisualStyleBackColor = true;
            this.btnIndicators.Click += new System.EventHandler(this.btnIndicators_Click);
            // 
            // tblUav
            // 
            resources.ApplyResources(this.tblUav, "tblUav");
            this.tblUav.Controls.Add(this.cbUavParam, 0, 1);
            this.tblUav.Controls.Add(this.btnUavParams, 0, 0);
            this.tblUav.Name = "tblUav";
            // 
            // cbUavParam
            // 
            resources.ApplyResources(this.cbUavParam, "cbUavParam");
            this.cbUavParam.Name = "cbUavParam";
            this.cbUavParam.UseVisualStyleBackColor = true;
            this.cbUavParam.CheckedChanged += new System.EventHandler(this.cbUavParam_CheckedChanged);
            // 
            // btnUavParams
            // 
            resources.ApplyResources(this.btnUavParams, "btnUavParams");
            this.btnUavParams.Name = "btnUavParams";
            this.btnUavParams.UseVisualStyleBackColor = true;
            this.btnUavParams.Click += new System.EventHandler(this.btnUavParams_Click);
            // 
            // tblBattery
            // 
            resources.ApplyResources(this.tblBattery, "tblBattery");
            this.tblBattery.Controls.Add(this.cbBattery, 0, 1);
            this.tblBattery.Controls.Add(this.btnBattery, 0, 0);
            this.tblBattery.Name = "tblBattery";
            // 
            // cbBattery
            // 
            resources.ApplyResources(this.cbBattery, "cbBattery");
            this.cbBattery.Name = "cbBattery";
            this.cbBattery.UseVisualStyleBackColor = true;
            this.cbBattery.CheckedChanged += new System.EventHandler(this.cbBattery_CheckedChanged);
            // 
            // btnBattery
            // 
            resources.ApplyResources(this.btnBattery, "btnBattery");
            this.btnBattery.Name = "btnBattery";
            this.btnBattery.UseVisualStyleBackColor = true;
            this.btnBattery.Click += new System.EventHandler(this.btnBattery_Click);
            // 
            // tblTarget
            // 
            resources.ApplyResources(this.tblTarget, "tblTarget");
            this.tblTarget.Controls.Add(this.cbTargetParam, 0, 1);
            this.tblTarget.Controls.Add(this.btnTarget, 0, 0);
            this.tblTarget.Name = "tblTarget";
            // 
            // cbTargetParam
            // 
            resources.ApplyResources(this.cbTargetParam, "cbTargetParam");
            this.cbTargetParam.Name = "cbTargetParam";
            this.cbTargetParam.UseVisualStyleBackColor = true;
            this.cbTargetParam.CheckedChanged += new System.EventHandler(this.cbTargetParam_CheckedChanged);
            // 
            // btnTarget
            // 
            resources.ApplyResources(this.btnTarget, "btnTarget");
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // tblOther
            // 
            resources.ApplyResources(this.tblOther, "tblOther");
            this.tblOther.Controls.Add(this.cbOtherParam, 0, 1);
            this.tblOther.Controls.Add(this.btnOther, 0, 0);
            this.tblOther.Name = "tblOther";
            // 
            // cbOtherParam
            // 
            resources.ApplyResources(this.cbOtherParam, "cbOtherParam");
            this.cbOtherParam.Name = "cbOtherParam";
            this.cbOtherParam.UseVisualStyleBackColor = true;
            this.cbOtherParam.CheckedChanged += new System.EventHandler(this.cbOtherParam_CheckedChanged);
            // 
            // btnOther
            // 
            resources.ApplyResources(this.btnOther, "btnOther");
            this.btnOther.Name = "btnOther";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // tlpDetails
            // 
            resources.ApplyResources(this.tlpDetails, "tlpDetails");
            this.tlpDetails.Controls.Add(this.IndicatorBox, 0, 0);
            this.tlpDetails.Controls.Add(this.UavParamBox, 0, 1);
            this.tlpDetails.Controls.Add(this.BatteryBox, 0, 2);
            this.tlpDetails.Controls.Add(this.TargetBox, 0, 3);
            this.tlpDetails.Controls.Add(this.OtherParamBox, 0, 4);
            this.tlpDetails.Name = "tlpDetails";
            // 
            // IndicatorBox
            // 
            resources.ApplyResources(this.IndicatorBox, "IndicatorBox");
            this.IndicatorBox.Controls.Add(this.cbGroundLevel);
            this.IndicatorBox.Controls.Add(this.cbCompass);
            this.IndicatorBox.Controls.Add(this.cbRollScale);
            this.IndicatorBox.Controls.Add(this.cbPitchScale);
            this.IndicatorBox.Controls.Add(this.cbCrossMark);
            this.IndicatorBox.Name = "IndicatorBox";
            this.IndicatorBox.TabStop = false;
            // 
            // cbGroundLevel
            // 
            resources.ApplyResources(this.cbGroundLevel, "cbGroundLevel");
            this.cbGroundLevel.Name = "cbGroundLevel";
            this.cbGroundLevel.UseVisualStyleBackColor = true;
            this.cbGroundLevel.CheckedChanged += new System.EventHandler(this.cbGroundLevel_CheckedChanged);
            // 
            // cbCompass
            // 
            resources.ApplyResources(this.cbCompass, "cbCompass");
            this.cbCompass.Name = "cbCompass";
            this.cbCompass.UseVisualStyleBackColor = true;
            this.cbCompass.CheckedChanged += new System.EventHandler(this.cbCompass_CheckedChanged);
            // 
            // cbRollScale
            // 
            resources.ApplyResources(this.cbRollScale, "cbRollScale");
            this.cbRollScale.Name = "cbRollScale";
            this.cbRollScale.UseVisualStyleBackColor = true;
            this.cbRollScale.CheckedChanged += new System.EventHandler(this.cbRollScale_CheckedChanged);
            // 
            // cbPitchScale
            // 
            resources.ApplyResources(this.cbPitchScale, "cbPitchScale");
            this.cbPitchScale.Name = "cbPitchScale";
            this.cbPitchScale.UseVisualStyleBackColor = true;
            this.cbPitchScale.CheckedChanged += new System.EventHandler(this.cbPitchScale_CheckedChanged);
            // 
            // cbCrossMark
            // 
            resources.ApplyResources(this.cbCrossMark, "cbCrossMark");
            this.cbCrossMark.Name = "cbCrossMark";
            this.cbCrossMark.UseVisualStyleBackColor = true;
            this.cbCrossMark.CheckedChanged += new System.EventHandler(this.cbCrossMark_CheckedChanged);
            // 
            // UavParamBox
            // 
            resources.ApplyResources(this.UavParamBox, "UavParamBox");
            this.UavParamBox.Controls.Add(this.cbLatitude);
            this.UavParamBox.Controls.Add(this.cbFlightTime);
            this.UavParamBox.Controls.Add(this.cbFlightPath);
            this.UavParamBox.Controls.Add(this.cbFlightMode);
            this.UavParamBox.Controls.Add(this.cbLongitude);
            this.UavParamBox.Controls.Add(this.cbInclination);
            this.UavParamBox.Controls.Add(this.cbAzimuth);
            this.UavParamBox.Controls.Add(this.cbHomeDistance);
            this.UavParamBox.Controls.Add(this.cbRollAngle);
            this.UavParamBox.Controls.Add(this.cbPitchAngle);
            this.UavParamBox.Name = "UavParamBox";
            this.UavParamBox.TabStop = false;
            // 
            // cbLatitude
            // 
            resources.ApplyResources(this.cbLatitude, "cbLatitude");
            this.cbLatitude.Name = "cbLatitude";
            this.cbLatitude.UseVisualStyleBackColor = true;
            this.cbLatitude.CheckedChanged += new System.EventHandler(this.cbLatitude_CheckedChanged);
            // 
            // cbFlightTime
            // 
            resources.ApplyResources(this.cbFlightTime, "cbFlightTime");
            this.cbFlightTime.Name = "cbFlightTime";
            this.cbFlightTime.UseVisualStyleBackColor = true;
            this.cbFlightTime.CheckedChanged += new System.EventHandler(this.cbFlightTime_CheckedChanged);
            // 
            // cbFlightPath
            // 
            resources.ApplyResources(this.cbFlightPath, "cbFlightPath");
            this.cbFlightPath.Name = "cbFlightPath";
            this.cbFlightPath.UseVisualStyleBackColor = true;
            this.cbFlightPath.CheckedChanged += new System.EventHandler(this.cbFlightPath_CheckedChanged);
            // 
            // cbFlightMode
            // 
            resources.ApplyResources(this.cbFlightMode, "cbFlightMode");
            this.cbFlightMode.Name = "cbFlightMode";
            this.cbFlightMode.UseVisualStyleBackColor = true;
            this.cbFlightMode.CheckedChanged += new System.EventHandler(this.cbFlightMode_CheckedChanged);
            // 
            // cbLongitude
            // 
            resources.ApplyResources(this.cbLongitude, "cbLongitude");
            this.cbLongitude.Name = "cbLongitude";
            this.cbLongitude.UseVisualStyleBackColor = true;
            this.cbLongitude.CheckedChanged += new System.EventHandler(this.cbLongitude_CheckedChanged);
            // 
            // cbInclination
            // 
            resources.ApplyResources(this.cbInclination, "cbInclination");
            this.cbInclination.Name = "cbInclination";
            this.cbInclination.UseVisualStyleBackColor = true;
            this.cbInclination.CheckedChanged += new System.EventHandler(this.cbInclination_CheckedChanged);
            // 
            // cbAzimuth
            // 
            resources.ApplyResources(this.cbAzimuth, "cbAzimuth");
            this.cbAzimuth.Name = "cbAzimuth";
            this.cbAzimuth.UseVisualStyleBackColor = true;
            this.cbAzimuth.CheckedChanged += new System.EventHandler(this.cbAzimuth_CheckedChanged);
            // 
            // cbHomeDistance
            // 
            resources.ApplyResources(this.cbHomeDistance, "cbHomeDistance");
            this.cbHomeDistance.Name = "cbHomeDistance";
            this.cbHomeDistance.UseVisualStyleBackColor = true;
            this.cbHomeDistance.CheckedChanged += new System.EventHandler(this.cbHomeDistance_CheckedChanged);
            // 
            // cbRollAngle
            // 
            resources.ApplyResources(this.cbRollAngle, "cbRollAngle");
            this.cbRollAngle.Name = "cbRollAngle";
            this.cbRollAngle.UseVisualStyleBackColor = true;
            this.cbRollAngle.CheckedChanged += new System.EventHandler(this.cbRollAngle_CheckedChanged);
            // 
            // cbPitchAngle
            // 
            resources.ApplyResources(this.cbPitchAngle, "cbPitchAngle");
            this.cbPitchAngle.Name = "cbPitchAngle";
            this.cbPitchAngle.UseVisualStyleBackColor = true;
            this.cbPitchAngle.CheckedChanged += new System.EventHandler(this.cbPitchAngle_CheckedChanged);
            // 
            // BatteryBox
            // 
            resources.ApplyResources(this.BatteryBox, "BatteryBox");
            this.BatteryBox.Controls.Add(this.cbBatteryVoltage);
            this.BatteryBox.Controls.Add(this.cbBatteryLevel);
            this.BatteryBox.Controls.Add(this.cbBatteryCapacity);
            this.BatteryBox.Controls.Add(this.cbBatteryTimeLeft);
            this.BatteryBox.Name = "BatteryBox";
            this.BatteryBox.TabStop = false;
            // 
            // cbBatteryVoltage
            // 
            resources.ApplyResources(this.cbBatteryVoltage, "cbBatteryVoltage");
            this.cbBatteryVoltage.Name = "cbBatteryVoltage";
            this.cbBatteryVoltage.UseVisualStyleBackColor = true;
            this.cbBatteryVoltage.CheckedChanged += new System.EventHandler(this.cbBatteryVoltage_CheckedChanged);
            // 
            // cbBatteryLevel
            // 
            resources.ApplyResources(this.cbBatteryLevel, "cbBatteryLevel");
            this.cbBatteryLevel.Name = "cbBatteryLevel";
            this.cbBatteryLevel.UseVisualStyleBackColor = true;
            this.cbBatteryLevel.CheckedChanged += new System.EventHandler(this.cbBatteryLevel_CheckedChanged);
            // 
            // cbBatteryCapacity
            // 
            resources.ApplyResources(this.cbBatteryCapacity, "cbBatteryCapacity");
            this.cbBatteryCapacity.Name = "cbBatteryCapacity";
            this.cbBatteryCapacity.UseVisualStyleBackColor = true;
            this.cbBatteryCapacity.CheckedChanged += new System.EventHandler(this.cbBatteryCapacity_CheckedChanged);
            // 
            // cbBatteryTimeLeft
            // 
            resources.ApplyResources(this.cbBatteryTimeLeft, "cbBatteryTimeLeft");
            this.cbBatteryTimeLeft.Name = "cbBatteryTimeLeft";
            this.cbBatteryTimeLeft.UseVisualStyleBackColor = true;
            this.cbBatteryTimeLeft.CheckedChanged += new System.EventHandler(this.cbBatteryTimeLeft_CheckedChanged);
            // 
            // TargetBox
            // 
            resources.ApplyResources(this.TargetBox, "TargetBox");
            this.TargetBox.Controls.Add(this.cbTarLon);
            this.TargetBox.Controls.Add(this.cbTarLat);
            this.TargetBox.Controls.Add(this.cbTargetHeight);
            this.TargetBox.Controls.Add(this.cbTargetWidth);
            this.TargetBox.Name = "TargetBox";
            this.TargetBox.TabStop = false;
            // 
            // cbTarLon
            // 
            resources.ApplyResources(this.cbTarLon, "cbTarLon");
            this.cbTarLon.Name = "cbTarLon";
            this.cbTarLon.UseVisualStyleBackColor = true;
            this.cbTarLon.CheckedChanged += new System.EventHandler(this.cbTarLon_CheckedChanged);
            // 
            // cbTarLat
            // 
            resources.ApplyResources(this.cbTarLat, "cbTarLat");
            this.cbTarLat.Name = "cbTarLat";
            this.cbTarLat.UseVisualStyleBackColor = true;
            this.cbTarLat.CheckedChanged += new System.EventHandler(this.cbTarLat_CheckedChanged);
            // 
            // cbTargetHeight
            // 
            resources.ApplyResources(this.cbTargetHeight, "cbTargetHeight");
            this.cbTargetHeight.Name = "cbTargetHeight";
            this.cbTargetHeight.UseVisualStyleBackColor = true;
            this.cbTargetHeight.CheckedChanged += new System.EventHandler(this.cbTargetHeight_CheckedChanged);
            // 
            // cbTargetWidth
            // 
            resources.ApplyResources(this.cbTargetWidth, "cbTargetWidth");
            this.cbTargetWidth.Name = "cbTargetWidth";
            this.cbTargetWidth.UseVisualStyleBackColor = true;
            this.cbTargetWidth.CheckedChanged += new System.EventHandler(this.cbTargetWidth_CheckedChanged);
            // 
            // OtherParamBox
            // 
            resources.ApplyResources(this.OtherParamBox, "OtherParamBox");
            this.OtherParamBox.Controls.Add(this.cbWeaponStatus);
            this.OtherParamBox.Controls.Add(this.cbWindSpeed);
            this.OtherParamBox.Controls.Add(this.cbWindAngle);
            this.OtherParamBox.Controls.Add(this.cbSatellites);
            this.OtherParamBox.Controls.Add(this.cbSignalLevel);
            this.OtherParamBox.Controls.Add(this.cbAltitudeWrtHome);
            this.OtherParamBox.Controls.Add(this.cbRange1);
            this.OtherParamBox.Controls.Add(this.cbRange2);
            this.OtherParamBox.Controls.Add(this.cbCameraVAngle);
            this.OtherParamBox.Controls.Add(this.cbCameraHAngle);
            this.OtherParamBox.Controls.Add(this.cbVerticalSpeed);
            this.OtherParamBox.Controls.Add(this.cbAltitudeWrtGround);
            this.OtherParamBox.Controls.Add(this.cbHorizontalSpeed);
            this.OtherParamBox.Name = "OtherParamBox";
            this.OtherParamBox.TabStop = false;
            // 
            // cbWeaponStatus
            // 
            resources.ApplyResources(this.cbWeaponStatus, "cbWeaponStatus");
            this.cbWeaponStatus.Name = "cbWeaponStatus";
            this.cbWeaponStatus.UseVisualStyleBackColor = true;
            this.cbWeaponStatus.CheckedChanged += new System.EventHandler(this.cbWeaponStatus_CheckedChanged);
            // 
            // cbWindSpeed
            // 
            resources.ApplyResources(this.cbWindSpeed, "cbWindSpeed");
            this.cbWindSpeed.Name = "cbWindSpeed";
            this.cbWindSpeed.UseVisualStyleBackColor = true;
            this.cbWindSpeed.CheckedChanged += new System.EventHandler(this.cbWindSpeed_CheckedChanged);
            // 
            // cbWindAngle
            // 
            resources.ApplyResources(this.cbWindAngle, "cbWindAngle");
            this.cbWindAngle.Name = "cbWindAngle";
            this.cbWindAngle.UseVisualStyleBackColor = true;
            this.cbWindAngle.CheckedChanged += new System.EventHandler(this.cbWindAngle_CheckedChanged);
            // 
            // cbSatellites
            // 
            resources.ApplyResources(this.cbSatellites, "cbSatellites");
            this.cbSatellites.Name = "cbSatellites";
            this.cbSatellites.UseVisualStyleBackColor = true;
            this.cbSatellites.CheckedChanged += new System.EventHandler(this.cbSatellites_CheckedChanged);
            // 
            // cbSignalLevel
            // 
            resources.ApplyResources(this.cbSignalLevel, "cbSignalLevel");
            this.cbSignalLevel.Name = "cbSignalLevel";
            this.cbSignalLevel.UseVisualStyleBackColor = true;
            this.cbSignalLevel.CheckedChanged += new System.EventHandler(this.cbSignalLevel_CheckedChanged);
            // 
            // cbAltitudeWrtHome
            // 
            resources.ApplyResources(this.cbAltitudeWrtHome, "cbAltitudeWrtHome");
            this.cbAltitudeWrtHome.Name = "cbAltitudeWrtHome";
            this.cbAltitudeWrtHome.UseVisualStyleBackColor = true;
            this.cbAltitudeWrtHome.CheckedChanged += new System.EventHandler(this.cbAltitudeWrtHome_CheckedChanged);
            // 
            // cbRange1
            // 
            resources.ApplyResources(this.cbRange1, "cbRange1");
            this.cbRange1.Name = "cbRange1";
            this.cbRange1.UseVisualStyleBackColor = true;
            this.cbRange1.CheckedChanged += new System.EventHandler(this.cbRange1_CheckedChanged);
            // 
            // cbRange2
            // 
            resources.ApplyResources(this.cbRange2, "cbRange2");
            this.cbRange2.Name = "cbRange2";
            this.cbRange2.UseVisualStyleBackColor = true;
            this.cbRange2.CheckedChanged += new System.EventHandler(this.cbRange2_CheckedChanged);
            // 
            // cbCameraVAngle
            // 
            resources.ApplyResources(this.cbCameraVAngle, "cbCameraVAngle");
            this.cbCameraVAngle.Name = "cbCameraVAngle";
            this.cbCameraVAngle.UseVisualStyleBackColor = true;
            this.cbCameraVAngle.CheckedChanged += new System.EventHandler(this.cbCameraVAngle_CheckedChanged);
            // 
            // cbCameraHAngle
            // 
            resources.ApplyResources(this.cbCameraHAngle, "cbCameraHAngle");
            this.cbCameraHAngle.Name = "cbCameraHAngle";
            this.cbCameraHAngle.UseVisualStyleBackColor = true;
            this.cbCameraHAngle.CheckedChanged += new System.EventHandler(this.cbCameraHAngle_CheckedChanged);
            // 
            // cbVerticalSpeed
            // 
            resources.ApplyResources(this.cbVerticalSpeed, "cbVerticalSpeed");
            this.cbVerticalSpeed.Name = "cbVerticalSpeed";
            this.cbVerticalSpeed.UseVisualStyleBackColor = true;
            this.cbVerticalSpeed.CheckedChanged += new System.EventHandler(this.cbVerticalSpeed_CheckedChanged);
            // 
            // cbAltitudeWrtGround
            // 
            resources.ApplyResources(this.cbAltitudeWrtGround, "cbAltitudeWrtGround");
            this.cbAltitudeWrtGround.Name = "cbAltitudeWrtGround";
            this.cbAltitudeWrtGround.UseVisualStyleBackColor = true;
            this.cbAltitudeWrtGround.CheckedChanged += new System.EventHandler(this.cbAltitudeWrtGround_CheckedChanged);
            // 
            // cbHorizontalSpeed
            // 
            resources.ApplyResources(this.cbHorizontalSpeed, "cbHorizontalSpeed");
            this.cbHorizontalSpeed.Name = "cbHorizontalSpeed";
            this.cbHorizontalSpeed.UseVisualStyleBackColor = true;
            this.cbHorizontalSpeed.CheckedChanged += new System.EventHandler(this.cbHorizontalSpeed_CheckedChanged);
            // 
            // rbHomeReturn
            // 
            resources.ApplyResources(this.rbHomeReturn, "rbHomeReturn");
            this.rbHomeReturn.Name = "rbHomeReturn";
            this.rbHomeReturn.TabStop = true;
            this.rbHomeReturn.UseVisualStyleBackColor = true;
            // 
            // rbTakeoffPoint
            // 
            resources.ApplyResources(this.rbTakeoffPoint, "rbTakeoffPoint");
            this.rbTakeoffPoint.Name = "rbTakeoffPoint";
            this.rbTakeoffPoint.TabStop = true;
            this.rbTakeoffPoint.UseVisualStyleBackColor = true;
            // 
            // rbAutoLanding
            // 
            resources.ApplyResources(this.rbAutoLanding, "rbAutoLanding");
            this.rbAutoLanding.Name = "rbAutoLanding";
            this.rbAutoLanding.TabStop = true;
            this.rbAutoLanding.UseVisualStyleBackColor = true;
            // 
            // lblIterationInstructionCount
            // 
            resources.ApplyResources(this.lblIterationInstructionCount, "lblIterationInstructionCount");
            this.lblIterationInstructionCount.Name = "lblIterationInstructionCount";
            // 
            // lblLbaAutoReturn
            // 
            resources.ApplyResources(this.lblLbaAutoReturn, "lblLbaAutoReturn");
            this.lblLbaAutoReturn.Name = "lblLbaAutoReturn";
            // 
            // lblLbaAutoLanding
            // 
            resources.ApplyResources(this.lblLbaAutoLanding, "lblLbaAutoLanding");
            this.lblLbaAutoLanding.Name = "lblLbaAutoLanding";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // panelButtons
            // 
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Controls.Add(this.tlpBottom);
            this.panelButtons.Name = "panelButtons";
            // 
            // tlpBottom
            // 
            resources.ApplyResources(this.tlpBottom, "tlpBottom");
            this.tlpBottom.Controls.Add(this.btnCancel, 0, 0);
            this.tlpBottom.Controls.Add(this.btnOk, 0, 0);
            this.tlpBottom.Name = "tlpBottom";
            // 
            // SettingView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.tableLayoutPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "SettingView";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsView_FormClosing);
            this.Load += new System.EventHandler(this.SettingView_Load);
            this.tabControl.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tlpGeneral.ResumeLayout(false);
            this.gbGpsFailtureActions.ResumeLayout(false);
            this.gbGpsFailtureActions.PerformLayout();
            this.bgAlternateAerodromesPresence.ResumeLayout(false);
            this.gbCrossHairType.ResumeLayout(false);
            this.gbIkrlFailureActions.ResumeLayout(false);
            this.gbIkrlFailureActions.PerformLayout();
            this.gbAutoMode.ResumeLayout(false);
            this.tlpAutoMode.ResumeLayout(false);
            this.tlpAutoMode.PerformLayout();
            this.gbLowBatteryActions.ResumeLayout(false);
            this.gbGps.ResumeLayout(false);
            this.tpInterface.ResumeLayout(false);
            this.tpInterface.PerformLayout();
            this.gbSpeed.ResumeLayout(false);
            this.gbSpeed.PerformLayout();
            this.gbCoordinateSystem.ResumeLayout(false);
            this.gbCoordinateSystem.PerformLayout();
            this.tpUpScreen.ResumeLayout(false);
            this.tlpHud.ResumeLayout(false);
            this.tlpHudParts.ResumeLayout(false);
            this.tlpIndicators.ResumeLayout(false);
            this.tblUav.ResumeLayout(false);
            this.tblBattery.ResumeLayout(false);
            this.tblTarget.ResumeLayout(false);
            this.tblOther.ResumeLayout(false);
            this.tlpDetails.ResumeLayout(false);
            this.IndicatorBox.ResumeLayout(false);
            this.IndicatorBox.PerformLayout();
            this.UavParamBox.ResumeLayout(false);
            this.UavParamBox.PerformLayout();
            this.BatteryBox.ResumeLayout(false);
            this.BatteryBox.PerformLayout();
            this.TargetBox.ResumeLayout(false);
            this.TargetBox.PerformLayout();
            this.OtherParamBox.ResumeLayout(false);
            this.OtherParamBox.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpInterface;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.GroupBox gbAutoMode;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblLbaAutoReturn;
        private System.Windows.Forms.Label lblLbaAutoLanding;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblIterationInstructionCount;
        private System.Windows.Forms.GroupBox gbLowBatteryActions;
        private System.Windows.Forms.TabPage tpUpScreen;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.GroupBox gbCoordinateSystem;
        private System.Windows.Forms.GroupBox gbSpeed;
        private System.Windows.Forms.RadioButton rbKm_h;
        private System.Windows.Forms.RadioButton rbM_S;
        private System.Windows.Forms.RadioButton rbSC_42;
        private System.Windows.Forms.RadioButton rbWGS_84;
        private MissionPlanner.Controls.TextBoxes.IntTextBox tbHeight;
        private MissionPlanner.Controls.TextBoxes.IntTextBox tbIterationInstructionCount;
        private MissionPlanner.Controls.TextBoxes.IntTextBox tbHangTime;
        private MissionPlanner.Controls.TextBoxes.IntTextBox tbPatrolRadius;
        private MissionPlanner.Controls.TextBoxes.IntTextBox tbSpeed;
        private System.Windows.Forms.CheckBox cbLatitude;
        private System.Windows.Forms.CheckBox cbInclination;
        private System.Windows.Forms.CheckBox cbSignalLevel;
        private System.Windows.Forms.CheckBox cbSatellites;
        private System.Windows.Forms.CheckBox cbCameraHAngle;
        private System.Windows.Forms.CheckBox cbRange2;
        private System.Windows.Forms.CheckBox cbRange1;
        private System.Windows.Forms.CheckBox cbPitchAngle;
        private System.Windows.Forms.CheckBox cbRollAngle;
        private System.Windows.Forms.CheckBox cbVerticalSpeed;
        private System.Windows.Forms.CheckBox cbHorizontalSpeed;
        private System.Windows.Forms.CheckBox cbHomeDistance;
        private System.Windows.Forms.CheckBox cbAltitudeWrtHome;
        private System.Windows.Forms.CheckBox cbAltitudeWrtGround;
        private System.Windows.Forms.CheckBox cbAzimuth;
        private System.Windows.Forms.CheckBox cbLongitude;
        private System.Windows.Forms.CheckBox cbCameraVAngle;
        private System.Windows.Forms.CheckBox cbBatteryTimeLeft;
        private System.Windows.Forms.CheckBox cbBatteryCapacity;
        private System.Windows.Forms.CheckBox cbBatteryVoltage;
        private System.Windows.Forms.CheckBox cbBatteryLevel;
        private System.Windows.Forms.CheckBox cbFlightMode;
        private System.Windows.Forms.CheckBox cbFlightTime;
        private System.Windows.Forms.CheckBox cbFlightPath;
        private System.Windows.Forms.CheckBox cbWeaponStatus;
        private System.Windows.Forms.CheckBox cbTargetHeight;
        private System.Windows.Forms.CheckBox cbTargetWidth;
        private System.Windows.Forms.CheckBox cbTarLon;
        private System.Windows.Forms.CheckBox cbTarLat;
        private System.Windows.Forms.CheckBox cbIndicators;
        private System.Windows.Forms.GroupBox TargetBox;
        private System.Windows.Forms.CheckBox cbTargetParam;
        private System.Windows.Forms.GroupBox BatteryBox;
        private System.Windows.Forms.CheckBox cbBattery;
        private System.Windows.Forms.CheckBox cbUavParam;
        private System.Windows.Forms.GroupBox UavParamBox;
        private System.Windows.Forms.CheckBox cbOtherParam;
        private System.Windows.Forms.GroupBox OtherParamBox;
        private System.Windows.Forms.CheckBox cbWindSpeed;
        private System.Windows.Forms.CheckBox cbWindAngle;
        private System.Windows.Forms.TableLayoutPanel tlpHudParts;
        private System.Windows.Forms.TableLayoutPanel tlpHud;
        private System.Windows.Forms.TableLayoutPanel tblTarget;
        private System.Windows.Forms.TableLayoutPanel tblUav;
        private System.Windows.Forms.TableLayoutPanel tblBattery;
        private System.Windows.Forms.TableLayoutPanel tblOther;
        private System.Windows.Forms.TableLayoutPanel tlpIndicators;
        private System.Windows.Forms.GroupBox IndicatorBox;
        private System.Windows.Forms.CheckBox cbGroundLevel;
        private System.Windows.Forms.CheckBox cbCompass;
        private System.Windows.Forms.CheckBox cbRollScale;
        private System.Windows.Forms.CheckBox cbPitchScale;
        private System.Windows.Forms.CheckBox cbCrossMark;
        private System.Windows.Forms.Button btnIndicators;
        private System.Windows.Forms.Button btnUavParams;
        private System.Windows.Forms.Button btnBattery;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.Label lblLowBatteryAction;
        private System.Windows.Forms.Label lblCrtBatteryAction;
        private System.Windows.Forms.RadioButton rbAutoLanding;
        private System.Windows.Forms.RadioButton rbTakeoffPoint;
        private System.Windows.Forms.RadioButton rbHomeReturn;
        private System.Windows.Forms.RadioButton rbWgs84Deg;
        private System.Windows.Forms.Label lblHangTime;
        private System.Windows.Forms.Label lblPatrolRadius;
        private System.Windows.Forms.GroupBox gbIkrlFailureActions;
        private System.Windows.Forms.RadioButton rbIkrlAutoLanding;
        private System.Windows.Forms.RadioButton rbIkrlTakeoffPoint;
        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpAutoMode;
        private System.Windows.Forms.Label lblIterationCount;
        private System.Windows.Forms.Label lblIdUav;
        private Controls.TextBoxes.IntTextBox tbIdUav;
        private System.Windows.Forms.CheckBox cbUseAlternateAirfieldStartPlace;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.ComboBox cmbCrtBatteryActions;
        private System.Windows.Forms.ComboBox cmbLowBatteryActions;
        private System.Windows.Forms.GroupBox gbCrossHairType;
        private System.Windows.Forms.RadioButton rbBallistic;
        private System.Windows.Forms.RadioButton rbRegular;
        private System.Windows.Forms.Label lblHomeReturnSpeed;
        private Controls.TextBoxes.IntTextBox tbHomeReturnSpeed;
        private System.Windows.Forms.GroupBox bgAlternateAerodromesPresence;
        private System.Windows.Forms.CheckBox cbCheckAlternateAirfields;
        private System.Windows.Forms.GroupBox gbGps;
        private System.Windows.Forms.Button btnGpsOn;
        private System.Windows.Forms.Button btnGpsOff;
        private System.Windows.Forms.GroupBox gbGpsFailtureActions;
        private System.Windows.Forms.RadioButton rbAutoManeuvering;
        private System.Windows.Forms.RadioButton rbLanding;
        private System.Windows.Forms.Label lblHomeReturnAltitude;
        private Controls.TextBoxes.IntTextBox tbHomeReturnAltitude;
    }
}