using System;
using System.Windows.Forms;
using NT106_Lab4.Bai1;
using NT106_Lab4.Bai3;
using NT106_Lab4.Bai_4;

namespace NT106_Lab4;

public partial class Dashboard : Form
{
    public Dashboard()
    {
        InitializeComponent();
    }

    private void btnBai1_Click(object? sender, EventArgs e)
    {
        OpenBai1Form();
    }

    private void OpenBai1Form()
    {
        Bai1.Bai1 formBai1 = new Bai1.Bai1();
        formBai1.Show();
    }

    private void btnBai3_Click(object? sender, EventArgs e)
    {
        OpenBai3Form();
    }

    private void OpenBai3Form()
    {
        Bai3.Bai3 formBai3 = new Bai3.Bai3();
        formBai3.Show();
    }

    private void btnBai4_Click(object? sender, EventArgs e)
    {
        OpenBai4Form();
    }

    private void OpenBai4Form()
    {
        Bai_4.Bai4 formBai4 = new Bai_4.Bai4();
        formBai4.Show();
    }

    private void btnOther_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            MessageBox.Show(
                $"Chức năng cho {btn.Text} chưa được triển khai hoặc không nằm trong yêu cầu hiện tại.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
