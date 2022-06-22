using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
using Controllers;

public class UsuarioDeletar : Form //Deletar Usuario
{
    private System.ComponentModel.IContainer components = null;

    int id;
    Label lblDeletar;

    Button btnConfirm;
    Button btnCancel;

    public UsuarioDeletar(int id)
    {
        this.id = id;

        lblDeletar = new Label();
        lblDeletar.Text = $"Deseja realmente excluir esse item? (ID: {id})";
        lblDeletar.Size = new Size(200, 40);
        lblDeletar.TextAlign = ContentAlignment.MiddleCenter;
        lblDeletar.Location = new Point(0, 20);

        btnConfirm = new Button();
        btnConfirm.Text = "Sim";
        btnConfirm.Size = new Size(80, 30);
        btnConfirm.Location = new Point(15, 90);
        btnConfirm.Click += new EventHandler(this.btnConfirmClick);

        btnCancel = new Button();
        btnCancel.Text = "Não";
        btnCancel.Size = new Size(80, 30);
        btnCancel.Location = new Point(105, 90);
        btnCancel.Click += new EventHandler(this.btnCancelClick);

        this.Controls.Add(this.lblDeletar);

        this.Controls.Add(this.btnConfirm);
        this.Controls.Add(this.btnCancel);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(200, 140);
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void btnConfirmClick(object sender, EventArgs e)
    {
        try
        {
            UsuarioController.RemoverUsuario(
                this.id
            );

            MessageBox.Show("Usuário deletado com sucesso!");
            this.Close();
        }
        catch(Exception err)
        {
            MessageBox.Show($"Erro ao deletar usuário. {err.Message}");
        }
    }

    private void btnCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
}