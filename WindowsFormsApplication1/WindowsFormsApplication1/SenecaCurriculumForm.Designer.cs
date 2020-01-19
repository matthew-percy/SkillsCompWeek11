namespace WindowsFormsApplication1
{
    partial class SenecaCurriculumForm
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
            this.CourseTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // CourseTreeView
            // 
            this.CourseTreeView.Location = new System.Drawing.Point(12, 12);
            this.CourseTreeView.Name = "CourseTreeView";
            this.CourseTreeView.Size = new System.Drawing.Size(370, 338);
            this.CourseTreeView.TabIndex = 0;
            // 
            // SenecaCurriculumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 362);
            this.Controls.Add(this.CourseTreeView);
            this.Name = "SenecaCurriculumForm";
            this.Text = "College Curriculum";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView CourseTreeView;
    }
}

