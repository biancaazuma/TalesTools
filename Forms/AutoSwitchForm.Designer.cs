﻿using _4RTools.Utils;
using System.Windows.Forms;
using System;

namespace _4RTools.Forms
{
    partial class AutoSwitchForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSwitchForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ITEMin319 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NEXTITEMin319 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.AutoSwitchGP = new System.Windows.Forms.GroupBox();
            this.btnAddAutoSwitch = new System.Windows.Forms.Button();
            this.skillCB = new System.Windows.Forms.ComboBox();
            this.ProcSwitchGP = new System.Windows.Forms.GroupBox();
            this.ITEMin461 = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin461 = new System.Windows.Forms.TextBox();
            this.ITEMin355 = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin355 = new System.Windows.Forms.TextBox();
            this.ITEMin25 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin25 = new System.Windows.Forms.TextBox();
            this.ITEMin2015 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin2015 = new System.Windows.Forms.TextBox();
            this.delay = new System.Windows.Forms.NumericUpDown();
            this.switchDelay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.ProcSwitchGP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 321;
            this.label1.Tag = "";
            this.label1.Text = "Delay";
            this.toolTip1.SetToolTip(this.label1, "Delay geral");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 322;
            this.label4.Text = "Troca Delay";
            this.toolTip1.SetToolTip(this.label4, "Delay entre Item e Próximo Item");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 296;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "319";
            // 
            // ITEMin319
            // 
            this.ITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin319.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin319.ForeColor = System.Drawing.Color.White;
            this.ITEMin319.Location = new System.Drawing.Point(51, 30);
            this.ITEMin319.Name = "ITEMin319";
            this.ITEMin319.Size = new System.Drawing.Size(45, 23);
            this.ITEMin319.TabIndex = 295;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 304;
            this.label2.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 305;
            this.label3.Text = "Próximo item";
            // 
            // NEXTITEMin319
            // 
            this.NEXTITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin319.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin319.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin319.Location = new System.Drawing.Point(158, 30);
            this.NEXTITEMin319.Name = "NEXTITEMin319";
            this.NEXTITEMin319.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin319.TabIndex = 308;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(116, 36);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 11);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 313;
            this.pictureBox4.TabStop = false;
            // 
            // AutoSwitchGP
            // 
            this.AutoSwitchGP.AutoSize = true;
            this.AutoSwitchGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoSwitchGP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.AutoSwitchGP.Location = new System.Drawing.Point(12, 43);
            this.AutoSwitchGP.Name = "AutoSwitchGP";
            this.AutoSwitchGP.Size = new System.Drawing.Size(302, 37);
            this.AutoSwitchGP.TabIndex = 314;
            this.AutoSwitchGP.TabStop = false;
            this.AutoSwitchGP.Text = "Customizados";
            // 
            // btnAddAutoSwitch
            // 
            this.btnAddAutoSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnAddAutoSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAutoSwitch.ForeColor = System.Drawing.Color.White;
            this.btnAddAutoSwitch.Location = new System.Drawing.Point(269, 10);
            this.btnAddAutoSwitch.Name = "btnAddAutoSwitch";
            this.btnAddAutoSwitch.Size = new System.Drawing.Size(45, 23);
            this.btnAddAutoSwitch.TabIndex = 316;
            this.btnAddAutoSwitch.Text = "Add";
            this.btnAddAutoSwitch.UseVisualStyleBackColor = false;
            this.btnAddAutoSwitch.Click += new System.EventHandler(this.btnNewSwitch);
            // 
            // skillCB
            // 
            this.skillCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.skillCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skillCB.ForeColor = System.Drawing.Color.White;
            this.skillCB.Location = new System.Drawing.Point(12, 12);
            this.skillCB.Name = "skillCB";
            this.skillCB.Size = new System.Drawing.Size(251, 21);
            this.skillCB.TabIndex = 317;
            // 
            // ProcSwitchGP
            // 
            this.ProcSwitchGP.AutoSize = true;
            this.ProcSwitchGP.Controls.Add(this.ITEMin461);
            this.ProcSwitchGP.Controls.Add(this.pictureBox9);
            this.ProcSwitchGP.Controls.Add(this.pictureBox10);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin461);
            this.ProcSwitchGP.Controls.Add(this.ITEMin355);
            this.ProcSwitchGP.Controls.Add(this.pictureBox7);
            this.ProcSwitchGP.Controls.Add(this.pictureBox8);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin355);
            this.ProcSwitchGP.Controls.Add(this.ITEMin25);
            this.ProcSwitchGP.Controls.Add(this.pictureBox5);
            this.ProcSwitchGP.Controls.Add(this.pictureBox6);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin25);
            this.ProcSwitchGP.Controls.Add(this.ITEMin2015);
            this.ProcSwitchGP.Controls.Add(this.pictureBox2);
            this.ProcSwitchGP.Controls.Add(this.pictureBox3);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin2015);
            this.ProcSwitchGP.Controls.Add(this.ITEMin319);
            this.ProcSwitchGP.Controls.Add(this.pictureBox1);
            this.ProcSwitchGP.Controls.Add(this.label2);
            this.ProcSwitchGP.Controls.Add(this.label3);
            this.ProcSwitchGP.Controls.Add(this.pictureBox4);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin319);
            this.ProcSwitchGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcSwitchGP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.ProcSwitchGP.Location = new System.Drawing.Point(333, 43);
            this.ProcSwitchGP.Name = "ProcSwitchGP";
            this.ProcSwitchGP.Size = new System.Drawing.Size(244, 200);
            this.ProcSwitchGP.TabIndex = 318;
            this.ProcSwitchGP.TabStop = false;
            this.ProcSwitchGP.Text = "Exclusivos";
            // 
            // ITEMin461
            // 
            this.ITEMin461.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin461.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin461.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin461.ForeColor = System.Drawing.Color.White;
            this.ITEMin461.Location = new System.Drawing.Point(51, 158);
            this.ITEMin461.Name = "ITEMin461";
            this.ITEMin461.Size = new System.Drawing.Size(45, 23);
            this.ITEMin461.TabIndex = 326;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(10, 157);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(24, 24);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 327;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(116, 164);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(19, 11);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 329;
            this.pictureBox10.TabStop = false;
            // 
            // NEXTITEMin461
            // 
            this.NEXTITEMin461.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin461.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin461.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin461.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin461.Location = new System.Drawing.Point(158, 158);
            this.NEXTITEMin461.Name = "NEXTITEMin461";
            this.NEXTITEMin461.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin461.TabIndex = 328;
            // 
            // ITEMin355
            // 
            this.ITEMin355.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin355.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin355.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin355.ForeColor = System.Drawing.Color.White;
            this.ITEMin355.Location = new System.Drawing.Point(51, 126);
            this.ITEMin355.Name = "ITEMin355";
            this.ITEMin355.Size = new System.Drawing.Size(45, 23);
            this.ITEMin355.TabIndex = 322;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(10, 125);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 24);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 323;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(116, 132);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(19, 11);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 325;
            this.pictureBox8.TabStop = false;
            // 
            // NEXTITEMin355
            // 
            this.NEXTITEMin355.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin355.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin355.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin355.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin355.Location = new System.Drawing.Point(158, 126);
            this.NEXTITEMin355.Name = "NEXTITEMin355";
            this.NEXTITEMin355.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin355.TabIndex = 324;
            // 
            // ITEMin25
            // 
            this.ITEMin25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin25.ForeColor = System.Drawing.Color.White;
            this.ITEMin25.Location = new System.Drawing.Point(51, 94);
            this.ITEMin25.Name = "ITEMin25";
            this.ITEMin25.Size = new System.Drawing.Size(45, 23);
            this.ITEMin25.TabIndex = 318;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(10, 93);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 319;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(116, 100);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(19, 11);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 321;
            this.pictureBox6.TabStop = false;
            // 
            // NEXTITEMin25
            // 
            this.NEXTITEMin25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin25.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin25.Location = new System.Drawing.Point(158, 94);
            this.NEXTITEMin25.Name = "NEXTITEMin25";
            this.NEXTITEMin25.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin25.TabIndex = 320;
            // 
            // ITEMin2015
            // 
            this.ITEMin2015.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin2015.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin2015.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin2015.ForeColor = System.Drawing.Color.White;
            this.ITEMin2015.Location = new System.Drawing.Point(51, 62);
            this.ITEMin2015.Name = "ITEMin2015";
            this.ITEMin2015.Size = new System.Drawing.Size(45, 23);
            this.ITEMin2015.TabIndex = 314;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 315;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(116, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 11);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 317;
            this.pictureBox3.TabStop = false;
            // 
            // NEXTITEMin2015
            // 
            this.NEXTITEMin2015.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin2015.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin2015.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin2015.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin2015.Location = new System.Drawing.Point(158, 62);
            this.NEXTITEMin2015.Name = "NEXTITEMin2015";
            this.NEXTITEMin2015.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin2015.TabIndex = 316;
            // 
            // delay
            // 
            this.delay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.delay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.delay.ForeColor = System.Drawing.Color.White;
            this.delay.Location = new System.Drawing.Point(369, 13);
            this.delay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(60, 20);
            this.delay.TabIndex = 319;
            this.delay.Tag = "delay";
            // 
            // switchDelay
            // 
            this.switchDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.switchDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchDelay.ForeColor = System.Drawing.Color.White;
            this.switchDelay.Location = new System.Drawing.Point(517, 13);
            this.switchDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.switchDelay.Name = "switchDelay";
            this.switchDelay.Size = new System.Drawing.Size(60, 20);
            this.switchDelay.TabIndex = 320;
            this.switchDelay.Tag = "switchDelay";
            // 
            // AutoSwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(606, 388);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.switchDelay);
            this.Controls.Add(this.delay);
            this.Controls.Add(this.ProcSwitchGP);
            this.Controls.Add(this.skillCB);
            this.Controls.Add(this.btnAddAutoSwitch);
            this.Controls.Add(this.AutoSwitchGP);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoSwitchForm";
            this.Text = "AutoSwitchForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ProcSwitchGP.ResumeLayout(false);
            this.ProcSwitchGP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ITEMin319;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NEXTITEMin319;
        private System.Windows.Forms.PictureBox pictureBox4;
        private GroupBox AutoSwitchGP;
        private Button btnAddAutoSwitch;
        private ComboBox skillCB;
        private GroupBox ProcSwitchGP;
        private NumericUpDown delay;
        private NumericUpDown switchDelay;
        private Label label1;
        private Label label4;
        private TextBox ITEMin25;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private TextBox NEXTITEMin25;
        private TextBox ITEMin2015;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox NEXTITEMin2015;
        private TextBox ITEMin461;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private TextBox NEXTITEMin461;
        private TextBox ITEMin355;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private TextBox NEXTITEMin355;
    }
}