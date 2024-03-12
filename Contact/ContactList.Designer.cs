namespace Contact
{
    partial class ContactList
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.contactView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModificationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contactView)).BeginInit();
            this.SuspendLayout();
            // 
            // contactView
            // 
            this.contactView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.contactView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FullName,
            this.PhoneNumber,
            this.LastModificationDate});
            this.contactView.GridColor = System.Drawing.SystemColors.Control;
            this.contactView.Location = new System.Drawing.Point(12, 122);
            this.contactView.Name = "contactView";
            this.contactView.RowHeadersWidth = 51;
            this.contactView.RowTemplate.Height = 24;
            this.contactView.Size = new System.Drawing.Size(776, 324);
            this.contactView.TabIndex = 0;
            this.contactView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contactView_CellContentClick);
            this.contactView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.contactView_CellEndEdit);
            this.contactView.SelectionChanged += new System.EventHandler(this.contactView_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Номер";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Наименование";
            this.FullName.MaxInputLength = 100;
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.Width = 250;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "Номер телефона";
            this.PhoneNumber.MaxInputLength = 18;
            this.PhoneNumber.MinimumWidth = 6;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Width = 125;
            // 
            // LastModificationDate
            // 
            this.LastModificationDate.HeaderText = "Дата последнего изменения";
            this.LastModificationDate.MinimumWidth = 6;
            this.LastModificationDate.Name = "LastModificationDate";
            this.LastModificationDate.ReadOnly = true;
            this.LastModificationDate.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отображение контактов";
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.infoLabel2.Location = new System.Drawing.Point(9, 34);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(562, 36);
            this.infoLabel2.TabIndex = 4;
            this.infoLabel2.Text = "Вы можете обновить данные после изменения с помощью кнопки \"Сохранить\"\r\nДля удале" +
    "ния строки нажмите на пространство слева от неё";
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.saveBtn.Location = new System.Drawing.Point(411, 73);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(232, 43);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Сохранить изменения";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchTxt.Location = new System.Drawing.Point(12, 73);
            this.searchTxt.Multiline = true;
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(240, 43);
            this.searchTxt.TabIndex = 6;
            this.searchTxt.Text = "Введите имя";
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.searchBtn.Location = new System.Drawing.Point(258, 73);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(147, 43);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "Поиск по имени";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // ContactList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contactView);
            this.Name = "ContactList";
            this.Text = "Все контакты";
            this.Load += new System.EventHandler(this.ContactList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contactView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView contactView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModificationDate;
    }
}

