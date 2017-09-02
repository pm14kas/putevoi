namespace putevoi
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.tabControlDatabase = new System.Windows.Forms.TabControl();
            this.tabDBDrivers = new System.Windows.Forms.TabPage();
            this.buttonDriverAdd = new System.Windows.Forms.Button();
            this.buttonDriverDelete = new System.Windows.Forms.Button();
            this.dataDrivers = new System.Windows.Forms.DataGridView();
            this.driver_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_familiya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_imya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_otchestvo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_document = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driver_updated_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDBEngines = new System.Windows.Forms.TabPage();
            this.buttonEngineAdd = new System.Windows.Forms.Button();
            this.buttonEngineDelete = new System.Windows.Forms.Button();
            this.dataEngines = new System.Windows.Forms.DataGridView();
            this.engine_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engine_marka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engine_gosnomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engine_rashod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engine_created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engine_updated_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDBCars = new System.Windows.Forms.TabPage();
            this.buttonCarAdd = new System.Windows.Forms.Button();
            this.buttonCarDelete = new System.Windows.Forms.Button();
            this.dataCars = new System.Windows.Forms.DataGridView();
            this.car_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car_marka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car_gosnomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car_rashod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car_created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.car_updated_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPutevoi = new System.Windows.Forms.TabPage();
            this.buttonPutevoiEdit = new System.Windows.Forms.Button();
            this.buttonPutevoiAdd = new System.Windows.Forms.Button();
            this.buttonPutevoiDelete = new System.Windows.Forms.Button();
            this.dataPutevoi = new System.Windows.Forms.DataGridView();
            this.tabGSM = new System.Windows.Forms.TabPage();
            this.buttonGSMSingle = new System.Windows.Forms.Button();
            this.buttonGSMAll = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimeGSMDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeGSMDateStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboSelectEngine = new System.Windows.Forms.ComboBox();
            this.putevoi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_nomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_driver_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_engine_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_car_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_date_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_date_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_zapravka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_karta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_rashod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_fuel_norma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_probeg_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_probeg_s_gruzom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_probeg_bez_gruza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_probeg_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putevoi_updated_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.tabControlDatabase.SuspendLayout();
            this.tabDBDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDrivers)).BeginInit();
            this.tabDBEngines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEngines)).BeginInit();
            this.tabDBCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCars)).BeginInit();
            this.tabPutevoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPutevoi)).BeginInit();
            this.tabGSM.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDatabase);
            this.tabControl.Controls.Add(this.tabPutevoi);
            this.tabControl.Controls.Add(this.tabGSM);
            this.tabControl.Location = new System.Drawing.Point(-1, -1);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(780, 460);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.tabControlDatabase);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(772, 434);
            this.tabDatabase.TabIndex = 2;
            this.tabDatabase.Text = "База данных";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // tabControlDatabase
            // 
            this.tabControlDatabase.Controls.Add(this.tabDBDrivers);
            this.tabControlDatabase.Controls.Add(this.tabDBEngines);
            this.tabControlDatabase.Controls.Add(this.tabDBCars);
            this.tabControlDatabase.Location = new System.Drawing.Point(3, 0);
            this.tabControlDatabase.Name = "tabControlDatabase";
            this.tabControlDatabase.SelectedIndex = 0;
            this.tabControlDatabase.Size = new System.Drawing.Size(765, 430);
            this.tabControlDatabase.TabIndex = 0;
            this.tabControlDatabase.SelectedIndexChanged += new System.EventHandler(this.tabControlDatabase_SelectedIndexChanged);
            // 
            // tabDBDrivers
            // 
            this.tabDBDrivers.Controls.Add(this.buttonDriverAdd);
            this.tabDBDrivers.Controls.Add(this.buttonDriverDelete);
            this.tabDBDrivers.Controls.Add(this.dataDrivers);
            this.tabDBDrivers.Location = new System.Drawing.Point(4, 22);
            this.tabDBDrivers.Name = "tabDBDrivers";
            this.tabDBDrivers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBDrivers.Size = new System.Drawing.Size(757, 404);
            this.tabDBDrivers.TabIndex = 0;
            this.tabDBDrivers.Text = "Водители";
            this.tabDBDrivers.UseVisualStyleBackColor = true;
            // 
            // buttonDriverAdd
            // 
            this.buttonDriverAdd.Location = new System.Drawing.Point(580, 375);
            this.buttonDriverAdd.Name = "buttonDriverAdd";
            this.buttonDriverAdd.Size = new System.Drawing.Size(166, 23);
            this.buttonDriverAdd.TabIndex = 2;
            this.buttonDriverAdd.Text = "Добавить новую запись";
            this.buttonDriverAdd.UseVisualStyleBackColor = true;
            this.buttonDriverAdd.Click += new System.EventHandler(this.buttonDriverAdd_Click);
            // 
            // buttonDriverDelete
            // 
            this.buttonDriverDelete.Location = new System.Drawing.Point(11, 375);
            this.buttonDriverDelete.Name = "buttonDriverDelete";
            this.buttonDriverDelete.Size = new System.Drawing.Size(166, 23);
            this.buttonDriverDelete.TabIndex = 1;
            this.buttonDriverDelete.Text = "Удалить выбранную запись";
            this.buttonDriverDelete.UseVisualStyleBackColor = true;
            this.buttonDriverDelete.Click += new System.EventHandler(this.buttonDriverDelete_Click);
            // 
            // dataDrivers
            // 
            this.dataDrivers.AllowUserToAddRows = false;
            this.dataDrivers.AllowUserToDeleteRows = false;
            this.dataDrivers.AllowUserToOrderColumns = true;
            this.dataDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.driver_id,
            this.driver_familiya,
            this.driver_imya,
            this.driver_otchestvo,
            this.driver_document,
            this.driver_passport,
            this.driver_created_at,
            this.driver_updated_at});
            this.dataDrivers.Location = new System.Drawing.Point(11, 8);
            this.dataDrivers.Name = "dataDrivers";
            this.dataDrivers.Size = new System.Drawing.Size(735, 360);
            this.dataDrivers.TabIndex = 0;
            this.dataDrivers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataDrivers_CellEndEdit);
            // 
            // driver_id
            // 
            this.driver_id.Frozen = true;
            this.driver_id.HeaderText = "ID";
            this.driver_id.Name = "driver_id";
            this.driver_id.ReadOnly = true;
            // 
            // driver_familiya
            // 
            this.driver_familiya.HeaderText = "Фамилия";
            this.driver_familiya.Name = "driver_familiya";
            // 
            // driver_imya
            // 
            this.driver_imya.HeaderText = "Имя";
            this.driver_imya.Name = "driver_imya";
            // 
            // driver_otchestvo
            // 
            this.driver_otchestvo.HeaderText = "Отчество";
            this.driver_otchestvo.Name = "driver_otchestvo";
            // 
            // driver_document
            // 
            this.driver_document.HeaderText = "Удостоверение";
            this.driver_document.Name = "driver_document";
            // 
            // driver_passport
            // 
            this.driver_passport.HeaderText = "Паспорт";
            this.driver_passport.Name = "driver_passport";
            // 
            // driver_created_at
            // 
            this.driver_created_at.HeaderText = "Дата создания";
            this.driver_created_at.Name = "driver_created_at";
            this.driver_created_at.ReadOnly = true;
            // 
            // driver_updated_at
            // 
            this.driver_updated_at.HeaderText = "Дата последнего изменения";
            this.driver_updated_at.Name = "driver_updated_at";
            this.driver_updated_at.ReadOnly = true;
            // 
            // tabDBEngines
            // 
            this.tabDBEngines.Controls.Add(this.buttonEngineAdd);
            this.tabDBEngines.Controls.Add(this.buttonEngineDelete);
            this.tabDBEngines.Controls.Add(this.dataEngines);
            this.tabDBEngines.Location = new System.Drawing.Point(4, 22);
            this.tabDBEngines.Name = "tabDBEngines";
            this.tabDBEngines.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBEngines.Size = new System.Drawing.Size(757, 404);
            this.tabDBEngines.TabIndex = 5;
            this.tabDBEngines.Text = "Автомобили";
            this.tabDBEngines.UseVisualStyleBackColor = true;
            // 
            // buttonEngineAdd
            // 
            this.buttonEngineAdd.Location = new System.Drawing.Point(580, 375);
            this.buttonEngineAdd.Name = "buttonEngineAdd";
            this.buttonEngineAdd.Size = new System.Drawing.Size(166, 23);
            this.buttonEngineAdd.TabIndex = 2;
            this.buttonEngineAdd.Text = "Добавить новую запись";
            this.buttonEngineAdd.UseVisualStyleBackColor = true;
            this.buttonEngineAdd.Click += new System.EventHandler(this.buttonEngineAdd_Click);
            // 
            // buttonEngineDelete
            // 
            this.buttonEngineDelete.Location = new System.Drawing.Point(11, 375);
            this.buttonEngineDelete.Name = "buttonEngineDelete";
            this.buttonEngineDelete.Size = new System.Drawing.Size(166, 23);
            this.buttonEngineDelete.TabIndex = 1;
            this.buttonEngineDelete.Text = "Удалить выбранную запись";
            this.buttonEngineDelete.UseVisualStyleBackColor = true;
            this.buttonEngineDelete.Click += new System.EventHandler(this.buttonEngineDelete_Click);
            // 
            // dataEngines
            // 
            this.dataEngines.AllowUserToAddRows = false;
            this.dataEngines.AllowUserToDeleteRows = false;
            this.dataEngines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEngines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.engine_id,
            this.engine_marka,
            this.engine_gosnomer,
            this.engine_rashod,
            this.engine_created_at,
            this.engine_updated_at});
            this.dataEngines.Location = new System.Drawing.Point(11, 8);
            this.dataEngines.Name = "dataEngines";
            this.dataEngines.Size = new System.Drawing.Size(735, 360);
            this.dataEngines.TabIndex = 0;
            this.dataEngines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEngines_CellEndEdit);
            // 
            // engine_id
            // 
            this.engine_id.Frozen = true;
            this.engine_id.HeaderText = "ID";
            this.engine_id.Name = "engine_id";
            this.engine_id.ReadOnly = true;
            // 
            // engine_marka
            // 
            this.engine_marka.HeaderText = "Марка";
            this.engine_marka.Name = "engine_marka";
            // 
            // engine_gosnomer
            // 
            this.engine_gosnomer.HeaderText = "Гос. номер";
            this.engine_gosnomer.Name = "engine_gosnomer";
            // 
            // engine_rashod
            // 
            this.engine_rashod.HeaderText = "Расход топлива (л/100км)";
            this.engine_rashod.Name = "engine_rashod";
            // 
            // engine_created_at
            // 
            this.engine_created_at.HeaderText = "Дата создания";
            this.engine_created_at.Name = "engine_created_at";
            this.engine_created_at.ReadOnly = true;
            // 
            // engine_updated_at
            // 
            this.engine_updated_at.HeaderText = "Дата последнего изменения";
            this.engine_updated_at.Name = "engine_updated_at";
            this.engine_updated_at.ReadOnly = true;
            // 
            // tabDBCars
            // 
            this.tabDBCars.Controls.Add(this.buttonCarAdd);
            this.tabDBCars.Controls.Add(this.buttonCarDelete);
            this.tabDBCars.Controls.Add(this.dataCars);
            this.tabDBCars.Location = new System.Drawing.Point(4, 22);
            this.tabDBCars.Name = "tabDBCars";
            this.tabDBCars.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBCars.Size = new System.Drawing.Size(757, 404);
            this.tabDBCars.TabIndex = 6;
            this.tabDBCars.Text = "Прицепы";
            this.tabDBCars.UseVisualStyleBackColor = true;
            // 
            // buttonCarAdd
            // 
            this.buttonCarAdd.Location = new System.Drawing.Point(580, 375);
            this.buttonCarAdd.Name = "buttonCarAdd";
            this.buttonCarAdd.Size = new System.Drawing.Size(166, 23);
            this.buttonCarAdd.TabIndex = 2;
            this.buttonCarAdd.Text = "Добавить новую запись";
            this.buttonCarAdd.UseVisualStyleBackColor = true;
            this.buttonCarAdd.Click += new System.EventHandler(this.buttonCarAdd_Click);
            // 
            // buttonCarDelete
            // 
            this.buttonCarDelete.Location = new System.Drawing.Point(11, 375);
            this.buttonCarDelete.Name = "buttonCarDelete";
            this.buttonCarDelete.Size = new System.Drawing.Size(166, 23);
            this.buttonCarDelete.TabIndex = 1;
            this.buttonCarDelete.Text = "Удалить выбранную запись";
            this.buttonCarDelete.UseVisualStyleBackColor = true;
            this.buttonCarDelete.Click += new System.EventHandler(this.buttonCarDelete_Click);
            // 
            // dataCars
            // 
            this.dataCars.AllowUserToAddRows = false;
            this.dataCars.AllowUserToDeleteRows = false;
            this.dataCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.car_id,
            this.car_marka,
            this.car_gosnomer,
            this.car_weight,
            this.car_rashod,
            this.car_created_at,
            this.car_updated_at});
            this.dataCars.Location = new System.Drawing.Point(11, 8);
            this.dataCars.Name = "dataCars";
            this.dataCars.Size = new System.Drawing.Size(735, 360);
            this.dataCars.TabIndex = 0;
            this.dataCars.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCars_CellEndEdit);
            // 
            // car_id
            // 
            this.car_id.Frozen = true;
            this.car_id.HeaderText = "ID";
            this.car_id.Name = "car_id";
            this.car_id.ReadOnly = true;
            // 
            // car_marka
            // 
            this.car_marka.HeaderText = "Марка";
            this.car_marka.Name = "car_marka";
            // 
            // car_gosnomer
            // 
            this.car_gosnomer.HeaderText = "Гос. номер";
            this.car_gosnomer.Name = "car_gosnomer";
            // 
            // car_weight
            // 
            this.car_weight.HeaderText = "Вес (т)";
            this.car_weight.Name = "car_weight";
            // 
            // car_rashod
            // 
            this.car_rashod.HeaderText = "Расход топлива (л/100км)";
            this.car_rashod.Name = "car_rashod";
            // 
            // car_created_at
            // 
            this.car_created_at.HeaderText = "Дата создания";
            this.car_created_at.Name = "car_created_at";
            this.car_created_at.ReadOnly = true;
            // 
            // car_updated_at
            // 
            this.car_updated_at.HeaderText = "Дата последнего изменения";
            this.car_updated_at.Name = "car_updated_at";
            this.car_updated_at.ReadOnly = true;
            // 
            // tabPutevoi
            // 
            this.tabPutevoi.Controls.Add(this.buttonPutevoiEdit);
            this.tabPutevoi.Controls.Add(this.buttonPutevoiAdd);
            this.tabPutevoi.Controls.Add(this.buttonPutevoiDelete);
            this.tabPutevoi.Controls.Add(this.dataPutevoi);
            this.tabPutevoi.Location = new System.Drawing.Point(4, 22);
            this.tabPutevoi.Name = "tabPutevoi";
            this.tabPutevoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPutevoi.Size = new System.Drawing.Size(772, 434);
            this.tabPutevoi.TabIndex = 8;
            this.tabPutevoi.Text = "Путевые листы";
            this.tabPutevoi.UseVisualStyleBackColor = true;
            // 
            // buttonPutevoiEdit
            // 
            this.buttonPutevoiEdit.Location = new System.Drawing.Point(312, 405);
            this.buttonPutevoiEdit.Name = "buttonPutevoiEdit";
            this.buttonPutevoiEdit.Size = new System.Drawing.Size(166, 23);
            this.buttonPutevoiEdit.TabIndex = 3;
            this.buttonPutevoiEdit.Text = "Изменить выбранную запись";
            this.buttonPutevoiEdit.UseVisualStyleBackColor = true;
            this.buttonPutevoiEdit.Click += new System.EventHandler(this.buttonPutevoiEdit_Click);
            // 
            // buttonPutevoiAdd
            // 
            this.buttonPutevoiAdd.Location = new System.Drawing.Point(600, 405);
            this.buttonPutevoiAdd.Name = "buttonPutevoiAdd";
            this.buttonPutevoiAdd.Size = new System.Drawing.Size(166, 23);
            this.buttonPutevoiAdd.TabIndex = 2;
            this.buttonPutevoiAdd.Text = "Добавить новую запись";
            this.buttonPutevoiAdd.UseVisualStyleBackColor = true;
            this.buttonPutevoiAdd.Click += new System.EventHandler(this.buttonPutevoiAdd_Click);
            // 
            // buttonPutevoiDelete
            // 
            this.buttonPutevoiDelete.Location = new System.Drawing.Point(9, 405);
            this.buttonPutevoiDelete.Name = "buttonPutevoiDelete";
            this.buttonPutevoiDelete.Size = new System.Drawing.Size(166, 23);
            this.buttonPutevoiDelete.TabIndex = 1;
            this.buttonPutevoiDelete.Text = "Удалить выбранную запись";
            this.buttonPutevoiDelete.UseVisualStyleBackColor = true;
            this.buttonPutevoiDelete.Click += new System.EventHandler(this.buttonPutevoiDelete_Click);
            // 
            // dataPutevoi
            // 
            this.dataPutevoi.AllowUserToAddRows = false;
            this.dataPutevoi.AllowUserToDeleteRows = false;
            this.dataPutevoi.AllowUserToOrderColumns = true;
            this.dataPutevoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPutevoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.putevoi_id,
            this.putevoi_nomer,
            this.putevoi_driver_id,
            this.putevoi_engine_id,
            this.putevoi_car_id,
            this.putevoi_date_start,
            this.putevoi_date_end,
            this.putevoi_fuel_start,
            this.putevoi_fuel_zapravka,
            this.putevoi_fuel_karta,
            this.putevoi_fuel_cash,
            this.putevoi_fuel_sum,
            this.putevoi_fuel_end,
            this.putevoi_fuel_rashod,
            this.putevoi_fuel_norma,
            this.putevoi_probeg_start,
            this.putevoi_probeg_s_gruzom,
            this.putevoi_probeg_bez_gruza,
            this.putevoi_probeg_end,
            this.putevoi_created_at,
            this.putevoi_updated_at});
            this.dataPutevoi.Location = new System.Drawing.Point(11, 8);
            this.dataPutevoi.Name = "dataPutevoi";
            this.dataPutevoi.ReadOnly = true;
            this.dataPutevoi.Size = new System.Drawing.Size(755, 390);
            this.dataPutevoi.TabIndex = 0;
            // 
            // tabGSM
            // 
            this.tabGSM.Controls.Add(this.buttonGSMSingle);
            this.tabGSM.Controls.Add(this.buttonGSMAll);
            this.tabGSM.Controls.Add(this.label17);
            this.tabGSM.Controls.Add(this.label16);
            this.tabGSM.Controls.Add(this.dateTimeGSMDateEnd);
            this.tabGSM.Controls.Add(this.dateTimeGSMDateStart);
            this.tabGSM.Controls.Add(this.label3);
            this.tabGSM.Controls.Add(this.comboSelectEngine);
            this.tabGSM.Location = new System.Drawing.Point(4, 22);
            this.tabGSM.Name = "tabGSM";
            this.tabGSM.Padding = new System.Windows.Forms.Padding(3);
            this.tabGSM.Size = new System.Drawing.Size(772, 434);
            this.tabGSM.TabIndex = 1;
            this.tabGSM.Text = "Расчет ГСМ";
            this.tabGSM.UseVisualStyleBackColor = true;
            // 
            // buttonGSMSingle
            // 
            this.buttonGSMSingle.Location = new System.Drawing.Point(441, 336);
            this.buttonGSMSingle.Name = "buttonGSMSingle";
            this.buttonGSMSingle.Size = new System.Drawing.Size(220, 23);
            this.buttonGSMSingle.TabIndex = 35;
            this.buttonGSMSingle.Text = "Отчёт по выбранному автомобилю";
            this.buttonGSMSingle.UseVisualStyleBackColor = true;
            this.buttonGSMSingle.Click += new System.EventHandler(this.buttonGSMSingle_Click);
            // 
            // buttonGSMAll
            // 
            this.buttonGSMAll.Location = new System.Drawing.Point(62, 336);
            this.buttonGSMAll.Name = "buttonGSMAll";
            this.buttonGSMAll.Size = new System.Drawing.Size(220, 23);
            this.buttonGSMAll.TabIndex = 34;
            this.buttonGSMAll.Text = "Отчет по всем автомобилям";
            this.buttonGSMAll.UseVisualStyleBackColor = true;
            this.buttonGSMAll.Click += new System.EventHandler(this.buttonGSMAll_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(236, 183);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "по";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(65, 183);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Период с";
            // 
            // dateTimeGSMDateEnd
            // 
            this.dateTimeGSMDateEnd.CustomFormat = "dd.MM.yyyy   HH:mm";
            this.dateTimeGSMDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeGSMDateEnd.Location = new System.Drawing.Point(261, 183);
            this.dateTimeGSMDateEnd.Name = "dateTimeGSMDateEnd";
            this.dateTimeGSMDateEnd.Size = new System.Drawing.Size(105, 20);
            this.dateTimeGSMDateEnd.TabIndex = 31;
            this.dateTimeGSMDateEnd.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimeGSMDateStart
            // 
            this.dateTimeGSMDateStart.CustomFormat = "dd.MM.yyyy   HH:mm";
            this.dateTimeGSMDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeGSMDateStart.Location = new System.Drawing.Point(125, 183);
            this.dateTimeGSMDateStart.Name = "dateTimeGSMDateStart";
            this.dateTimeGSMDateStart.Size = new System.Drawing.Size(105, 20);
            this.dateTimeGSMDateStart.TabIndex = 30;
            this.dateTimeGSMDateStart.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Автомобиль";
            // 
            // comboSelectEngine
            // 
            this.comboSelectEngine.DisplayMember = "value";
            this.comboSelectEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectEngine.FormattingEnabled = true;
            this.comboSelectEngine.Location = new System.Drawing.Point(62, 91);
            this.comboSelectEngine.Name = "comboSelectEngine";
            this.comboSelectEngine.Size = new System.Drawing.Size(168, 21);
            this.comboSelectEngine.TabIndex = 6;
            this.comboSelectEngine.ValueMember = "id";
            // 
            // putevoi_id
            // 
            this.putevoi_id.Frozen = true;
            this.putevoi_id.HeaderText = "ID";
            this.putevoi_id.Name = "putevoi_id";
            this.putevoi_id.ReadOnly = true;
            // 
            // putevoi_nomer
            // 
            this.putevoi_nomer.HeaderText = "Номер ПЛ";
            this.putevoi_nomer.Name = "putevoi_nomer";
            this.putevoi_nomer.ReadOnly = true;
            // 
            // putevoi_driver_id
            // 
            this.putevoi_driver_id.HeaderText = "Водитель";
            this.putevoi_driver_id.Name = "putevoi_driver_id";
            this.putevoi_driver_id.ReadOnly = true;
            this.putevoi_driver_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // putevoi_engine_id
            // 
            this.putevoi_engine_id.HeaderText = "Автомобиль";
            this.putevoi_engine_id.Name = "putevoi_engine_id";
            this.putevoi_engine_id.ReadOnly = true;
            this.putevoi_engine_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // putevoi_car_id
            // 
            this.putevoi_car_id.HeaderText = "Прицеп";
            this.putevoi_car_id.Name = "putevoi_car_id";
            this.putevoi_car_id.ReadOnly = true;
            this.putevoi_car_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // putevoi_date_start
            // 
            this.putevoi_date_start.HeaderText = "Выезд";
            this.putevoi_date_start.Name = "putevoi_date_start";
            this.putevoi_date_start.ReadOnly = true;
            // 
            // putevoi_date_end
            // 
            this.putevoi_date_end.HeaderText = "Въезд";
            this.putevoi_date_end.Name = "putevoi_date_end";
            this.putevoi_date_end.ReadOnly = true;
            // 
            // putevoi_fuel_start
            // 
            this.putevoi_fuel_start.HeaderText = "Топливо на начало периода (л)";
            this.putevoi_fuel_start.Name = "putevoi_fuel_start";
            this.putevoi_fuel_start.ReadOnly = true;
            // 
            // putevoi_fuel_zapravka
            // 
            this.putevoi_fuel_zapravka.HeaderText = "Заправлено на заправке (л)";
            this.putevoi_fuel_zapravka.Name = "putevoi_fuel_zapravka";
            this.putevoi_fuel_zapravka.ReadOnly = true;
            // 
            // putevoi_fuel_karta
            // 
            this.putevoi_fuel_karta.HeaderText = "Заправлено по карте (л)";
            this.putevoi_fuel_karta.Name = "putevoi_fuel_karta";
            this.putevoi_fuel_karta.ReadOnly = true;
            // 
            // putevoi_fuel_cash
            // 
            this.putevoi_fuel_cash.HeaderText = "Заправлено наличными (л)";
            this.putevoi_fuel_cash.Name = "putevoi_fuel_cash";
            this.putevoi_fuel_cash.ReadOnly = true;
            // 
            // putevoi_fuel_sum
            // 
            this.putevoi_fuel_sum.HeaderText = "Итого заправлено (л)";
            this.putevoi_fuel_sum.Name = "putevoi_fuel_sum";
            this.putevoi_fuel_sum.ReadOnly = true;
            // 
            // putevoi_fuel_end
            // 
            this.putevoi_fuel_end.HeaderText = "Топливо на конец периода (л)";
            this.putevoi_fuel_end.Name = "putevoi_fuel_end";
            this.putevoi_fuel_end.ReadOnly = true;
            // 
            // putevoi_fuel_rashod
            // 
            this.putevoi_fuel_rashod.HeaderText = "Расход (л)";
            this.putevoi_fuel_rashod.Name = "putevoi_fuel_rashod";
            this.putevoi_fuel_rashod.ReadOnly = true;
            // 
            // putevoi_fuel_norma
            // 
            this.putevoi_fuel_norma.HeaderText = "Норма расхода (л)";
            this.putevoi_fuel_norma.Name = "putevoi_fuel_norma";
            this.putevoi_fuel_norma.ReadOnly = true;
            // 
            // putevoi_probeg_start
            // 
            this.putevoi_probeg_start.HeaderText = "Одометр на выезде (км)";
            this.putevoi_probeg_start.Name = "putevoi_probeg_start";
            this.putevoi_probeg_start.ReadOnly = true;
            // 
            // putevoi_probeg_s_gruzom
            // 
            this.putevoi_probeg_s_gruzom.HeaderText = "Пробег с грузом (км)";
            this.putevoi_probeg_s_gruzom.Name = "putevoi_probeg_s_gruzom";
            this.putevoi_probeg_s_gruzom.ReadOnly = true;
            // 
            // putevoi_probeg_bez_gruza
            // 
            this.putevoi_probeg_bez_gruza.HeaderText = "Пробег без груза (км)";
            this.putevoi_probeg_bez_gruza.Name = "putevoi_probeg_bez_gruza";
            this.putevoi_probeg_bez_gruza.ReadOnly = true;
            // 
            // putevoi_probeg_end
            // 
            this.putevoi_probeg_end.HeaderText = "Одометр на въезде (км)";
            this.putevoi_probeg_end.Name = "putevoi_probeg_end";
            this.putevoi_probeg_end.ReadOnly = true;
            // 
            // putevoi_created_at
            // 
            this.putevoi_created_at.HeaderText = "Дата создания";
            this.putevoi_created_at.Name = "putevoi_created_at";
            this.putevoi_created_at.ReadOnly = true;
            // 
            // putevoi_updated_at
            // 
            this.putevoi_updated_at.HeaderText = "Дата последнего изменения";
            this.putevoi_updated_at.Name = "putevoi_updated_at";
            this.putevoi_updated_at.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "Расчет путевых листов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MainForm_SizeChanged);
            this.tabControl.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.tabControlDatabase.ResumeLayout(false);
            this.tabDBDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataDrivers)).EndInit();
            this.tabDBEngines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataEngines)).EndInit();
            this.tabDBCars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataCars)).EndInit();
            this.tabPutevoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPutevoi)).EndInit();
            this.tabGSM.ResumeLayout(false);
            this.tabGSM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGSM;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.TabControl tabControlDatabase;
        private System.Windows.Forms.TabPage tabDBDrivers;
        private System.Windows.Forms.DataGridView dataDrivers;
        private System.Windows.Forms.Button buttonDriverAdd;
        private System.Windows.Forms.Button buttonDriverDelete;
        private System.Windows.Forms.TabPage tabDBEngines;
        private System.Windows.Forms.Button buttonEngineAdd;
        private System.Windows.Forms.Button buttonEngineDelete;
        private System.Windows.Forms.DataGridView dataEngines;
        private System.Windows.Forms.TabPage tabDBCars;
        private System.Windows.Forms.Button buttonCarAdd;
        private System.Windows.Forms.Button buttonCarDelete;
        private System.Windows.Forms.DataGridView dataCars;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_familiya;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_imya;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_otchestvo;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_document;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn driver_updated_at;
        private System.Windows.Forms.TabPage tabPutevoi;
        private System.Windows.Forms.Button buttonPutevoiEdit;
        private System.Windows.Forms.Button buttonPutevoiAdd;
        private System.Windows.Forms.Button buttonPutevoiDelete;
        private System.Windows.Forms.DataGridView dataPutevoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboSelectEngine;
        private System.Windows.Forms.Button buttonGSMSingle;
        private System.Windows.Forms.Button buttonGSMAll;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimeGSMDateEnd;
        private System.Windows.Forms.DateTimePicker dateTimeGSMDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_marka;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_gosnomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_rashod;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn car_updated_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn engine_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn engine_marka;
        private System.Windows.Forms.DataGridViewTextBoxColumn engine_gosnomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn engine_rashod;
        private System.Windows.Forms.DataGridViewTextBoxColumn engine_created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn engine_updated_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_nomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_driver_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_engine_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_car_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_date_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_date_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_zapravka;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_karta;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_rashod;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_fuel_norma;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_probeg_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_probeg_s_gruzom;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_probeg_bez_gruza;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_probeg_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn putevoi_updated_at;


    }
}

